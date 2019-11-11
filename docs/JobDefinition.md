# FozzyHosting.WinVPS.Model.JobDefinition
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **int?** | Job primary ID. Can be used to show Job details or cancel the command | [optional] 
**ParentId** | **int?** | ID of the last Job before the current one. Since the commands are executed sequentially, parent ID can be used to monitor the progress of command processing. | [optional] 
**MachineId** | **int?** | ID of the machine Job created for. | [optional] 
**Type** | **string** | Defines the command which be executed. | [optional] 
**Status** | **string** | Command status. | [optional] 
**StartTime** | **string** | Time after which the command can be started. The Job will not be started before this time but can be started some time later when the queue reaches its completion. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

