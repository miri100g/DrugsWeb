using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL;
using Gui_.Data;
using Gui_.Models;
using NuGet.Protocol.Core.Types;

namespace Gui_.Controllers
{
    public class PrescriptionController : Controller
    {
        private Gui_Context db = new Gui_Context();
        private PrescriptionModel prescriptionModel = new PrescriptionModel();
        // GET: Prescription

        // GET: Prescription/Details/5
        public ActionResult History(int? Id)
        {           
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*IBL bl=new bl()
             bl.getpatient()*/
            var patientModel = new PatientModel();
            PatientViewModel patientViewModel = patientModel.GetPatient((int)Id);
            var prescription = prescriptionModel.GetPrescriptions();
            PatientPrescriptionViewModel patientPrescription = new PatientPrescriptionViewModel();
            patientPrescription.patientList = patientViewModel;
            patientPrescription.prescriptionList = prescription;
            return View(patientPrescription);
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult GetId()
        {
            return View();
        }

        // GET: Prescription/Create
        public ActionResult Create(int? Id)
        {

            var patientModel = new PatientModel();

            PatientViewModel patientViewModel = patientModel.GetPatient((int)Id);
            PatientPrescriptionViewModel patientPrescription = new PatientPrescriptionViewModel();
            patientPrescription.patientList = patientViewModel;
          
            return View(patientPrescription);
        }

        // POST: Prescription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)//[Bind(Include = "Id,patientId,doctorId,medicineName,Start,End,notes")] PrescriptionViewModel prescriptionViewModel)
        {
            try { 
                PrescriptionAdminLogic bl = new PrescriptionAdminLogic();
                DateTime g = Convert.ToDateTime(collection["Start"]);
                string h = collection["medicineName"];
                long f = Convert.ToInt64(collection["doctorId"]);
                long t = Convert.ToInt64(collection["patientId"]);
                string result = bl.AddPrescription(collection["medicineName"], collection["notes"], Convert.ToInt64(collection["doctorId"]), Convert.ToInt64(collection["patientId"]), Convert.ToDateTime(collection["Start"]), Convert.ToDateTime(collection["End"]));


                ViewBag.Message = String.Format("The prescription was created successfully.");//\n Notes:"+result);
                return View("Home");
            }
            catch (Exception ex)
            {
                if (ex.Message == "The ID number of the patient dosn't exist in the system")
                    ViewBag.Message = String.Format("The ID number of the patient dosn't exist in the system, try again");
               
                if (ex.Message == "The ID number of the doctor dosn't exist in the system")
                    ViewBag.Message = String.Format("The ID number of the doctor dosn't exist in the system, try again");

                if (ex.Message == "Start date should be before end date")
                    ViewBag.Message = String.Format("Start date should be before end date, try again");
                
                if (ex.Message == "not correct date")
                    ViewBag.Message = String.Format("not a correct date, try again");
                
                if (ex.Message == "The is no such medicine in the system")
                    ViewBag.Message = String.Format("The drug does not appear in the system, try again");
               
               else
                    ViewBag.Message = String.Format(ex.Message);
                
                return View();
            }
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
