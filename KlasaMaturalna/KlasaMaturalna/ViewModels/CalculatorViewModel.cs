using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using KlasaMaturalna.Services;
using Xamarin.Forms;

namespace KlasaMaturalna.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private int _queueNumberIndex;
        public int QueueNumberIndex
        {
            get { return _queueNumberIndex; }
            set
            {
                _queueNumberIndex = value;
                OnPropetyChanged();
            }
        }

        private int _hourIndex;
        public int HourIndex
        {
            get { return _hourIndex; }
            set
            {
                _hourIndex = value;
                OnPropetyChanged();
            }
        }

        private bool _resultVisable;
        public bool ResultVisable
        {
            get { return _resultVisable; }
            set
            {
                _resultVisable = value;
                OnPropetyChanged();
            }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropetyChanged();
            }
        }

        private List<String> _hoursList;
        public List<String> HoursList
        {
            get { return _hoursList; }
            set
            {
                _hoursList = value;
                OnPropetyChanged();
            }
        }
        private List<String> _queueNumberList;
        public List<String> QueueNumberList
        {
            get { return _queueNumberList; }
            set
            {
                _queueNumberList = value;
                OnPropetyChanged();
            }
        }

        public CalculatorViewModel()
        {
           var calculatorPageServices = new CalculatorPageServices();
            HoursList = calculatorPageServices.GetHours();
            QueueNumberList = calculatorPageServices.GetNumbersQueue();
        }

        public Command GetResponseCommand
        {
            get
            {
                return new Command(() =>
                {
                    buttonClick();
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropetyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

        private void buttonClick()
        {
            int[] points = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
                13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24,
                25, 26, 27, 28, 29, 30, 31, 32
            };
            int ExamTime = HourIndex;
            List<int> currArray = new List<int>();
            switch (ExamTime)
            {
                case 0:
                    for (int o = 0; o < 28; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 1:
                    for (int o = 3; o < 31; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 2:
                    for (int o = 6; o < 32; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 3:
                    for (int o = 9; o < 32; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 4:
                    for (int o = 12; o < 32; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 5:
                    for (int o = 15; o < 32; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 6:
                    for (int o = 18; o < 32; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 7:
                    for (int o = 21; o < 32; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 8:
                    for (int o = 24; o < 32; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
                case 9:
                    for (int o = 27; o < 32; o++)
                    {
                        currArray.Add(points[o]);
                    }
                    break;
            }
            int numer = QueueNumberIndex;
            List<int> currentGroup = new List<int>();
            List<int> arrayToReturn = new List<int>();
            int x = 0;
            if (numer < 5)
            {
                try
                {
                    for (int k = 0; k < 7; k++)
                    {
                        currentGroup.Add(currArray[k]);
                    }
                }
                catch (Exception ex) { }
            }
            else if (numer >= 5 && numer < 10)
            {
                try
                {
                    for (int k = 7; k < 14; k++)
                    {
                        currentGroup.Add(currArray[k]);
                    }
                }
                catch (Exception ex) { }
            }
            else if (numer >= 10 && numer < 15)
            {
                try
                {
                    for (int k = 14; k < 21; k++)
                    {
                        currentGroup.Add(currArray[k]);
                    }
                }
                catch (Exception ex) { }
            }
            else if (numer >= 15)
            {
                try
                {
                    for (int k = 21; k < 28; k++)
                    {
                        currentGroup.Add(currArray[k]);
                    }
                }
                catch (Exception ex) { }
            }

            int removeCount = (numer + 1) % 5;
            switch (removeCount)
            {
                case 0:
                    x = 0;
                    break;
                case 1:
                    x = 4;
                    break;
                case 2:
                    x = 3;
                    break;
                case 3:
                    x = 2;
                    break;
                case 4:
                    x = 1;
                    break;
            }
            try
            {
                for (int i = 0; i < currentGroup.Count - x; i++)
                {
                    arrayToReturn.Add(currentGroup[i]);
                }
            }
            catch (Exception ex)
            {

            }
            string toReturn = " ";
            foreach (int item in arrayToReturn)
            {
                toReturn += item + " ";
            }
            Result = toReturn;
            ResultVisable = true;
        }
    }
}
