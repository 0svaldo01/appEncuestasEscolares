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
                HttpResponseMessage response = await cliente.PostAsync("encuestas", content);
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
        public async Task<EncuestasDTO?> GetById(int id)
        {
            try
            {
                var response = await cliente.GetAsync($"encuestas/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EncuestasDTO>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById: {ex.Message}");
            }
            return null;
        }

       

        public async Task<bool> Update(int id, EncuestasDTO encuesta)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(encuesta), Encoding.UTF8, "application/json");
                var response = await cliente.PutAsync($"encuestas/{id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Update: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = await cliente.DeleteAsync($"encuestas/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete: {ex.Message}");
                return false;
            }
        }
    }



}

