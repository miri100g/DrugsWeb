using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using BL;
using Gui_.Data;
using Gui_.Models;

namespace Gui_.Controllers
{
    public class PatientController : Controller
    {
        private Gui_Context db = new Gui_Context();
        private PatientModel patientModel=new PatientModel();
        // GET: Patient
        public ActionResult Index()
        {
            return View(patientModel.GetPatients());
        }
        public ActionResult Watch()
        {
            return View(patientModel.GetPatients());
        }
        public ActionResult Home()
        {
            return View();
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientViewModel patientViewModel = db.PatientViewModels.Find(id);
            if (patientViewModel == null)
            {
                return HttpNotFound();
            }
            return View(patientViewModel);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)//[Bind(Include = "Id,IdP,FName,LName,gender,DateOfBirth,DateOfRegistration,email,PhoneNumber")] PatientViewModel patientViewModel)
        {
            try
            {
                PatientAdminLogic bl = new PatientAdminLogic();
                bl.addPatient(collection["FName"], collection["LName"], collection["email"], Convert.ToInt64(collection["IdP"]), Convert.ToInt64(collection["PhonNumber"]), Convert.ToDateTime(collection["DateOfBirthd"]), DateTime.Now, collection["gender"]);
                ViewBag.Message = String.Format("The patient was added successfully.");
                return View("Home");
            }
            catch (Exception ex)
            {
                if (ex.Message == "not correct date")
                    ViewBag.Message = String.Format("One of the details were not correct, try again");
                
                if (ex.Message == "The ID number already exists in the system")
                    ViewBag.Message = String.Format("The ID number already exists in the system, try again");
              

                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*IBL bl=new bl()
             bl.getpatient()*/
            PatientViewModel patientViewModel = patientModel.GetPatient((int)id);
            if (patientViewModel == null)
            {
                return HttpNotFound();
            }
            return View(patientViewModel);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Edit(FormCollection collection)//[Bind(Include = "Id,IdP,FName,LName,gender,DateOfBirth,DateOfRegistration,email,PhoneNumber")] PatientViewModel patientViewModel)
        {
            try
            {
                PatientAdminLogic bl = new PatientAdminLogic();
                bl.EditPatient(collection["FName"], collection["LName"], collection["email"], Convert.ToInt64(collection["IdP"]), Convert.ToInt64(collection["PhonNumber"]), Convert.ToDateTime(collection["DateOfBirthd"]), Convert.ToDateTime(collection["DateOfRegistration"]), collection["gender"]);
                ViewBag.Message = String.Format("The patient was edited successfully.");
                return View("Home");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientViewModel patientViewModel = patientModel.GetPatient((int)id);
            if (patientViewModel == null)
            {
                return HttpNotFound();
            }

            return View(patientViewModel);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientAdminLogic bl = new PatientAdminLogic();
            bl.deletePatient(id);
            ViewBag.Message = String.Format("The patient was deleted successfully.");
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
