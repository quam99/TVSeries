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
    /// YouTubeData
    /// </summary>
    [DataContract]
        public partial class YouTubeData :  IEquatable<YouTubeData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeData" /> class.
        /// </summary>
        /// <param name="videoId">videoId (required).</param>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="duration">duration.</param>
        /// <param name="uploadDate">uploadDate.</param>
        /// <param name="image">image.</param>
        /// <param name="videos">videos.</param>
        /// <param name="errorMessage">errorMessage.</param>
        public YouTubeData(string videoId = default(string), string title = default(string), string description = default(string), string duration = default(string), string uploadDate = default(string), string image = default(string), List<YouTubeDataItem> videos = default(List<YouTubeDataItem>), string errorMessage = default(string))
        {
            // to ensure "videoId" is required (not null)
            if (videoId == null)
            {
                throw new InvalidDataException("videoId is a required property for YouTubeData and cannot be null");
            }
            else
            {
                this.VideoId = videoId;
            }
            this.Title = title;
            this.Description = description;
            this.Duration = duration;
            this.UploadDate = uploadDate;
            this.Image = image;
            this.Videos = videos;
            this.ErrorMessage = errorMessage;
        }
        
        /// <summary>
        /// Gets or Sets VideoId
        /// </summary>
        [DataMember(Name="videoId", EmitDefaultValue=false)]
        public string VideoId { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Duration
        /// </summary>
        [DataMember(Name="duration", EmitDefaultValue=false)]
        public string Duration { get; set; }

        /// <summary>
        /// Gets or Sets UploadDate
        /// </summary>
        [DataMember(Name="uploadDate", EmitDefaultValue=false)]
        public string UploadDate { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name="image", EmitDefaultValue=false)]
        public string Image { get; set; }

        /// <summary>
        /// Gets or Sets Videos
        /// </summary>
        [DataMember(Name="videos", EmitDefaultValue=false)]
        public List<YouTubeDataItem> Videos { get; set; }

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
            sb.Append("class YouTubeData {\n");
            sb.Append("  VideoId: ").Append(VideoId).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  UploadDate: ").Append(UploadDate).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  Videos: ").Append(Videos).Append("\n");
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
            return this.Equals(input as YouTubeData);
        }

        /// <summary>
        /// Returns true if YouTubeData instances are equal
        /// </summary>
        /// <param name="input">Instance of YouTubeData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(YouTubeData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.VideoId == input.VideoId ||
                    (this.VideoId != null &&
                    this.VideoId.Equals(input.VideoId))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Duration == input.Duration ||
                    (this.Duration != null &&
                    this.Duration.Equals(input.Duration))
                ) && 
                (
                    this.UploadDate == input.UploadDate ||
                    (this.UploadDate != null &&
                    this.UploadDate.Equals(input.UploadDate))
                ) && 
                (
                    this.Image == input.Image ||
                    (this.Image != null &&
                    this.Image.Equals(input.Image))
                ) && 
                (
                    this.Videos == input.Videos ||
                    this.Videos != null &&
                    input.Videos != null &&
                    this.Videos.SequenceEqual(input.Videos)
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
                if (this.VideoId != null)
                    hashCode = hashCode * 59 + this.VideoId.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Duration != null)
                    hashCode = hashCode * 59 + this.Duration.GetHashCode();
                if (this.UploadDate != null)
                    hashCode = hashCode * 59 + this.UploadDate.GetHashCode();
                if (this.Image != null)
                    hashCode = hashCode * 59 + this.Image.GetHashCode();
                if (this.Videos != null)
                    hashCode = hashCode * 59 + this.Videos.GetHashCode();
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
