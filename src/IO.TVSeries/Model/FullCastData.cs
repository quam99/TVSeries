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
    /// FullCastData
    /// </summary>
    [DataContract]
        public partial class FullCastData :  IEquatable<FullCastData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FullCastData" /> class.
        /// </summary>
        /// <param name="imDbId">imDbId.</param>
        /// <param name="title">title.</param>
        /// <param name="fullTitle">fullTitle.</param>
        /// <param name="type">type.</param>
        /// <param name="year">year.</param>
        /// <param name="directors">directors.</param>
        /// <param name="writers">writers.</param>
        /// <param name="actors">actors.</param>
        /// <param name="others">others.</param>
        /// <param name="errorMessage">errorMessage.</param>
        public FullCastData(string imDbId = default(string), string title = default(string), string fullTitle = default(string), string type = default(string), string year = default(string), CastShort directors = default(CastShort), CastShort writers = default(CastShort), List<ActorShort> actors = default(List<ActorShort>), List<CastShort> others = default(List<CastShort>), string errorMessage = default(string))
        {
            this.ImDbId = imDbId;
            this.Title = title;
            this.FullTitle = fullTitle;
            this.Type = type;
            this.Year = year;
            this.Directors = directors;
            this.Writers = writers;
            this.Actors = actors;
            this.Others = others;
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
        /// Gets or Sets Directors
        /// </summary>
        [DataMember(Name="directors", EmitDefaultValue=false)]
        public CastShort Directors { get; set; }

        /// <summary>
        /// Gets or Sets Writers
        /// </summary>
        [DataMember(Name="writers", EmitDefaultValue=false)]
        public CastShort Writers { get; set; }

        /// <summary>
        /// Gets or Sets Actors
        /// </summary>
        [DataMember(Name="actors", EmitDefaultValue=false)]
        public List<ActorShort> Actors { get; set; }

        /// <summary>
        /// Gets or Sets Others
        /// </summary>
        [DataMember(Name="others", EmitDefaultValue=false)]
        public List<CastShort> Others { get; set; }

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
            sb.Append("class FullCastData {\n");
            sb.Append("  ImDbId: ").Append(ImDbId).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  FullTitle: ").Append(FullTitle).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Year: ").Append(Year).Append("\n");
            sb.Append("  Directors: ").Append(Directors).Append("\n");
            sb.Append("  Writers: ").Append(Writers).Append("\n");
            sb.Append("  Actors: ").Append(Actors).Append("\n");
            sb.Append("  Others: ").Append(Others).Append("\n");
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
            return this.Equals(input as FullCastData);
        }

        /// <summary>
        /// Returns true if FullCastData instances are equal
        /// </summary>
        /// <param name="input">Instance of FullCastData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FullCastData input)
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
                    this.Directors == input.Directors ||
                    (this.Directors != null &&
                    this.Directors.Equals(input.Directors))
                ) && 
                (
                    this.Writers == input.Writers ||
                    (this.Writers != null &&
                    this.Writers.Equals(input.Writers))
                ) && 
                (
                    this.Actors == input.Actors ||
                    this.Actors != null &&
                    input.Actors != null &&
                    this.Actors.SequenceEqual(input.Actors)
                ) && 
                (
                    this.Others == input.Others ||
                    this.Others != null &&
                    input.Others != null &&
                    this.Others.SequenceEqual(input.Others)
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
                if (this.Directors != null)
                    hashCode = hashCode * 59 + this.Directors.GetHashCode();
                if (this.Writers != null)
                    hashCode = hashCode * 59 + this.Writers.GetHashCode();
                if (this.Actors != null)
                    hashCode = hashCode * 59 + this.Actors.GetHashCode();
                if (this.Others != null)
                    hashCode = hashCode * 59 + this.Others.GetHashCode();
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
