using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaMaturalna.Services
{
    using KlasaMaturalna.Models;
    public class TodayQuestionServices
    {
        public string GetTodayDate()
        {
            return DateTime.Today.ToString("yyyy-MM-dd"); ;
        }
        public List<string> GetQuestionsToday()
        {
            List<string> listToReturn = new List<string>();
            List<TodayQuestion> todayQuestions = APIServices.quesitonTodayGET();
            foreach (var item in todayQuestions)
            {
              listToReturn.Add(item.AsString());   
            }
            return listToReturn;
        }

    }
}
