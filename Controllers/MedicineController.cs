using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using BL;
using Gui_.Data;
using Gui_.Models;

namespace Gui_.Controllers
{
    public class MedicineController : Controller
    {
        private Gui_Context db = new Gui_Context();
        private MedicineModel medicineModel = new MedicineModel();

        // GET: Medicine
        public ActionResult Index()
        {
            return View(medicineModel.GetMedicines());
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Info()
        {
            return View(medicineModel.GetMedicines());
        }

        // GET: Medicine/Details/5
        public ActionResult Details()
        {          
            return View(medicineModel.GetMedicines());
        }

        // GET: Medicine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)//[Bind(Include = "ID,Ndc,Name,Producer,MImage,GenericName,ActiveIngredients,Properties")] MedicineViewModel medicineViewModel)
        {
            try { 
                DetailsViewModel DescriptionList = new DetailsViewModel();
                ImageValidateLogic bl = new ImageValidateLogic();
                string filePath = Server.MapPath(Url.Content($"~/images/{collection["MImage"].ToString()}"));
                DescriptionList.Descriptions = new List<string>(bl.CheckImage(filePath));
                DrugAdminLogic bl2 = new DrugAdminLogic();
                
                bl2.AddDrug(collection["Name"], collection["GenericName"], collection["Producer"], collection["ActiveIngredients"], collection["Properties"], collection["MImage"].ToString(), collection["Ndc"]);

                ViewBag.Message = String.Format("The medicine was added successfully.");
                return View("Home");// RedirectToAction("Home");


           }
            catch (Exception ex)
            {
               
                if (ex.Message == "The medicine already exists in the system") 
                    ViewBag.Message = String.Format("The medicine already exists in the system , try again");
                    
                if (ex.Message == "not a drug image")
                    ViewBag.Message = String.Format("The image that you selected is not a medicine , try again");
                
                
                return View();
            }
        }

        // GET: Medicine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineViewModel medicineViewModel = medicineModel.GetMedicine((int )id);
            if (medicineViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medicineViewModel);
        }

        // POST: Medicine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)//[Bind(Include = "ID,Ndc,Name,Producer,MImage,GenericName,ActiveIngredients,Properties")] MedicineViewModel medicineViewModel)
        {

            try { 
                DrugAdminLogic bl2 = new DrugAdminLogic();
                if(collection["MImage"]==string.Empty)
                {
                    bl2.EditDrug(collection["Name"], collection["GenericName"], collection["Producer"], collection["ActiveIngredients"], collection["Properties"], null, collection["Ndc"]);
                }
                else
                { 
                    DetailsViewModel DescriptionList = new DetailsViewModel();
                    ImageValidateLogic bl = new ImageValidateLogic();
                    string filePath = "C:\\Users\\מירי\\Downloads\\Gui_\\Gui_\\images\\"+ collection["MImage"];// Server.MapPath(Url.Content($"{ collection["MImage"].ToString()}")); 
                    DescriptionList.Descriptions = new List<string>(bl.CheckImage(filePath));
                    bl2.EditDrug(collection["Name"], collection["GenericName"], collection["Producer"], collection["ActiveIngredients"], collection["Properties"], collection["MImage"], collection["Ndc"]);
                }
                ViewBag.Message = String.Format("The medicine was edited successfully.");
                return View("Home");
            }
            catch (Exception ex)
            {

                if (ex.Message == "not a drug image")
                    ViewBag.Message = String.Format("The image that you selected is not a medicine , try again");
               

                return View();
            }
        }

        // GET: Medicine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineViewModel medicineViewModel = medicineModel.GetMedicine((int)id);
            if (medicineViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medicineViewModel);
        }

        // POST: Medicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrugAdminLogic bl = new DrugAdminLogic();
            bl.deleteDrug(id);
            ViewBag.Message = String.Format("The medicine was deleted successfully.");
            return  View("Home");
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
