// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace BookFast.Web.Proxy.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class AccommodationData
    {
        /// <summary>
        /// Initializes a new instance of the AccommodationData class.
        /// </summary>
        public AccommodationData() { }

        /// <summary>
        /// Initializes a new instance of the AccommodationData class.
        /// </summary>
        public AccommodationData(string name, string description = default(string), int? roomCount = default(int?), IList<string> images = default(IList<string>))
        {
            Name = name;
            Description = description;
            RoomCount = roomCount;
            Images = images;
        }

        /// <summary>
        /// Accommodation name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Accommodation description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Number of rooms
        /// </summary>
        [JsonProperty(PropertyName = "roomCount")]
        public int? RoomCount { get; set; }

        /// <summary>
        /// Accommodation images
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public IList<string> Images { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (this.Name != null)
            {
                if (this.Name.Length > 100)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Name", 100);
                }
                if (this.Name.Length < 3)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Name", 3);
                }
            }
            if (this.Description != null)
            {
                if (this.Description.Length > 1000)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Description", 1000);
                }
                if (this.Description.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Description", 0);
                }
            }
            if (this.RoomCount > 20)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "RoomCount", 20);
            }
            if (this.RoomCount < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "RoomCount", 0);
            }
        }
    }
}