using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using transporte.Service.Models;

namespace transporte.Service.Services
{
    public class TransporteService
    {
        HttpClient client;
        
        public TransporteService()
        {
            client = new HttpClient();
        }

        public async  Task<List<Line>> TransporteAhora() {

            List<Line> data = new List<Line>();

            if(DateTime.Now.Hour < 10){
                //volver de bankia
                string urlIda1 = "https://api.interurbanos.welbits.com/v1/stop/140"; //autobus en arturio soria
                var result = await client.GetAsync(urlIda1);
                if(result.IsSuccessStatusCode){
                    string content1 = await result.Content.ReadAsStringAsync();
                    var response1 = JsonConvert.DeserializeObject<TransporteResponse>(content1);
                    foreach (var item in response1.lines)
                    {
                        data.Add(item);
                    }
                }

                string urlIda2 = "https://api.interurbanos.welbits.com/v1/stop/5-64"; //autobus en arturio soria
                var result2 = await client.GetAsync(urlIda2);
                if (result2.IsSuccessStatusCode)
                {
                    string content2 = await result2.Content.ReadAsStringAsync();
                    var response2 = JsonConvert.DeserializeObject<TransporteResponse>(content2);
                    foreach (var item in response2.lines)
                    {
                        data.Add(item);
                    }

                }


            }
            else
            {
                string urlIda1 = "https://api.interurbanos.welbits.com/v1/stop/5-55"; //autobus en arturio soria
                var result = await client.GetAsync(urlIda1);
                if (result.IsSuccessStatusCode)
                {
                    string content1 = await result.Content.ReadAsStringAsync();
                    var response1 = JsonConvert.DeserializeObject<TransporteResponse>(content1);
                    foreach (var item in response1.lines)
                    {
                        data.Add(item);
                    }
                }

                string urlIda2 = "https://api.interurbanos.welbits.com/v1/stop/955"; //autobus en arturio soria
                var result2 = await client.GetAsync(urlIda2);
                if (result2.IsSuccessStatusCode)
                {
                    string content2 = await result2.Content.ReadAsStringAsync();
                    var response2 = JsonConvert.DeserializeObject<TransporteResponse>(content2);
                    foreach (var item in response2.lines)
                    {
                        data.Add(item);
                    }

                }
            }

        

            return data;

        }


    }
}
