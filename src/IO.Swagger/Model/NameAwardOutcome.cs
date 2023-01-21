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
using SwaggerDateConverter = IO.TVSeries.Client.SwaggerDateConverter;

namespace IO.TVSeries.Model
{
    /// <summary>
    /// NameAwardOutcome
    /// </summary>
    [DataContract]
        public partial class NameAwardOutcome :  IEquatable<NameAwardOutcome>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameAwardOutcome" /> class.
        /// </summary>
        /// <param name="outcomeYear">outcomeYear.</param>
        /// <param name="outcomeTitle">outcomeTitle.</param>
        /// <param name="outcomeCategory">outcomeCategory.</param>
        /// <param name="outcomeDetails">outcomeDetails.</param>
        public NameAwardOutcome(string outcomeYear = default(string), string outcomeTitle = default(string), string outcomeCategory = default(string), List<NameAwardOutcomeDetail> outcomeDetails = default(List<NameAwardOutcomeDetail>))
        {
            this.OutcomeYear = outcomeYear;
            this.OutcomeTitle = outcomeTitle;
            this.OutcomeCategory = outcomeCategory;
            this.OutcomeDetails = outcomeDetails;
        }
        
        /// <summary>
        /// Gets or Sets OutcomeYear
        /// </summary>
        [DataMember(Name="outcomeYear", EmitDefaultValue=false)]
        public string OutcomeYear { get; set; }

        /// <summary>
        /// Gets or Sets OutcomeTitle
        /// </summary>
        [DataMember(Name="outcomeTitle", EmitDefaultValue=false)]
        public string OutcomeTitle { get; set; }

        /// <summary>
        /// Gets or Sets OutcomeCategory
        /// </summary>
        [DataMember(Name="outcomeCategory", EmitDefaultValue=false)]
        public string OutcomeCategory { get; set; }

        /// <summary>
        /// Gets or Sets OutcomeDetails
        /// </summary>
        [DataMember(Name="outcomeDetails", EmitDefaultValue=false)]
        public List<NameAwardOutcomeDetail> OutcomeDetails { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NameAwardOutcome {\n");
            sb.Append("  OutcomeYear: ").Append(OutcomeYear).Append("\n");
            sb.Append("  OutcomeTitle: ").Append(OutcomeTitle).Append("\n");
            sb.Append("  OutcomeCategory: ").Append(OutcomeCategory).Append("\n");
            sb.Append("  OutcomeDetails: ").Append(OutcomeDetails).Append("\n");
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
            return this.Equals(input as NameAwardOutcome);
        }

        /// <summary>
        /// Returns true if NameAwardOutcome instances are equal
        /// </summary>
        /// <param name="input">Instance of NameAwardOutcome to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NameAwardOutcome input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OutcomeYear == input.OutcomeYear ||
                    (this.OutcomeYear != null &&
                    this.OutcomeYear.Equals(input.OutcomeYear))
                ) && 
                (
                    this.OutcomeTitle == input.OutcomeTitle ||
                    (this.OutcomeTitle != null &&
                    this.OutcomeTitle.Equals(input.OutcomeTitle))
                ) && 
                (
                    this.OutcomeCategory == input.OutcomeCategory ||
                    (this.OutcomeCategory != null &&
                    this.OutcomeCategory.Equals(input.OutcomeCategory))
                ) && 
                (
                    this.OutcomeDetails == input.OutcomeDetails ||
                    this.OutcomeDetails != null &&
                    input.OutcomeDetails != null &&
                    this.OutcomeDetails.SequenceEqual(input.OutcomeDetails)
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
                if (this.OutcomeYear != null)
                    hashCode = hashCode * 59 + this.OutcomeYear.GetHashCode();
                if (this.OutcomeTitle != null)
                    hashCode = hashCode * 59 + this.OutcomeTitle.GetHashCode();
                if (this.OutcomeCategory != null)
                    hashCode = hashCode * 59 + this.OutcomeCategory.GetHashCode();
                if (this.OutcomeDetails != null)
                    hashCode = hashCode * 59 + this.OutcomeDetails.GetHashCode();
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
