using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using KlasaMaturalna.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace KlasaMaturalna.Services
{
    public static class APIServices
    {
        public static async Task<string> addQustionPOST(TodayQuestionPOST questionToAdd)
        {
            string todayDate = DateTime.Today.ToString("yyyy-MM-dd");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("date", todayDate),
                new KeyValuePair<string, string>("question_number", questionToAdd.question_number),
                new KeyValuePair<string, string>("question_content", questionToAdd.question_content),
                new KeyValuePair<string, string>("img_src", questionToAdd.img_src)
            });

            string url = "http://klasamaturalna.pl/addQuestion.php";

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = await httpClient.PostAsync(url, content);
                    if (result.IsSuccessStatusCode)
                    {
                        var responseContent = result.Content;
                        string works = responseContent.ReadAsStringAsync().Result;
                        return works;
                    }//end if
                    string errorMessage = result.StatusCode.ToString();
                    await App.Current.MainPage.DisplayAlert("", errorMessage, "", "Ok");
                    return errorMessage;
                }//end try
                catch (AggregateException ex)
                {
                    string ErrorMessage = ex.InnerException.Message == "A task was canceled." ? "Try again letter connection" +
                                            " time out, try again letter" : "Turn on your internet conection then try again";
                    await App.Current.MainPage.DisplayAlert("", ErrorMessage, "", "Ok");
                    return ErrorMessage;
                }//catch AggregateEx
            }//end using
        }//end method

        public static List<TodayQuestion> quesitonTodayGET()
        {
            string todayDate = DateTime.Today.ToString("yyyy-MM-dd");
            List <TodayQuestion> list = new List<TodayQuestion>();
            
            string url = $"http://klasamaturalna.pl/ajax.php?get=quesitonTodayGET&date="+todayDate;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = httpClient.GetAsync(url).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var responseContent = result.Content;
                        string works = responseContent.ReadAsStringAsync().Result;
                        string[] array = works.Split('}');
                        Regex r = new Regex("id\":\"([0-9]+)\",\"date\":\"([0-9]{4}-[0-9]{2}-[0-9]{2})\",\"question_number\":\"" +
                                            "([0-9]{1,2})\",\"question_content\":\"([^\"]+)\",\"Img\":\"([^\"]+)");
                        foreach (string quest in array)
                        {
                            MatchCollection mch = r.Matches(quest);
                            foreach (Match item in mch)
                            {
                                string img = item.Groups[5].ToString().Replace("\\", "");
                                img = img.Replace("\"", "");
                                list.Add(new TodayQuestion()
                                {
                                    id = item.Groups[1].ToString(),
                                    date = item.Groups[2].ToString(),
                                    question_number = item.Groups[3].ToString(),
                                    question_content = item.Groups[4].ToString(),
                                    img_src = new UriImageSource()
                                    {
                                        Uri = new Uri(img)
                                    }
                                    
                                });
                            }
                        }
                        return list;
                    }//end if
                    string errorMessage = result.StatusCode.ToString();
                    App.Current.MainPage.DisplayAlert("", errorMessage, "", "Ok");
                    return list;
                }//end try
                catch (AggregateException ex)
                {
                    string ErrorMessage = ex.InnerException.Message == "A task was canceled." ? "Try again letter connection" +
                                            " time out, try again letter" : "Turn on your internet conection then try again";
                    App.Current.MainPage.DisplayAlert("",ErrorMessage, "", "Ok");
                    return list;
                }//catch AggregateEx
            }//end using
        }//end method


        public static Question qeustionRandomGET(int id)
        {
            Question question = new Question();

            string url = $"http://klasamaturalna.pl/ajax.php?get=qeustionRandomGET&id={id}";

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = httpClient.GetAsync(url).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var responseContent = result.Content;
                        string works = responseContent.ReadAsStringAsync().Result;
                        Regex r = new Regex("\"pytanie\":\"([^\"]+)\",\"odpowiedz\":\"([^\"]+)\",\"img\":(null|\"[^\"]+)");
                        MatchCollection mch = r.Matches(works);
                        foreach (Match ite in mch)
                        {
                            question.pytanie = ite.Groups[1].ToString();
                            question.odpowiedz = ite.Groups[2].ToString();
                            question.img = ite.Groups[3].ToString();
                        }
                        return question;
                    }//end if
                    string errorMessage = result.StatusCode.ToString();
                    App.Current.MainPage.DisplayAlert("", errorMessage, "", "Ok");
                    return question;
                }//end try
                catch (AggregateException ex)
                {
                    string ErrorMessage = ex.InnerException.Message == "A task was canceled." ? "Try again letter connection" +
                                            " time out, try again letter" : "Turn on your internet conection then try again";
                    App.Current.MainPage.DisplayAlert("", ErrorMessage, "", "Ok");
                    return question;
                }//catch AggregateEx
            }//end using
        }//end method


        public static int countRandomQuesitonsGET()
        {
            string url = $"http://klasamaturalna.pl/ajax.php?get=countRandomQuesitonsGET";

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = httpClient.GetAsync(url).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var responseContent = result.Content;
                        string works = responseContent.ReadAsStringAsync().Result;
                        string toReturn = "";
                        Regex r = new Regex("([0-9^+])");
                        MatchCollection mch = r.Matches(works);
                        foreach (Match item in mch)
                        {
                            toReturn = item.Groups[0].ToString();
                        }
                        return int.Parse(toReturn);
                    }//end if
                    string errorMessage = result.StatusCode.ToString();
                    App.Current.MainPage.DisplayAlert("", errorMessage, "", "Ok");
                    return -1;
                }//end try
                catch (AggregateException ex)
                {
                    string ErrorMessage = ex.InnerException.Message == "A task was canceled." ? "Try again letter connection" +
                                            " time out, try again letter" : "Turn on your internet conection then try again";
                    App.Current.MainPage.DisplayAlert("", ErrorMessage, "", "Ok");
                    return -1;
                }//catch AggregateEx
            }//end using
        }//end method
    }
}
