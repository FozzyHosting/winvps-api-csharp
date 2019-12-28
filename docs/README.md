## Documentation for API Endpoints

All URIs are relative to *https://winvps.fozzy.com/api/v2*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*BrandsApi* | [**BrandsGet**](BrandsApi.md#brandsget) | **GET** /brands | Returns list of all available preinstalled software set.
*JobsApi* | [**JobsGet**](JobsApi.md#jobsget) | **GET** /jobs | List of all planned and completed commands.
*JobsApi* | [**JobsIdDelete**](JobsApi.md#jobsiddelete) | **DELETE** /jobs/{id} | Cancel specified Job.
*JobsApi* | [**JobsIdGet**](JobsApi.md#jobsidget) | **GET** /jobs/{id} | View single Job details.
*JobsApi* | [**JobsPendingGet**](JobsApi.md#jobspendingget) | **GET** /jobs/pending | List of all planned commands.
*LocationsApi* | [**LocationsGet**](LocationsApi.md#locationsget) | **GET** /locations | Returns list of locations available for new machines.
*MachinesApi* | [**MachinesGet**](MachinesApi.md#machinesget) | **GET** /machines | Returns machines list in short form.
*MachinesApi* | [**MachinesNameAddIpPost**](MachinesApi.md#machinesnameaddippost) | **POST** /machines/{name}/add_ip | Send unary machine command
*MachinesApi* | [**MachinesNameCommandPost**](MachinesApi.md#machinesnamecommandpost) | **POST** /machines/{name}/{command} | Send single command which does not need additional options.
*MachinesApi* | [**MachinesNameDelete**](MachinesApi.md#machinesnamedelete) | **DELETE** /machines/{name} | Terminate machine
*MachinesApi* | [**MachinesNameGet**](MachinesApi.md#machinesnameget) | **GET** /machines/{name} | Returns machine details
*MachinesApi* | [**MachinesNameJobsGet**](MachinesApi.md#machinesnamejobsget) | **GET** /machines/{name}/jobs | Returns list of jobs assigned to machine.
*MachinesApi* | [**MachinesNamePost**](MachinesApi.md#machinesnamepost) | **POST** /machines/{name} | Reinstall machine
*MachinesApi* | [**MachinesNamePut**](MachinesApi.md#machinesnameput) | **PUT** /machines/{name} | Update machine details
*MachinesApi* | [**MachinesNameUsersGet**](MachinesApi.md#machinesnameusersget) | **GET** /machines/{name}/users | Returns list of additional system users.
*MachinesApi* | [**MachinesPost**](MachinesApi.md#machinespost) | **POST** /machines | Create new machine.
*MachinesApi* | [**MachinesRunningGet**](MachinesApi.md#machinesrunningget) | **GET** /machines/running | Returns list of currently running machines.
*MachinesApi* | [**MachinesStoppedGet**](MachinesApi.md#machinesstoppedget) | **GET** /machines/stopped | Returns list of currently stopped or suspended machines.
*ProductsApi* | [**ProductsGet**](ProductsApi.md#productsget) | **GET** /products | Returns list of all available products.
*TemplatesApi* | [**TemplatesGet**](TemplatesApi.md#templatesget) | **GET** /templates | Returns list of all templates available for new machines.

<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.BrandDefinition](BrandDefinition.md)
 - [Model.BrandsList](BrandsList.md)
 - [Model.BrandsListResponse](BrandsListResponse.md)
 - [Model.ErrorResponse](ErrorResponse.md)
 - [Model.IpDefinition](IpDefinition.md)
 - [Model.JobDefinition](JobDefinition.md)
 - [Model.JobDetailsResponse](JobDetailsResponse.md)
 - [Model.JobsList](JobsList.md)
 - [Model.JobsListResponse](JobsListResponse.md)
 - [Model.LocationDefinition](LocationDefinition.md)
 - [Model.LocationsList](LocationsList.md)
 - [Model.LocationsListResponse](LocationsListResponse.md)
 - [Model.MachineAddIpResponse](MachineAddIpResponse.md)
 - [Model.MachineAddIpResponseData](MachineAddIpResponseData.md)
 - [Model.MachineAdditionsDefinition](MachineAdditionsDefinition.md)
 - [Model.MachineCommandResultResponse](MachineCommandResultResponse.md)
 - [Model.MachineCommandResultResponseData](MachineCommandResultResponseData.md)
 - [Model.MachineConfig](MachineConfig.md)
 - [Model.MachineCreateRequestBody](MachineCreateRequestBody.md)
 - [Model.MachineCreateResponse](MachineCreateResponse.md)
 - [Model.MachineCreateResponseData](MachineCreateResponseData.md)
 - [Model.MachineDefinition](MachineDefinition.md)
 - [Model.MachineDetailsResponse](MachineDetailsResponse.md)
 - [Model.MachineEditableFields](MachineEditableFields.md)
 - [Model.MachineListItem](MachineListItem.md)
 - [Model.MachineNonReinstallableFields](MachineNonReinstallableFields.md)
 - [Model.MachineOS](MachineOS.md)
 - [Model.MachineOSUpdateStatus](MachineOSUpdateStatus.md)
 - [Model.MachineReinstallRequestBody](MachineReinstallRequestBody.md)
 - [Model.MachineReinstallableFields](MachineReinstallableFields.md)
 - [Model.MachineUpdateRequestBody](MachineUpdateRequestBody.md)
 - [Model.MachineUserDefinition](MachineUserDefinition.md)
 - [Model.MachineUsersList](MachineUsersList.md)
 - [Model.MachineUsersListResponse](MachineUsersListResponse.md)
 - [Model.MachinesList](MachinesList.md)
 - [Model.MachinesListResponse](MachinesListResponse.md)
 - [Model.PaginationDetails](PaginationDetails.md)
 - [Model.ProductDefinition](ProductDefinition.md)
 - [Model.ProductDefinitionLimits](ProductDefinitionLimits.md)
 - [Model.ProductsList](ProductsList.md)
 - [Model.ProductsListResponse](ProductsListResponse.md)
 - [Model.TemplateDefinition](TemplateDefinition.md)
 - [Model.TemplatesList](TemplatesList.md)
 - [Model.TemplatesListResponse](TemplatesListResponse.md)

<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="ApiKeyAuth"></a>
### ApiKeyAuth

- **Type**: API key
- **API key parameter name**: Api-Key
- **Location**: HTTP header

