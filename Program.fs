open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Configuration
open System.Collections.Generic

let printAllConfigItems =
    Seq.iter (fun (kvp : KeyValuePair<string,string>) ->
        printfn $"Key: {kvp.Key} Value: {kvp.Value}" )

let createHostBuilder argv =
    Host
        .CreateDefaultBuilder(argv) 
        .ConfigureAppConfiguration(
            fun (context : HostBuilderContext) (configBuilder : IConfigurationBuilder) ->
                
                // You can add more items to the configuration here, either manually or using a ConfigurationProvider of some kind such as KeyStore

                configBuilder.Build().AsEnumerable()
                |> printAllConfigItems

                ()
            ) 

[<EntryPoint>]
let main argv =

    createHostBuilder(argv).Build().Run();

    0 // return an integer exit code