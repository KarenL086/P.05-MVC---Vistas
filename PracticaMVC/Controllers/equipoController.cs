using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class equipoController : Controller
    {
        private readonly equiposDbContext _equiposDbContext;

        public equipoController(equiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }   
        public IActionResult CrearEquipos(equiposDbContext nuevoEquipo)
        {
            _equiposDbContext.Add(nuevoEquipo);
            _equiposDbContext.SaveChanges();
            return RedirectToAction("Index");   
        }

        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDbContext.marcas
                                  select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listaDeTipo = (from t in _equiposDbContext.tipo_equipo
                                  select t).ToList();
            ViewData["listadoDeTipo"] = new SelectList(listaDeTipo, "id_tipo_equipo", "descripcion", "estado");

            var listadoEquipos = (from e in _equiposDbContext.equipos
                                    join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                    select new
                                    {
                                        nombre=e.nombre,
                                        descripcion=e.descripcion,
                                        marca_id=e.marca_id,
                                        marcas_nombre = m.nombre_marca
                                    }).ToList();

            return View();
        }
    }
}
