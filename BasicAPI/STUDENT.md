# BasicAPI

The application was generated from the `sdg-api` template. It includes:

- CORS Enabled
- Swagger
- Postgres & EF Core

## To use

The default database will be named BasicAPIDatabase. You can change this in `DatabaseContext.cs`

## To push your code to github:

1. `git add .`
1. `git commit -m "Here I describe my changes"`
1. `git push`

## To SETUP deployment to Heroku

These steps need to be done _ONCE_ before you can deploy to heroku

> NOTE: You must choose an app name that is unique across all of heroku. If you want to use a name that isn't available, try appending unique like `-sdg` or `-janedoe` replacing `janedoe` with your name.

- `heroku apps:create NAMEOFAPP` - NOTE: replace `NAMEOFAPP` with something that is unique to your project.
- `heroku buildpacks:set suncoast-devs/dotnetcore-buildpack`
- `git push heroku HEAD:main`

## To setup secrets for Heroku

Heroku stores secrets in your _environment variables_. You can change these from the command line or from your app's configuration on `heroku.com`

If you are using JWT tokens, you need to do the following:

- `heroku config:set JWT_KEY="MY RANDOM STRING OF LETTERS AND NUMBERS TO USE FOR A KEY"`

If you are using a third party API you can set any configuration as such:

- `heroku config:set THIRD_PARTY_KEY_NAME="THIRD PARTY KEY VALUE"`

## To deploy to Heroku

- `git push heroku HEAD:main`

## To open your deployed application

- `heroku open`

## To setup continuous deployment

- Visit [heroku.com](https://heroku.com) and go to the configuration page for your app
- Choose the `deploy` tab
- Select `github` as the deployment method. ![github](./docs/heroku1.png)
- Select `Connect to Github` ![github](./docs/heroku2.png)
- Browse for your repository ![github](./docs/heroku3.png)
- Connect to your repository ![github](./docs/heroku4.png)
- Enable automatic deploys ![github](./docs/heroku5.png)

## PROTIP:

When you are complete with the project and have turned it in to your instructor, update README.md with details about the assignment.
