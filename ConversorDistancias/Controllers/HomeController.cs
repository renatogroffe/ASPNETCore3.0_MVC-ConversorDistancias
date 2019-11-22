using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConversorDistancias.Models;

namespace ConversorDistancias.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DistanciasViewModel distancias)
        {
            if (ModelState.IsValid)
            {
                distancias.DistanciaKm = Convert.ToDouble(distancias.DistanciaMilhas) * 1.609;
                return View(distancias);
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError(nameof(distancias.DistanciaMilhas),
                    "Informe uma distância em milhas entre 0,01 e 9.999.999,99!");
                return View("Index", distancias);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}