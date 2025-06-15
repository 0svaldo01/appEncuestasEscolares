using appEncuestasEscolares.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace appEncuestasEscolares.Services
{
    public class AuthServices
    {
        HttpClient cliente = new HttpClient();

        static string accesoapi = "https://appencuestas.labsystec.net/api/";

        public AuthServices()
        {
            cliente.BaseAddress = new Uri(accesoapi);
        }

        public async Task<UsuarioDTO> Login(string email, string password)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(new { email, password }),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response = await cliente.PostAsync("auth/login", content);


                if (response.IsSuccessStatusCode)
                {


                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UsuarioDTO>(data);
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
