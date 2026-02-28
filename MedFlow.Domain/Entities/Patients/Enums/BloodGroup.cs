using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Patients.Enums
{
    public enum BloodGroup : short
    {
        Unknown=0,
        OPlus = 1,  // O+
        OMinus = 2,  // O-

        APlus = 3,  // A+
        AMinus = 4,  // A-

        BPlus = 5,  // B+
        BMinus = 6,  // B-

        ABPlus = 7, // AB+
        ABMinus = 8  // AB-
    }
}
