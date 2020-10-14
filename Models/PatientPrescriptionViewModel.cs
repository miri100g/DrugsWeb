using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gui_.Models
{
    public class PatientPrescriptionViewModel
    {
        public PatientViewModel patientList { get; set; }
        public List<PrescriptionViewModel> prescriptionList { get; set; }
    }
}