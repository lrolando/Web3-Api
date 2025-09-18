using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.DTOs
{
    public class CoinMarketCapCategoriesDTO
    {
        [JsonProperty("status")]
        public Status? Status { get; set; }

        [JsonProperty("data")]
        public List<Datos>? Data { get; set; }
    }
}
