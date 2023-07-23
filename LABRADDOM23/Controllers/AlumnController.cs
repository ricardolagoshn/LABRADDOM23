using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;

namespace LABRADDOM23.Controllers
{
    public class AlumnController
    {
        public async static Task<Models.Message> CreateAlumn(Models.Alumnos alumn)
        {
            Models.Message msg = new Models.Message();
            String jsonObject = JsonConvert.SerializeObject(alumn);
 
            StringContent contenido = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            using(HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage respuesta = null;
                respuesta = await client.PostAsync("http://192.168.0.8/labrad/AlumnCreate.php", contenido);

                if (respuesta.IsSuccessStatusCode) 
                {
                    var result = respuesta.Content.ReadAsStringAsync();
                    msg = JsonConvert.DeserializeObject<Models.Message>(await result);
                }
            }

            return msg;
        }
    }
}
