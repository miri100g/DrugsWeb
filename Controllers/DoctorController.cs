using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BE;
using BL;
using Gui_.Data;
using Gui_.Models;

namespace Gui_.Controllers
{
    public class DoctorController : Controller
    {
        private Gui_Context db = new Gui_Context();
        private DoctorModel doctorModel = new DoctorModel();
        // GET: Doctor
        public ActionResult Index()
        {
            return View(doctorModel.GetDoctors());
        }
        public ActionResult Home()
        {
            return View();
        }
        // GET: Doctor/Details/5
        public ActionResult Details()
        {
            return View(doctorModel.GetDoctors());
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            //Doctor d = new Doctor { FName = string.Empty, email = string.Empty, LName = string.Empty };
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try { 
                DoctorAdminLogic bl = new DoctorAdminLogic();
               
                long j = Convert.ToInt64(collection["PhoneNumber"]);
                bl.AddDoctor(collection["FName"], collection["LName"], collection["email"], Convert.ToInt64(collection["IdP"]), Convert.ToInt64(collection["Licensing"]),j, collection["Specialty"], collection["gender"]);
                ViewBag.Message = String.Format("The doctor was added successfully.");
                return View("Home");


            }
            catch
            {
                ViewBag.Message = String.Format("The ID number already exists in the system , try again");
                
                return View();
            }
        }

       

        // GET: Doctor/Edit/5
        public ActionResult Edit(int? id)
        {        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorViewModel doctorViewModel = doctorModel.GetDoctor((int)id);
            if (doctorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(doctorViewModel);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)//[Bind(Include = "Id,IdP,FName,LName,gender,Specialty,Licensing,PhoneNumber,email")] DoctorViewModel doctorViewModel)
        {
            try
            {
                DoctorAdminLogic bl = new DoctorAdminLogic();

                long j = Convert.ToInt64(collection["PhoneNumber"]);
                string g = collection["FName"];
                long f = Convert.ToInt64(collection["IdP"]);
                string h= collection["gender"];
                bl.EditDoctor(collection["FName"], collection["LName"], collection["email"], Convert.ToInt64(collection["IdP"]), Convert.ToInt64(collection["Licensing"]), j, collection["Specialty"], collection["gender"]);
                ViewBag.Message = String.Format("The doctor was edited successfully.");
                return View("Home");


            }
            catch
            {
                
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorViewModel doctorViewModel = doctorModel.GetDoctor((int)id);
            if (doctorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(doctorViewModel);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorAdminLogic bl = new DoctorAdminLogic();
            bl.deleteDoctor(id);
            ViewBag.Message = String.Format("The doctor was deleted successfully.");
            return View("Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
