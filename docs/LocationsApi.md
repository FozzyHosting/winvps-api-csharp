# FozzyHosting.WinVPS.Api.LocationsApi

All URIs are relative to *https://winvps.fozzy.com/api/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**LocationsGet**](LocationsApi.md#locationsget) | **GET** /locations | Returns list of locations available for new machines.

<a name="locationsget"></a>
# **LocationsGet**
> LocationsListResponse LocationsGet ()

Returns list of locations available for new machines.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class LocationsGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new LocationsApi();

            try
            {
                // Returns list of locations available for new machines.
                LocationsListResponse result = apiInstance.LocationsGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LocationsApi.LocationsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**LocationsListResponse**](LocationsListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
