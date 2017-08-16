﻿using FPLedit.Aushangfahrplan.Model;
using FPLedit.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPLedit.Aushangfahrplan.Templates
{
    partial class AfplTemplate : IAfplTemplate
    {
        private Timetable tt;
        private string font = "Arial";
        private string hwFont = "serif";
        private string additionalCss = "";
        private string abfahrtSVG;

        protected bool useSVG = false;

        public virtual string Name => "Standard (DRG aus Malsch)";

        private TemplateHelper helper;

        public virtual string GetResult(Timetable tt)
        {
            abfahrtSVG = useSVG ? Properties.Resources.abfahrt_text : "Abfahrt";

            this.tt = tt;
            helper = new TemplateHelper(tt);

            var attrs = AfplAttrs.GetAttrs(tt);
            if (attrs != null)
            {
                if (attrs.Font != "")
                    font = attrs.Font;
                if (attrs.HwFont != "")
                    hwFont = attrs.HwFont;
                additionalCss = attrs.Css ?? "";
            }

            GenerationEnvironment = null; //BUGFIX: Clear last build
            return TransformText();
        }

        public string GetDays(Train t)
            => DaysHelper.DaysToString(t.Days, true);

        private string GetTimeString(TimeSpan t)
            => t.Hours.ToString() + "<sup>" + t.Minutes.ToString("00") + "</sup>";

        private string TimeString(Train[] trains, Station sta, int i)
            => trains.Count() > i ? GetTimeString(trains[i].GetArrDep(sta).Departure) + " " + GetDays(trains[i]) : "";

        private string NameString(Train[] trains, int i)
            => trains.Count() > i ? trains[i].TName : "";
    }

    public class SvgAfplTemplate : AfplTemplate, IAfplTemplate
    {
        public override string Name => "Wie Standard, mit Schriftzug \"Abfahrt\" in Originalschrift";

        public SvgAfplTemplate()
        {
            useSVG = true;
        }
    }
}