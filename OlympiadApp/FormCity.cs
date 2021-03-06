using Microsoft.EntityFrameworkCore;
using OlympiadLibrary;
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
    public partial class FormCity : Form
    {
        private DbContextOptions<OlympiadContext> options;
        private City city;
        public FormCity(DbContextOptions<OlympiadContext> options)
        {
            InitializeComponent();
            this.options = options;
            city = null;
            comboBox1.DisplayMember = "Name";
            OlympiadContext db = new OlympiadContext(options);
            ComboBoxControl.UpdateComboBoxCountry(db, comboBox1);
        }
        public City City
        {
            set
            {
                city = value;
                textBox1.Text = city.Name;
                foreach (Country item in comboBox1.Items)
                {
                    if (item.Id == city.CountryId)
                    {
                        comboBox1.SelectedItem = item;
                        break;
                    }
                }
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
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Enter name of city");
                    return;
                }
                try
                {
                    if (city == null)
                    {
                        city = new City();
                        db.Cities.Add(city);
                    }
                    else
                    {
                        city = db.Cities.Find(city.Id);
                    }
                    city.Name = textBox1.Text;
                    city.CountryId = (comboBox1.SelectedItem as Country).Id;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in {this}, create object {typeof(City)}, exception: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
