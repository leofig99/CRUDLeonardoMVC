using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDLeonardoMVC.Models;
using CRUDLeonardoMVC.Models.ViewModels;
namespace CRUDLeonardoMVC.Controllers

{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<ListEmpleadoViewModel> lista = new List<ListEmpleadoViewModel>();
            using (EmpleadosEntities db = new EmpleadosEntities())
            {
                
                lista = (from e in db.Empleado
                            select new ListEmpleadoViewModel
                            {
                                id = e.id,
                                nombre = e.nombre,
                                correo = e.correo,
                                fecha_registro = e.fecha_registro,
                                edad = e.edad,
                                apellidopaterno = e.apellidopaterno,
                                apellidomaterno = e.apellidomaterno

                            }).ToList();
            }
            return View(lista);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(EmpleadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(EmpleadosEntities db = new EmpleadosEntities())
                    {
                        var empleado = new Empleado();
                        empleado.id = model.id;
                        empleado.nombre = model.nombre;
                        empleado.correo = model.correo;
                        empleado.fecha_registro = DateTime.Now;
                        empleado.edad = model.edad;
                        empleado.apellidopaterno = model.apellidopaterno;
                        empleado.apellidomaterno = model.apellidomaterno;

                        db.Empleado.Add(empleado);
                        db.SaveChanges();
                    }
                    return Redirect("~/Empleado/");
                }
                return View(model);
                
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Editar(EmpleadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EmpleadosEntities db = new EmpleadosEntities())
                    {
                        var empleado = db.Empleado.Find(model.id);
                        empleado.id = model.id;
                        empleado.nombre = model.nombre;
                        empleado.correo = model.correo;
                        empleado.fecha_registro = DateTime.Now;
                        empleado.edad = model.edad;
                        empleado.apellidopaterno = model.apellidopaterno;
                        empleado.apellidomaterno = model.apellidomaterno;
                        db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Empleado/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int id)
        {
            EmpleadoViewModel model = new EmpleadoViewModel();

            using (EmpleadosEntities db = new EmpleadosEntities())
            {
                var empleado = db.Empleado.Find(id);
                model.nombre = empleado.nombre;
                model.correo = empleado.correo;
                model.id = empleado.id;
                model.fecha_registro = DateTime.Now;
                model.edad = empleado.edad;
                model.apellidopaterno = empleado.apellidopaterno;
                model.apellidomaterno = empleado.apellidomaterno;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            EmpleadoViewModel model = new EmpleadoViewModel();

            using (EmpleadosEntities db = new EmpleadosEntities())
            {
                var empleado = db.Empleado.Find(id);
                db.Empleado.Remove(empleado);
                db.SaveChanges();
            }
            return Redirect("~/Empleado/");
        }
    }
}