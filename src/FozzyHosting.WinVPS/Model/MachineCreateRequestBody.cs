/* 
 * Fozzy Windows VPS resellers API
 *
 *  Application Programming Interface (API) allows clients to manage the Windows VPS machines lifecycle.  ## Endpoint  `https://winvps.fozzy.com/api/v2/`  ## Authentication  To access the API, an existing client of Fozzy Inc. should be registered as Windows VPS Reseller by the company tech support through the ticket or using Sales Email. After that, the client will have an access to the winvps.fozzy.com and will be able to get an API Token (Signature) in `Settings -> API` section of main menu.  If you have already used the previous API version, then the token is known to you.  Note that the Token grants full access to your account and should be protected the same way you would protect your password. Also you can reset the Token on the receipt page.  To use the Token you should pass it to `Api-Key` header of each request like this:  ` curl -H 'API-KEY: TOKEN' https://winvps.fozzy.com/api/v2/products `  ## Content-Type  API v2 supports `application/json`, `application/x-www-form-urlencoded` and `multipart/form-data` content types.  In the first case HTTP request must be JSON-encoded with the body as a valid JSON string. The othres are default POST types with content in key=value format.  The response always has `application/json` type and contains JSON-encoded payload.  ## Response  A successful response will be returned as a JSON object with at least one of the following top-level members: - `data` - the document’s “primary data” - `error` - error message - `pagination` - pagination details  The members data and error cannot coexist in the same document.  ### Codes   - `200 OK` - Everything worked as expected.  - `201 Created` - The request was successful and a resource was created. This is typically a response from a POST request to create a resource which runs immediately.  - `202 Accepted` - The request has been accepted for processing. This is typically a response from a POST request that is handled async in our system, such as a request for some machine command.  - `204 No Content` - The request was successful but the response body is empty. This is typically a response from a DELETE request to delete a resource or cancel the command.  - `400 Bad Request` - A required parameter or the request is invalid.  - `403 Unauthorized` - The authentication credentials are invalid.  - `404 Not Found` - The requested resource doesn’t exist.  - `500 Server error` - something went wrong. Please contact our support team.  ### Examples  #### Error:  ```json {   \"error\": \"Error message\" } ```  #### Success - retrieve single record:  ```json {   \"data\": {     \"id\": 1,     \"name\": \"String\"   } } ```   #### Success - retrieve multiple records:  ```json {   \"data\": [     {       \"id\": 1,       \"name\": \"String\"     }, {       \"id\": 2,       \"name\": \"String\"     }   ],   \"pagination\": {     \"total\": 10,   } } ```  #### Success - response for some delayed action:  ```json {   \"data\": {     \"name\": \"String\",     \"jobs\": [       {         \"id\": 0,         \"parent_id\": 0,         \"machine_id\": 0,         \"type\": \"string\",         \"status\": \"string\",         \"start_time\": \"string\"       }     ]   } } ```  ## Pagination  Any API endpoint that returns a list of items requires pagination. By default we will return `50` records from any listing endpoint.  If an API endpoint returns a list of items, then it will include an additional object with pagination information.  The pagination information contains the following details:   - `total` - The total number of entries available in the entire collection  - `limit` - The number of entries returned per page (default: 50)  - `page` - The page currently returned (default: 1)  - `pages` - The total number of pages  To go through the pages you need to pass additional GET parameter `page` with the number of page wanted.  ## Entities meaning  ### Product  A product is a resources set with which a VPS will be created by default. This is a resources such ads CPU cores count, CPU power in percents of the maximum available limit, RAM minimum and maximum values, Disk Size etc.  ### Template  Template is an operating system version for VPS.  ### Brand  Brand is a set of custom software which installs on the machine automatically. Currently this set can be created only through the request to our administrators.  ### Location  Location is a list of regions in which the new VPS creation is available.  ### Job  Job is a command to perform specific actions on the machine such as creation, starting, changing, terminating, etc. Since most actions cannot be performed instantly, they are all queued and executed one after another. You will receive an additional property `jobs` in your response if any request generates new queue positions.  ### Machine  Machine is a virtual private server (VPS) which used to your own needs. Each Mahine has Operating System defined by **Template** installed on the server in a data center in a country specified by **Location** option. The machine has some specified by **Product** resources which can be used by your software installed automatically by the **Brand** option or manually from the RDP interface.  ## Changelog  ### Version 2.3.0 Methods `/machines` and `/machines/{name}` is now additionaly returns `notes` param.  ### Version 2.2.0  The machine creation command now supports an additional option `add_ipv6` to provide the IPv6 for the new machine.  ### Version 2.1.0  Added new command `run_updates_install` for starting Windows updates installation. Command can be used in the *_/machines/{name}/{command}* request.  The status of updates is displayed in the general information about the machine by the *_/machines/{name}* request. 
 *
 * OpenAPI spec version: 2.1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = FozzyHosting.WinVPS.Client.SwaggerDateConverter;

namespace FozzyHosting.WinVPS.Model
{
    /// <summary>
    /// MachineCreateRequestBody
    /// </summary>
    [DataContract]
        public partial class MachineCreateRequestBody : MachineEditableFields,  IEquatable<MachineCreateRequestBody>, IValidatableObject
    {
        /// <summary>
        /// Server disk type. HDD or SSD.
        /// </summary>
        /// <value>Server disk type. HDD or SSD.</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum DiskTypeEnum
        {
            /// <summary>
            /// Enum Hdd for value: hdd
            /// </summary>
            [EnumMember(Value = "hdd")]
            Hdd = 0,
            /// <summary>
            /// Enum Ssd for value: ssd
            /// </summary>
            [EnumMember(Value = "ssd")]
            Ssd = 1        }
        /// <summary>
        /// Server disk type. HDD or SSD.
        /// </summary>
        /// <value>Server disk type. HDD or SSD.</value>
        [DataMember(Name="disk_type", EmitDefaultValue=false)]
        public DiskTypeEnum? DiskType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MachineCreateRequestBody" /> class.
        /// </summary>
        /// <param name="templateId">Primary Template ID..</param>
        /// <param name="brandId">Primary Brand ID..</param>
        /// <param name="diskType">Server disk type. HDD or SSD..</param>
        /// <param name="locationId">Primary Location ID..</param>
        /// <param name="addDisk">Additional disk saze..</param>
        /// <param name="addRam">Additional RAM size in MB..</param>
        /// <param name="addCpu">Additional CPU cores count..</param>
        /// <param name="addBand">Additional bandwidth..</param>
        /// <param name="autoStart">autoStart.</param>
        /// <param name="addIpv6">addIpv6.</param>
        public MachineCreateRequestBody(int? templateId = default(int?), int? brandId = default(int?), DiskTypeEnum? diskType = default(DiskTypeEnum?), int? locationId = default(int?), int? addDisk = default(int?), int? addRam = default(int?), int? addCpu = default(int?), int? addBand = default(int?), int? autoStart = default(int?), int? addIpv6 = default(int?), int? templateId = default(int?), string password = default(string), int? productId = default(int?)) : base(password, productId)
        {
            this.TemplateId = templateId;
            this.BrandId = brandId;
            this.DiskType = diskType;
            this.LocationId = locationId;
            this.AddDisk = addDisk;
            this.AddRam = addRam;
            this.AddCpu = addCpu;
            this.AddBand = addBand;
            this.AutoStart = autoStart;
            this.AddIpv6 = addIpv6;
        }

        /// <summary>
        /// Primary Template ID.
        /// </summary>
        /// <value>Primary Template ID.</value>
        [DataMember(Name="template_id", EmitDefaultValue=false)]
        public int? TemplateId { get; set; }

        /// <summary>
        /// Primary Brand ID.
        /// </summary>
        /// <value>Primary Brand ID.</value>
        [DataMember(Name="brand_id", EmitDefaultValue=false)]
        public int? BrandId { get; set; }


        /// <summary>
        /// Primary Location ID.
        /// </summary>
        /// <value>Primary Location ID.</value>
        [DataMember(Name="location_id", EmitDefaultValue=false)]
        public int? LocationId { get; set; }

        /// <summary>
        /// Additional disk saze.
        /// </summary>
        /// <value>Additional disk saze.</value>
        [DataMember(Name="add_disk", EmitDefaultValue=false)]
        public int? AddDisk { get; set; }

        /// <summary>
        /// Additional RAM size in MB.
        /// </summary>
        /// <value>Additional RAM size in MB.</value>
        [DataMember(Name="add_ram", EmitDefaultValue=false)]
        public int? AddRam { get; set; }

        /// <summary>
        /// Additional CPU cores count.
        /// </summary>
        /// <value>Additional CPU cores count.</value>
        [DataMember(Name="add_cpu", EmitDefaultValue=false)]
        public int? AddCpu { get; set; }

        /// <summary>
        /// Additional bandwidth.
        /// </summary>
        /// <value>Additional bandwidth.</value>
        [DataMember(Name="add_band", EmitDefaultValue=false)]
        public int? AddBand { get; set; }

        /// <summary>
        /// Gets or Sets AutoStart
        /// </summary>
        [DataMember(Name="auto_start", EmitDefaultValue=false)]
        public int? AutoStart { get; set; }

        /// <summary>
        /// Gets or Sets AddIpv6
        /// </summary>
        [DataMember(Name="add_ipv6", EmitDefaultValue=false)]
        public int? AddIpv6 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MachineCreateRequestBody {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  TemplateId: ").Append(TemplateId).Append("\n");
            sb.Append("  BrandId: ").Append(BrandId).Append("\n");
            sb.Append("  DiskType: ").Append(DiskType).Append("\n");
            sb.Append("  LocationId: ").Append(LocationId).Append("\n");
            sb.Append("  AddDisk: ").Append(AddDisk).Append("\n");
            sb.Append("  AddRam: ").Append(AddRam).Append("\n");
            sb.Append("  AddCpu: ").Append(AddCpu).Append("\n");
            sb.Append("  AddBand: ").Append(AddBand).Append("\n");
            sb.Append("  AutoStart: ").Append(AutoStart).Append("\n");
            sb.Append("  AddIpv6: ").Append(AddIpv6).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as MachineCreateRequestBody);
        }

        /// <summary>
        /// Returns true if MachineCreateRequestBody instances are equal
        /// </summary>
        /// <param name="input">Instance of MachineCreateRequestBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MachineCreateRequestBody input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.TemplateId == input.TemplateId ||
                    (this.TemplateId != null &&
                    this.TemplateId.Equals(input.TemplateId))
                ) && base.Equals(input) && 
                (
                    this.BrandId == input.BrandId ||
                    (this.BrandId != null &&
                    this.BrandId.Equals(input.BrandId))
                ) && base.Equals(input) && 
                (
                    this.DiskType == input.DiskType ||
                    (this.DiskType != null &&
                    this.DiskType.Equals(input.DiskType))
                ) && base.Equals(input) && 
                (
                    this.LocationId == input.LocationId ||
                    (this.LocationId != null &&
                    this.LocationId.Equals(input.LocationId))
                ) && base.Equals(input) && 
                (
                    this.AddDisk == input.AddDisk ||
                    (this.AddDisk != null &&
                    this.AddDisk.Equals(input.AddDisk))
                ) && base.Equals(input) && 
                (
                    this.AddRam == input.AddRam ||
                    (this.AddRam != null &&
                    this.AddRam.Equals(input.AddRam))
                ) && base.Equals(input) && 
                (
                    this.AddCpu == input.AddCpu ||
                    (this.AddCpu != null &&
                    this.AddCpu.Equals(input.AddCpu))
                ) && base.Equals(input) && 
                (
                    this.AddBand == input.AddBand ||
                    (this.AddBand != null &&
                    this.AddBand.Equals(input.AddBand))
                ) && base.Equals(input) && 
                (
                    this.AutoStart == input.AutoStart ||
                    (this.AutoStart != null &&
                    this.AutoStart.Equals(input.AutoStart))
                ) && base.Equals(input) && 
                (
                    this.AddIpv6 == input.AddIpv6 ||
                    (this.AddIpv6 != null &&
                    this.AddIpv6.Equals(input.AddIpv6))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.TemplateId != null)
                    hashCode = hashCode * 59 + this.TemplateId.GetHashCode();
                if (this.BrandId != null)
                    hashCode = hashCode * 59 + this.BrandId.GetHashCode();
                if (this.DiskType != null)
                    hashCode = hashCode * 59 + this.DiskType.GetHashCode();
                if (this.LocationId != null)
                    hashCode = hashCode * 59 + this.LocationId.GetHashCode();
                if (this.AddDisk != null)
                    hashCode = hashCode * 59 + this.AddDisk.GetHashCode();
                if (this.AddRam != null)
                    hashCode = hashCode * 59 + this.AddRam.GetHashCode();
                if (this.AddCpu != null)
                    hashCode = hashCode * 59 + this.AddCpu.GetHashCode();
                if (this.AddBand != null)
                    hashCode = hashCode * 59 + this.AddBand.GetHashCode();
                if (this.AutoStart != null)
                    hashCode = hashCode * 59 + this.AutoStart.GetHashCode();
                if (this.AddIpv6 != null)
                    hashCode = hashCode * 59 + this.AddIpv6.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            ///foreach(var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }
}
