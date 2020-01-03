/* 
 * Fozzy Windows VPS resellers API
 *
 *  Application Programming Interface (API) allows clients to manage the Windows VPS machines lifecycle.  ## Endpoint  `https://winvps.fozzy.com/api/v2/`  ## Authentication  To access the API, an existing client of Fozzy Inc. should be registered as Windows VPS Reseller by the company tech support through the ticket or using Sales Email. After that, the client will have an access to the winvps.fozzy.com and will be able to get an API Token (Signature) in `Settings -> API` section of main menu.  If you have already used the previous API version, then the token is known to you.  Note that the Token grants full access to your account and should be protected the same way you would protect your password. Also you can reset the Token on the receipt page.  To use the Token you should pass it to `Api-Key` header of each request like this:  ` curl -H 'API-KEY: TOKEN' https://winvps.fozzy.com/api/v2/products `  ## Content-Type  API v2 supports `application/json`, `application/x-www-form-urlencoded` and `multipart/form-data` content types.  In the first case HTTP request must be JSON-encoded with the body as a valid JSON string. The othres are default POST types with content in key=value format.  The response always has `application/json` type and contains JSON-encoded payload.  ## Response  A successful response will be returned as a JSON object with at least one of the following top-level members: - `data` - the document’s “primary data” - `error` - error message - `pagination` - pagination details  The members data and error cannot coexist in the same document.  ### Codes   - `200 OK` - Everything worked as expected.  - `201 Created` - The request was successful and a resource was created. This is typically a response from a POST request to create a resource which runs immediately.  - `202 Accepted` - The request has been accepted for processing. This is typically a response from a POST request that is handled async in our system, such as a request for some machine command.  - `204 No Content` - The request was successful but the response body is empty. This is typically a response from a DELETE request to delete a resource or cancel the command.  - `400 Bad Request` - A required parameter or the request is invalid.  - `403 Unauthorized` - The authentication credentials are invalid.  - `404 Not Found` - The requested resource doesn’t exist.  - `500 Server error` - something went wrong. Please contact our support team.  ### Examples  #### Error:  ```json {   \"error\": \"Error message\" } ```  #### Success - retrieve single record:  ```json {   \"data\": {     \"id\": 1,     \"name\": \"String\"   } } ```   #### Success - retrieve multiple records:  ```json {   \"data\": [     {       \"id\": 1,       \"name\": \"String\"     }, {       \"id\": 2,       \"name\": \"String\"     }   ],   \"pagination\": {     \"total\": 10,   } } ```  #### Success - response for some delayed action:  ```json {   \"data\": {     \"name\": \"String\",     \"jobs\": [       {         \"id\": 0,         \"parent_id\": 0,         \"machine_id\": 0,         \"type\": \"string\",         \"status\": \"string\",         \"start_time\": \"string\"       }     ]   } } ```  ## Pagination  Any API endpoint that returns a list of items requires pagination. By default we will return `50` records from any listing endpoint.  If an API endpoint returns a list of items, then it will include an additional object with pagination information.  The pagination information contains the following details:   - `total` - The total number of entries available in the entire collection  - `limit` - The number of entries returned per page (default: 50)  - `page` - The page currently returned (default: 1)  - `pages` - The total number of pages  To go through the pages you need to pass additional GET parameter `page` with the number of page wanted.  ## Entities meaning  ### Product  A product is a resources set with which a VPS will be created by default. This is a resources such ads CPU cores count, CPU power in percents of the maximum available limit, RAM minimum and maximum values, Disk Size etc.  ### Template  Template is an operating system version for VPS.  ### Brand  Brand is a set of custom software which installs on the machine automatically. Currently this set can be created only through the request to our administrators.  ### Location  Location is a list of regions in which the new VPS creation is available.  ### Job  Job is a command to perform specific actions on the machine such as creation, starting, changing, terminating, etc. Since most actions cannot be performed instantly, they are all queued and executed one after another. You will receive an additional property `jobs` in your response if any request generates new queue positions.  ### Machine  Machine is a virtual private server (VPS) which used to your own needs. Each Mahine has Operating System defined by **Template** installed on the server in a data center in a country specified by **Location** option. The machine has some specified by **Product** resources which can be used by your software installed automatically by the **Brand** option or manually from the RDP interface.  ## Changelog  ### Version 2.2.0  The machine creation command now supports an additional option `add_ipv6` to provide the IPv6 for the new machine.  ### Version 2.1.0  Added new command `run_updates_install` for starting Windows updates installation. Command can be used in the *_/machines/{name}/{command}* request.  The status of updates is displayed in the general information about the machine by the *_/machines/{name}* request. 
 *
 * OpenAPI spec version: 2.1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using FozzyHosting.WinVPS.Client;
using FozzyHosting.WinVPS.Model;

namespace FozzyHosting.WinVPS.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface IBrandsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Returns list of all available preinstalled software set.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>BrandsListResponse</returns>
        BrandsListResponse BrandsGet ();

        /// <summary>
        /// Returns list of all available preinstalled software set.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of BrandsListResponse</returns>
        ApiResponse<BrandsListResponse> BrandsGetWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Returns list of all available preinstalled software set.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of BrandsListResponse</returns>
        System.Threading.Tasks.Task<BrandsListResponse> BrandsGetAsync ();

        /// <summary>
        /// Returns list of all available preinstalled software set.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (BrandsListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<BrandsListResponse>> BrandsGetAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class BrandsApi : IBrandsApi
    {
        private FozzyHosting.WinVPS.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BrandsApi(String basePath)
        {
            this.Configuration = new FozzyHosting.WinVPS.Client.Configuration { BasePath = basePath };

            ExceptionFactory = FozzyHosting.WinVPS.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandsApi"/> class
        /// </summary>
        /// <returns></returns>
        public BrandsApi()
        {
            this.Configuration = FozzyHosting.WinVPS.Client.Configuration.Default;

            ExceptionFactory = FozzyHosting.WinVPS.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public BrandsApi(FozzyHosting.WinVPS.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = FozzyHosting.WinVPS.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = FozzyHosting.WinVPS.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public FozzyHosting.WinVPS.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public FozzyHosting.WinVPS.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Returns list of all available preinstalled software set. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>BrandsListResponse</returns>
        public BrandsListResponse BrandsGet ()
        {
             ApiResponse<BrandsListResponse> localVarResponse = BrandsGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns list of all available preinstalled software set. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of BrandsListResponse</returns>
        public ApiResponse< BrandsListResponse > BrandsGetWithHttpInfo ()
        {

            var localVarPath = "/brands";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("BrandsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<BrandsListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (BrandsListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(BrandsListResponse)));
        }

        /// <summary>
        /// Returns list of all available preinstalled software set. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of BrandsListResponse</returns>
        public async System.Threading.Tasks.Task<BrandsListResponse> BrandsGetAsync ()
        {
             ApiResponse<BrandsListResponse> localVarResponse = await BrandsGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns list of all available preinstalled software set. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (BrandsListResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<BrandsListResponse>> BrandsGetAsyncWithHttpInfo ()
        {

            var localVarPath = "/brands";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("BrandsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<BrandsListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (BrandsListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(BrandsListResponse)));
        }

    }
}
