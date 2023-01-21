/* 
 * IMDb-API
 *
 * The IMDb-API Documentation. You need a <a href='/Identity/Account/Manage' target='_blank'><code>API Key</code></a> for testing APIs.<br/><a class='link' href='/API'>Back to API Tester</a>
 *
 * OpenAPI spec version: 1.8.1
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
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// NameAwardData
    /// </summary>
    [DataContract]
        public partial class NameAwardData :  IEquatable<NameAwardData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameAwardData" /> class.
        /// </summary>
        /// <param name="imDbId">imDbId.</param>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="items">items.</param>
        /// <param name="nameAwardsHtml">nameAwardsHtml.</param>
        /// <param name="errorMessage">errorMessage.</param>
        public NameAwardData(string imDbId = default(string), string name = default(string), string description = default(string), List<NameAwardEvent> items = default(List<NameAwardEvent>), string nameAwardsHtml = default(string), string errorMessage = default(string))
        {
            this.ImDbId = imDbId;
            this.Name = name;
            this.Description = description;
            this.Items = items;
            this.NameAwardsHtml = nameAwardsHtml;
            this.ErrorMessage = errorMessage;
        }
        
        /// <summary>
        /// Gets or Sets ImDbId
        /// </summary>
        [DataMember(Name="imDbId", EmitDefaultValue=false)]
        public string ImDbId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue=false)]
        public List<NameAwardEvent> Items { get; set; }

        /// <summary>
        /// Gets or Sets NameAwardsHtml
        /// </summary>
        [DataMember(Name="nameAwardsHtml", EmitDefaultValue=false)]
        public string NameAwardsHtml { get; set; }

        /// <summary>
        /// Gets or Sets ErrorMessage
        /// </summary>
        [DataMember(Name="errorMessage", EmitDefaultValue=false)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NameAwardData {\n");
            sb.Append("  ImDbId: ").Append(ImDbId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  NameAwardsHtml: ").Append(NameAwardsHtml).Append("\n");
            sb.Append("  ErrorMessage: ").Append(ErrorMessage).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
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
            return this.Equals(input as NameAwardData);
        }

        /// <summary>
        /// Returns true if NameAwardData instances are equal
        /// </summary>
        /// <param name="input">Instance of NameAwardData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NameAwardData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ImDbId == input.ImDbId ||
                    (this.ImDbId != null &&
                    this.ImDbId.Equals(input.ImDbId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    input.Items != null &&
                    this.Items.SequenceEqual(input.Items)
                ) && 
                (
                    this.NameAwardsHtml == input.NameAwardsHtml ||
                    (this.NameAwardsHtml != null &&
                    this.NameAwardsHtml.Equals(input.NameAwardsHtml))
                ) && 
                (
                    this.ErrorMessage == input.ErrorMessage ||
                    (this.ErrorMessage != null &&
                    this.ErrorMessage.Equals(input.ErrorMessage))
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
                int hashCode = 41;
                if (this.ImDbId != null)
                    hashCode = hashCode * 59 + this.ImDbId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Items != null)
                    hashCode = hashCode * 59 + this.Items.GetHashCode();
                if (this.NameAwardsHtml != null)
                    hashCode = hashCode * 59 + this.NameAwardsHtml.GetHashCode();
                if (this.ErrorMessage != null)
                    hashCode = hashCode * 59 + this.ErrorMessage.GetHashCode();
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
            yield break;
        }
    }
}
