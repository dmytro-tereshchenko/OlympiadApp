using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OlympiadApp
{
    public partial class FormDiscipline : Form
    {
        private DbContextOptions<OlympiadContext> options;
        private Discipline discipline;
        public FormDiscipline(DbContextOptions<OlympiadContext> options)
        {
            InitializeComponent();
            this.options = options;
            discipline = null;
            comboBox1.DisplayMember = "Name";
            comboBox2.DisplayMember = "Year";
            comboBox3.DisplayMember = "FullName";
            listBox1.DisplayMember = "FullName";
            OlympiadContext db = new OlympiadContext(options);
            UpdateComboBoxTypeOfSport(db, false);
            UpdateComboBoxOlympiad(db, false);
            UpdateComboBoxParticipant(db);
        }

        public Discipline Discipline
        {
            set
            {
                discipline = value;
                foreach (TypeOfSport item in comboBox1.Items)
                {
                    if (item.Id == discipline.TypeOfSportId)
                    {
                        comboBox1.SelectedItem = item;
                        break;
                    }
                }
                foreach (Olympiad item in comboBox2.Items)
                {
                    if (item.Year == discipline.OlympiadYear)
                    {
                        comboBox2.SelectedItem = item;
                        break;
                    }
                }
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    UpdateComboBoxParticipant(db, false);
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(db.DisciplineParticipants
                        .Where(dp => dp.DisciplineId == discipline.Id)
                        .Join(db.Participants,
                        discPart => discPart.ParticipantId,
                        p => p.Id,
                        (discPart, p) => p).ToArray());
                };
            }
        }

        private void UpdateComboBoxOlympiad(OlympiadContext db, bool closeConnection = true)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(db.Olympiads.ToArray());
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }

        private void UpdateComboBoxTypeOfSport(OlympiadContext db, bool closeConnection = true)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(db.TypeOfSports.ToArray());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }

        private void UpdateComboBoxParticipant(OlympiadContext db, bool closeConnection = true)
        {
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(db.Participants.ToArray());
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OlympiadContext db = new OlympiadContext(options))
            {
                try
                {
                    if (discipline == null)
                    {
                        discipline = new Discipline();
                        db.Disciplines.Add(discipline);
                    }
                    else
                    {
                        discipline = db.Disciplines.Find(discipline.Id);
                    }
                    discipline.TypeOfSportId = (comboBox1.SelectedItem as TypeOfSport).Id;
                    discipline.OlympiadYear = (comboBox2.SelectedItem as Olympiad).Year;
                    db.DisciplineParticipants
                        .RemoveRange(db.DisciplineParticipants
                        .Where(dp => dp.DisciplineId == discipline.Id));
                    foreach (Participant participant in listBox1.Items)
                    {
                        discipline.DisciplineParticipants.Add(new DisciplineParticipant()
                        {
                            DisciplineId = discipline.Id,
                            ParticipantId = participant.Id
                        });
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in {this}, create object {typeof(Discipline)}, exception: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1 && !listBox1.Items.Contains(comboBox3.SelectedItem))
            {
                listBox1.Items.Add(comboBox3.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
    }
}
