using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestTest
{
	public class RestClient
	{
		public async Task<string> Get(string url)
		{
			var client = new HttpClient();
			var result = await client.GetStringAsync(url);
			return result;
		}
	}
}
