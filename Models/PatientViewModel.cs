using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gui_.Models
{  
    public class PatientViewModel
    {
        private Patient Cueernt;
        public int Id
        {
            get { return Cueernt.Id; }
            set { Cueernt.Id = value; }
        }
        [DisplayName("ID:")]
        public long IdP
        {
            get { return Cueernt.IdP; }
            set { Cueernt.IdP = value; }
        }

        [DisplayName("First Name:")]
        public string FName
        {
            get { return Cueernt.FName; }
            set { Cueernt.FName = value; }
        }
        [DisplayName("Last Name:")]
        public string LName
        {
            get { return Cueernt.LName; }
            set { Cueernt.LName = value; }
        }
        [DisplayName("Gender:")]
        public string gender
        {
            get { return Cueernt.gender; }
            set { Cueernt.gender = value; }
        }
        [DisplayName("Date of Birth:")]
        public DateTime  DateOfBirthd
        {
            get { return Cueernt.DateOfBirthd; }
            set { Cueernt.DateOfBirthd = value; }
        }
       
        [DisplayName("Date of Registration:")]
        public DateTime DateOfRegistration
        {
            get { return Cueernt.DateOfRegistration; }
            set { Cueernt.DateOfRegistration = value; }
        }
        [DisplayName("Email Address:")]
        public string email
        {
            get { return Cueernt.email; }
            set { Cueernt.email = value; }
        }
        [DisplayName("Phone Number")]
        public long PhonNumber
        {
            get { return Cueernt.PhonNumber; }
            set { Cueernt.PhonNumber = value; }
        }
        public PatientViewModel(Patient patient)
        {
            this.Cueernt = patient;
        }
    }
}
