﻿using FPLedit.Shared.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPLedit.Shared;
using System.Diagnostics;

namespace FPLedit.Kursbuch.Forms
{
    public class Preview : IPreviewable
    {
        public string DisplayName => "Kursbuch";

        public void Show(IInfo info)
        {
            HtmlExport exp = new HtmlExport();
            string path = info.GetTemp("kfpl.html");

            bool tryoutConsole = info.Settings.Get<bool>("kfpl.console");
            bool success = exp.Exp(info.Timetable, path, info, tryoutConsole);

            if (success)
                Process.Start(path);
        }
    }
}