using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gui_.Models
{
    public class DoctorViewModel
    {

        private Doctor Cueernt;
        public int Id
        {
            get { return Cueernt.Id; }
            set { Cueernt.Id= value; }
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

        [DisplayName("Specialty:")]
        public string Specialty
        {
            get { return Cueernt.Specialty; }
            set { Cueernt.Specialty = value; }
        }
        [DisplayName("License Number:")]
        public long Licensing
        {
            get { return Cueernt.Licensing; }
            set { Cueernt.Licensing = value; }
        }
        [DisplayName("Phone Number:")]
        public long PhoneNumber
        {
            get { return Cueernt.PhonNumber; }
            set { Cueernt.PhonNumber = value; }
        }
        [DisplayName("Email Address:")]
        public string email
        {
            get { return Cueernt.email; }
            set { Cueernt.email = value; }
        }
        public DoctorViewModel(Doctor doc)
        {
            this.Cueernt = doc;
        }
    }

}

