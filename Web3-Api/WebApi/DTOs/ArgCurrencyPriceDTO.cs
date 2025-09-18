using System.Text.Json.Serialization;

namespace WebApi.DTOs
{
    public class ArsQuote
    {
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("volume_24h")]
        public double Volume24h { get; set; }

        [JsonPropertyName("volume_change_24h")]
        public double VolumeChange24h { get; set; }

        [JsonPropertyName("percent_change_1h")]
        public double PercentChange1h { get; set; }

        [JsonPropertyName("percent_change_24h")]
        public double PercentChange24h { get; set; }

        [JsonPropertyName("percent_change_7d")]
        public double PercentChange7d { get; set; }

        [JsonPropertyName("percent_change_30d")]
        public double PercentChange30d { get; set; }

        [JsonPropertyName("percent_change_60d")]
        public double PercentChange60d { get; set; }

        [JsonPropertyName("percent_change_90d")]
        public double PercentChange90d { get; set; }

        [JsonPropertyName("market_cap")]
        public double MarketCap { get; set; }

        [JsonPropertyName("market_cap_dominance")]
        public double MarketCapDominance { get; set; }

        [JsonPropertyName("fully_diluted_market_cap")]
        public double FullyDilutedMarketCap { get; set; }

        [JsonPropertyName("tvl")]
        public object? Tvl { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
    }

    public class CryptocurrencyData
    {
        [JsonPropertyName("USDT")]
        public UsdtCryptocurrency? Usdt { get; set; }
    }

    public class Platform
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = string.Empty;

        [JsonPropertyName("token_address")]
        public string TokenAddress { get; set; } = string.Empty;
    }

    public class Quote
    {
        [JsonPropertyName("ARS")]
        public ArsQuote? Ars { get; set; }
    }

    public class ArgCurrencyPriceDTO
    {
        [JsonPropertyName("data")]
        public CryptocurrencyData? Data { get; set; }
    }

    public class UsdtCryptocurrency
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = string.Empty;

        [JsonPropertyName("num_market_pairs")]
        public int NumMarketPairs { get; set; }

        [JsonPropertyName("date_added")]
        public DateTime DateAdded { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonPropertyName("max_supply")]
        public object? MaxSupply { get; set; }

        [JsonPropertyName("circulating_supply")]
        public double CirculatingSupply { get; set; }

        [JsonPropertyName("total_supply")]
        public double TotalSupply { get; set; }

        [JsonPropertyName("platform")]
        public Platform? Platform { get; set; }

        [JsonPropertyName("is_active")]
        public int IsActive { get; set; }

        [JsonPropertyName("infinite_supply")]
        public bool InfiniteSupply { get; set; }

        [JsonPropertyName("cmc_rank")]
        public int CmcRank { get; set; }

        [JsonPropertyName("is_fiat")]
        public int IsFiat { get; set; }

        [JsonPropertyName("self_reported_circulating_supply")]
        public object? SelfReportedCirculatingSupply { get; set; }

        [JsonPropertyName("self_reported_market_cap")]
        public object? SelfReportedMarketCap { get; set; }

        [JsonPropertyName("tvl_ratio")]
        public object? TvlRatio { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("quote")]
        public Quote? Quote { get; set; }
    }
}
