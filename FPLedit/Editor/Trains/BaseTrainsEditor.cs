﻿using Eto.Forms;
using FPLedit.Shared;
using FPLedit.Shared.UI;
using System.Linq;

namespace FPLedit.Editor.Trains
{
    internal abstract class BaseTrainsEditor : FDialog<DialogResult>
    {
        private readonly Timetable tt;

        public BaseTrainsEditor(Timetable tt)
        {
            this.tt = tt;
        }

        protected void UpdateListView(GridView view, TrainDirection direction)
        {
            view.DataStore = tt.Trains.Where(t => t.Direction == direction);
        }

        protected void DeleteTrain(GridView view, TrainDirection dir, bool message = true)
        {
            if (view.SelectedItem != null)
            {
                if (view.SelectedItem is Train train)
                {
                    if (train.TrainLinks.Any(l => l.TrainCount > 0))
                    {
                        if (message)
                            MessageBox.Show(T._("Der Zug kann nicht gelöscht werden, da er mindestens von einem verlinkten Zug referenziert wird!"), T._("Zug löschen"));
                    }
                    else
                    {
                        tt.RemoveTrain(train);
                        UpdateListView(view, dir);
                    }
                }
                else if (message)
                    MessageBox.Show(T._("Verlinke Züge können nicht gelöscht werden."), T._("Zug löschen"));
            }
            else if (message)
                MessageBox.Show(T._("Zuerst muss ein Zug ausgewählt werden!"), T._("Zug löschen"));
        }

        protected void EditTrain(GridView view, TrainDirection dir, bool message = true)
        {
            if (view.SelectedItem != null)
            {
                if (view.SelectedItem is Train tra)
                {
                    using (var tef = new TrainEditForm(tra))
                        if (tef.ShowModal(this) == DialogResult.Ok)
                            UpdateListView(view, dir);
                }
                else if (message)
                    MessageBox.Show(T._("Verlinke Züge können nicht bearbeitet werden."), T._("Zug bearbeiten"));
            }
            else if (message)
                MessageBox.Show(T._("Zuerst muss ein Zug ausgewählt werden!"), T._("Zug bearbeiten"));
        }

        protected void NewTrain(GridView view, TrainDirection direction)
        {
            using (var tef = new TrainEditForm(tt, direction))
            {
                if (tef.ShowModal(this) == DialogResult.Ok)
                {
                    tt.AddTrain(tef.Train);
                    if (tef.NextTrains.Any())
                        tt.SetTransitions(tef.Train, tef.NextTrains);

                    UpdateListView(view, direction);
                }
            }
        }

        protected void CopyTrain(GridView view, TrainDirection dir, bool message = true)
        {
            if (view.SelectedItem != null)
            {
                if (view.SelectedItem is Train train)
                {
                    using (var tcf = new TrainCopyDialog(train, tt))
                        tcf.ShowModal(this);

                    UpdateListView(view, dir);
                }
                else if (message)
                    MessageBox.Show(T._("Verlinke Züge können nicht kopiert werden."), T._("Zug kopieren"));
            }
            else if (message)
                MessageBox.Show(T._("Zuerst muss ein Zug ausgewählt werden!"), T._("Zug kopieren"));
        }

        protected void SortTrains(GridView view, TrainDirection dir)
        {
            using (var tsd = new TrainSortDialog(dir, tt))
                if (tsd.ShowModal(this) == DialogResult.Ok)
                    UpdateListView(view, dir);
        }
    }
}