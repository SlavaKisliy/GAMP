using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GAMP
{
    public class TransactionHelper
    {
        private const string Endpoint = "https://api.blockcypher.com/v1/btc/main";

        public static async Task<decimal> GetUnconfirmedTransCountAsync()
        {
            using var client = new HttpClient();
            
            var result = await client.GetAsync(Endpoint);

            string resultJson = await result.Content.ReadAsStringAsync();

            dynamic blockchainObj = JsonConvert.DeserializeObject(resultJson);

            string countStr = blockchainObj.unconfirmed_count;

            return decimal.Parse(countStr);
        }
    }
}
