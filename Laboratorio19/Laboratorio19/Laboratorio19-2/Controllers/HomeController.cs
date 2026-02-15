using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Laboratorio192.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public async Task<ActionResult> Index()
        {
            string resultado = await GetAllValues();
            ViewBag.Resultado = resultado;
            return View();
        }

        // Método que consume el API
        private async Task<string> GetAllValues()
        {
            using (HttpClient client = new HttpClient())
            {
                // ⚠️ IMPORTANTE: Cambia el puerto según tu API
                string url = "https://localhost:44328/";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
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