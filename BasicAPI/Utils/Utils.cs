using System;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace BasicAPI.Utils
{
    public class Utilities
    {
        // Change this to true if you want to have your app browsable on the local network
        private static bool ALLOW_APP_TO_BE_BROWSABLE_ON_THE_LOCAL_NETWORK = false;

        public static async Task<bool> WaitForMigrations(IWebHost host, DbContext context)
        {
            if (await MigrationCount(context) == 0)
            {
                return true;
            }

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                Console.WriteLine("There are migrations to run, execute: dotnet ef database update");

                return false;
            }

            Console.WriteLine("Starting to migrate database....");
            try
            {
                await context.Database.MigrateAsync();
                Console.WriteLine("Database is up to date, #party time");

                return true;
            }
            catch (DbException)
            {
                Notify("Database Migration FAILED");
                throw;
            }
        }

        private static async Task<int> MigrationCount(DbContext context)
        {
            return (await context.Database.GetPendingMigrationsAsync()).Count();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            if (ALLOW_APP_TO_BE_BROWSABLE_ON_THE_LOCAL_NETWORK && Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                builder = builder.UseUrls("http://*:5000/;https://*:5001");
            }

            return builder.UseStartup<Startup>();
        }

        public static void Notify(string message)
        {
            try
            {
                // Create a process to launch the `sdg toast` with our message
                var newProcess = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "sdg",
                        Arguments = $"toast \"{message}\" \"BasicAPI\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                // Start the message but do not wait for it to end, we don't care about the termination result.
                newProcess.Start();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // Nothing to do
            }
        }
    }
}