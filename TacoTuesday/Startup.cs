using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using TacoTuesday.Models;

namespace TacoTuesday
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JWT_KEY = Configuration["JWT_KEY"];
        }

        public IConfiguration Configuration { get; }
        private readonly string JWT_KEY;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Use NewtonsoftJson to avoid JSON cyclical loops
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TacoTuesday", Version = "v1" });
            });

            services.AddDbContext<DatabaseContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT_KEY))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (JWT_KEY == null || JWT_KEY.Length < 20)
            {
                app.Run(async (context) =>
                {
                    var message = env.IsDevelopment() ?
                        $"<p>You do not have a valid JWT_KEY. Stop the application and then run these two commands:</p><p><code>dotnet user-secrets init</code></p><p><code>dotnet user-secrets set JWT_KEY {Guid.NewGuid()}</code></p><p>Then restart <code>dotnet watch run.</code></p>" :
                        $"<p>You do not have a valid JWT_KEY. Use</p><p><code>heroku config:set JWT_KEY={Guid.NewGuid()}</code></p><p>to set one</p>";

                    await context.Response.WriteAsync(message);
                });
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // Only enforce https in production
                app.UseHttpsRedirection();

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TacoTuesday");
            });

            app.UseRouting();

            // Allow for authorization of endpoints (using JWT)
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpaStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    // This will set a caching time for any files in `/static`
                    // Since these files come from our compiled react app we
                    // will set a relatively long caching time.
                    //
                    // Anything not in `/static` will receive a non cacheable
                    // max-age of 0.

                    // In a real production we might cache this for much longer
                    // since assets will have unique names. In those cases a
                    // longer MaxAge such as 365 days is fine and often recommended.
                    //
                    // This value is a good middle ground for student projects.
                    var longDurationCachingHeader = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromHours(1)
                    };

                    var noCachingHeader = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(0)
                    };

                    var headers = ctx.Context.Response.GetTypedHeaders();
                    if (ctx.Context.Request.Path.StartsWithSegments("/static"))
                    {
                        headers.CacheControl = longDurationCachingHeader;
                    }
                    else
                    {
                        headers.CacheControl = noCachingHeader;
                    }
                }
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                // Set caching for static files
                spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        // Do not cache implicit `/index.html`.
                        var headers = ctx.Context.Response.GetTypedHeaders();
                        headers.CacheControl = new CacheControlHeaderValue
                        {
                            Public = true,
                            MaxAge = TimeSpan.FromDays(0)
                        };
                    }
                };

                if (env.IsDevelopment())
                {
                    // Assume the client app is running on port 3000, this is
                    // a big assumption since it might run on a differnet port
                    // if multiple react-scripts/create-react-app are running on
                    // the machine.
                    //
                    // However, this is better than running the UseReactDevelopmentServer
                    // which has all kinds of issues with ansi coloring, timeouts,
                    // and a silent delay when starting the first time and doing
                    // a background `npm install` which can timeout during the install
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                }
            });
        }
    }
}
