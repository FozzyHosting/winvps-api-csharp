/* 
 * Fozzy Windows VPS resellers API
 *
 *  Application Programming Interface (API) allows clients to manage the Windows VPS machines lifecycle.  ## Endpoint  `https://winvps.fozzy.com/api/v2/`  ## Authentication  To access the API, an existing client of Fozzy Inc. should be registered as Windows VPS Reseller by the company tech support through the ticket or using Sales Email. After that, the client will have an access to the winvps.fozzy.com and will be able to get an API Token (Signature) in `Settings -> API` section of main menu.  If you have already used the previous API version, then the token is known to you.  Note that the Token grants full access to your account and should be protected the same way you would protect your password. Also you can reset the Token on the receipt page.  To use the Token you should pass it to `Api-Key` header of each request like this:  ` curl -H 'API-KEY: TOKEN' https://winvps.fozzy.com/api/v2/products `  ## Content-Type  API v2 supports `application/json`, `application/x-www-form-urlencoded` and `multipart/form-data` content types.  In the first case HTTP request must be JSON-encoded with the body as a valid JSON string. The othres are default POST types with content in key=value format.  The response always has `application/json` type and contains JSON-encoded payload.  ## Response  A successful response will be returned as a JSON object with at least one of the following top-level members: - `data` - the document’s “primary data” - `error` - error message - `pagination` - pagination details  The members data and error cannot coexist in the same document.  ### Codes   - `200 OK` - Everything worked as expected.  - `201 Created` - The request was successful and a resource was created. This is typically a response from a POST request to create a resource which runs immediately.  - `202 Accepted` - The request has been accepted for processing. This is typically a response from a POST request that is handled async in our system, such as a request for some machine command.  - `204 No Content` - The request was successful but the response body is empty. This is typically a response from a DELETE request to delete a resource or cancel the command.  - `400 Bad Request` - A required parameter or the request is invalid.  - `403 Unauthorized` - The authentication credentials are invalid.  - `404 Not Found` - The requested resource doesn’t exist.  - `500 Server error` - something went wrong. Please contact our support team.  ### Examples  #### Error:  ```json {   \"error\": \"Error message\" } ```  #### Success - retrieve single record:  ```json {   \"data\": {     \"id\": 1,     \"name\": \"String\"   } } ```   #### Success - retrieve multiple records:  ```json {   \"data\": [     {       \"id\": 1,       \"name\": \"String\"     }, {       \"id\": 2,       \"name\": \"String\"     }   ],   \"pagination\": {     \"total\": 10,   } } ```  #### Success - response for some delayed action:  ```json {   \"data\": {     \"name\": \"String\",     \"jobs\": [       {         \"id\": 0,         \"parent_id\": 0,         \"machine_id\": 0,         \"type\": \"string\",         \"status\": \"string\",         \"start_time\": \"string\"       }     ]   } } ```  ## Pagination  Any API endpoint that returns a list of items requires pagination. By default we will return `50` records from any listing endpoint.  If an API endpoint returns a list of items, then it will include an additional object with pagination information.  The pagination information contains the following details:   - `total` - The total number of entries available in the entire collection  - `limit` - The number of entries returned per page (default: 50)  - `page` - The page currently returned (default: 1)  - `pages` - The total number of pages  To go through the pages you need to pass additional GET parameter `page` with the number of page wanted.  ## Entities meaning  ### Product  A product is a resources set with which a VPS will be created by default. This is a resources such ads CPU cores count, CPU power in percents of the maximum available limit, RAM minimum and maximum values, Disk Size etc.  ### Template  Template is an operating system version for VPS.  ### Brand  Brand is a set of custom software which installs on the machine automatically. Currently this set can be created only through the request to our administrators.  ### Location  Location is a list of regions in which the new VPS creation is available.  ### Job  Job is a command to perform specific actions on the machine such as creation, starting, changing, terminating, etc. Since most actions cannot be performed instantly, they are all queued and executed one after another. You will receive an additional property `jobs` in your response if any request generates new queue positions.  ### Machine  Machine is a virtual private server (VPS) which used to your own needs. Each Mahine has Operating System defined by **Template** installed on the server in a data center in a country specified by **Location** option. The machine has some specified by **Product** resources which can be used by your software installed automatically by the **Brand** option or manually from the RDP interface.  ## Changelog  ### Version 2.1.0  Added new command `run_updates_install` for starting Windows updates installation. Command can be used in the *_/machines/{name}/{command}* request.  The status of updates is displayed in the general information about the machine by the *_/machines/{name}* request. 
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
        public interface IMachinesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Returns machines list in short form.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>MachinesListResponse</returns>
        MachinesListResponse MachinesGet ();

        /// <summary>
        /// Returns machines list in short form.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of MachinesListResponse</returns>
        ApiResponse<MachinesListResponse> MachinesGetWithHttpInfo ();
        /// <summary>
        /// Send unary machine command
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MachineAddIpResponse</returns>
        MachineAddIpResponse MachinesNameAddIpPost (string name);

        /// <summary>
        /// Send unary machine command
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineAddIpResponse</returns>
        ApiResponse<MachineAddIpResponse> MachinesNameAddIpPostWithHttpInfo (string name);
        /// <summary>
        /// Send single command which does not need additional options.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Machine name.</param>
        /// <param name="command">Command key.</param>
        /// <returns>MachineCommandResultResponse</returns>
        MachineCommandResultResponse MachinesNameCommandPost (string name, string command);

        /// <summary>
        /// Send single command which does not need additional options.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Machine name.</param>
        /// <param name="command">Command key.</param>
        /// <returns>ApiResponse of MachineCommandResultResponse</returns>
        ApiResponse<MachineCommandResultResponse> MachinesNameCommandPostWithHttpInfo (string name, string command);
        /// <summary>
        /// Terminate machine
        /// </summary>
        /// <remarks>
        /// Creates machine deletion jobs. This action can be cancelled in two days.
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MachineCommandResultResponse</returns>
        MachineCommandResultResponse MachinesNameDelete (string name);

        /// <summary>
        /// Terminate machine
        /// </summary>
        /// <remarks>
        /// Creates machine deletion jobs. This action can be cancelled in two days.
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineCommandResultResponse</returns>
        ApiResponse<MachineCommandResultResponse> MachinesNameDeleteWithHttpInfo (string name);
        /// <summary>
        /// Returns machine details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MachineDetailsResponse</returns>
        MachineDetailsResponse MachinesNameGet (string name);

        /// <summary>
        /// Returns machine details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineDetailsResponse</returns>
        ApiResponse<MachineDetailsResponse> MachinesNameGetWithHttpInfo (string name);
        /// <summary>
        /// Returns list of jobs assigned to machine.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>JobsListResponse</returns>
        JobsListResponse MachinesNameJobsGet (string name);

        /// <summary>
        /// Returns list of jobs assigned to machine.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of JobsListResponse</returns>
        ApiResponse<JobsListResponse> MachinesNameJobsGetWithHttpInfo (string name);
        /// <summary>
        /// Reinstall machine
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>MachineCommandResultResponse</returns>
        MachineCommandResultResponse MachinesNamePost (MachineReinstallRequestBody body, string name);

        /// <summary>
        /// Reinstall machine
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineCommandResultResponse</returns>
        ApiResponse<MachineCommandResultResponse> MachinesNamePostWithHttpInfo (MachineReinstallRequestBody body, string name);
        /// <summary>
        /// Update machine details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>MachineCommandResultResponse</returns>
        MachineCommandResultResponse MachinesNamePut (MachineUpdateRequestBody body, string name);

        /// <summary>
        /// Update machine details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineCommandResultResponse</returns>
        ApiResponse<MachineCommandResultResponse> MachinesNamePutWithHttpInfo (MachineUpdateRequestBody body, string name);
        /// <summary>
        /// Returns list of additional system users.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MachineUsersListResponse</returns>
        MachineUsersListResponse MachinesNameUsersGet (string name);

        /// <summary>
        /// Returns list of additional system users.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineUsersListResponse</returns>
        ApiResponse<MachineUsersListResponse> MachinesNameUsersGetWithHttpInfo (string name);
        /// <summary>
        /// Create new machine.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <returns>MachineCreateResponse</returns>
        MachineCreateResponse MachinesPost (MachineCreateRequestBody body);

        /// <summary>
        /// Create new machine.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <returns>ApiResponse of MachineCreateResponse</returns>
        ApiResponse<MachineCreateResponse> MachinesPostWithHttpInfo (MachineCreateRequestBody body);
        /// <summary>
        /// Returns list of currently running machines.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>MachinesListResponse</returns>
        MachinesListResponse MachinesRunningGet ();

        /// <summary>
        /// Returns list of currently running machines.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of MachinesListResponse</returns>
        ApiResponse<MachinesListResponse> MachinesRunningGetWithHttpInfo ();
        /// <summary>
        /// Returns list of currently stopped or suspended machines.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>MachinesListResponse</returns>
        MachinesListResponse MachinesStoppedGet ();

        /// <summary>
        /// Returns list of currently stopped or suspended machines.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of MachinesListResponse</returns>
        ApiResponse<MachinesListResponse> MachinesStoppedGetWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Returns machines list in short form.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of MachinesListResponse</returns>
        System.Threading.Tasks.Task<MachinesListResponse> MachinesGetAsync ();

        /// <summary>
        /// Returns machines list in short form.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (MachinesListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachinesListResponse>> MachinesGetAsyncWithHttpInfo ();
        /// <summary>
        /// Send unary machine command
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MachineAddIpResponse</returns>
        System.Threading.Tasks.Task<MachineAddIpResponse> MachinesNameAddIpPostAsync (string name);

        /// <summary>
        /// Send unary machine command
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineAddIpResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachineAddIpResponse>> MachinesNameAddIpPostAsyncWithHttpInfo (string name);
        /// <summary>
        /// Send single command which does not need additional options.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Machine name.</param>
        /// <param name="command">Command key.</param>
        /// <returns>Task of MachineCommandResultResponse</returns>
        System.Threading.Tasks.Task<MachineCommandResultResponse> MachinesNameCommandPostAsync (string name, string command);

        /// <summary>
        /// Send single command which does not need additional options.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Machine name.</param>
        /// <param name="command">Command key.</param>
        /// <returns>Task of ApiResponse (MachineCommandResultResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachineCommandResultResponse>> MachinesNameCommandPostAsyncWithHttpInfo (string name, string command);
        /// <summary>
        /// Terminate machine
        /// </summary>
        /// <remarks>
        /// Creates machine deletion jobs. This action can be cancelled in two days.
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MachineCommandResultResponse</returns>
        System.Threading.Tasks.Task<MachineCommandResultResponse> MachinesNameDeleteAsync (string name);

        /// <summary>
        /// Terminate machine
        /// </summary>
        /// <remarks>
        /// Creates machine deletion jobs. This action can be cancelled in two days.
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineCommandResultResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachineCommandResultResponse>> MachinesNameDeleteAsyncWithHttpInfo (string name);
        /// <summary>
        /// Returns machine details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MachineDetailsResponse</returns>
        System.Threading.Tasks.Task<MachineDetailsResponse> MachinesNameGetAsync (string name);

        /// <summary>
        /// Returns machine details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineDetailsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachineDetailsResponse>> MachinesNameGetAsyncWithHttpInfo (string name);
        /// <summary>
        /// Returns list of jobs assigned to machine.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of JobsListResponse</returns>
        System.Threading.Tasks.Task<JobsListResponse> MachinesNameJobsGetAsync (string name);

        /// <summary>
        /// Returns list of jobs assigned to machine.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (JobsListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<JobsListResponse>> MachinesNameJobsGetAsyncWithHttpInfo (string name);
        /// <summary>
        /// Reinstall machine
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of MachineCommandResultResponse</returns>
        System.Threading.Tasks.Task<MachineCommandResultResponse> MachinesNamePostAsync (MachineReinstallRequestBody body, string name);

        /// <summary>
        /// Reinstall machine
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineCommandResultResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachineCommandResultResponse>> MachinesNamePostAsyncWithHttpInfo (MachineReinstallRequestBody body, string name);
        /// <summary>
        /// Update machine details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of MachineCommandResultResponse</returns>
        System.Threading.Tasks.Task<MachineCommandResultResponse> MachinesNamePutAsync (MachineUpdateRequestBody body, string name);

        /// <summary>
        /// Update machine details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineCommandResultResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachineCommandResultResponse>> MachinesNamePutAsyncWithHttpInfo (MachineUpdateRequestBody body, string name);
        /// <summary>
        /// Returns list of additional system users.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MachineUsersListResponse</returns>
        System.Threading.Tasks.Task<MachineUsersListResponse> MachinesNameUsersGetAsync (string name);

        /// <summary>
        /// Returns list of additional system users.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineUsersListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachineUsersListResponse>> MachinesNameUsersGetAsyncWithHttpInfo (string name);
        /// <summary>
        /// Create new machine.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <returns>Task of MachineCreateResponse</returns>
        System.Threading.Tasks.Task<MachineCreateResponse> MachinesPostAsync (MachineCreateRequestBody body);

        /// <summary>
        /// Create new machine.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <returns>Task of ApiResponse (MachineCreateResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachineCreateResponse>> MachinesPostAsyncWithHttpInfo (MachineCreateRequestBody body);
        /// <summary>
        /// Returns list of currently running machines.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of MachinesListResponse</returns>
        System.Threading.Tasks.Task<MachinesListResponse> MachinesRunningGetAsync ();

        /// <summary>
        /// Returns list of currently running machines.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (MachinesListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachinesListResponse>> MachinesRunningGetAsyncWithHttpInfo ();
        /// <summary>
        /// Returns list of currently stopped or suspended machines.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of MachinesListResponse</returns>
        System.Threading.Tasks.Task<MachinesListResponse> MachinesStoppedGetAsync ();

        /// <summary>
        /// Returns list of currently stopped or suspended machines.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (MachinesListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachinesListResponse>> MachinesStoppedGetAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class MachinesApi : IMachinesApi
    {
        private FozzyHosting.WinVPS.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MachinesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MachinesApi(String basePath)
        {
            this.Configuration = new FozzyHosting.WinVPS.Client.Configuration { BasePath = basePath };

            ExceptionFactory = FozzyHosting.WinVPS.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MachinesApi"/> class
        /// </summary>
        /// <returns></returns>
        public MachinesApi()
        {
            this.Configuration = FozzyHosting.WinVPS.Client.Configuration.Default;

            ExceptionFactory = FozzyHosting.WinVPS.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MachinesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public MachinesApi(FozzyHosting.WinVPS.Client.Configuration configuration = null)
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
        /// Returns machines list in short form. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>MachinesListResponse</returns>
        public MachinesListResponse MachinesGet ()
        {
             ApiResponse<MachinesListResponse> localVarResponse = MachinesGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns machines list in short form. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of MachinesListResponse</returns>
        public ApiResponse< MachinesListResponse > MachinesGetWithHttpInfo ()
        {

            var localVarPath = "/machines";
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
                Exception exception = ExceptionFactory("MachinesGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachinesListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachinesListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachinesListResponse)));
        }

        /// <summary>
        /// Returns machines list in short form. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of MachinesListResponse</returns>
        public async System.Threading.Tasks.Task<MachinesListResponse> MachinesGetAsync ()
        {
             ApiResponse<MachinesListResponse> localVarResponse = await MachinesGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns machines list in short form. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (MachinesListResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachinesListResponse>> MachinesGetAsyncWithHttpInfo ()
        {

            var localVarPath = "/machines";
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
                Exception exception = ExceptionFactory("MachinesGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachinesListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachinesListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachinesListResponse)));
        }

        /// <summary>
        /// Send unary machine command 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MachineAddIpResponse</returns>
        public MachineAddIpResponse MachinesNameAddIpPost (string name)
        {
             ApiResponse<MachineAddIpResponse> localVarResponse = MachinesNameAddIpPostWithHttpInfo(name);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Send unary machine command 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineAddIpResponse</returns>
        public ApiResponse< MachineAddIpResponse > MachinesNameAddIpPostWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameAddIpPost");

            var localVarPath = "/machines/{name}/add_ip";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNameAddIpPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineAddIpResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineAddIpResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineAddIpResponse)));
        }

        /// <summary>
        /// Send unary machine command 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MachineAddIpResponse</returns>
        public async System.Threading.Tasks.Task<MachineAddIpResponse> MachinesNameAddIpPostAsync (string name)
        {
             ApiResponse<MachineAddIpResponse> localVarResponse = await MachinesNameAddIpPostAsyncWithHttpInfo(name);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Send unary machine command 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineAddIpResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachineAddIpResponse>> MachinesNameAddIpPostAsyncWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameAddIpPost");

            var localVarPath = "/machines/{name}/add_ip";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNameAddIpPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineAddIpResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineAddIpResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineAddIpResponse)));
        }

        /// <summary>
        /// Send single command which does not need additional options. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Machine name.</param>
        /// <param name="command">Command key.</param>
        /// <returns>MachineCommandResultResponse</returns>
        public MachineCommandResultResponse MachinesNameCommandPost (string name, string command)
        {
             ApiResponse<MachineCommandResultResponse> localVarResponse = MachinesNameCommandPostWithHttpInfo(name, command);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Send single command which does not need additional options. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Machine name.</param>
        /// <param name="command">Command key.</param>
        /// <returns>ApiResponse of MachineCommandResultResponse</returns>
        public ApiResponse< MachineCommandResultResponse > MachinesNameCommandPostWithHttpInfo (string name, string command)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameCommandPost");
            // verify the required parameter 'command' is set
            if (command == null)
                throw new ApiException(400, "Missing required parameter 'command' when calling MachinesApi->MachinesNameCommandPost");

            var localVarPath = "/machines/{name}/{command}";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (command != null) localVarPathParams.Add("command", this.Configuration.ApiClient.ParameterToString(command)); // path parameter
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNameCommandPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCommandResultResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCommandResultResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCommandResultResponse)));
        }

        /// <summary>
        /// Send single command which does not need additional options. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Machine name.</param>
        /// <param name="command">Command key.</param>
        /// <returns>Task of MachineCommandResultResponse</returns>
        public async System.Threading.Tasks.Task<MachineCommandResultResponse> MachinesNameCommandPostAsync (string name, string command)
        {
             ApiResponse<MachineCommandResultResponse> localVarResponse = await MachinesNameCommandPostAsyncWithHttpInfo(name, command);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Send single command which does not need additional options. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Machine name.</param>
        /// <param name="command">Command key.</param>
        /// <returns>Task of ApiResponse (MachineCommandResultResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachineCommandResultResponse>> MachinesNameCommandPostAsyncWithHttpInfo (string name, string command)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameCommandPost");
            // verify the required parameter 'command' is set
            if (command == null)
                throw new ApiException(400, "Missing required parameter 'command' when calling MachinesApi->MachinesNameCommandPost");

            var localVarPath = "/machines/{name}/{command}";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (command != null) localVarPathParams.Add("command", this.Configuration.ApiClient.ParameterToString(command)); // path parameter
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNameCommandPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCommandResultResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCommandResultResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCommandResultResponse)));
        }

        /// <summary>
        /// Terminate machine Creates machine deletion jobs. This action can be cancelled in two days.
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MachineCommandResultResponse</returns>
        public MachineCommandResultResponse MachinesNameDelete (string name)
        {
             ApiResponse<MachineCommandResultResponse> localVarResponse = MachinesNameDeleteWithHttpInfo(name);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Terminate machine Creates machine deletion jobs. This action can be cancelled in two days.
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineCommandResultResponse</returns>
        public ApiResponse< MachineCommandResultResponse > MachinesNameDeleteWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameDelete");

            var localVarPath = "/machines/{name}";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNameDelete", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCommandResultResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCommandResultResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCommandResultResponse)));
        }

        /// <summary>
        /// Terminate machine Creates machine deletion jobs. This action can be cancelled in two days.
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MachineCommandResultResponse</returns>
        public async System.Threading.Tasks.Task<MachineCommandResultResponse> MachinesNameDeleteAsync (string name)
        {
             ApiResponse<MachineCommandResultResponse> localVarResponse = await MachinesNameDeleteAsyncWithHttpInfo(name);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Terminate machine Creates machine deletion jobs. This action can be cancelled in two days.
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineCommandResultResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachineCommandResultResponse>> MachinesNameDeleteAsyncWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameDelete");

            var localVarPath = "/machines/{name}";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNameDelete", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCommandResultResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCommandResultResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCommandResultResponse)));
        }

        /// <summary>
        /// Returns machine details 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MachineDetailsResponse</returns>
        public MachineDetailsResponse MachinesNameGet (string name)
        {
             ApiResponse<MachineDetailsResponse> localVarResponse = MachinesNameGetWithHttpInfo(name);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns machine details 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineDetailsResponse</returns>
        public ApiResponse< MachineDetailsResponse > MachinesNameGetWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameGet");

            var localVarPath = "/machines/{name}";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                Exception exception = ExceptionFactory("MachinesNameGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineDetailsResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineDetailsResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineDetailsResponse)));
        }

        /// <summary>
        /// Returns machine details 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MachineDetailsResponse</returns>
        public async System.Threading.Tasks.Task<MachineDetailsResponse> MachinesNameGetAsync (string name)
        {
             ApiResponse<MachineDetailsResponse> localVarResponse = await MachinesNameGetAsyncWithHttpInfo(name);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns machine details 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineDetailsResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachineDetailsResponse>> MachinesNameGetAsyncWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameGet");

            var localVarPath = "/machines/{name}";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                Exception exception = ExceptionFactory("MachinesNameGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineDetailsResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineDetailsResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineDetailsResponse)));
        }

        /// <summary>
        /// Returns list of jobs assigned to machine. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>JobsListResponse</returns>
        public JobsListResponse MachinesNameJobsGet (string name)
        {
             ApiResponse<JobsListResponse> localVarResponse = MachinesNameJobsGetWithHttpInfo(name);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns list of jobs assigned to machine. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of JobsListResponse</returns>
        public ApiResponse< JobsListResponse > MachinesNameJobsGetWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameJobsGet");

            var localVarPath = "/machines/{name}/jobs";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                Exception exception = ExceptionFactory("MachinesNameJobsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<JobsListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (JobsListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(JobsListResponse)));
        }

        /// <summary>
        /// Returns list of jobs assigned to machine. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of JobsListResponse</returns>
        public async System.Threading.Tasks.Task<JobsListResponse> MachinesNameJobsGetAsync (string name)
        {
             ApiResponse<JobsListResponse> localVarResponse = await MachinesNameJobsGetAsyncWithHttpInfo(name);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns list of jobs assigned to machine. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (JobsListResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<JobsListResponse>> MachinesNameJobsGetAsyncWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameJobsGet");

            var localVarPath = "/machines/{name}/jobs";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                Exception exception = ExceptionFactory("MachinesNameJobsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<JobsListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (JobsListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(JobsListResponse)));
        }

        /// <summary>
        /// Reinstall machine 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>MachineCommandResultResponse</returns>
        public MachineCommandResultResponse MachinesNamePost (MachineReinstallRequestBody body, string name)
        {
             ApiResponse<MachineCommandResultResponse> localVarResponse = MachinesNamePostWithHttpInfo(body, name);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Reinstall machine 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineCommandResultResponse</returns>
        public ApiResponse< MachineCommandResultResponse > MachinesNamePostWithHttpInfo (MachineReinstallRequestBody body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling MachinesApi->MachinesNamePost");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNamePost");

            var localVarPath = "/machines/{name}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNamePost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCommandResultResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCommandResultResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCommandResultResponse)));
        }

        /// <summary>
        /// Reinstall machine 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of MachineCommandResultResponse</returns>
        public async System.Threading.Tasks.Task<MachineCommandResultResponse> MachinesNamePostAsync (MachineReinstallRequestBody body, string name)
        {
             ApiResponse<MachineCommandResultResponse> localVarResponse = await MachinesNamePostAsyncWithHttpInfo(body, name);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Reinstall machine 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineCommandResultResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachineCommandResultResponse>> MachinesNamePostAsyncWithHttpInfo (MachineReinstallRequestBody body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling MachinesApi->MachinesNamePost");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNamePost");

            var localVarPath = "/machines/{name}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNamePost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCommandResultResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCommandResultResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCommandResultResponse)));
        }

        /// <summary>
        /// Update machine details 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>MachineCommandResultResponse</returns>
        public MachineCommandResultResponse MachinesNamePut (MachineUpdateRequestBody body, string name)
        {
             ApiResponse<MachineCommandResultResponse> localVarResponse = MachinesNamePutWithHttpInfo(body, name);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update machine details 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineCommandResultResponse</returns>
        public ApiResponse< MachineCommandResultResponse > MachinesNamePutWithHttpInfo (MachineUpdateRequestBody body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling MachinesApi->MachinesNamePut");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNamePut");

            var localVarPath = "/machines/{name}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNamePut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCommandResultResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCommandResultResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCommandResultResponse)));
        }

        /// <summary>
        /// Update machine details 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of MachineCommandResultResponse</returns>
        public async System.Threading.Tasks.Task<MachineCommandResultResponse> MachinesNamePutAsync (MachineUpdateRequestBody body, string name)
        {
             ApiResponse<MachineCommandResultResponse> localVarResponse = await MachinesNamePutAsyncWithHttpInfo(body, name);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update machine details 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineCommandResultResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachineCommandResultResponse>> MachinesNamePutAsyncWithHttpInfo (MachineUpdateRequestBody body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling MachinesApi->MachinesNamePut");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNamePut");

            var localVarPath = "/machines/{name}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesNamePut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCommandResultResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCommandResultResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCommandResultResponse)));
        }

        /// <summary>
        /// Returns list of additional system users. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MachineUsersListResponse</returns>
        public MachineUsersListResponse MachinesNameUsersGet (string name)
        {
             ApiResponse<MachineUsersListResponse> localVarResponse = MachinesNameUsersGetWithHttpInfo(name);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns list of additional system users. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of MachineUsersListResponse</returns>
        public ApiResponse< MachineUsersListResponse > MachinesNameUsersGetWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameUsersGet");

            var localVarPath = "/machines/{name}/users";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                Exception exception = ExceptionFactory("MachinesNameUsersGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineUsersListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineUsersListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineUsersListResponse)));
        }

        /// <summary>
        /// Returns list of additional system users. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MachineUsersListResponse</returns>
        public async System.Threading.Tasks.Task<MachineUsersListResponse> MachinesNameUsersGetAsync (string name)
        {
             ApiResponse<MachineUsersListResponse> localVarResponse = await MachinesNameUsersGetAsyncWithHttpInfo(name);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns list of additional system users. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (MachineUsersListResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachineUsersListResponse>> MachinesNameUsersGetAsyncWithHttpInfo (string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling MachinesApi->MachinesNameUsersGet");

            var localVarPath = "/machines/{name}/users";
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

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                Exception exception = ExceptionFactory("MachinesNameUsersGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineUsersListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineUsersListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineUsersListResponse)));
        }

        /// <summary>
        /// Create new machine. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <returns>MachineCreateResponse</returns>
        public MachineCreateResponse MachinesPost (MachineCreateRequestBody body)
        {
             ApiResponse<MachineCreateResponse> localVarResponse = MachinesPostWithHttpInfo(body);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create new machine. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <returns>ApiResponse of MachineCreateResponse</returns>
        public ApiResponse< MachineCreateResponse > MachinesPostWithHttpInfo (MachineCreateRequestBody body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling MachinesApi->MachinesPost");

            var localVarPath = "/machines";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCreateResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCreateResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCreateResponse)));
        }

        /// <summary>
        /// Create new machine. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <returns>Task of MachineCreateResponse</returns>
        public async System.Threading.Tasks.Task<MachineCreateResponse> MachinesPostAsync (MachineCreateRequestBody body)
        {
             ApiResponse<MachineCreateResponse> localVarResponse = await MachinesPostAsyncWithHttpInfo(body);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create new machine. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <returns>Task of ApiResponse (MachineCreateResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachineCreateResponse>> MachinesPostAsyncWithHttpInfo (MachineCreateRequestBody body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling MachinesApi->MachinesPost");

            var localVarPath = "/machines";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Key")))
            {
                localVarHeaderParams["Api-Key"] = this.Configuration.GetApiKeyWithPrefix("Api-Key");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MachinesPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachineCreateResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachineCreateResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachineCreateResponse)));
        }

        /// <summary>
        /// Returns list of currently running machines. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>MachinesListResponse</returns>
        public MachinesListResponse MachinesRunningGet ()
        {
             ApiResponse<MachinesListResponse> localVarResponse = MachinesRunningGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns list of currently running machines. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of MachinesListResponse</returns>
        public ApiResponse< MachinesListResponse > MachinesRunningGetWithHttpInfo ()
        {

            var localVarPath = "/machines/running";
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
                Exception exception = ExceptionFactory("MachinesRunningGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachinesListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachinesListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachinesListResponse)));
        }

        /// <summary>
        /// Returns list of currently running machines. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of MachinesListResponse</returns>
        public async System.Threading.Tasks.Task<MachinesListResponse> MachinesRunningGetAsync ()
        {
             ApiResponse<MachinesListResponse> localVarResponse = await MachinesRunningGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns list of currently running machines. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (MachinesListResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachinesListResponse>> MachinesRunningGetAsyncWithHttpInfo ()
        {

            var localVarPath = "/machines/running";
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
                Exception exception = ExceptionFactory("MachinesRunningGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachinesListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachinesListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachinesListResponse)));
        }

        /// <summary>
        /// Returns list of currently stopped or suspended machines. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>MachinesListResponse</returns>
        public MachinesListResponse MachinesStoppedGet ()
        {
             ApiResponse<MachinesListResponse> localVarResponse = MachinesStoppedGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns list of currently stopped or suspended machines. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of MachinesListResponse</returns>
        public ApiResponse< MachinesListResponse > MachinesStoppedGetWithHttpInfo ()
        {

            var localVarPath = "/machines/stopped";
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
                Exception exception = ExceptionFactory("MachinesStoppedGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachinesListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachinesListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachinesListResponse)));
        }

        /// <summary>
        /// Returns list of currently stopped or suspended machines. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of MachinesListResponse</returns>
        public async System.Threading.Tasks.Task<MachinesListResponse> MachinesStoppedGetAsync ()
        {
             ApiResponse<MachinesListResponse> localVarResponse = await MachinesStoppedGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns list of currently stopped or suspended machines. 
        /// </summary>
        /// <exception cref="FozzyHosting.WinVPS.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (MachinesListResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachinesListResponse>> MachinesStoppedGetAsyncWithHttpInfo ()
        {

            var localVarPath = "/machines/stopped";
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
                Exception exception = ExceptionFactory("MachinesStoppedGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachinesListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (MachinesListResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachinesListResponse)));
        }

    }
}
