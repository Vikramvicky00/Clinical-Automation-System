using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CASServiceLayer.Models;
using DALLayer;

namespace CASUILayer.Controllers
{
    public class DoctorsController : Controller
    {
        private ClinicalDbContext db = new ClinicalDbContext();
        private Service service;

        public DoctorsController()
        {
            service = new Service();
        }

        public ActionResult MedicineList()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("DoctorLogin", "Home");
            }
            return View(db.Medicines.ToList()); 
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

        public ActionResult MessagePatient() 
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("DoctorLogin", "Home");
            }
            var obj = Session["DocObject"] as Doctor;// we used the doctor data which was stored in session during Login 
            Session["DoctorId"] = obj.DoctorId;   //we store the doctor id to the session
            var appointments = service.SearchbyDoctorIdApproved(obj.DoctorId);  
            // we are retriving the approved appoinments which are booked for specific doctor.
            ViewBag.Appointments = appointments; //we are storing all the approved appoinments for patients in ViewBag to display in the view
            return View();//return Message page UI view 
        }

        [HttpPost]
        public ActionResult MessagePatient(int id)
        {
            var obj = Session["DocObject"] as Doctor;// we used the doctor data which was stored in session during login
            Patient patient=service.FindPatientById(id);//we find the patient data by using patient id and stores in patient object
            Session["PatientId"] = patient.PatientId;//storing patientid in session
            Session["Pname"] = patient.Name;//storing patient name               //sender      //recevier
            IEnumerable<Message> messages = service.GetBySenderIdAndRecieverId(obj.DoctorId, patient.PatientId);
            var appointments = service.SearchbyDoctorIdApproved(obj.DoctorId); // we are retriving the approved appoinments which are booked for specific doctor.
            ViewBag.Appointments = appointments;//we are storing all the approved appoinments for patients in ViewBag to display in the view
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


        public ActionResult ProfileChange()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("DoctorLogin", "Home");
            }
            var obj = Session["DocObject"] as Doctor;
            Doctor doctor = service.GetDoctorById(obj.DoctorId);
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", doctor.SpecializationId);
            return View(doctor);
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
            return View(doctor);
        }

   
    }
}
