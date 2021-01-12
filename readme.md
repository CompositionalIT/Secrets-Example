# Secrets Example

## Host

A **Host** is a handy way of bundling together your app's resources such as service dependencies and configuration etc.

You can do this for an ASP web app or a plain console app, the process is very similar.

> Console apps (generic host) - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-5.0
> 
> ASP apps (web host) - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host?view=aspnetcore-5.0

`CreateDefaultBuilder()` creates a host builder with the most common things already set up for you.
   
This includes the following configuration sources, so there is no need to add them yourself:

- appsettings.json
- appsettings.{Environment}.json
- secrets.json (**if in Development environment specifically**)
- Environment variables
- Command line arguments

>For more info on the default builder, see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.1#default-builder-settings-1


## Environment variables

You can set 'environment variables' on your machine which will be added to the default configuration as explained above.

If you are using Powershell, the command to set a variable is:

`Set-Item -Path Env:"{key}" -Value "{value}"`

> To get a Powershell command prompt in Visual Studio, go to Tools > CommandLine > Developer Powershell
> >
> If you are using an old cmd prompt the commands are slightly different. 

The environment can have any name, but 'Development', 'Staging' and 'Production' are commonly used and some helper methods are provided for checking / using them.

>This will be set for the **current Powershell session only** - if you want it to persist, you will need to add it at the system level


We also mentioned above that secrets will be loaded if you are in a Development environment.

To achieve this, we just set an environment var with the key "DOTNET_ENVIRONMENT" like so:

`Set-Item -Path Env:"DOTNET_ENVIRONMENT" -Value "Development"`


> If you are working on a **web app**, the key is "ASPNETCORE_ENVIRONMENT" and you need to call "ConfigureWebHostDefaults" on the host builder.
> This is usually set up for you out of the box.
> 
>See https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-5.0#environments

## Using this sample

1. If you just run the app using

```powershell
dotnet run
```

it will print out each and every configuration value loaded by the default host builder. You will see there are quite a few.

2. Run the following command to initialise a secrets store on your machine:

```powershell
dotnet user-secrets init
```

3. Add a secret to the store like so:

```powershell
dotnet user-secrets set "ExampleKey" "ExampleValue"
```

4. Run the app again and check the list of config items.

You will see that your secret is not listed.
    
This is because we are not in a development environment.

5. Run the command

```powershell
Set-Item -Path Env:"DOTNET_ENVIRONMENT" -Value "Development"
```

>You can check that it was set using
>
>```powershell
>Get-Item -Path Env:"DOTNET_ENVIRONMENT"

6. Run the app again and you should see your secret listed in the print out.

> You should also see the 'Development' environment variable you set
