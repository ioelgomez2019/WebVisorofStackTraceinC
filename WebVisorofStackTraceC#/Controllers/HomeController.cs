using Microsoft.AspNetCore.Mvc;
using WebVisorofStackTraceC_.Models;
using WebVisorofStackTraceC_.Services; // Asegúrate de que este espacio de nombres y el ensamblado estén referenciados correctamente
using WebVisorofStackTraceC_.Models;
using WebVisorofStackTraceC_.Services; // Asegúrate de que este espacio de nombres y el ensamblado estén referenciados correctamente


using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebVisorofStackTraceC_.Models;
using WebVisorofStackTraceC_.Services;

namespace WebVisorofStackTraceC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISolicitudService _solicitudService;

        // Un único constructor que recibe todas las dependencias
        public HomeController(
            ILogger<HomeController> logger,
            ISolicitudService solicitudService)
        {
            _logger = logger;
            _solicitudService = solicitudService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Stacktrace() => View();

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [HttpGet]  // ? Cambiado de HttpPost a HttpGet

        public async Task<IActionResult> ObtenerStacktrace(int nIDLogErr)
        {
            try
            {
                // Tu lógica para obtener el stacktrace
                var stacktrace = await _solicitudService.ObtenerStacktracePorIdStacktraceAsync(nIDLogErr);

                ViewBag.stacktrace = stacktrace; // Pasa el DataTable a la vista
                var joel = stacktrace.Rows[0]["cTipErrGen"];
                return PartialView("_Stacktrace");
                //return PartialView("_Stacktrace", stacktrace); // Devuelve una vista parcial con el stacktrace
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en ObtenerStacktrace");
                return StatusCode(500, new { error = ex.Message }); // Devuelve un error 500 en caso de excepción
            }


        }



    }
}
