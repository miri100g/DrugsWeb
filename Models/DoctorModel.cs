using System;
using BE;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL;

namespace Gui_.Models
{
    public class DoctorModel
    {
        public List<Doctor> doctors { get; set; }
        DoctorAdminLogic dl = new DoctorAdminLogic();
        public DoctorModel()
        {
            doctors = dl.listDoctors();
        }
        public List<DoctorViewModel> Add(DoctorViewModel doctor)
        {
            List<DoctorViewModel> result = GetDoctors();
            result.Add(doctor);
            return result;
        }
        public DoctorViewModel GetDoctor(int id)
        {
            var result = (from doc in doctors
                          where doc.Id == id
                          select doc).Single<Doctor>();
            return new DoctorViewModel(result);

        }
        public List<DoctorViewModel> GetDoctors()
        {
            List<DoctorViewModel> result = new List<DoctorViewModel>();
            DoctorViewModel Vm = null;
            foreach (var item in doctors)
            {
                Vm = new DoctorViewModel(item);
                result.Add(Vm);
            }
            return result;
        }
    }
}
