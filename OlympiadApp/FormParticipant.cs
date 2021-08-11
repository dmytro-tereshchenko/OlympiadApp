using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OlympiadApp
{
    public partial class FormParticipant : Form
    {
        private DbContextOptions<OlympiadContext> options;
        private Participant participant;
        public FormParticipant(DbContextOptions<OlympiadContext> options)
        {
            InitializeComponent();
            this.options = options;
            participant = null;
            comboBox1.DisplayMember = "Name";
            comboBox2.DisplayMember = "Name";
            listBox1.DisplayMember = "Name";
            OlympiadContext db = new OlympiadContext(options);
            ComboBoxControl.UpdateComboBoxTypeOfSport(db, comboBox2, false);
            ComboBoxControl.UpdateComboBoxCountry(db, comboBox1);
        }
        public Participant Participant
        {
            set
            {
                participant = value;
                textBox1.Text = participant.FirstName;
                textBox2.Text = participant.MiddleName;
                textBox3.Text = participant.LastName;
                ComboBoxControl.SelectCountry(comboBox1, participant.CountryId);
                dateTimePicker1.Value = participant.DateOfBirth;
                if (participant.Photo != null)
                {
                    pictureBox1.Image = Image.FromStream(new MemoryStream(participant.Photo));
                }
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    ComboBoxControl.UpdateComboBoxTypeOfSport(db, comboBox2, false);
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(db.ParticipantTypeOfSports
                        .Where(pts => pts.ParticipantId == participant.Id)
                        .Join(db.TypeOfSports,
                        parSport => parSport.TypeOfSportId,
                        s => s.Id,
                        (parSport, s) => s).ToArray());
                };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1 && !listBox1.Items.Contains(comboBox2.SelectedItem))
            {
                listBox1.Items.Add(comboBox2.SelectedItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                message.Append("FirstName i required field\n");
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                message.Append("LastName i required field");
            }
            if (message.Length > 1)
            {
                MessageBox.Show(message.ToString());
                return;
            }
            using (OlympiadContext db = new OlympiadContext(options))
            {
                try
                {
                    if (participant == null)
                    {
                        participant = new Participant();
                        db.Participants.Add(participant);
                    }
                    else
                    {
                        participant = db.Participants.Find(participant.Id);
                    }
                    participant.FirstName = textBox1.Text;
                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        participant.MiddleName = textBox2.Text;
                    }
                    participant.LastName = textBox3.Text;
                    participant.CountryId = (comboBox1.SelectedItem as Country).Id;
                    participant.DateOfBirth = dateTimePicker1.Value.Date;
                    if (pictureBox1.Image != null)
                    {
                        participant.Photo = PictureCreator.GetBytesFromImage(pictureBox1.Image);
                    }
                    db.ParticipantTypeOfSports
                        .RemoveRange(db.ParticipantTypeOfSports
                        .Where(pts => pts.ParticipantId == participant.Id));
                    foreach (TypeOfSport typeOfSport in listBox1.Items)
                    {
                        participant.ParticipantTypeOfSports.Add(new ParticipantTypeOfSport()
                        {
                            ParticipantId = participant.Id,
                            TypeOfSportId = typeOfSport.Id
                        });
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in {this}, create object {typeof(Participant)}, exception: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.InitialDirectory = Directory.GetCurrentDirectory();
                file.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF)|*.BMP;*.JPG;*.JPEG;*.GIF";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = PictureCreator.GetImage(file.FileName);
                }
            }
        }
    }
}
