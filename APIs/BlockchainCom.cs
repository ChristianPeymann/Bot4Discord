// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var coinInfo = CoinInfo.FromJson(jsonString);

namespace DiscordBot.APIs
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CoinInfo
    {
        [JsonProperty("base_currency", NullValueHandling = NullValueHandling.Ignore)]
        public string BaseCurrency { get; set; }

        [JsonProperty("base_currency_scale", NullValueHandling = NullValueHandling.Ignore)]
        public long? BaseCurrencyScale { get; set; }

        [JsonProperty("counter_currency", NullValueHandling = NullValueHandling.Ignore)]
        public CounterCurrency? CounterCurrency { get; set; }

        [JsonProperty("counter_currency_scale", NullValueHandling = NullValueHandling.Ignore)]
        public long? CounterCurrencyScale { get; set; }

        [JsonProperty("min_price_increment", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinPriceIncrement { get; set; }

        [JsonProperty("min_price_increment_scale", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinPriceIncrementScale { get; set; }

        [JsonProperty("min_order_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinOrderSize { get; set; }

        [JsonProperty("min_order_size_scale", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinOrderSizeScale { get; set; }

        [JsonProperty("max_order_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxOrderSize { get; set; }

        [JsonProperty("max_order_size_scale", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxOrderSizeScale { get; set; }

        [JsonProperty("lot_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? LotSize { get; set; }

        [JsonProperty("lot_size_scale", NullValueHandling = NullValueHandling.Ignore)]
        public long? LotSizeScale { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Status? Status { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("auction_price", NullValueHandling = NullValueHandling.Ignore)]
        public long? AuctionPrice { get; set; }

        [JsonProperty("auction_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? AuctionSize { get; set; }

        [JsonProperty("auction_time", NullValueHandling = NullValueHandling.Ignore)]
        public string AuctionTime { get; set; }

        [JsonProperty("imbalance", NullValueHandling = NullValueHandling.Ignore)]
        public long? Imbalance { get; set; }
    }

    public enum CounterCurrency { Btc, Dgld, Eth, Eur, Gbp, Pax, Try, Usd, Usdc, Usdt };

    public enum Status { Close, Open };

    public partial class CoinInfo
    {
        public static Dictionary<string, CoinInfo> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, CoinInfo>>(json, DiscordBot.APIs.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Dictionary<string, CoinInfo> self) => JsonConvert.SerializeObject(self, DiscordBot.APIs.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CounterCurrencyConverter.Singleton,
                StatusConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CounterCurrencyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CounterCurrency) || t == typeof(CounterCurrency?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BTC":
                    return CounterCurrency.Btc;
                case "DGLD":
                    return CounterCurrency.Dgld;
                case "ETH":
                    return CounterCurrency.Eth;
                case "EUR":
                    return CounterCurrency.Eur;
                case "GBP":
                    return CounterCurrency.Gbp;
                case "PAX":
                    return CounterCurrency.Pax;
                case "TRY":
                    return CounterCurrency.Try;
                case "USD":
                    return CounterCurrency.Usd;
                case "USDC":
                    return CounterCurrency.Usdc;
                case "USDT":
                    return CounterCurrency.Usdt;
                

            }
            throw new Exception("Cannot unmarshal type CounterCurrency");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CounterCurrency)untypedValue;
            switch (value)
            {
                case CounterCurrency.Btc:
                    serializer.Serialize(writer, "BTC");
                    return;
                case CounterCurrency.Dgld:
                    serializer.Serialize(writer, "DGLD");
                    return;
                case CounterCurrency.Eth:
                    serializer.Serialize(writer, "ETH");
                    return;
                case CounterCurrency.Eur:
                    serializer.Serialize(writer, "EUR");
                    return;
                case CounterCurrency.Gbp:
                    serializer.Serialize(writer, "GBP");
                    return;
                case CounterCurrency.Pax:
                    serializer.Serialize(writer, "PAX");
                    return;
                case CounterCurrency.Try:
                    serializer.Serialize(writer, "TRY");
                    return;
                case CounterCurrency.Usd:
                    serializer.Serialize(writer, "USD");
                    return;
                case CounterCurrency.Usdc:
                    serializer.Serialize(writer, "USDC");
                    return;
                case CounterCurrency.Usdt:
                    serializer.Serialize(writer, "USDT");
                    return;
            }
            throw new Exception("Cannot marshal type CounterCurrency");
        }

        public static readonly CounterCurrencyConverter Singleton = new CounterCurrencyConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "close":
                    return Status.Close;
                case "open":
                    return Status.Open;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Close:
                    serializer.Serialize(writer, "close");
                    return;
                case Status.Open:
                    serializer.Serialize(writer, "open");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }
}
