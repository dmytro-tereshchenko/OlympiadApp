using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using OlympiadLibrary;

namespace OlympiadApp
{
    public partial class FormOlympiad : Form
    {
        private DbContextOptions<OlympiadContext> options;
        private Olympiad olympiad;
        public FormOlympiad(DbContextOptions<OlympiadContext> options)
        {
            InitializeComponent();
            this.options = options;
            olympiad = null;
            comboBox1.DisplayMember = "Name";
            comboBox2.DisplayMember = "Name";
            listBox1.DisplayMember = "Name";
            OlympiadContext db = new OlympiadContext(options);
            ComboBoxControl.UpdateComboBoxCountry(db, comboBox1, false);
            ComboBoxControl.UpdateComboBoxCity(db, comboBox2);
        }
        public Olympiad Olympiad
        {
            set
            {
                olympiad = value;
                numericUpDown1.Value = olympiad.Year;
                foreach (Country item in comboBox1.Items)
                {
                    if (item.Id == olympiad.HostCountryId)
                    {
                        comboBox1.SelectedItem = item;
                        break;
                    }
                }
                using(OlympiadContext db = new OlympiadContext(options))
                {
                    ComboBoxControl.UpdateComboBoxCity(db, comboBox2, false);
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(db.CityOlympiads
                        .Where(co=>co.OlympiadYear==olympiad.Year)
                        .Join(db.Cities,
                        citOl => citOl.CityId,
                        c => c.Id,
                        (citOl, c) => c).ToArray());
                };
                if (olympiad.IsSummer)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                ComboBoxControl.UpdateComboBoxCity(new OlympiadContext(options), comboBox2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OlympiadContext db = new OlympiadContext(options))
            {
                try
                {
                    if (olympiad == null)
                    {
                        olympiad = new Olympiad();
                        db.Olympiads.Add(olympiad);
                    }
                    else
                    {
                        olympiad = db.Olympiads.Find(olympiad.Year);
                    }
                    olympiad.Year = Convert.ToInt32(numericUpDown1.Value);
                    olympiad.HostCountryId = (comboBox1.SelectedItem as Country).Id;
                    olympiad.IsSummer = radioButton1.Checked;
                    db.CityOlympiads.RemoveRange(db.CityOlympiads.Where(co => co.OlympiadYear == olympiad.Year));
                    foreach (City city in listBox1.Items)
                    {
                        olympiad.CityOlympiads.Add(new CityOlympiad()
                        {
                            CityId = city.Id,
                            OlympiadYear = olympiad.Year
                        });
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in {this}, create object {typeof(Olympiad)}, exception: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1 && !listBox1.Items.Contains(comboBox2.SelectedItem))
            {
                listBox1.Items.Add(comboBox2.SelectedItem);
            }
        }
    }
}
