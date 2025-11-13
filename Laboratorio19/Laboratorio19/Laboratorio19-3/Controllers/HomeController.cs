using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Laboratorio19_3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public async Task<ActionResult> Index(int id = 2)
        {
            string resultado = await GetValueById(id);
            ViewBag.Resultado = resultado;
            ViewBag.Id = id;
            return View();
        }

        // Método que consume el API para obtener un valor por ID
        private async Task<string> GetValueById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                // ⚠️ IMPORTANTE: Cambia el puerto según tu API
                string url = $"https://localhost:44328/{id}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result; // Para id=2 retorna: "value2"
                    }

                    return $"Error: {response.StatusCode}";
                }
                catch (Exception ex)
                {
                    return $"Error de conexión: {ex.Message}";
                }
            }
        }
    }
}