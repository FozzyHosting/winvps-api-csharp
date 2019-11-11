# FozzyHosting.WinVPS.Api.BrandsApi

All URIs are relative to *https://winvps.fozzy.com/api/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**BrandsGet**](BrandsApi.md#brandsget) | **GET** /brands | Returns list of all available preinstalled software set.

<a name="brandsget"></a>
# **BrandsGet**
> BrandsListResponse BrandsGet ()

Returns list of all available preinstalled software set.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class BrandsGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

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

### Parameters
This endpoint does not need any parameter.

### Return type

[**BrandsListResponse**](BrandsListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
