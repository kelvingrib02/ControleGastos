using ControleGastos.ControleGastos.Infra.Data;
using ControleGastos.ControleGastos.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.WebApps.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
