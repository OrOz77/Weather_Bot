﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_Weather_Bot.API
{

    public class LUISModel
    {
        public string query { get; set; }
        public Topscoringintent topScoringIntent { get; set; }
        public Intent[] intents { get; set; }
        public object[] entities { get; set; }
    }

    public class Topscoringintent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

}