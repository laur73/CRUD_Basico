using CRUDCore.Models;
using CRUDCore.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCore.Controllers
{
    public class ContactosController : Controller
    {
        RepositorioContactos repositorioContactos = new RepositorioContactos();

        //Mostrar todos los contactos
        public IActionResult Listar()
        {
            var lista = repositorioContactos.Listar();

            //Le pasamos a la vista la lista
            return View(lista);
        }

        //Metodo para mostrar la vista del formulario
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        //Metodo para recibir la info del formulario a la BD
        [HttpPost]
        public IActionResult Crear(ContactoViewModel contacto)
        {
            //Validamos el modelo
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = repositorioContactos.Guardar(contacto);

            //Si todo esta OK lo regresamos a la vista de Listar
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }

        //Metodo para mostrar la vista del formulario
        [HttpGet]
        public IActionResult Editar(int IdContacto)
        {
            var contacto = repositorioContactos.ObtenerId(IdContacto);

            return View(contacto);
        }


        //Metodo para pasar los datos a la BD update
        [HttpPost]
        public IActionResult Editar(ContactoViewModel contacto)
        {
            //Validamos el modelo
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = repositorioContactos.Editar(contacto);

            //Si todo esta OK lo regresamos a la vista de Listar
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        //Metodo para mostrar la vista del formulario
        [HttpGet]
        public IActionResult Eliminar(int IdContacto)
        {
            var contacto = repositorioContactos.ObtenerId(IdContacto);

            return View(contacto);
        }


        //Metodo para pasar los datos a la BD delete
        [HttpPost]
        public IActionResult Eliminar(ContactoViewModel contacto)
        {

            var respuesta = repositorioContactos.Eliminar(contacto.IdContacto);

            //Si todo esta OK lo regresamos a la vista de Listar
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
