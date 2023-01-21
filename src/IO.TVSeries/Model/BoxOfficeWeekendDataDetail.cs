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
    /// BoxOfficeWeekendDataDetail
    /// </summary>
    [DataContract]
        public partial class BoxOfficeWeekendDataDetail :  IEquatable<BoxOfficeWeekendDataDetail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxOfficeWeekendDataDetail" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="rank">rank.</param>
        /// <param name="title">title.</param>
        /// <param name="image">image.</param>
        /// <param name="weekend">weekend.</param>
        /// <param name="gross">gross.</param>
        /// <param name="weeks">weeks.</param>
        public BoxOfficeWeekendDataDetail(string id = default(string), string rank = default(string), string title = default(string), string image = default(string), string weekend = default(string), string gross = default(string), string weeks = default(string))
        {
            this.Id = id;
            this.Rank = rank;
            this.Title = title;
            this.Image = image;
            this.Weekend = weekend;
            this.Gross = gross;
            this.Weeks = weeks;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Rank
        /// </summary>
        [DataMember(Name="rank", EmitDefaultValue=false)]
        public string Rank { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name="image", EmitDefaultValue=false)]
        public string Image { get; set; }

        /// <summary>
        /// Gets or Sets Weekend
        /// </summary>
        [DataMember(Name="weekend", EmitDefaultValue=false)]
        public string Weekend { get; set; }

        /// <summary>
        /// Gets or Sets Gross
        /// </summary>
        [DataMember(Name="gross", EmitDefaultValue=false)]
        public string Gross { get; set; }

        /// <summary>
        /// Gets or Sets Weeks
        /// </summary>
        [DataMember(Name="weeks", EmitDefaultValue=false)]
        public string Weeks { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BoxOfficeWeekendDataDetail {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Rank: ").Append(Rank).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  Weekend: ").Append(Weekend).Append("\n");
            sb.Append("  Gross: ").Append(Gross).Append("\n");
            sb.Append("  Weeks: ").Append(Weeks).Append("\n");
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
            return this.Equals(input as BoxOfficeWeekendDataDetail);
        }

        /// <summary>
        /// Returns true if BoxOfficeWeekendDataDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of BoxOfficeWeekendDataDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BoxOfficeWeekendDataDetail input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Rank == input.Rank ||
                    (this.Rank != null &&
                    this.Rank.Equals(input.Rank))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Image == input.Image ||
                    (this.Image != null &&
                    this.Image.Equals(input.Image))
                ) && 
                (
                    this.Weekend == input.Weekend ||
                    (this.Weekend != null &&
                    this.Weekend.Equals(input.Weekend))
                ) && 
                (
                    this.Gross == input.Gross ||
                    (this.Gross != null &&
                    this.Gross.Equals(input.Gross))
                ) && 
                (
                    this.Weeks == input.Weeks ||
                    (this.Weeks != null &&
                    this.Weeks.Equals(input.Weeks))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Rank != null)
                    hashCode = hashCode * 59 + this.Rank.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Image != null)
                    hashCode = hashCode * 59 + this.Image.GetHashCode();
                if (this.Weekend != null)
                    hashCode = hashCode * 59 + this.Weekend.GetHashCode();
                if (this.Gross != null)
                    hashCode = hashCode * 59 + this.Gross.GetHashCode();
                if (this.Weeks != null)
                    hashCode = hashCode * 59 + this.Weeks.GetHashCode();
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