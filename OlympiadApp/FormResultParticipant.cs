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
    public partial class FormResultParticipant : Form
    {
        private DbContextOptions<OlympiadContext> options;
        private ResultParticipant resultParticipant;
        public FormResultParticipant(DbContextOptions<OlympiadContext> options)
        {
            InitializeComponent();
            this.options = options;
            resultParticipant = null;
            comboBox1.DisplayMember = "FullName";
            comboBox2.DisplayMember = "Name";
            ComboBoxControl.UpdateComboBoxDiscipline(new OlympiadContext(options), comboBox2);
        }
        public ResultParticipant ResultParticipant
        {
            set
            {
                resultParticipant = value;
                ComboBoxControl.SelectParticipant(comboBox1, resultParticipant.ParticipantId);
                ComboBoxControl.SelectDiscipline(comboBox2, resultParticipant.DisciplineId);
                numericUpDown1.Value = Convert.ToDecimal(resultParticipant.Position is null ? 0 : resultParticipant.Position.Value);
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
                if (comboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Field Participant i required");
                    return;
                }
                try
                {
                    if (resultParticipant == null)
                    {
                        resultParticipant = new ResultParticipant();
                        db.ResultParticipants.Add(resultParticipant);
                    }
                    else
                    {
                        resultParticipant = db.ResultParticipants.Find(resultParticipant.Id);
                    }
                    resultParticipant.ParticipantId = (comboBox1.SelectedItem as Participant).Id;
                    resultParticipant.DisciplineId = (comboBox2.SelectedItem as Discipline).Id;
                    if(numericUpDown1.Value == 0)
                    {
                        resultParticipant.Position = null;
                    }
                    else
                    {
                        resultParticipant.Position = Convert.ToInt32(numericUpDown1.Value);
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in {this}, create object {typeof(ResultParticipant)}, exception: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxControl.UpdateComboBoxParticipant(new OlympiadContext(options), comboBox1, comboBox2.SelectedItem as Discipline);
        }
    }
}
