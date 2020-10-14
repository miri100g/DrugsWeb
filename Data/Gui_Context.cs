using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gui_.Data
{
    public class Gui_Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Gui_Context() : base("name=Gui_Context")
        {
        }

        public System.Data.Entity.DbSet<Gui_.Models.PatientViewModel> PatientViewModels { get; set; }

        public System.Data.Entity.DbSet<Gui_.Models.DoctorViewModel> DoctorViewModels { get; set; }

        public System.Data.Entity.DbSet<Gui_.Models.MedicineViewModel> MedicineViewModels { get; set; }

        public System.Data.Entity.DbSet<Gui_.Models.PrescriptionViewModel> PrescriptionViewModels { get; set; }

        public System.Data.Entity.DbSet<Gui_.Models.DetailsViewModel> DetailsViewModels { get; set; }
    }
}
