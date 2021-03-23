using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GAMP
{
    public class TransactionHelper
    {
        private const string Endpoint = "https://api.blockcypher.com/v1/btc/main";

        public static async Task<string> GetLastTransactionHashAsync()
        {
            using var client = new HttpClient();
            
            var result = await client.GetAsync(Endpoint);

            string resultJson = await result.Content.ReadAsStringAsync();

            dynamic blockchainObj = JsonConvert.DeserializeObject(resultJson);

            string lastTransactionId = blockchainObj.last_fork_hash;

            return lastTransactionId;
        }
    }
}
