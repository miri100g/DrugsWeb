using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gui_.Models
{
    public class PrescriptionViewModel
    {
        private Prescription Cueernt;
        public int Id
        {
            get { return Cueernt.id; }
            set { Cueernt.id = value; }
        }
        [DisplayName("Patient's ID")]
        public long patientId
        {
            get { return Cueernt.patientId; }
            set { Cueernt.patientId = value; }
        }
        [DisplayName("Doctor's ID")]
        public long doctorId
        {
            get { return Cueernt.doctorId; }
            set { Cueernt.doctorId = value; }
        }
        [DisplayName("Medicine Name:")]
        public string medicineName
        {
        get { return Cueernt.medicineName; }
        set { Cueernt.medicineName = value; }
        }

        [DisplayName("Taking the Medicine From:")]
        public DateTime Start
        {
            get { return Cueernt.Start; }
            set { Cueernt.Start= value; }
        }
        [DisplayName("Until:")]           
        public DateTime End
        {
            get { return Cueernt.End; }
            set { Cueernt.End = value; }
        }
        [DisplayName("Notes:")]
        public string notes
        {
            get { return Cueernt.notes; }
            set { Cueernt.notes = value; }
        }
        public PrescriptionViewModel(Prescription prescription)
        {
            this.Cueernt = prescription;
        }
    }
  
    }
