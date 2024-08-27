using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class BitcoinPriceService
{
    private readonly HttpClient _httpClient;

    public BitcoinPriceService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetBitcoinPriceAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<BitcoinPriceClass>("https://mempool.space/api/v1/prices");
        return response?.USD ?? 0;
    }
}

public class BitcoinPriceClass
{
    public decimal USD { get; set; }
}
