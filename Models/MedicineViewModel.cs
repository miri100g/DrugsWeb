using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gui_.Models
{
    public class MedicineViewModel
    {
            private Medicine Cueernt;
        public int ID
        {
            get { return Cueernt.Id; }
            set { Cueernt.Id = value; }
        }
            [DisplayName("NDC:")]
            public string Ndc
            {
                get { return Cueernt.Ndc; }
                set { Cueernt.Ndc = value; }
            }
            [DisplayName("Medicine Name:")]
            public string Name
            {
                get { return Cueernt.Name; }
                set { Cueernt.Name = value; }
            }
            [DisplayName("Manufacturer:")]
            public string Producer
        {
                get { return Cueernt.Producer; }
                set { Cueernt.Producer = value; }
            }
            [DisplayName("Image:")]
            public string MImage
            {
                get { return Cueernt.MImage; }
                set { Cueernt.MImage = value; }
            }
            [DisplayName("Generic Name:")]
            public string GenericName
            {
                get { return Cueernt.GenericName; }
                set { Cueernt.GenericName = value; }
            }
            [DisplayName("Active Ingredients:")]
            public string ActiveIngredients
            {
                get { return Cueernt.ActiveIngredients; }
                set { Cueernt.ActiveIngredients = value; }
            }
            [DisplayName("Properties:")]
            public string Properties
            {
                get { return Cueernt.Properties; }
                set { Cueernt.Properties = value; }
            }

        public MedicineViewModel(Medicine medicine)
            {
                this.Cueernt = medicine;
            }
        }

    }

