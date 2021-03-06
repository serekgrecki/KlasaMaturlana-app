﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KlasaMaturalna.Models
{
     public class TodayQuestion
    {
        public string id { get; set; }
        public string date { get; set; }
        public string question_number { get; set; }
        public string question_content { get; set; }
        public UriImageSource img_src { get; set; }

        public string AsString()
        {
            return $"{question_number}. {question_content}";
        }
    }
}
