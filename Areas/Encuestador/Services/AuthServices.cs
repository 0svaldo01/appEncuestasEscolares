using appEncuestasEscolares.Areas.Encuestador.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace appEncuestasEscolares.Areas.Encuestador.Services
{
    public class AuthServices
    {
        HttpClient cliente = new HttpClient();

        static string accesoapi = "https://appencuestas.labsystec.net/api/auth/login";

        public AuthServices()
        {
            cliente.BaseAddress = new Uri(accesoapi);
        }

        public async Task<UsuarioDTO> Login(string correoElectronico, string contrasena)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(new { correoElectronico, contrasena }), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PostAsync("auth", content);
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
