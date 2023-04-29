using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2R_Medical_Associates.Maui.EMR_Management
{
    public class EMR: BaseEntity
    {
        [Table("EMRs")]

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DOB { get; set; }
        public double TelephoneNo { get; set; }
        public string NextOfKin { get; set; }
        public string Address { get; set; }
        public string MedicalHistory { get; set; }
        public string Prescripitons { get; set; }
        public string TestResults { get; set; }


    }
}
