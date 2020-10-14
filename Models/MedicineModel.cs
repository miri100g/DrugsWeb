using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gui_.Models
{
    public class MedicineModel
    {
        public List<Medicine> Medicines { get; set; }
        DrugAdminLogic dl = new DrugAdminLogic();
        public MedicineModel()
        {
            Medicines = dl.listMedicine();
        }
        public List<MedicineViewModel> Add(MedicineViewModel medicine)
        {
            List<MedicineViewModel> result = GetMedicines();
            result.Add(medicine);
            return result;
        }
        
        public MedicineViewModel GetMedicine(int id)
        {
            var result = (from m in Medicines
                          where m.Id == id
                          select m).Single<Medicine>();
            return new MedicineViewModel(result);

        }

        public List<MedicineViewModel> GetMedicines()
        {
            List<MedicineViewModel> result = new List<MedicineViewModel>();
            MedicineViewModel Vm = null;
            foreach (var item in Medicines)
            {
                Vm = new MedicineViewModel(item);
                result.Add(Vm);
            }
            return result;
        }
    }
}
    
