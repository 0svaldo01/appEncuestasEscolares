using appEncuestasEscolares.Areas.Encuestador.Models.DTOs;
using appEncuestasEscolares.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace appEncuestasEscolares.Services
{
    public class EncuestasService
    {
        HttpClient cliente = new HttpClient()
        {
            BaseAddress = new Uri("https://appencuestas.labsystec.net/api/")
        };


        public async Task<IEnumerable<EncuestasDTO>> Get()
        {
            try
            {
                HttpResponseMessage response = await cliente.GetAsync("encuestas");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<EncuestasDTO>>(data);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return new List<EncuestasDTO>();
        }

        public async Task<EncuestasDTO> Create(EncuestasDTO encuesta)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(encuesta), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PostAsync("caja", content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EncuestasDTO>(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


    }
}
