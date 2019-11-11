# Fozzy Windows VPS APIs Client library for Java

The API Client Library enables you to work with Fozzy Windows VPS APIs for creating or managing your machines.

## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.2.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

<a name="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;
```



### Authorization

To be able to send requests you need to get API key as described in API Documentation.


### Full example

```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class Example
    {
        public void main()
        {
            Configuration.Default.ApiKey.Add("Api-Key", "API key from WinVPS client area");

            var apiInstance = new BrandsApi();

            try
            {
                // Returns list of all available preinstalled software set.
                BrandsListResponse result = apiInstance.BrandsGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BrandsApi.BrandsGet: " + e.Message );
            }
        }
    }
}
```
