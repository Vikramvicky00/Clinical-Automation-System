using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CASServiceLayer.Models;
using DALLayer;

namespace CASUILayer.Controllers
{
    public class DoctorsController : Controller
    {
        private ClinicalDbContext db = new ClinicalDbContext();
        private ServiceOperations service;

        public DoctorsController()
        {
            service = new ServiceOperations();
        }
         
        //Get Medicine List view
        public ActionResult MedicineList()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("DoctorLogin", "Home");
            }
            return View(service.GetAllMedicines()); 
        }
       
        [HttpPost]
        public ActionResult MedicineList(string MediName)
        {
            IEnumerable<Medicine> medicine =service.FindMedicineByName(MediName);
            if (medicine != null)
            {
                return View(medicine);
            }
            return View(medicine);
        }

        //Appointment List View 
        public ActionResult AppointmentList()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("DoctorLogin", "Home");
            }
            var obj = Session["DocObject"] as Doctor;
            var appointments = service.SearchbyDoctorIdApproved(obj.DoctorId);
            return View(appointments);
        }

        //Message page UI view
        public ActionResult MessagePatient() 
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("DoctorLogin", "Home");
            }
            var obj = Session["DocObject"] as Doctor; 
            Session["DoctorId"] = obj.DoctorId;      
            var appointments = service.SearchbyDoctorIdApproved(obj.DoctorId);  
            ViewBag.Appointments = appointments; 
            return View(); 
        }

        [HttpPost]
        public ActionResult MessagePatient(int id)
        {
            var obj = Session["DocObject"] as Doctor;
            Patient patient=service.FindPatientById(id);
            Session["PatientId"] = patient.PatientId;
            Session["Pname"] = patient.Name;               
            IEnumerable<Message> messages = service.GetBySenderIdAndRecieverId(obj.DoctorId, patient.PatientId);
            var appointments = service.SearchbyDoctorIdApproved(obj.DoctorId); 
            ViewBag.Appointments = appointments;
            return View(messages);
        }

        [HttpPost]
        public ActionResult AddMessage(int id, string txtMessage)
        {
            Message message = new Message();
            message.SenderId = (int)Session["DoctorId"];
            message.MessageTime = DateTime.Now;
            message.ReceiverId = id;
            message.Status = "Sent";
            message.Message1 = txtMessage;
            service.AddMessage(message);
            return RedirectToAction("MessagePatient", message.ReceiverId);
        }

        //Profile Change View 
        public ActionResult ProfileChange()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("DoctorLogin", "Home");
            }
            var obj = Session["DocObject"] as Doctor;
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", obj.SpecializationId);
            return View(obj);
        }

        [HttpPost]
        public ActionResult ProfileChange([Bind(Include = "DoctorId,DoctorName,Email,Password,Gender,DOB,Phone,Address,IsAvailable,SpecializationId,Timings")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                service.AddDoctor(doctor);
                return RedirectToAction("AppointmentList");
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", doctor.SpecializationId);
            return View();
        }

   
    }
}
