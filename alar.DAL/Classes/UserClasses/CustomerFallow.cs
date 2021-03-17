using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.CustomerClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.Classes.UserClasses
{
    public class CustomerFallow:BaseObject
    {
        public int UserClassID { get; set; }
        public UserClass UserClass { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        //Kontrol edilecek ve Ve aotationslar yazılacak!!!
    }
}
