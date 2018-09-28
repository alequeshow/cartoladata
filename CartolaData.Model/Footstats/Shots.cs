using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace CartolaData.Model.Footstats
{    

    public partial class Shots
    {
        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("teamFlag")]
        public Uri TeamFlag { get; set; }

        [JsonProperty("gamesOrMinutes")]
        public long GamesOrMinutes { get; set; }

        [JsonProperty("totals")]
        public Average Totals { get; set; }

        [JsonProperty("average")]
        public Average Average { get; set; }

        [JsonProperty("percentage")]
        public Average Percentage { get; set; }
    }

    public partial class Average
    {
        [JsonProperty("absolute")]
        public long Absolute { get; set; }

        [JsonProperty("right")]
        public double Right { get; set; }

        [JsonProperty("wrong")]
        public double Wrong { get; set; }
    }

    public enum Position { Ata, Gol, Lat, Mei, Vol, Zag };

    public partial class Shots
    {
        public static Shots[] FromJson(string json) => JsonConvert.DeserializeObject<ShotsRodada1[]>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Shots[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                PositionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PositionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Position) || t == typeof(Position?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ATA":
                    return Position.Ata;
                case "GOL":
                    return Position.Gol;
                case "LAT":
                    return Position.Lat;
                case "MEI":
                    return Position.Mei;
                case "VOL":
                    return Position.Vol;
                case "ZAG":
                    return Position.Zag;
            }
            throw new Exception("Cannot unmarshal type Position");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Position)untypedValue;
            switch (value)
            {
                case Position.Ata:
                    serializer.Serialize(writer, "ATA");
                    return;
                case Position.Gol:
                    serializer.Serialize(writer, "GOL");
                    return;
                case Position.Lat:
                    serializer.Serialize(writer, "LAT");
                    return;
                case Position.Mei:
                    serializer.Serialize(writer, "MEI");
                    return;
                case Position.Vol:
                    serializer.Serialize(writer, "VOL");
                    return;
                case Position.Zag:
                    serializer.Serialize(writer, "ZAG");
                    return;
            }
            throw new Exception("Cannot marshal type Position");
        }

        public static readonly PositionConverter Singleton = new PositionConverter();
    }
}
