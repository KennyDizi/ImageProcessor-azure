using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ImageProcessor.Common
{
    public class Image
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        [JsonProperty("id"), BsonIgnore]
        public string Id
        {
            get { return _Id.ToString(); }
            set { _Id = ObjectId.Parse(value); }
        }

        [JsonProperty("name")]
        public string FileName { get; set; }

        [JsonProperty("status")]
        public ImageStatus Status { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("adult")]
        public AdultData Adult { get; set; }

        [JsonProperty("categories")]
        public List<CategoryData> Categories { get; set; }

        [JsonProperty("color")]
        public ColorData Color { get; set; }

        [JsonProperty("type")]
        public TypeData TypeData { get; set; }

        [JsonProperty("tags")]
        public List<TagData> TagData { get; set; }

        [JsonProperty("imageUrl"), BsonIgnore]
        public string ImageUrl
        {
            get { return string.Format("https://imagestore12345.blob.core.windows.net/images/{0}", Id); }
        }

        [JsonIgnore]
        public DateTime AddedOn { get; set; }
    }

    public class AdultData
    {
        public AdultData(double adultScore, bool isAdultContent, bool isRacyContent, double racyScore)
        {
            this.AdultScore = adultScore;
            this.IsAdultContent = isAdultContent;
            this.IsRacyContent = isRacyContent;
            this.RacyScore = racyScore;
        }

        [JsonProperty("adultScore")]
        public double AdultScore { get; set; }

        [JsonProperty("isAdultContent")]
        public bool IsAdultContent { get; set; }

        [JsonProperty("isRacyContent")]
        public bool IsRacyContent { get; set; }

        [JsonProperty("racyScore")]
        public double RacyScore { get; set; }
    }

    public class CategoryData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        public CategoryData(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }

    public class ColorData
    {
        [JsonProperty("accentColor")]
        public string AccentColor { get; set; }

        [JsonProperty("dominantColorBackground")]
        public string DominantColorBackground { get; set; }

        [JsonProperty("dominantColorForeground")]
        public string DominantColorForeground { get; set; }

        [JsonProperty("isBlackAndWhite")]
        public bool IsBWImg { get; set; }

        public ColorData(string accentColor, string dominantColorBackground, string dominantColorForeground, bool isBWImg)
        {
            AccentColor = accentColor;
            DominantColorBackground = dominantColorBackground;
            DominantColorForeground = dominantColorForeground;
            IsBWImg = isBWImg;
        }
    }

    public class TypeData
    {
        [JsonProperty("clipArtType")]
        public string ClipArtType { get; set; }

        [JsonProperty("lineDrawingType")]
        public string LineDrawingType { get; set; }

        public TypeData(string clipArtType, string lineDrawingType)
        {
            ClipArtType = clipArtType;
            LineDrawingType = lineDrawingType;
        }
    }

    public class TagData
    {
        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public TagData(double confidence, string name)
        {
            Confidence = confidence;
            Name = name;
        }
    }
}
