using Domain.Dangerouses.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dangerouses.Services
{
    public class DangerousesService : IDangerousesService
    {
        private readonly string _url;
        public DangerousesService(string url)
        {
            this._url = url;
        }
        public async Task<string> GetAllNotificationsJSON()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.um.warszawa.pl/api/action/19115store_getNotifications?id=28dc65ad-fff5-447b-99a3-95b71b4a7d1e&apikey=b5b4d4ca-92fb-4cf8-8f43-18b965dc6d03");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if(responseBody.Length > 0)
                    {
                        var jsonNotifications = GetNotificationsFromResponseBody(responseBody);
                        return jsonNotifications;
                    }

                    return "Data Not Found";
                }
                catch (Exception e)
                {
                    return "Internal server error";
                }
            }
        }
        private string GetNotificationsFromResponseBody(string responseBody)
        {
            try
            {
                var firstBrace = responseBody.IndexOf('[');
                var lastBrac = responseBody.LastIndexOf(']') + 1;
                var lenghtToCopy = responseBody.Length - firstBrace - (responseBody.Length - lastBrac);
                var notifications = responseBody.Substring(responseBody.IndexOf('['), lenghtToCopy);
                return notifications;
            }
            catch(Exception e)
            {
                return "Wrong response body";
            }
            
        }
    }
}
