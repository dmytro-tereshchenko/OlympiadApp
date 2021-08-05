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
            OlympiadContext db = new OlympiadContext(options);
            UpdateComboBoxTypeOfSport(db, false);
            UpdateComboBoxOlympiad(db);
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
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in {this}, create object {typeof(Discipline)}, exception: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
