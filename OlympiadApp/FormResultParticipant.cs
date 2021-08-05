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
            UpdateComboBoxDiscipline(new OlympiadContext(options));
        }
        public ResultParticipant ResultParticipant
        {
            set
            {
                resultParticipant = value;
                foreach (Participant participant in comboBox1.Items)
                {
                    if (participant.Id == resultParticipant.ParticipantId)
                    {
                        comboBox1.SelectedItem = participant;
                        break;
                    }
                }
                foreach (Discipline discipline in comboBox2.Items)
                {
                    if (discipline.Id == resultParticipant.DisciplineId)
                    {
                        comboBox2.SelectedItem = discipline;
                        break;
                    }
                }
                numericUpDown1.Value = Convert.ToDecimal(resultParticipant.Position is null ? 0 : resultParticipant.Position.Value);
            }
        }

        private void UpdateComboBoxParticipant(OlympiadContext db, Discipline discipline, bool closeConnection = true)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox1.Items.AddRange(db.DisciplineParticipants
                .Where(dp => dp.DisciplineId == discipline.Id)
                .Join(db.Participants,
                disPar => disPar.ParticipantId,
                p => p.Id,
                (disPar, p) => p)
                .ToArray());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (closeConnection)
            {
                db.Dispose();
            }
        }

        private void UpdateComboBoxDiscipline(OlympiadContext db, bool closeConnection = true)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.Items.AddRange(db.Disciplines.Include(t => t.TypeOfSport).ToArray());
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
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
            UpdateComboBoxParticipant(new OlympiadContext(options), comboBox2.SelectedItem as Discipline);
        }
    }
}
