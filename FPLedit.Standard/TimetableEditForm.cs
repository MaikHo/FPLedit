﻿using FPLedit.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private DataGridView focused;

        private Font fb, fn;

        public TimetableEditForm()
        {
            InitializeComponent();
            fb = new Font(DefaultFont, FontStyle.Bold);
            fn = new Font(DefaultFont, FontStyle.Regular);
        }

        public TimetableEditForm(IInfo info) : this()
        {
            this.info = info;
            info.BackupTimetable();

            topLineLabel.Text = "Züge " + info.Timetable.GetLineName(TOP_DIRECTION);
            bottomLineLabel.Text = "Züge " + info.Timetable.GetLineName(BOTTOM_DIRECTION);

            InitializeGridView(topDataGridView, TOP_DIRECTION);
            InitializeGridView(bottomDataGridView, BOTTOM_DIRECTION);

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.T)
                {
                    e.Handled = true;
                    ViewDependantAction(Trapez);
                }
                else if (e.KeyCode == Keys.Z)
                {
                    e.Handled = true;
                    ViewDependantAction(Zuglaufmeldung);
                }
            };
        }

        private void InitializeGridView(DataGridView view, TrainDirection direction)
        {
            var stas = info.Timetable.GetStationsOrderedByDirection(direction);
            foreach (var sta in stas)
            {
                if (stas.First() != sta)
                    view.Columns.Add(stas.IndexOf(sta) + "ar", sta.SName + " an");
                if (stas.Last() != sta)
                    view.Columns.Add(stas.IndexOf(sta) + "dp", sta.SName + " ab");
            }

            foreach (var tra in info.Timetable.Trains.Where(t => t.Direction == direction))
            {
                DataGridViewRow trainRow = view.Rows[view.Rows.Add()];

                var fb = new Font(DefaultFont, FontStyle.Bold);
                foreach (var sta in info.Timetable.Stations)
                {
                    var ardp = tra.GetArrDep(sta);
                    var ar = ardp.Arrival.ToShortTimeString();
                    var dp = ardp.Departure.ToShortTimeString();
                    if (ar != "00:00")
                        trainRow.Cells[stas.IndexOf(sta) + "ar"].Value = ar;
                    if (dp != "00:00")
                        trainRow.Cells[stas.IndexOf(sta) + "dp"].Value = dp;
                    if (stas.First() != sta)
                    {
                        var cell = trainRow.Cells[stas.IndexOf(sta) + "ar"];
                        cell.Tag = new Tuple<bool, string>(ardp.TrapeztafelHalt, ardp.Zuglaufmeldung);
                        cell.Style.BackColor = ardp.TrapeztafelHalt ? Color.LightGray : Color.White;
                        if (ardp.Zuglaufmeldung != null && ardp.Zuglaufmeldung != "")
                            cell.Style.Font = fb;
                    }
                }

                trainRow.Tag = tra;
                trainRow.HeaderCell = new DataGridViewRowHeaderCell() { Value = tra.TName };
            }

            foreach (DataGridViewColumn column in view.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            view.GotFocus += (s, e) => focused = view;

            view.SelectionChanged += (s, e) =>
            {
                if (view.SelectedCells.Count != 0)
                {
                    var cell = view.SelectedCells[0];
                    trapeztafelToggle.Enabled = zlmButton.Enabled = cell.ColumnIndex != 0 && cell.ColumnIndex % 2 != 0;

                    var tr = false;
                    if (cell.Tag != null)
                    {
                        var val = (Tuple<bool, string>)cell.Tag;
                        tr = val.Item1;
                    }
                    trapeztafelToggle.Checked = tr;
                }
            };
        }

        private bool UpdateTrainDataFromGrid(Train train, DataGridView view)
        {
            foreach (DataGridViewRow row in view.Rows)
            {
                Train t = (Train)row.Tag;

                if (t != train)
                    continue;

                var stas = info.Timetable.GetStationsOrderedByDirection(train.Direction);
                foreach (var sta in stas)
                {
                    ArrDep ardp = new ArrDep();
                    if (view.Columns.Contains(stas.IndexOf(sta) + "ar"))
                    {
                        DataGridViewCell cellAr = row.Cells[stas.IndexOf(sta) + "ar"];

                        if ((string)cellAr.Value != "" && cellAr.Value != null)
                        {
                            TimeSpan tsAr = TimeSpan.Parse((string)cellAr.Value);
                            ardp.Arrival = tsAr;
                            if (cellAr.Tag != null)
                            {
                                var val = (Tuple<bool, string>)cellAr.Tag;
                                ardp.TrapeztafelHalt = val.Item1;
                                ardp.Zuglaufmeldung = val.Item2;
                            }
                        }
                    }

                    if (view.Columns.Contains(stas.IndexOf(sta) + "dp"))
                    {
                        DataGridViewCell cellDp = row.Cells[stas.IndexOf(sta) + "dp"];

                        if ((string)cellDp.Value != "" && cellDp.Value != null)
                        {
                            TimeSpan tsDp = TimeSpan.Parse((string)cellDp.Value);
                            ardp.Departure = tsDp;
                            if (cellDp.Tag != null)
                                throw new Exception("Keine Abfahrtszelle darf einen Trapeztafelhalt/Zugalufmeldungseintrag enthalten!");
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
            if (e.FormattedValue == null || (string)e.FormattedValue == "")
                return;

            string val = (string)e.FormattedValue;
            if (val.Length == 4 && char.IsDigit(val[0]) && char.IsDigit(val[1]) && char.IsDigit(val[2]) && char.IsDigit(val[3]))
            {
                val = val.Substring(0, 2) + ":" + val.Substring(2, 2);
                view.EditingControl.Text = val;
            }

            if (!TimeSpan.TryParse(val, out TimeSpan ts))
            {
                MessageBox.Show("Formatierungsfehler: Zeit muss im Format hh:mm vorliegen!");
                e.Cancel = true;
            }
        }

        private void Trapez(DataGridView view)
        {
            var cells = view.SelectedCells;
            if (cells.Count == 0)
                return;

            var cell = cells[0];
            if (cell.ColumnIndex == 0 || cell.ColumnIndex % 2 == 0)
                return;

            var val = (Tuple<bool, string>)cell.Tag;
            var trapez = !(val?.Item1 ?? false);
            cell.Tag = new Tuple<bool, string>(trapez, val?.Item2 ?? "");

            cell.Style.BackColor = trapez ? Color.LightGray : Color.White;
            trapeztafelToggle.Checked = trapez;
        }

        private void Zuglaufmeldung(DataGridView view)
        {
            var cells = view.SelectedCells;
            if (cells.Count == 0)
                return;

            var cell = cells[0];
            if (cell.ColumnIndex == 0 || cell.ColumnIndex % 2 == 0)
                return;

            var val = (Tuple<bool, string>)cell.Tag;
            var zlmDialog = new ZlmEditForm(val?.Item2 ?? "");
            if (zlmDialog.ShowDialog() != DialogResult.OK)
                return;

            cell.Tag = new Tuple<bool, string>(val?.Item1 ?? false, zlmDialog.Zlm);

            cell.Style.Font = zlmDialog.Zlm != "" ? fb : fn;
        }

        private void ViewDependantAction(Action<DataGridView> action)
        {
            if (focused == topDataGridView)
                action(topDataGridView);
            else if (focused == bottomDataGridView)
                action(bottomDataGridView);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            foreach (var t in info.Timetable.Trains)
            {
                if ((t.Direction == TOP_DIRECTION && !UpdateTrainDataFromGrid(t, topDataGridView))
                    || (t.Direction == BOTTOM_DIRECTION && !UpdateTrainDataFromGrid(t, bottomDataGridView)))
                    throw new Exception("In der Anwendung ist ein interner Fehler aufgetreten!");
            }

            info.ClearBackup();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            info.RestoreTimetable();

            Close();
        }

        private void trapeztafelToggle_Click(object sender, EventArgs e)
            => ViewDependantAction(Trapez);

        private void zlmButton_Click(object sender, EventArgs e)
            => ViewDependantAction(Zuglaufmeldung);

        private void topDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            => ValidateCell(topDataGridView, e);

        private void bottomDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            => ValidateCell(bottomDataGridView, e);
    }
}
