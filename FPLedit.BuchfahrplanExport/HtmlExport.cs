﻿using FPLedit.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FPLedit.BuchfahrplanExport
{
    public class HtmlExport : IExport
    {

        public string Filter
        {
            get { return "Buchfahrplan als HTML Datei (*.html)|*.html"; }
        }

        public bool Reoppenable
        {
            get { return false; }
        }

        public bool Export(Timetable timetable, string filename, ILog logger)
        {
            BuchfahrplanTemplate templ = new BuchfahrplanTemplate(timetable);
            string cont = templ.TransformText();
            File.WriteAllText(filename, cont);
            return true;
        }
    }
}