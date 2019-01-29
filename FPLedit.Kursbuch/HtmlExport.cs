﻿using FPLedit.Shared;
using FPLedit.Shared.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FPLedit.Kursbuch
{
    public class HtmlExport : IExport
    {
        public string Filter => "Tabellenfahrplan/Kursbuch als HTML Datei (*.html)|*.html";

        internal bool Exp(Timetable tt, string filename, IInfo info, bool tryout_console)
        {
            var chooser = new KfplTemplateChooser(info);

            ITemplate templ = chooser.GetTemplate(tt);
            string cont = templ.GenerateResult(tt);

            if (cont == null)
                return false;

            if (tryout_console)
                cont += global::ResourceHelper.GetStringResource("Kursbuch.Resources.TryoutScript.txt");

            File.WriteAllText(filename, cont);

            return true;
        }

        public bool Export(Timetable tt, string filename, IInfo info)
            => Exp(tt, filename, info, false);
    }
}
