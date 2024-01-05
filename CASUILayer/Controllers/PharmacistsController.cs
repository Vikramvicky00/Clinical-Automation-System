using System.Collections.Generic;
using System.Web.Mvc;
using CASServiceLayer.Models;
using DALLayer;

namespace CASUILayer.Controllers
{
    public class PharmacistsController : Controller
    {
        private readonly ServiceOperations service;
        public PharmacistsController()
        {
            service = new ServiceOperations(); //invoke service class to acces operations
        }

        //Get Medicine list
        public ActionResult Index()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("PharmacistsLogin", "Home");
            }
            return View(service.GetAllMedicines());
        }

        [HttpPost]//when we click on search button, these action will call
        public ActionResult Index(string MediName)
        {

            IEnumerable<Medicine> result = service.FindMedicineByName(MediName);
            return View(result);
        }

        //Add Medicine to list
        public ActionResult Create()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("PharmacistsLogin", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicineId,MedicineName,Price,Stock,IsAvailable,Tax")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                service.AddMedicine(medicine);
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        //Edit Medicine
        public ActionResult Edit(int id)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("PharmacistsLogin", "Home");
            }
            Medicine medicine = service.GetMedicineById(id);
            return View(medicine);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]//it is used to prevent the Cross sites Request Forgery
        public ActionResult Edit([Bind(Include = "MedicineId,MedicineName,Price,Stock,IsAvailable,Tax")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                service.UpdateMedicine(medicine);
                return RedirectToAction("Index");
            }    
            return View(medicine);
        }

        // Delete Medicine
        public ActionResult Delete(int id)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("PharmacistsLogin", "Home");
            }
            Medicine medicine = service.GetMedicineById(id);
            return View(medicine);  
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteMedicine(id);
            return RedirectToAction("Index");//medicine list view 
        }

        public ActionResult ProfileChange()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("PharmacistsLogin", "Home");
            }
            var obj = Session["PhObject"] as Pharmacist;
            return View(obj);
        }

        [HttpPost]
        public ActionResult ProfileChange([Bind(Include = "PharmacistId,Name,Email,Password,Gender,DOB,Phone,Address")] Pharmacist pharmacist)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePharmacist(pharmacist);
                return RedirectToAction("Index");
            }
            return View();
        }


      
    }
}
