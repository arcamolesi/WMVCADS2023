using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMVCADS2023.Models;

namespace WMVCADS2023.Controllers
{
    
    public class LabsController : Controller
    {
        private readonly Contexto _context;

        public LabsController(Contexto context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index() {

            ViewData["texto"] = "Listar Salas"; 

                return View(await _context.Salas.ToListAsync());  
        }


    }
}
