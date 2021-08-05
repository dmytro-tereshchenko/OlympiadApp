using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OlympiadApp
{
    public partial class FormCountry : Form
    {
        private DbContextOptions<OlympiadContext> options;
        private Country country;
        public FormCountry(DbContextOptions<OlympiadContext> options)
        {
            InitializeComponent();
            this.options = options;
            country = null;
            OlympiadContext db = new OlympiadContext(options);
        }
        public Country Country
        {
            set
            {
                country = value;
                textBox1.Text = country.Name;
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
                    MessageBox.Show("Enter name of country");
                    return;
                }
                try
                {
                    if (country == null)
                    {
                        country = new Country();
                        db.Countries.Add(country);
                    }
                    else
                    {
                        country = db.Countries.Find(country.Id);
                    }
                    country.Name = textBox1.Text;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in {this}, create object {typeof(Country)}, exception: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
