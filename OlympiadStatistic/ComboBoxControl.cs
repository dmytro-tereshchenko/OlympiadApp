using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OlympiadApp
{
    public static class ComboBoxControl
    {
        public static void UpdateComboBoxOlympiad(OlympiadContext db, ComboBox comboBox, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.Olympiads.ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void UpdateComboBoxCountry(OlympiadContext db, ComboBox comboBox, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.Countries.ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void UpdateComboBoxCity(OlympiadContext db, ComboBox comboBox, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.Cities.ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void UpdateComboBoxTypeOfSport(OlympiadContext db, ComboBox comboBox, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.TypeOfSports.ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void UpdateComboBoxParticipant(OlympiadContext db, ComboBox comboBox, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.Participants.ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void UpdateComboBoxDiscipline(OlympiadContext db, ComboBox comboBox, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.Disciplines
                .Include(d => d.TypeOfSport)
                .ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void UpdateComboBoxResultParticipant(OlympiadContext db, ComboBox comboBox, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.ResultParticipants
                .Include(rp => rp.Participant)
                .Include(rp => rp.Discipline)
                .Include(rp => rp.Discipline.TypeOfSport)
                .ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void UpdateComboBoxParticipant(OlympiadContext db, ComboBox comboBox, Discipline discipline, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.DisciplineParticipants
                .Where(dp => dp.DisciplineId == discipline.Id)
                .Join(db.Participants,
                disPar => disPar.ParticipantId,
                p => p.Id,
                (disPar, p) => p)
                .ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void UpdateComboBoxCountry(OlympiadContext db, ComboBox comboBox, Olympiad olympiad, bool closeConnection = true)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.AddRange(db.Disciplines
                .Where(d => d.OlympiadYear == olympiad.Year)
                .Join(db.DisciplineParticipants,
                dis => dis.Id,
                disPar => disPar.DisciplineId,
                (dis, disPar) => disPar)
                .Join(db.Participants,
                disPar => disPar.ParticipantId,
                p => p.Id,
                (disPar, p) => p)
                .Join(db.Countries,
                p => p.CountryId,
                c => c.Id,
                (p, c) => c)
                .Distinct()
                .ToArray());
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        public static void SelectParticipant(ComboBox comboBox, int participantId)
        {
            foreach (Participant participant in comboBox.Items)
            {
                if (participant.Id == participantId)
                {
                    comboBox.SelectedItem = participant;
                    break;
                }
            }
        }
        public static void SelectDiscipline(ComboBox comboBox, int disciplineId)
        {
            foreach (Discipline discipline in comboBox.Items)
            {
                if (discipline.Id == disciplineId)
                {
                    comboBox.SelectedItem = discipline;
                    break;
                }
            }
        }
        public static void SelectTypeOfSport(ComboBox comboBox, int typeOfSportId)
        {
            foreach (TypeOfSport typeOfSport in comboBox.Items)
            {
                if (typeOfSport.Id == typeOfSportId)
                {
                    comboBox.SelectedItem = typeOfSport;
                    break;
                }
            }
        }
        public static void SelectOlympiad(ComboBox comboBox, int olympiadId)
        {
            foreach (Olympiad olympiad in comboBox.Items)
            {
                if (olympiad.Year == olympiadId)
                {
                    comboBox.SelectedItem = olympiad;
                    break;
                }
            }
        }
        public static void SelectCountry(ComboBox comboBox, int? countryId)
        {
            foreach (Country country in comboBox.Items)
            {
                if (country.Id == countryId)
                {
                    comboBox.SelectedItem = country;
                    break;
                }
            }
        }
    }
}
