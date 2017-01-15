﻿using FPLedit.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPLedit.Standard
{
    public partial class TimetableEditForm : Form
    {
        private IInfo info;

        private const TrainDirection TOP_DIRECTION = TrainDirection.ti;
        private const TrainDirection BOTTOM_DIRECTION = TrainDirection.ta;

        public TimetableEditForm()
        {
            InitializeComponent();
        }

        public TimetableEditForm(IInfo info) : this()
        {
            this.info = info;
            info.BackupTimetable();

            topLineLabel.Text = "Züge " + info.Timetable.GetLineName(TOP_DIRECTION);
            bottomLineLabel.Text = "Züge " + info.Timetable.GetLineName(BOTTOM_DIRECTION);

            InitializeGridView(topDataGridView, TOP_DIRECTION);
            InitializeGridView(bottomDataGridView, BOTTOM_DIRECTION);
        }

        private void InitializeGridView(DataGridView view, TrainDirection direction)
        {
            var stations = info.Timetable.GetStationsOrderedByDirection(direction);
            foreach (var sta in stations)
            {
                if (stations.First() != sta)
                    view.Columns.Add(sta.SName + "ar", sta.SName + " an");
                if (stations.Last() != sta)
                    view.Columns.Add(sta.SName + "dp", sta.SName + " ab");
            }

            foreach (var tra in info.Timetable.Trains.Where(t => t.Direction == direction))
            {
                DataGridViewRow trainRow = view.Rows[view.Rows.Add()];

                foreach (var sta in info.Timetable.Stations)
                {
                    var ardp = tra.GetArrDep(sta);
                    var ar = ardp.Arrival.ToShortTimeString();
                    var dp = ardp.Departure.ToShortTimeString();
                    if (ar != "00:00")
                        trainRow.Cells[sta.SName + "ar"].Value = ar;
                    if (dp != "00:00")
                        trainRow.Cells[sta.SName + "dp"].Value = dp;
                }

                trainRow.Tag = tra;
                trainRow.HeaderCell = new DataGridViewRowHeaderCell() { Value = tra.TName };
            }

            foreach (DataGridViewColumn column in view.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private bool UpdateTrainDataFromGrid(Train train, DataGridView view)
        {
            foreach (DataGridViewRow row in view.Rows)
            {
                Train t = (Train)row.Tag;

                if (t != train)
                    continue;

                foreach (var sta in info.Timetable.Stations)
                {
                    ArrDep ardp = new ArrDep(); 
                    if (view.Columns.Contains(sta.SName + "ar"))
                    {
                        DataGridViewCell cellAr = row.Cells[sta.SName + "ar"];

                        if ((string)cellAr.Value != "" && cellAr.Value != null)
                        {
                            TimeSpan tsAr = TimeSpan.Parse((string)cellAr.Value);
                            ardp.Arrival = tsAr;
                        }
                    }

                    if (view.Columns.Contains(sta.SName + "dp"))
                    {
                        DataGridViewCell cellDp = row.Cells[sta.SName + "dp"];

                        if ((string)cellDp.Value != "" && cellDp.Value != null)
                        {
                            TimeSpan tsDp = TimeSpan.Parse((string)cellDp.Value);
                            ardp.Departure = tsDp;
                        }
                    }

                    t.SetArrDep(sta, ardp);
                }
                return true;
            }

            return false;
        }

        private void ValidateCell(DataGridView view, DataGridViewCellValidatingEventArgs e)
        {
            TimeSpan ts;
            if (e.FormattedValue == null || (string)e.FormattedValue == "")
                return;

            if (!TimeSpan.TryParse((string)e.FormattedValue, out ts))
            {
                MessageBox.Show("Formatierungsfehler: Zeit muss im Format hh:mm vorliegen!");
                e.Cancel = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            foreach (var t in info.Timetable.Trains)
                if (!(UpdateTrainDataFromGrid(t, topDataGridView) || UpdateTrainDataFromGrid(t, bottomDataGridView)))
                    throw new Exception("In der Anwendung ist ein interner Fehler aufgetreten!");

            info.ClearBackup();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            info.RestoreTimetable();

            Close();
        }        

        private void topDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            => ValidateCell(topDataGridView, e);

        private void bottomDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            => ValidateCell(bottomDataGridView, e);
    }
}
