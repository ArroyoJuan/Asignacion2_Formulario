using Asignacion2_Formulario.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asignacion2_Formulario.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AccesoDatos _acceso;

        public HomeController(AccesoDatos acceso)
        {
            _acceso = acceso;
        }
        [HttpPost]
        public IActionResult Submit(Productos modelo,string opcion)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", modelo);
            }
            try
            {
                switch (opcion)
                {
                    case "guardar":
                        _acceso.AgregarUsuario(modelo);
                        //Si al agregar el usuario es exitoso
                        TempData["SuccessMessage"] = "Tu producto se guardó con éxito.";
                        return RedirectToAction("Index");
                        break;
                    case "editar":
                        return RedirectToAction("Index");
                        break;
                    case "eliminar":
                        return RedirectToAction("Index");
                        break;
                    case "consultar":
                        return RedirectToAction("Index");
                        break;
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Tu producto se guardó";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
