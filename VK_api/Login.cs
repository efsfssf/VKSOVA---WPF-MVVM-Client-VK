using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWPF.DTOs;
using TestWPF.Services;

namespace TestWPF.VK_api
{
    public class Login : IAPIService
    {
        async Task<LoginDTO> IAPIService.GetAPIService(string login, string password)
        {
            /*using(HttpClient client = new HttpClient())
            {
                string uri = $"https://oauth.vk.com/token?grant_type=password&client_id=2274003&client_secret=hHbZxrka2uZ6jB1inYsH&username={login}&password={password}&v=5.131&2fa_supported=1";

                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                LoginDTO? loginDTO = JsonConvert.DeserializeObject<LoginDTO>(jsonResponse);
                return loginDTO;
            }*/


            HttpClient Vk = new HttpClient();
            Vk.DefaultRequestHeaders.Add("Connection", "close");

            string url = string.Format("https://oauth.vk.com/token?scope=nohttps%2Call&client_id=123456&client_secret=qwertyu&2fa_supported=1&lang=ru&device_id=123456789def&grant_type=password&username={0}&password={1}&libverify_support=1",login, password);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Host = "oauth.vk.com";
            request.UserAgent = "qwert";
            request.ContentType = "application/x-www-form-urlencoded";
            request.KeepAlive = false;

            using (HttpWebResponse responsevk = (HttpWebResponse)request.GetResponse())
            using (var stream = responsevk.GetResponseStream())
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {

                Debug.WriteLine(streamReader.ReadToEnd());
                LoginDTO? loginDTO = JsonConvert.DeserializeObject<LoginDTO>(streamReader.ReadToEnd());
                return loginDTO;

            }
            
        }

    }
}
