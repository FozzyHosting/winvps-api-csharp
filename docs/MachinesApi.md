# FozzyHosting.WinVPS.Api.MachinesApi

All URIs are relative to *https://winvps.fozzy.com/api/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**MachinesGet**](MachinesApi.md#machinesget) | **GET** /machines | Returns machines list in short form.
[**MachinesNameAddIpPost**](MachinesApi.md#machinesnameaddippost) | **POST** /machines/{name}/add_ip | Send unary machine command
[**MachinesNameCommandPost**](MachinesApi.md#machinesnamecommandpost) | **POST** /machines/{name}/{command} | Send single command which does not need additional options.
[**MachinesNameDelete**](MachinesApi.md#machinesnamedelete) | **DELETE** /machines/{name} | Terminate machine
[**MachinesNameGet**](MachinesApi.md#machinesnameget) | **GET** /machines/{name} | Returns machine details
[**MachinesNameJobsGet**](MachinesApi.md#machinesnamejobsget) | **GET** /machines/{name}/jobs | Returns list of jobs assigned to machine.
[**MachinesNamePost**](MachinesApi.md#machinesnamepost) | **POST** /machines/{name} | Reinstall machine
[**MachinesNamePut**](MachinesApi.md#machinesnameput) | **PUT** /machines/{name} | Update machine details
[**MachinesNameUsersGet**](MachinesApi.md#machinesnameusersget) | **GET** /machines/{name}/users | Returns list of additional system users.
[**MachinesPost**](MachinesApi.md#machinespost) | **POST** /machines | Create new machine.
[**MachinesRunningGet**](MachinesApi.md#machinesrunningget) | **GET** /machines/running | Returns list of currently running machines.
[**MachinesStoppedGet**](MachinesApi.md#machinesstoppedget) | **GET** /machines/stopped | Returns list of currently stopped or suspended machines.

<a name="machinesget"></a>
# **MachinesGet**
> MachinesListResponse MachinesGet ()

Returns machines list in short form.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();

            try
            {
                // Returns machines list in short form.
                MachinesListResponse result = apiInstance.MachinesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**MachinesListResponse**](MachinesListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesnameaddippost"></a>
# **MachinesNameAddIpPost**
> MachineAddIpResponse MachinesNameAddIpPost (string name)

Send unary machine command

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesNameAddIpPostExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var name = name_example;  // string | 

            try
            {
                // Send unary machine command
                MachineAddIpResponse result = apiInstance.MachinesNameAddIpPost(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesNameAddIpPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 

### Return type

[**MachineAddIpResponse**](MachineAddIpResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesnamecommandpost"></a>
# **MachinesNameCommandPost**
> MachineCommandResultResponse MachinesNameCommandPost (string name, string command)

Send single command which does not need additional options.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesNameCommandPostExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var name = name_example;  // string | Machine name.
            var command = command_example;  // string | Command key.

            try
            {
                // Send single command which does not need additional options.
                MachineCommandResultResponse result = apiInstance.MachinesNameCommandPost(name, command);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesNameCommandPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Machine name. | 
 **command** | **string**| Command key. | 

### Return type

[**MachineCommandResultResponse**](MachineCommandResultResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesnamedelete"></a>
# **MachinesNameDelete**
> MachineCommandResultResponse MachinesNameDelete (string name)

Terminate machine

Creates machine deletion jobs. This action can be cancelled in two days.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesNameDeleteExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var name = name_example;  // string | 

            try
            {
                // Terminate machine
                MachineCommandResultResponse result = apiInstance.MachinesNameDelete(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesNameDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 

### Return type

[**MachineCommandResultResponse**](MachineCommandResultResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesnameget"></a>
# **MachinesNameGet**
> MachineDetailsResponse MachinesNameGet (string name)

Returns machine details

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesNameGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var name = name_example;  // string | 

            try
            {
                // Returns machine details
                MachineDetailsResponse result = apiInstance.MachinesNameGet(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesNameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 

### Return type

[**MachineDetailsResponse**](MachineDetailsResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesnamejobsget"></a>
# **MachinesNameJobsGet**
> JobsListResponse MachinesNameJobsGet (string name)

Returns list of jobs assigned to machine.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesNameJobsGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var name = name_example;  // string | 

            try
            {
                // Returns list of jobs assigned to machine.
                JobsListResponse result = apiInstance.MachinesNameJobsGet(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesNameJobsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 

### Return type

[**JobsListResponse**](JobsListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesnamepost"></a>
# **MachinesNamePost**
> MachineCommandResultResponse MachinesNamePost (MachineReinstallRequestBody body, string name)

Reinstall machine

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesNamePostExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var body = new MachineReinstallRequestBody(); // MachineReinstallRequestBody | 
            var name = name_example;  // string | 

            try
            {
                // Reinstall machine
                MachineCommandResultResponse result = apiInstance.MachinesNamePost(body, name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesNamePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**MachineReinstallRequestBody**](MachineReinstallRequestBody.md)|  | 
 **name** | **string**|  | 

### Return type

[**MachineCommandResultResponse**](MachineCommandResultResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesnameput"></a>
# **MachinesNamePut**
> MachineCommandResultResponse MachinesNamePut (MachineUpdateRequestBody body, string name)

Update machine details

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesNamePutExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var body = new MachineUpdateRequestBody(); // MachineUpdateRequestBody | 
            var name = name_example;  // string | 

            try
            {
                // Update machine details
                MachineCommandResultResponse result = apiInstance.MachinesNamePut(body, name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesNamePut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**MachineUpdateRequestBody**](MachineUpdateRequestBody.md)|  | 
 **name** | **string**|  | 

### Return type

[**MachineCommandResultResponse**](MachineCommandResultResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesnameusersget"></a>
# **MachinesNameUsersGet**
> MachineUsersListResponse MachinesNameUsersGet (string name)

Returns list of additional system users.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesNameUsersGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var name = name_example;  // string | 

            try
            {
                // Returns list of additional system users.
                MachineUsersListResponse result = apiInstance.MachinesNameUsersGet(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesNameUsersGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 

### Return type

[**MachineUsersListResponse**](MachineUsersListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinespost"></a>
# **MachinesPost**
> MachineCreateResponse MachinesPost (MachineCreateRequestBody body)

Create new machine.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesPostExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();
            var body = new MachineCreateRequestBody(); // MachineCreateRequestBody | Optional description in *Markdown*

            try
            {
                // Create new machine.
                MachineCreateResponse result = apiInstance.MachinesPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**MachineCreateRequestBody**](MachineCreateRequestBody.md)| Optional description in *Markdown* | 

### Return type

[**MachineCreateResponse**](MachineCreateResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesrunningget"></a>
# **MachinesRunningGet**
> MachinesListResponse MachinesRunningGet ()

Returns list of currently running machines.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesRunningGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();

            try
            {
                // Returns list of currently running machines.
                MachinesListResponse result = apiInstance.MachinesRunningGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesRunningGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**MachinesListResponse**](MachinesListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="machinesstoppedget"></a>
# **MachinesStoppedGet**
> MachinesListResponse MachinesStoppedGet ()

Returns list of currently stopped or suspended machines.

### Example
```csharp
using System;
using System.Diagnostics;
using FozzyHosting.WinVPS.Api;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace Example
{
    public class MachinesStoppedGetExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Api-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Api-Key", "Bearer");

            var apiInstance = new MachinesApi();

            try
            {
                // Returns list of currently stopped or suspended machines.
                MachinesListResponse result = apiInstance.MachinesStoppedGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MachinesApi.MachinesStoppedGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**MachinesListResponse**](MachinesListResponse.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
