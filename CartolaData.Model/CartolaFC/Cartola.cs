// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using CartolaData.Model.CartolaFC;
//
//    var cartola = Cartola.FromJson(jsonString);

namespace CartolaData.Model.CartolaFC
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Cartola
    {
        [JsonProperty("atletas")]
        public List<Atleta> Atletas { get; set; }

        [JsonProperty("clubes")]
        public Dictionary<string, Clube> Clubes { get; set; }

        [JsonProperty("posicoes")]
        public Dictionary<string, Posicoe> Posicoes { get; set; }

        [JsonProperty("status")]
        public Dictionary<string, Status> Status { get; set; }
    }

    public partial class Atleta
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("apelido")]
        public string Apelido { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

        [JsonProperty("atleta_id")]
        public long AtletaId { get; set; }

        [JsonProperty("rodada_id")]
        public long RodadaId { get; set; }

        [JsonProperty("clube_id")]
        public long ClubeId { get; set; }

        [JsonProperty("posicao_id")]
        public long PosicaoId { get; set; }

        [JsonProperty("status_id")]
        public long StatusId { get; set; }

        [JsonProperty("pontos_num")]
        public double PontosNum { get; set; }

        [JsonProperty("preco_num")]
        public double PrecoNum { get; set; }

        [JsonProperty("variacao_num")]
        public double VariacaoNum { get; set; }

        [JsonProperty("media_num")]
        public double MediaNum { get; set; }

        [JsonProperty("jogos_num")]
        public long JogosNum { get; set; }

        [JsonProperty("scout")]
        public Scout Scout { get; set; }
    }

    public partial class Scout
    {
        [JsonProperty("CA", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ca { get; set; }

        [JsonProperty("FC", NullValueHandling = NullValueHandling.Ignore)]
        public long? Fc { get; set; }

        [JsonProperty("FD", NullValueHandling = NullValueHandling.Ignore)]
        public long? Fd { get; set; }

        [JsonProperty("FF", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ff { get; set; }

        [JsonProperty("FS", NullValueHandling = NullValueHandling.Ignore)]
        public long? Fs { get; set; }

        [JsonProperty("G", NullValueHandling = NullValueHandling.Ignore)]
        public long? G { get; set; }

        [JsonProperty("PE", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pe { get; set; }

        [JsonProperty("RB", NullValueHandling = NullValueHandling.Ignore)]
        public long? Rb { get; set; }

        [JsonProperty("DD", NullValueHandling = NullValueHandling.Ignore)]
        public long? Dd { get; set; }

        [JsonProperty("GS", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gs { get; set; }

        [JsonProperty("SG", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sg { get; set; }

        [JsonProperty("A", NullValueHandling = NullValueHandling.Ignore)]
        public long? A { get; set; }

        [JsonProperty("I", NullValueHandling = NullValueHandling.Ignore)]
        public long? I { get; set; }

        [JsonProperty("FT", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ft { get; set; }

        [JsonProperty("GC", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gc { get; set; }

        [JsonProperty("PP", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pp { get; set; }

        [JsonProperty("CV", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cv { get; set; }

        [JsonProperty("DP", NullValueHandling = NullValueHandling.Ignore)]
        public long? Dp { get; set; }
    }

    public partial class Clube
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("abreviacao")]
        public string Abreviacao { get; set; }

        [JsonProperty("posicao")]
        public long Posicao { get; set; }

        [JsonProperty("escudos")]
        public Dictionary<string, string> Escudos { get; set; }
    }

    public partial class Posicoe
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("abreviacao")]
        public string Abreviacao { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }
    }

    public partial class Cartola
    {
        public static Cartola FromJson(string json) => JsonConvert.DeserializeObject<Cartola>(json, CartolaData.Model.CartolaFC.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Cartola self) => JsonConvert.SerializeObject(self, CartolaData.Model.CartolaFC.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
