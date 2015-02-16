﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Buchfahrplan.FileModel
{
    [Serializable]
    public sealed class Train
    {
        public string Name { get; set; }

        public string Line { get; set; }

        public Dictionary<Station, DateTime> Arrivals { get; set; }

        public Dictionary<Station, DateTime> Departures { get; set; }

        public string Locomotive { get; set; }

        public bool Negative { get; set; }


        /*public bool Monday { get; set; }


        public bool Tuesday { get; set; }


        public bool Wednesday { get; set; }


        public bool Thursday { get; set; }


        public bool Friday { get; set; }


        public bool Saturday { get; set; }


        public bool Sunday { get; set; }*/
    }
}
