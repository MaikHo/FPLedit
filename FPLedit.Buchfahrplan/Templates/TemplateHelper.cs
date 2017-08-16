﻿using FPLedit.Buchfahrplan.Model;
using FPLedit.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPLedit.Buchfahrplan.Templates
{
    public class TemplateHelper
    {
        public BfplAttrs Attrs { get; set; }
        public Timetable TT { get; set; }

        public string HtmlName(string name, string prefix)
        {
            return prefix + name.Replace("#", "")
                .Replace(" ", "-")
                .Replace(".", "-")
                .Replace(":", "-")
                .ToLower();
        }

        public List<IStation> GetStations(TrainDirection dir)
        {
            List<IStation> points = new List<IStation>();
            points.AddRange(TT.Stations);
            if (Attrs != null)
                points.AddRange(Attrs.Points);

            var oPoints = (dir == TrainDirection.ta ?
                points.OrderByDescending(o => o.Kilometre)
                : points.OrderBy(o => o.Kilometre));

            return oPoints.ToList();
        }

        public string OptAttr(string caption, string value)
        {
            if (value != null && value != "")
                return caption + " " + value;
            return "";
        }

        public string Kreuzt(Train ot, Station s)
        {
            var t = IntersectTrains(ot, s, true);
            if (t == null)
                return "";
            return t.TName + " " + IntersectDaysSt(ot, t);
        }

        public string Ueberholt(Train ot, Station s)
        {
            var t = IntersectTrains(ot, s, false);
            if (t == null)
                return "";
            return t.TName + " " + IntersectDaysSt(ot, t);
        }

        public string TrapezHalt(Train ot, Station s)
        {
            var it = IntersectTrains(ot, s, true);
            if (it == null)
                return "";

            var oth = ot.GetArrDep(s).TrapeztafelHalt;
            var ith = it.GetArrDep(s).TrapeztafelHalt;

            if (oth && !ith)
                return "<span class=\"trapez-tt\">" + ot.TName + "</span> " + IntersectDaysSt(ot, it);
            if (ith && !oth)
                return it.TName + " " + IntersectDaysSt(ot, it);
            if (ith && oth)
                return "<span class=\"trapez-tt\">" + ot.TName + "</span> " + IntersectDaysSt(ot, it);
            return "";
        }

        private string IntersectDaysSt(Train ot, Train t)
            => DaysHelper.DaysToString(DaysHelper.IntersectingDays(ot.Days, t.Days), true);

        private Train IntersectTrains(Train ot, Station s, bool kreuzung)
        {
            TimeSpan start = ot.GetArrDep(s).Arrival;
            TimeSpan end = ot.GetArrDep(s).Departure;

            if (start == TimeSpan.Zero || end == TimeSpan.Zero)
                return null;

            Func<Train, bool> pred = (t => t.Direction == ot.Direction); // Überholung
            if (kreuzung)
                pred = (t => t.Direction != ot.Direction); // Kreuzung

            foreach (var train in TT.Trains.Where(pred))
            {
                if (train == ot)
                    continue;

                TimeSpan start2 = train.GetArrDep(s).Arrival;
                TimeSpan end2 = train.GetArrDep(s).Departure;

                if (start2 == TimeSpan.Zero || end2 == TimeSpan.Zero)
                    continue;

                var st = start < start2 ? start2 : start;
                var en = end < end2 ? end : end2;
                var crossing = st < en ? true : false;

                if (crossing && DaysHelper.IntersectDays(ot.Days, train.Days))
                    return train;
            }

            return null;
        }
    }
}