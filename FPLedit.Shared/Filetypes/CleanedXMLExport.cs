﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FPLedit.Shared.Filetypes
{
    public class CleanedXMLExport : IExport
    {
        public string Filter => "Bereinigte Fahrplan Dateien (*.fpl)|*.fpl";

        private string[] node_names = new[]
        {
            "bfpl_attrs",   // Buchfahrplaneigenschaften
        };

        private string[] attrs_names = new[]
        {
            "fpl-vmax",     // Höchstgeschwindigkeit
            "fpl-wl",       // Wellenlinien
            "fpl-tr",       // Trapeztafel
            "fpl-zlm",      // Zuglaufmeldung
            "fpl-tfz",      // Triebfahrzeug
            "fpl-mbr",      // Mindestbremshundertstel
            "fpl-last",     // max. Last eines Zuges
        };

        private XElement BuildNode(XMLEntity node)
        {
            XElement elm = new XElement(node.XName);
            if (node.Value != null)
                elm.SetValue(node.Value);

            var f_attrs = node.Attributes.Where(a => !attrs_names.Contains(a.Key));
            foreach (var attr in f_attrs)
                elm.SetAttributeValue(attr.Key, attr.Value);

            var f_nodes = node.Children.Where(c => !node_names.Contains(c.XName));
            foreach (var ch in f_nodes)
                elm.Add(BuildNode(ch));
            return elm;
        }

        public bool Export(Timetable tt, string filename, IInfo info)
        {
            var res = MessageBox.Show("Hiermit werden alle in FPLedit zusätzlich eingebenen Werte (z.B. Lokomotiven, Lasten, Mindestbremshundertstel, Geschwindigkeiten, Wellenlinien, Trapeztafelhalte und Zuglaufmeldungen) und Buchfahrplaneinstellungen aus dem gespeicherten Fahrplan gelöscht! Fortfahren?",
                "FPLedit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.No)
                return false;

            bool debug = SettingsManager.Get<bool>("xml.indent");
#if DEBUG
            debug = true;
#endif
            try
            {
                var clone = tt.Clone(); // Klon zum anschließenden Verwerfen!
                var ttElm = BuildNode(clone.XMLEntity);

                using (var writer = new XmlTextWriter(filename, new UTF8Encoding(false)))
                {
                    if (debug)
                        writer.Formatting = Formatting.Indented;
                    ttElm.Save(writer);
                }
                return true;
            }
            catch (Exception ex)
            {
                info.Logger.Error("XMLExport: " + ex.Message);
                return false;
            }
        }
    }
}