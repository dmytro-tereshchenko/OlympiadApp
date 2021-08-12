using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OlympiadLibrary;

namespace OlympiadApp
{
    public partial class FormTypeOfSport : Form
    {
        private DbContextOptions<OlympiadContext> options;
        private TypeOfSport typeOfSport;
        public FormTypeOfSport(DbContextOptions<OlympiadContext> options)
        {
            InitializeComponent();
            this.options = options;
            typeOfSport = null;
            OlympiadContext db = new OlympiadContext(options);
        }
        public TypeOfSport TypeOfSport
        {
            set
            {
                typeOfSport = value;
                textBox1.Text = typeOfSport.Name;
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
                    MessageBox.Show("Enter name of type of sport");
                    return;
                }
                try
                {
                    if (typeOfSport == null)
                    {
                        typeOfSport = new TypeOfSport();
                        db.TypeOfSports.Add(typeOfSport);
                    }
                    else
                    {
                        typeOfSport = db.TypeOfSports.Find(typeOfSport.Id);
                    }
                    typeOfSport.Name = textBox1.Text;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in {this}, create object {typeof(TypeOfSport)}, exception: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
