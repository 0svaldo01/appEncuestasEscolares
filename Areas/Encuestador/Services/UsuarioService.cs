using appEncuestasEscolares.Areas.Encuestador.Models.DTOs;
using Newtonsoft.Json;

namespace appEncuestasEscolares.Areas.Encuestador.Services
{
    public class UsuarioService
    {
        HttpClient cliente = new HttpClient()
        {
            BaseAddress = new Uri("https://appencuestas.labsystec.net/api/")
        };

        public async Task<IEnumerable<UsuarioDTO>> Get()
        {
            try
            {
                HttpResponseMessage response = await cliente.GetAsync("Usuarios");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(data);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return new List<UsuarioDTO>();
        }
    }
}
