using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaMaturalna.Services
{
    public class CalculatorPageServices
    {
        public List<String> GetHours()
        {
            var list = new List<String>()
            {
                "9:00-9:45",
                "10:00-10:45",
                "11:00-11:45",
                "12:00-12:45",
                "13:00-13:45",
                "14:00-14:45",
                "15:00-15:45",
                "16:00-16:45",
                "17:00-17:45",
                "18:00-18:45"
            };
            return list;
        }
        public List<String> GetNumbersQueue()
        {
            var list = new List<String>()
            {
                "1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20"
            };
            return list;
        }
    }
}
