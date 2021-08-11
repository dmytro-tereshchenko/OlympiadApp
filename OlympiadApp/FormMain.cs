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


namespace OlympiadApp
{
    public partial class FormMain : Form
    {
        private DbContextOptions<OlympiadContext> options;
        public FormMain()
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
            ComboBoxControl.UpdateComboBoxOlympiad(db, comboBox1, false);
            ComboBoxControl.UpdateComboBoxCountry(db, comboBox2, false);
            ComboBoxControl.UpdateComboBoxCity(db, comboBox3, false);
            ComboBoxControl.UpdateComboBoxTypeOfSport(db, comboBox4, false);
            ComboBoxControl.UpdateComboBoxParticipant(db, comboBox5, false);
            ComboBoxControl.UpdateComboBoxDiscipline(db, comboBox6, false);
            ComboBoxControl.UpdateComboBoxResultParticipant(db, comboBox7);
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
                    ComboBoxControl.UpdateComboBoxOlympiad(db, comboBox1, false);
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
                    ComboBoxControl.UpdateComboBoxCountry(db, comboBox2, false);
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
                    ComboBoxControl.UpdateComboBoxCity(db, comboBox3, false);
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
                    ComboBoxControl.UpdateComboBoxTypeOfSport(db, comboBox4, false);
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
                    ComboBoxControl.UpdateComboBoxParticipant(db, comboBox5, false);
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
                    ComboBoxControl.UpdateComboBoxDiscipline(db, comboBox6, false);
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
                    ComboBoxControl.UpdateComboBoxResultParticipant(db, comboBox7, false);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOlympiad form = new FormOlympiad(options);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxOlympiad(new OlympiadContext(options), comboBox1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOlympiad form = new FormOlympiad(options);
            form.Olympiad = comboBox1.SelectedItem as Olympiad;
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxOlympiad(new OlympiadContext(options), comboBox1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormCity form = new FormCity(options);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxCity(new OlympiadContext(options), comboBox3, false);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormCity form = new FormCity(options);
            form.City = comboBox3.SelectedItem as City;
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxCity(new OlympiadContext(options), comboBox3, false);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormCountry form = new FormCountry(options);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxCountry(new OlympiadContext(options), comboBox2);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormCountry form = new FormCountry(options);
            form.Country = comboBox2.SelectedItem as Country;
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxCountry(new OlympiadContext(options), comboBox2);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormTypeOfSport form = new FormTypeOfSport(options);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxTypeOfSport(new OlympiadContext(options), comboBox4);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormTypeOfSport form = new FormTypeOfSport(options);
            form.TypeOfSport = comboBox4.SelectedItem as TypeOfSport;
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxTypeOfSport(new OlympiadContext(options), comboBox4);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            FormDiscipline form = new FormDiscipline(options);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxDiscipline(new OlympiadContext(options), comboBox6);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            FormDiscipline form = new FormDiscipline(options);
            form.Discipline = comboBox6.SelectedItem as Discipline;
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxDiscipline(new OlympiadContext(options), comboBox6);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FormParticipant form = new FormParticipant(options);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxParticipant(new OlympiadContext(options), comboBox5);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FormParticipant form = new FormParticipant(options);
            form.Participant = comboBox5.SelectedItem as Participant;
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxParticipant(new OlympiadContext(options), comboBox5);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            FormResultParticipant form = new FormResultParticipant(options);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxResultParticipant(new OlympiadContext(options), comboBox7);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            FormResultParticipant form = new FormResultParticipant(options);
            form.ResultParticipant = comboBox7.SelectedItem as ResultParticipant;
            if (form.ShowDialog() == DialogResult.OK)
            {
                ComboBoxControl.UpdateComboBoxResultParticipant(new OlympiadContext(options), comboBox7);
            }
        }
    }
}
