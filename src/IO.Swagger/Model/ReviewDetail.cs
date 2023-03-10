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
    /// ReviewDetail
    /// </summary>
    [DataContract]
        public partial class ReviewDetail :  IEquatable<ReviewDetail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewDetail" /> class.
        /// </summary>
        /// <param name="username">username.</param>
        /// <param name="userUrl">userUrl.</param>
        /// <param name="reviewLink">reviewLink.</param>
        /// <param name="warningSpoilers">warningSpoilers.</param>
        /// <param name="date">date.</param>
        /// <param name="rate">rate.</param>
        /// <param name="helpful">helpful.</param>
        /// <param name="title">title.</param>
        /// <param name="content">content.</param>
        public ReviewDetail(string username = default(string), string userUrl = default(string), string reviewLink = default(string), bool? warningSpoilers = default(bool?), string date = default(string), string rate = default(string), string helpful = default(string), string title = default(string), string content = default(string))
        {
            this.Username = username;
            this.UserUrl = userUrl;
            this.ReviewLink = reviewLink;
            this.WarningSpoilers = warningSpoilers;
            this.Date = date;
            this.Rate = rate;
            this.Helpful = helpful;
            this.Title = title;
            this.Content = content;
        }
        
        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets UserUrl
        /// </summary>
        [DataMember(Name="userUrl", EmitDefaultValue=false)]
        public string UserUrl { get; set; }

        /// <summary>
        /// Gets or Sets ReviewLink
        /// </summary>
        [DataMember(Name="reviewLink", EmitDefaultValue=false)]
        public string ReviewLink { get; set; }

        /// <summary>
        /// Gets or Sets WarningSpoilers
        /// </summary>
        [DataMember(Name="warningSpoilers", EmitDefaultValue=false)]
        public bool? WarningSpoilers { get; set; }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name="date", EmitDefaultValue=false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets Rate
        /// </summary>
        [DataMember(Name="rate", EmitDefaultValue=false)]
        public string Rate { get; set; }

        /// <summary>
        /// Gets or Sets Helpful
        /// </summary>
        [DataMember(Name="helpful", EmitDefaultValue=false)]
        public string Helpful { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [DataMember(Name="content", EmitDefaultValue=false)]
        public string Content { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReviewDetail {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  UserUrl: ").Append(UserUrl).Append("\n");
            sb.Append("  ReviewLink: ").Append(ReviewLink).Append("\n");
            sb.Append("  WarningSpoilers: ").Append(WarningSpoilers).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Rate: ").Append(Rate).Append("\n");
            sb.Append("  Helpful: ").Append(Helpful).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
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
            return this.Equals(input as ReviewDetail);
        }

        /// <summary>
        /// Returns true if ReviewDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of ReviewDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReviewDetail input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
                ) && 
                (
                    this.UserUrl == input.UserUrl ||
                    (this.UserUrl != null &&
                    this.UserUrl.Equals(input.UserUrl))
                ) && 
                (
                    this.ReviewLink == input.ReviewLink ||
                    (this.ReviewLink != null &&
                    this.ReviewLink.Equals(input.ReviewLink))
                ) && 
                (
                    this.WarningSpoilers == input.WarningSpoilers ||
                    (this.WarningSpoilers != null &&
                    this.WarningSpoilers.Equals(input.WarningSpoilers))
                ) && 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.Rate == input.Rate ||
                    (this.Rate != null &&
                    this.Rate.Equals(input.Rate))
                ) && 
                (
                    this.Helpful == input.Helpful ||
                    (this.Helpful != null &&
                    this.Helpful.Equals(input.Helpful))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Content == input.Content ||
                    (this.Content != null &&
                    this.Content.Equals(input.Content))
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
                if (this.Username != null)
                    hashCode = hashCode * 59 + this.Username.GetHashCode();
                if (this.UserUrl != null)
                    hashCode = hashCode * 59 + this.UserUrl.GetHashCode();
                if (this.ReviewLink != null)
                    hashCode = hashCode * 59 + this.ReviewLink.GetHashCode();
                if (this.WarningSpoilers != null)
                    hashCode = hashCode * 59 + this.WarningSpoilers.GetHashCode();
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.Rate != null)
                    hashCode = hashCode * 59 + this.Rate.GetHashCode();
                if (this.Helpful != null)
                    hashCode = hashCode * 59 + this.Helpful.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Content != null)
                    hashCode = hashCode * 59 + this.Content.GetHashCode();
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
