# FozzyHosting.WinVPS.Api.JobsApi

All URIs are relative to *https://winvps.fozzy.com/api/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**JobsGet**](JobsApi.md#jobsget) | **GET** /jobs | List of all planned and completed commands.
[**JobsIdDelete**](JobsApi.md#jobsiddelete) | **DELETE** /jobs/{id} | Cancel specified Job.
[**JobsIdGet**](JobsApi.md#jobsidget) | **GET** /jobs/{id} | View single Job details.
[**JobsPendingGet**](JobsApi.md#jobspendingget) | **GET** /jobs/pending | List of all planned commands.

<a name="jobsget"></a>
# **JobsGet**
> JobsListResponse JobsGet ()

List of all planned and completed commands.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class JobsGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new JobsApi();

            try
            {
                // List of all planned and completed commands.
                JobsListResponse result = apiInstance.JobsGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JobsApi.JobsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**JobsListResponse**](JobsListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="jobsiddelete"></a>
# **JobsIdDelete**
> void JobsIdDelete (int? id)

Cancel specified Job.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class JobsIdDeleteExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new JobsApi();
            var id = 56;  // int? | 

            try
            {
                // Cancel specified Job.
                apiInstance.JobsIdDelete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JobsApi.JobsIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

void (empty response body)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="jobsidget"></a>
# **JobsIdGet**
> JobDetailsResponse JobsIdGet (int? id)

View single Job details.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class JobsIdGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new JobsApi();
            var id = 56;  // int? | 

            try
            {
                // View single Job details.
                JobDetailsResponse result = apiInstance.JobsIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JobsApi.JobsIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

[**JobDetailsResponse**](JobDetailsResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="jobspendingget"></a>
# **JobsPendingGet**
> JobsListResponse JobsPendingGet ()

List of all planned commands.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class JobsPendingGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new JobsApi();

            try
            {
                // List of all planned commands.
                JobsListResponse result = apiInstance.JobsPendingGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JobsApi.JobsPendingGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**JobsListResponse**](JobsListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
