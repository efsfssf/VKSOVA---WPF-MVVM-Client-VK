using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWPF.DTOs;
using TestWPF.Services;

namespace TestWPF.VK_api
{
    public class Login : IAPIService
    {
        async Task<DataDTO> IAPIService.GetAPIService(string login, string password)
        {
            using(HttpClient client = new HttpClient())
            {
                string uri = $"https://oauth.vk.com/token?grant_type=password&client_id=2274003&client_secret=hHbZxrka2uZ6jB1inYsH&username={login}&password={password}&v=5.131&2fa_supported=1";

                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                DataDTO? loginDTO = JsonConvert.DeserializeObject<DataDTO>(jsonResponse);
                return loginDTO;
            }
        }

    }
}
