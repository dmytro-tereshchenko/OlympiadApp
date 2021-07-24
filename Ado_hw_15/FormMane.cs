using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ado_hw_15
{
    public partial class FormMane : Form
    {
        private DbContextOptions<OlympiadContext> options;
        public FormMane()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "Year";
            comboBox2.DisplayMember = "Name";
            comboBox3.DisplayMember = "Name";
            comboBox4.DisplayMember = "Name";
            comboBox4.DisplayMember = "Name";
            comboBox5.DisplayMember = "FullName";
            comboBox6.DisplayMember = "Name";
            comboBox7.DisplayMember = "ResultView";
            Configures config = new Configures("appsettings.json");
            options = config.GetOptions("DefaultConnection");
            OlympiadContext db = new OlympiadContext(options);
            UpdateComboBoxOlympiad(db, false);
            UpdateComboBoxCountry(db, false);
            UpdateComboBoxCity(db, false);
            UpdateComboBoxTypeOfSport(db, false);
            UpdateComboBoxParticipant(db, false);
            UpdateComboBoxDiscipline(db, false);
            UpdateComboBoxResultParticipant(db);
            //string picturesDirectoryPath = config.GetStringParameter("PicturesDirectoryPath");
            //pictureBox1.Image = PictureCreator.GetImage($"{picturesDirectoryPath}1.jpg");
        }
        private void UpdateComboBoxOlympiad(OlympiadContext db, bool closeConnection = true)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(db.Olympiads.ToArray());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        private void UpdateComboBoxCountry(OlympiadContext db, bool closeConnection = true)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(db.Countries.ToArray());
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        private void UpdateComboBoxCity(OlympiadContext db, bool closeConnection = true)
        {
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(db.Cities.ToArray());
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        private void UpdateComboBoxTypeOfSport(OlympiadContext db, bool closeConnection = true)
        {
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(db.TypeOfSports.ToArray());
            if (comboBox4.Items.Count > 0)
            {
                comboBox4.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        private void UpdateComboBoxParticipant(OlympiadContext db, bool closeConnection = true)
        {
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(db.Participants.ToArray());
            if (comboBox5.Items.Count > 0)
            {
                comboBox5.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        private void UpdateComboBoxDiscipline(OlympiadContext db, bool closeConnection = true)
        {
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(db.Disciplines.ToArray());
            if (comboBox6.Items.Count > 0)
            {
                comboBox6.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }
        private void UpdateComboBoxResultParticipant(OlympiadContext db, bool closeConnection = true)
        {
            comboBox7.Items.Clear();
            comboBox7.Items.AddRange(db.ResultParticipants.ToArray());
            if (comboBox7.Items.Count > 0)
            {
                comboBox7.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            using(OlympiadContext db = new OlympiadContext(options))
            {
                Olympiad olympiad = db.Olympiads.Find((comboBox1.SelectedItem as Olympiad).Year);
                if (olympiad != null)
                {
                    db.Olympiads.Remove(olympiad);
                    db.SaveChanges();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                return;
            }
            using (OlympiadContext db = new OlympiadContext(options))
            {
                Country country = db.Countries.Find((comboBox2.SelectedItem as Country).Id);
                if (country != null)
                {
                    db.Countries.Remove(country);
                    db.SaveChanges();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                return;
            }
            using (OlympiadContext db = new OlympiadContext(options))
            {
                City city = db.Cities.Find((comboBox3.SelectedItem as City).Id);
                if (city != null)
                {
                    db.Cities.Remove(city);
                    db.SaveChanges();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                return;
            }
            using (OlympiadContext db = new OlympiadContext(options))
            {
                TypeOfSport typeOfSport = db.TypeOfSports.Find((comboBox4.SelectedItem as TypeOfSport).Id);
                if (typeOfSport != null)
                {
                    db.TypeOfSports.Remove(typeOfSport);
                    db.SaveChanges();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == -1)
            {
                return;
            }
            using (OlympiadContext db = new OlympiadContext(options))
            {
                Participant participant = db.Participants.Find((comboBox5.SelectedItem as Participant).Id);
                if (participant != null)
                {
                    db.Participants.Remove(participant);
                    db.SaveChanges();
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                return;
            }
            using (OlympiadContext db = new OlympiadContext(options))
            {
                Discipline discipline = db.Disciplines.Find((comboBox6.SelectedItem as Discipline).Id);
                if (discipline != null)
                {
                    db.Disciplines.Remove(discipline);
                    db.SaveChanges();
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == -1)
            {
                return;
            }
            using (OlympiadContext db = new OlympiadContext(options))
            {
                ResultParticipant resultParticipant = db.ResultParticipants.Find((comboBox7.SelectedItem as ResultParticipant).Id);
                if (resultParticipant != null)
                {
                    db.ResultParticipants.Remove(resultParticipant);
                    db.SaveChanges();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOlympiad form = new FormOlympiad(options);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateComboBoxOlympiad(new OlympiadContext(options));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOlympiad form = new FormOlympiad(options);
            form.Olympiad = comboBox1.SelectedItem as Olympiad;
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateComboBoxOlympiad(new OlympiadContext(options));
            }
        }
    }
}
