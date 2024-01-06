using System;
using System.Web.Mvc;
using CASServiceLayer.Models;
using DALLayer;

namespace CASUILayer.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ClinicalDbContext db; //db class
        private readonly ServiceOperations Service;//operation for all entity
        public AdminsController()
        {
            Service = new ServiceOperations();
            db = new ClinicalDbContext();
        }

    /*--------------------------------------------------------------ADMIN-----------------------------------------------------------------------------*/
        public ActionResult AdminIndex()// Admin Index/landing Page
        {
            if (Session["SId"] == null) 
            {
                return RedirectToAction("AdminLogin", "Home"); 
            }
            return View();
        }
        //Admin Profile Change
        public ActionResult ProfileChange()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            var obj = Session["AdminObject"] as Admin;  
            return View(obj); 
        }

        [HttpPost]
        public ActionResult ProfileChange([Bind(Include = "EmailId,Password")] Admin admin)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            if (ModelState.IsValid)
            {
               Service.UpdateAdmin(admin); 
                return RedirectToAction("PatientList"); 
            }
            return View();
        }

   /*-----------------------------------------------------------------Patient--------------------------------------------------------------------------*/
                     
        public ActionResult PatientList()//List of patients View
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            return View(Service.GetAllPatients());
        }

        //Adding Patients View
        public ActionResult AddPatient()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient([Bind(Include = "PatientId,Name,Phone,Address,DOB,Gender,Email,Password")] Patient patient)
        {                                            
            if (DateTime.Now < patient.DOB)
            {
                ModelState.AddModelError("DOB", "Please select a valid date.");
            }
            if (ModelState.IsValid)
            {
                Service.InsertPatient(patient);
                return RedirectToAction("PatientList");
            }
            return View();
        }
       
        public ActionResult DeletePatient(int id) //Delete patient view
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            Patient patient = Service.FindPatientById(id); 
            return View(patient);                         
        }

        [HttpPost, ActionName("DeletePatient")]  //Delete post action
        public ActionResult DeletePat(int id)
        {
            Service.DeletePatient(id);
            return RedirectToAction("PatientList");
        }

/*--------------------------------------------------------------------Doctor------------------------------------------------------------------------*/
        public ActionResult AddDoctor()//Add Doctor
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName");
            return View();
        }

        [HttpPost]
        public ActionResult AddDoctor([Bind(Include = "DoctorId,DoctorName,Email,Password,Gender,DOB,Phone,Address,IsAvailable,SpecializationId,Timings")]Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                Service.AddDoctor(doctor);
                return RedirectToAction("DoctorList");
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", doctor.SpecializationId);
            return View(doctor);
        }

        //Doctor List
        public ActionResult DoctorList()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            return View(Service.GetAllDoctors());
        }

        //Delete Doctor
        public ActionResult DeleteDoctor(int id)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            Doctor doctor = Service.GetDoctorById(id);  
            return View(doctor);
        }
        //Delete Action
        [HttpPost, ActionName("DeleteDoctor")]
        public ActionResult DeleteDoc(int id)
        {
            Service.DeleteDoctor(id);
            return RedirectToAction("DoctorList");
        }
 /*----------------------------------------------------------------------Pharmacist---------------------------------------------------------------------*/
        //Add Pharmacist
        public ActionResult AddPharmacist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPharmacist([Bind(Include = "PharmacistId,Name,Email,Password,Gender,DOB,Phone,Address")] Pharmacist Ph)
        {
            if (ModelState.IsValid)
            {
                Service.AddPharmacist(Ph);
                return RedirectToAction("PharmacistList");
            }
            return View();
        }

        //list of Pharmacist
        public ActionResult PharmacistList()
        {
            return View(Service.GetAllPharmacists());
        }
        //Delete Pharmacist
        public ActionResult DeletePharmacist(int id)
        {
            Pharmacist ph = Service.GetPharmacistById(id);
            return View(ph);
        }

        [HttpPost, ActionName("DeletePharmacist")]
        public ActionResult DeletePharm(int id)
        {
            Service.DeletePharmacist(id);
            return RedirectToAction("PharmacistList");
        }

  /*---------------------------------------------------------------------Front Office Executive-----------------------------------------------------------*/
        //Add Front Executive
        public ActionResult AddFrontExecutive()
        {
            return View();
        }
 
        [HttpPost]
        public ActionResult AddFrontExecutive([Bind(Include = "FrontOffExecutiveId,Name,Email,Password,DOB,Phone,Gender,Address")] FrontOfficeExecutive FO)
        {
            if (ModelState.IsValid)
            {
                Service.AddFrontOfficeExecutive(FO);
                return RedirectToAction("FrontExecutiveList");
            }

            return View();
        }
        
        //FrontExecutive List
        public ActionResult FrontExecutiveList()
        {
            return View(Service.GetAllFrontOfficeExecutives());
        }
        //Delete Fo
        public ActionResult DeleteFO(int id)
        {
           FrontOfficeExecutive FO=Service.GetFrontOfficeExecutiveById(id);
            return View(FO);
        }

        [HttpPost, ActionName("DeleteFO")]
        public ActionResult DeleteFOE(int id)
        {
            Service.DeleteFrontOfficeExecutive(id);
            return RedirectToAction("FrontExecutiveList");
        }
  /*------------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
