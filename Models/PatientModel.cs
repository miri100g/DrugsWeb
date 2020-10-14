using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gui_.Models;
using BL;

namespace Gui_.Models
{
    public class PatientModel
    {
        public List<Patient> patients { get; set; }
        PatientAdminLogic pl = new PatientAdminLogic();
        public PatientModel()
        {
            patients = pl.listPatient();
        }
  
        public List<PatientViewModel> Add (PatientViewModel patient)
        {
            List<PatientViewModel> result = GetPatients();
            result.Add(patient);
            return result;
        }
        public PatientViewModel GetPatient(int id)//id = 206833139
        {
            var result = (from p in pl.listPatient()
                          where p.IdP == id
                          select p).Single<Patient>();
            return new PatientViewModel(result);
        }
        public List<PatientViewModel> GetPatients()
        {
            List<PatientViewModel> result = new List<PatientViewModel>();
                PatientViewModel Vm = null;
            foreach (var item in patients)
            {
                Vm = new PatientViewModel(item);
                result.Add(Vm);
            }
            return result;
        }
    }
}
