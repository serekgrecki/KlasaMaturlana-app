using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaMaturalna.Services
{
    public class DefaultServices
    {
        public List<string> GetTimeTable()
        {
            var timetableList = new List<string>()
            {
                "4 MAJA, CZWARTEK - POLSKI PISEMNY PODSTAWA + ROZSZERZENIE",
                "5 MAJA, PIATEK - MATEMATYKA PODSTAWA",
                "8 MAJA, PONIEDZIAŁEK - ANGIELSKI PISEMNY PODSTAWA + ROZSZERZENIE",
                "POLSKI USTNY : MAJ 8 - 20",
                "ANGIELSKI USTNY : MAJ 4 - 26"
            };
            return timetableList;
        }
    }
}
