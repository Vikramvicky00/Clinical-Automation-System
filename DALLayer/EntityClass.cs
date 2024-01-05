using System;
using System.ComponentModel.DataAnnotations;//contains the attributes
using System.ComponentModel.DataAnnotations.Schema;//contains the database 

namespace DALLayer
{
    //Specialization Class
    public class Specialization
    {
        [Key] //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Unique(Automatic numbering from 1 so on) 
        [Required(ErrorMessage = "Specialization  is required")] //propertry must be filled into database.otherwise shows errors message
        public int SpecializationId { get; set; }

        [Required(ErrorMessage = "Specilaization  is required")]
        [StringLength(15, ErrorMessage = "The field must be between 15 characters.")]//is used to define the length of the property
        public string SpecializationName { get; set; }
    }
    //Admin Class
    public class Admin
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]//it is the inbult email attribute used to check the email validations
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must meet the specified criteria.")]
        public string Password { get; set; }
    }
    //Patient Class
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(20)]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [StringLength(10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Please Enter Address")]
        [StringLength(50)]
        public string Address { get; set; }
       
        [Required(ErrorMessage = "Please select Date of Birth")]
        [DataType(DataType.Date)]//for display the field as calender
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

      
        [Required(ErrorMessage = "Please Enter Email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must meet the specified criteria.")]
        public string Password { get; set; }
    }
    //Doctor Class , has relation with Specialization table ,thats why we add specialization id in doctor table,i.e one Specialization has many doctors
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(20)]
        public string DoctorName { get; set; }


        [Required(ErrorMessage = "Please Enter Email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must meet the specified criteria.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select Date of Birth")]
        [DataType(DataType.Date)] //from      //To      
        [Range(typeof(DateTime), "1/1/1900", "1/1/1997", ErrorMessage = "Date of birth should be greater than 25 years")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [StringLength(10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select available or not")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Please Enter Specialization")]
        public int SpecializationId { get; set; }

        [Required(ErrorMessage = "Please Select Timings")]
        [StringLength(20)]
        public string Timings { get; set; }

        [ForeignKey("SpecializationId")] //has relation with Specialization table ,thats why we add specialization id in doctor table,i.e one Specialization has many doctors
        public virtual Specialization Specialization { get; set; } //is used to override the properties which is present in the Specialization Class(Base Class)
    }
    //Pharmacist class
    public class Pharmacist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PharmacistId { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(20)]
        public string  Name { get; set; }


        [Required(ErrorMessage = "Please Enter Email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must meet the specified criteria")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select Date of Birth")]
        [DataType(DataType.Date)] //from       //to
        [Range(typeof(DateTime), "1/1/1900", "1/1/2004", ErrorMessage = "Date of birth should be greater than 18 years")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [StringLength(10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

    } 
    //FrontOffice Executive Class
    public class FrontOfficeExecutive 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FrontOffExecutiveId { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must meet the specified criteria.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select Date of Birth")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2004", ErrorMessage = "Date of birth should be greater than 18 years")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [StringLength(10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [StringLength(50)]
        public string Address { get; set; }

    }
    //Appoinment Class
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = " Please select Date ")]
        [DataType(DataType.Date)]
        public DateTime StartDateTime { get; set; }

        [Required(ErrorMessage = "Please select status")]
        [MaxLength(10)]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please describe your problem")]
        [MaxLength(200)]
        public string Details { get; set; }

        [Required(ErrorMessage = "Field required")]
        public bool IsApprove { get; set; }

        public int MsgLimit { get; set; }

        [Required (ErrorMessage = "Please Select Patient")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please Select Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        
    }
    //Medicine Class
    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "Please enter medicine name")]
        [MaxLength(50)]
        public string MedicineName { get; set; }

        [Required(ErrorMessage = "Please Enter price")]
        public float Price { get; set; }
        //price-((price+tax)/100)*10
        [Required (ErrorMessage = "Please Enter Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Please select available or not")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Please Enter Tax")]
        public float Tax { get; set; }
        
    }
    //Message
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        [Required]
        public DateTime MessageTime { get; set; }

        [Required(ErrorMessage = "Please Type the message")]
        [StringLength(200)]
        public string Message1 { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public int SenderId { get; set; }
    }
}
