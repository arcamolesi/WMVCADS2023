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

      
        public IActionResult Create (){
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,monitor,equipamentos,situacao")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }

    }
}
