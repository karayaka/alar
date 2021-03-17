using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.UserClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.Classes.BranchClasses
{
    /// <summary>
    /// Subede işlem yapmaya yetkili kişiler
    /// </summary>
    public class BranchAuthorized:BaseObject
    {
        public int BranchID { get; set; }
        public Branch Branch { get; set; }

        public int UserClassID { get; set; }
        public UserClass UserClass { get; set; }
    }
}
