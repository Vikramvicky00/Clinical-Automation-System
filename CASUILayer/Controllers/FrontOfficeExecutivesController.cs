using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CASServiceLayer.Models;
using DALLayer;

namespace CASUILayer.Controllers
{
    public class FrontOfficeExecutivesController : Controller
    {
        
        private readonly ServiceOperations service;//object define


        public FrontOfficeExecutivesController()
        {
            service = new ServiceOperations(); //object create
        }


        public ActionResult AddPatient()//Adding patient
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("FrontOfficeLogin", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                service.InsertPatient(patient);
                return RedirectToAction("BookAppointment");
            }
            return View();
        }


        public ActionResult BookAppointment()//Book_Appointment 
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("FrontOfficeLogin", "Home");
            }
            ViewBag.Patient = service.GetAllPatients();       //get all patient list     
            ViewBag.Doctor = service.GetAllDoctors();         //get all doctor list
            return View();
        }
        [HttpPost]
        public ActionResult BookAppointment(Appointment appointment)
        {                                   
            if (appointment.StartDateTime.Date >= DateTime.Now.Date)
            {
                if (ModelState.IsValid)
                {
                    service.AddAppointment(appointment);
                    return RedirectToAction("ViewAppointment");
                }
            }
            ModelState.AddModelError("StartDateTime", "Appointment date must be in the present / future.");
            ViewBag.Patient = service.GetAllPatients();
            ViewBag.Doctor = service.GetAllDoctors();
            return View();
        }



        public ActionResult ViewAppointment()//View_Appointments
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("FrontOfficeLogin", "Home");
            }
            List<Appointment> Appoinmentlist = service.GetAllAppointments();
            return View(Appoinmentlist);
        }

        [HttpPost]
        public ActionResult ViewAppointment(string PatientSearch)
        {
            IEnumerable<Appointment> patientAppoinments= service.FindPatientAppointByName(PatientSearch);
            return View(patientAppoinments);
        }

        [HttpPost]
        public ActionResult ApproveAppoint(int id)//Post Action for Approve Appointments
        {
            Appointment appointment = service.GetAppointmentById(id);
            appointment.IsApprove = true;
            appointment.Status = "Approved";
            service.UpdateAppointment(appointment);
            return RedirectToAction("ViewAppointment");
        }
        [HttpPost]
        public ActionResult RejectAppoint(int id) //Post Action for Reject Approvement
        {
            Appointment appointment = service.GetAppointmentById(id);
            appointment.IsApprove = false;
            appointment.Status = "Rejected";
            service.UpdateAppointment(appointment);
            return RedirectToAction("ViewAppointment");
        }

        public ActionResult ProfileChange()  //Front Office Executives
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("FrontOfficeLogin", "Home");
            }
            var obj = Session["FOObject"] as FrontOfficeExecutive;
            return View(obj);
        }
        [HttpPost]
        public ActionResult ProfileChange([Bind(Include = "FrontOffExecutiveId,Name,Email,Password,DOB,Phone,Gender,Address")] FrontOfficeExecutive frontOfficeExecutive)
        {
            if (ModelState.IsValid)
            { 
                service.UpdateFrontOfficeExecutive(frontOfficeExecutive);
                return RedirectToAction("ViewAppointment");
            }

            return View();
        }




       
    }
}
