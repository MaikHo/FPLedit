﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FPLedit.Shared
{
    [Serializable]
    public sealed class Timetable : Entity
    {
        public const string MAGIC = "BFPL/1.1";

        public string Name { get; set; }

        public List<Station> Stations { get; set; }

        public List<Train> Trains { get; set; }        

        public Timetable() : base()
        {
            Stations = new List<Station>();
            Trains = new List<Train>();

            Name = "";
        }        

        public List<Station> GetStationsOrderedByDirection(TrainDirection direction)
        {
            return (direction.Get() ?
                Stations.OrderByDescending(s => s.Kilometre)
                : Stations.OrderBy(s => s.Kilometre)).ToList();
        }

        public string GetLineName(TrainDirection direction)
        {
            string first = GetStationsOrderedByDirection(direction).First().Name;
            string last = GetStationsOrderedByDirection(direction).Last().Name;

            return first + " - " + last;
        }

        public override string ToString()
        {
            return GetLineName(TrainDirection.ta);
        }

        public Timetable Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return (Timetable)formatter.Deserialize(stream);
            }
        }

        /*public static Timetable GenerateTestTimetable()
        {
            Timetable t = new Timetable();
            t.Name = "ATal - BTal";
            Station a = new Station() { Name = "ATal", Kilometre = 0.0f };
            Station b = new Station() { Name = "BTal", Kilometre = 1.0f };
            Train tr = new Train() { Name = "P 01", Locomotive = "211" };
            tr.Line = "ATal - BTal";
            tr.Direction = true;
            tr.Arrivals = new Dictionary<Station, TimeSpan>();
            tr.Departures = new Dictionary<Station, TimeSpan>();
            tr.Arrivals.Add(b, DateTime.Now.TimeOfDay);
            tr.Departures.Add(a, DateTime.Now.TimeOfDay);

            Train t2 = new Train() { Name = "P 01", Locomotive = "211" };
            t2.Arrivals = new Dictionary<Station, TimeSpan>();
            t2.Departures = new Dictionary<Station, TimeSpan>();
            t2.Arrivals.Add(b, DateTime.Now.TimeOfDay);
            t2.Departures.Add(a, DateTime.Now.TimeOfDay);

            t.Stations = new List<Station>();
            t.Trains = new List<Train>();
            t.Stations.Add(b);
            t.Stations.Add(a);
            t.Trains.Add(tr);
            t.Trains.Add(t2);

            return t;
        }*/
    }
}