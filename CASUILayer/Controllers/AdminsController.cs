using System;
using System.Web.Mvc;
using CASServiceLayer.Models;
using DALLayer;

namespace CASUILayer.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ClinicalDbContext db;//just for using the specialization table
        private readonly Service Service;
        public AdminsController()
        {
            Service = new Service();
            db = new ClinicalDbContext();
        }

    /*--------------------------------------------------------------ADMIN-----------------------------------------------------------------------------*/
        public ActionResult AdminIndex()// Admin Index/landing Page
        {
            if (Session["SId"] == null) //need for Authencation,no one access through the url without login
            {
                return RedirectToAction("AdminLogin", "Home");// 
            }
            return View();
        }
        public ActionResult ProfileChange()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            var obj = Session["AdminObject"] as Admin;  //stores the adminobject which is store in session ,while login into admin 
            return View(obj);//returns the data of admin 
        }

        [HttpPost]
        public ActionResult ProfileChange([Bind(Include = "EmailId,Password")] Admin admin)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            if (ModelState.IsValid)//check the validation of the fields which are required
            {
               Service.UpdateAdmin(admin); //update the admin details 
                return RedirectToAction("PatientList"); //redirects to patient list.
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

        public ActionResult AddPatient()//Adding Patients View
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
           
            //int age = DateTime.Now.Year - patient.DOB.Year;
                                              
            if (DateTime.Now < patient.DOB)
            {
                ModelState.AddModelError("DOB", "Please select a valid date.");
            }
            //else if (age < 18)
            //{
            //    ModelState.AddModelError("DOB", "You must be at least 18 years old to sign up.");
            //    return View();
            //}
            if (ModelState.IsValid)
            {
                Service.InsertPatient(patient);
                return RedirectToAction("PatientList");
            }
            return View();
        }
        //this view is used for displaying the data 
        public ActionResult DeletePatient(int id) //Delete patient view
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            Patient patient = Service.FindPatientById(id); //find the patient data of specific id , when we clicked on delete button ,it passes the value of
            return View(patient);                           //passing the patient data to the view page(.cshtml)
        }

        [HttpPost, ActionName("DeletePatient")]  //whenever we click on delte button in delete patient view page, it automatically calls this Action.
        public ActionResult DeletePat(int id)
        {
            Service.DeletePatient(id);
            return RedirectToAction("PatientList");
        }

/*--------------------------------------------------------------------Doctor------------------------------------------------------------------------*/
    

        public ActionResult AddDoctor()
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
        public ActionResult DoctorList()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            return View(Service.GetAllDoctors());
        }
        public ActionResult DeleteDoctor(int id)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            Doctor doctor = Service.GetDoctorById(id);  
            return View(doctor);
        }

        [HttpPost, ActionName("DeleteDoctor")]
        public ActionResult DeleteDoc(int id)
        {
            Service.DeleteDoctor(id);
            return RedirectToAction("DoctorList");
        }
 /*----------------------------------------------------------------------Pharmacist---------------------------------------------------------------------*/
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

        public ActionResult PharmacistList()
        {
            return View(Service.GetAllPharmacists());
        }
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

        public ActionResult FrontExecutiveList()
        {
            return View(Service.GetAllFrontOfficeExecutives());
        }

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
