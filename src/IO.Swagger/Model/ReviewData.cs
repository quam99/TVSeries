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
    /// ReviewData
    /// </summary>
    [DataContract]
        public partial class ReviewData :  IEquatable<ReviewData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewData" /> class.
        /// </summary>
        /// <param name="imDbId">imDbId.</param>
        /// <param name="title">title.</param>
        /// <param name="fullTitle">fullTitle.</param>
        /// <param name="type">type.</param>
        /// <param name="year">year.</param>
        /// <param name="items">items.</param>
        /// <param name="errorMessage">errorMessage.</param>
        public ReviewData(string imDbId = default(string), string title = default(string), string fullTitle = default(string), string type = default(string), string year = default(string), List<ReviewDetail> items = default(List<ReviewDetail>), string errorMessage = default(string))
        {
            this.ImDbId = imDbId;
            this.Title = title;
            this.FullTitle = fullTitle;
            this.Type = type;
            this.Year = year;
            this.Items = items;
            this.ErrorMessage = errorMessage;
        }
        
        /// <summary>
        /// Gets or Sets ImDbId
        /// </summary>
        [DataMember(Name="imDbId", EmitDefaultValue=false)]
        public string ImDbId { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets FullTitle
        /// </summary>
        [DataMember(Name="fullTitle", EmitDefaultValue=false)]
        public string FullTitle { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Year
        /// </summary>
        [DataMember(Name="year", EmitDefaultValue=false)]
        public string Year { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue=false)]
        public List<ReviewDetail> Items { get; set; }

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
            sb.Append("class ReviewData {\n");
            sb.Append("  ImDbId: ").Append(ImDbId).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  FullTitle: ").Append(FullTitle).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Year: ").Append(Year).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
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
            return this.Equals(input as ReviewData);
        }

        /// <summary>
        /// Returns true if ReviewData instances are equal
        /// </summary>
        /// <param name="input">Instance of ReviewData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReviewData input)
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
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.FullTitle == input.FullTitle ||
                    (this.FullTitle != null &&
                    this.FullTitle.Equals(input.FullTitle))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Year == input.Year ||
                    (this.Year != null &&
                    this.Year.Equals(input.Year))
                ) && 
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    input.Items != null &&
                    this.Items.SequenceEqual(input.Items)
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
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.FullTitle != null)
                    hashCode = hashCode * 59 + this.FullTitle.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Year != null)
                    hashCode = hashCode * 59 + this.Year.GetHashCode();
                if (this.Items != null)
                    hashCode = hashCode * 59 + this.Items.GetHashCode();
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
