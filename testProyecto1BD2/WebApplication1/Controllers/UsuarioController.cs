using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private Neo4jDB neo = new Neo4jDB();
        private Usuario actual = new Usuario();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(neo.getUsuarios());
        }

        // GET: Usuario/Details/5
        /*public ActionResult Details(String nombre)
        {
            return View(neo.logIn(nombre));
        }*/

        public ActionResult logIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult logIn(Usuario user)
        {
            try
            {
                if (neo.logIn(user.nombreUsuario, user.contrasena))
                {
                    List<Usuario> usuario = new List<Usuario>();
                    actual = usuario.ElementAt(0);
                    usuario = neo.getCliente(user.nombreUsuario);
                    if (usuario.ElementAt(0).tipoUsuario == "admin")
                    {
                        return RedirectToAction("RegistrarAdministrador");
                    }
                    else
                    {
                        return RedirectToAction("RegistrarCliente");
                    }
                    
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Create
        public ActionResult RegistrarCliente()
        {
            return View();
        }



        // POST: Usuario/Create
        [HttpPost]
        public ActionResult RegistrarCliente(Usuario user)
        {
            try
            {
                if(neo.registrarCliente(user.nombre, user.apellido, user.contrasena, user.correo, user.nombreUsuario))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult RegistrarAdministrador()
        {
            return View();
        }



        // POST: Usuario/Create
        [HttpPost]
        public ActionResult RegistrarAdministrador(Usuario user)
        {
            try
            {
                if (neo.registrarAdministrador(user.nombre, user.apellido, user.contrasena, user.correo, user.nombreUsuario))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
