using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinMarketCapController : ControllerBase
    {

        private string? ApiKey { get; }
        private static readonly HttpClient client = new HttpClient();

        public CoinMarketCapController(IConfiguration configuration)
        {
            ApiKey = configuration.GetSection("CoinMarketCap:APIKey").Get<string>();
        }

        [HttpGet("GetCoins")]
        public async Task<ActionResult> GetCoins()
        {
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            URL.Port = -1;
            var queryString = HttpUtility.ParseQueryString(URL.Query);
            queryString["limit"] = "5000";
            URL.Query = queryString.ToString();

            var response = await client.GetAsync(URL.ToString());

            if (!response.IsSuccessStatusCode)
            {
                return NotFound("Response failed with status code: " + response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
            {
                return NotFound("No response content found");
            }

            var coinMarketCapDTO = JsonConvert.DeserializeObject<CoinMarketCapLatestCoinsDTO>(content);


            var arg = coinMarketCapDTO?.Data?.Where(x => x.Id == "2821").OrderBy(x => int.Parse(x.CmcRank!)).ToList();

            return Ok(coinMarketCapDTO);
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult> GetCategories()
        {
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/categories");
            URL.Port = -1;
            var queryString = HttpUtility.ParseQueryString(URL.Query);
            queryString["limit"] = "5000";
            URL.Query = queryString.ToString();

            var response = await client.GetAsync(URL.ToString());

            if (!response.IsSuccessStatusCode)
            {
                return NotFound("Response failed with status code: " + response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
            {
                return NotFound("No response content found");
            }

            var coinMarketCapDTO = JsonConvert.DeserializeObject<CoinMarketCapCategoriesDTO>(content);

            return Ok(coinMarketCapDTO);
        }

        [HttpGet("GetArgPesosPerUSDT")]
        public async Task<ActionResult> GetArgPesosPerUSDT()
        {
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", ApiKey);
            client.DefaultRequestHeaders.Add("Accepts", "application/json");

            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest");
            URL.Port = -1;
            var queryString = HttpUtility.ParseQueryString(URL.Query);
            queryString["symbol"] = "USDT";
            queryString["convert"] = "ARS";
            URL.Query = queryString.ToString();

            var response = await client.GetAsync(URL.ToString());

            if (!response.IsSuccessStatusCode)
            {
                return NotFound("Response failed with status code: " + response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
            {
                return NotFound("No response content found");
            }

            var ArgCurrencyCapDTO = JsonConvert.DeserializeObject<ArgCurrencyPriceDTO>(content);

            return Ok(ArgCurrencyCapDTO.Data.Usdt.Quote.Ars.Price);
        }
    }
}
