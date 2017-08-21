using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyApi.ConsoleClient
{
    public class Parser
    {
        private HttpClient _client;

        public Parser()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetAvailableCurrencies()
        {
            var response = await _client.GetAsync(Constants.ConstantUrls.AvailableCurrenciesUrl);
            var result = await response.Content.ReadAsStringAsync();

            if (result != null)
                return result;
            return "false";
            // return new string(new char[] { 'F', 'a', 'l', 's', 'e' });
        }

        public async Task<string> GetAvaliable()
        {

            return null;
        }
    }
}
