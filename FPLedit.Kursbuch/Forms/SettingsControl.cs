﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FPLedit.Shared;
using FPLedit.Kursbuch.Model;
using System.Drawing.Text;
using System.Diagnostics;
using FPLedit.Shared.Ui;

namespace FPLedit.Kursbuch.Forms
{
    public partial class SettingsControl : UserControl, ISaveHandler, IExpertHandler
    {
        private ISettings settings;
        private KfplAttrs attrs;
        private KfplTemplateChooser chooser;

        private const string NO_KBS_TEXT = "<keine Nummer>";

        private SettingsControl()
        {
            InitializeComponent();

            kbsnListView.Columns.Add("Streckennummer");
            kbsnListView.Columns.Add("Strecke");
        }

        public SettingsControl(Timetable tt, IInfo info) : this()
        {
            settings = info.Settings;
            chooser = new KfplTemplateChooser(info);
            var templates = chooser.AvailableTemplates.Select(t => t.TemplateName).ToArray();
            templateComboBox.Items.AddRange(templates);

            attrs = KfplAttrs.GetAttrs(tt);
            if (attrs != null)
            {
                fontComboBox.Text = attrs.Font;
                cssTextBox.Text = attrs.Css ?? "";
            }
            else
            {
                attrs = new KfplAttrs(tt);
                tt.Children.Add(attrs.XMLEntity);
            }
            foreach (var route in tt.GetRoutes())
            {
                var kbs = attrs.KBSn.GetKbsn(route.Index) ?? NO_KBS_TEXT;
                kbsnListView.Items.Add(new ListViewItem(new[] { kbs, route.GetRouteName() }) { Tag = route });
            }

            var tmpl = chooser.GetTemplate(tt);
            templateComboBox.Text = tmpl.TemplateName;
        }

        private void SettingsControl_Load(object sender, EventArgs e)
        {
            string[] fontFamilies = new InstalledFontCollection().Families.Select(f => f.Name).ToArray();
            fontComboBox.Items.AddRange(fontFamilies);
            hwfontComboBox.Items.AddRange(fontFamilies);

            consoleCheckBox.Checked = settings.Get<bool>("kfpl.console");
        }

        private void cssHelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => Process.Start("https://fahrplan.manuelhu.de/dev/css/");

        private void fontComboBox_TextChanged(object sender, EventArgs e)
           => exampleLabel.Font = new Font(fontComboBox.Text, 10);

        private void hwfontComboBox_TextChanged(object sender, EventArgs e)
            => hwexampleLabel.Font = new Font(hwfontComboBox.Text, 10);

        private void cssTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Tab-Width anpassen
            int tabWidth = 4;
            if (e.KeyCode == Keys.Tab)
            {
                cssTextBox.SelectedText = new string(' ', tabWidth);
                e.SuppressKeyPress = true;
            }
        }

        public void Save()
        {
            attrs.Font = fontComboBox.Text;
            attrs.HeFont = hwfontComboBox.Text;
            attrs.Css = cssTextBox.Text;
            foreach (ListViewItem itm in kbsnListView.Items)
            {
                var route = (Route)itm.Tag;
                var kbs = itm.Text;
                if (kbs == NO_KBS_TEXT)
                    continue;
                attrs.KBSn.SetKbsn(route.Index, kbs);
            }

            var tmpl_idx = templateComboBox.SelectedIndex;
            if (tmpl_idx != -1)
            {
                var tmpl = chooser.AvailableTemplates[tmpl_idx];
                attrs.Template = tmpl.Identifier;
            }

            settings.Set("kfpl.console", consoleCheckBox.Checked);
        }

        public void SetExpertMode(bool enabled)
        {
            cssTextBox.Visible = cssLabel.Visible = cssHelpLinkLabel.Visible = consoleCheckBox.Visible = enabled;
        }
    }
}
