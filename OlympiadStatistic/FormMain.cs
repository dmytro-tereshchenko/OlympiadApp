using Microsoft.EntityFrameworkCore;
using OlympiadLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlympiadStatistic
{
    public partial class FormMain : Form
    {
        private DbContextOptions<OlympiadContext> options;
        private DataGridView dataGridViewTabPage1;
        private DataGridView dataGridViewTabPage2;
        private DataGridView dataGridViewTabPage3;
        private DataGridView dataGridViewTabPage4;
        private DataGridView dataGridViewTabPage5;
        private DataGridView dataGridViewTabPage6;
        private DataGridView dataGridViewTabPage7;
        public FormMain()
        {
            InitializeComponent();

            this.dataGridViewTabPage1 = new DataGridView();
            this.dataGridViewTabPage1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabPage1.Location = new Point(14, 44);
            this.dataGridViewTabPage1.Margin = new Padding(4, 3, 4, 3);
            this.dataGridViewTabPage1.Name = "dataGridViewTabPage1";
            this.dataGridViewTabPage1.Size = new Size(841, 328);
            this.tabPage1.Controls.Add(this.dataGridViewTabPage1);

            this.dataGridViewTabPage2 = new DataGridView();
            this.dataGridViewTabPage2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabPage2.Location = new Point(14, 44);
            this.dataGridViewTabPage2.Margin = new Padding(4, 3, 4, 3);
            this.dataGridViewTabPage2.Name = "dataGridViewTabPage2";
            this.dataGridViewTabPage2.Size = new Size(841, 328);
            this.tabPage2.Controls.Add(this.dataGridViewTabPage2);

            this.dataGridViewTabPage3 = new DataGridView();
            this.dataGridViewTabPage3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabPage3.Location = new Point(14, 44);
            this.dataGridViewTabPage3.Margin = new Padding(4, 3, 4, 3);
            this.dataGridViewTabPage3.Name = "dataGridViewTabPage3";
            this.dataGridViewTabPage3.Size = new Size(841, 328);
            this.tabPage3.Controls.Add(this.dataGridViewTabPage3);

            this.dataGridViewTabPage4 = new DataGridView();
            this.dataGridViewTabPage4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabPage4.Location = new Point(14, 44);
            this.dataGridViewTabPage4.Margin = new Padding(4, 3, 4, 3);
            this.dataGridViewTabPage4.Name = "dataGridViewTabPage4";
            this.dataGridViewTabPage4.Size = new Size(841, 328);
            this.tabPage4.Controls.Add(this.dataGridViewTabPage4);

            this.dataGridViewTabPage5 = new DataGridView();
            this.dataGridViewTabPage5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabPage5.Location = new Point(14, 14);
            this.dataGridViewTabPage5.Margin = new Padding(4, 3, 4, 3);
            this.dataGridViewTabPage5.Name = "dataGridViewTabPage5";
            this.dataGridViewTabPage5.Size = new Size(841, 358);
            this.tabPage5.Controls.Add(this.dataGridViewTabPage5);

            this.dataGridViewTabPage6 = new DataGridView();
            this.dataGridViewTabPage6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabPage6.Location = new Point(14, 44);
            this.dataGridViewTabPage6.Margin = new Padding(4, 3, 4, 3);
            this.dataGridViewTabPage6.Name = "dataGridViewTabPage6";
            this.dataGridViewTabPage6.Size = new Size(841, 328);
            this.tabPage6.Controls.Add(this.dataGridViewTabPage6);

            this.dataGridViewTabPage7 = new DataGridView();
            this.dataGridViewTabPage7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabPage7.Location = new Point(14, 44);
            this.dataGridViewTabPage7.Margin = new Padding(4, 3, 4, 3);
            this.dataGridViewTabPage7.Name = "dataGridViewTabPage7";
            this.dataGridViewTabPage7.Size = new Size(841, 328);
            this.tabPage7.Controls.Add(this.dataGridViewTabPage7);

            comboBoxTabPage1.DisplayMember = "Year";
            comboBoxTabPage2.DisplayMember = "Year";
            comboBoxTabPage3.DisplayMember = "Year";
            comboBoxTabPage4.DisplayMember = "Name";
            comboBoxTabPage6_Olympiad.DisplayMember = "Year";
            comboBoxTabPage6_Country.DisplayMember = "Name";
            comboBoxTabPage7_Olympiad.DisplayMember = "Year";
            comboBoxTabPage7_Country.DisplayMember = "Name";
            Configures config = new Configures("appsettings.json");
            options = config.GetOptions("DefaultConnection");
            OlympiadContext db = new OlympiadContext(options);
            ComboBoxControl.UpdateComboBoxOlympiad(db, comboBoxTabPage1, false);
            ComboBoxControl.UpdateComboBoxOlympiad(db, comboBoxTabPage2, false);
            ComboBoxControl.UpdateComboBoxOlympiad(db, comboBoxTabPage3, false);
            ComboBoxControl.UpdateComboBoxTypeOfSport(db, comboBoxTabPage4, false);
            ComboBoxControl.UpdateComboBoxOlympiad(db, comboBoxTabPage6_Olympiad, false);
            ComboBoxControl.UpdateComboBoxOlympiad(db, comboBoxTabPage7_Olympiad);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTabPage1.SelectedIndex != -1)
            {
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    var countGoldMedals = db.ResultParticipants
                        .Include(r => r.Discipline)
                        .Include(r => r.Participant)
                        .Include(r => r.Participant.Country)
                        .Where(r => r.Discipline.OlympiadYear == (comboBoxTabPage1.SelectedItem as Olympiad).Year && r.Position == 1)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, GoldMedals = r.Count() });
                    var countSilverMedals = db.ResultParticipants
                        .Where(r => r.Discipline.OlympiadYear == (comboBoxTabPage1.SelectedItem as Olympiad).Year && r.Position == 2)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, SilverMedals = r.Count() });
                    var countBronzeMedals = db.ResultParticipants
                        .Where(r => r.Discipline.OlympiadYear == (comboBoxTabPage1.SelectedItem as Olympiad).Year && r.Position == 3)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, BronzeMedals = r.Count() });
                    dataGridViewTabPage1.DataSource = countGoldMedals.Outer()
                        .FullOuterJoin(countSilverMedals.Outer(),
                        gold => gold.Country,
                        silver => silver.Country,
                        (gold, silver) => new
                        {
                            Country = gold?.Country ?? silver?.Country,
                            GoldMedals = gold?.GoldMedals ?? 0,
                            SilverMedals = silver?.SilverMedals ?? 0
                        })
                        .FullOuterJoin(countBronzeMedals.Outer(),
                        g_s => g_s.Country,
                        bronze => bronze.Country,
                        (g_s, bronze) => new
                        {
                            Country = g_s?.Country ?? bronze?.Country,
                            GoldMedals = g_s?.GoldMedals ?? 0,
                            SilverMedals = g_s?.SilverMedals ?? 0,
                            BronzeMedals = bronze?.BronzeMedals ?? 0,
                            Total = (g_s?.GoldMedals ?? 0) + (g_s?.SilverMedals ?? 0) + (bronze?.BronzeMedals ?? 0)
                        })
                        .OrderByDescending(m => m.GoldMedals)
                        .ThenByDescending(m => m.SilverMedals)
                        .ThenByDescending(m => m.BronzeMedals)
                        .ToList();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTabPage2.SelectedIndex != -1)
            {
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    dataGridViewTabPage2.DataSource = db.ResultParticipants
                        .Include(r => r.Discipline)
                        .Include(r => r.Participant)
                        .Include(r => r.Participant.Country)
                        .Include(r => r.Discipline.TypeOfSport)
                        .AsEnumerable()
                        .Where(r => r.Discipline.OlympiadYear == (comboBoxTabPage2.SelectedItem as Olympiad).Year && r.Position < 4)
                        .Select((p, index) => new
                        {
                            index,
                            Participant = p.Participant.FullName,
                            Country = p.Participant.Country.Name,
                            TypeOfSport = p.Discipline.TypeOfSport.Name,
                            Position = p.Position
                        })
                        .ToList();
                }
            }
        }

        private void comboBoxTabPage3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTabPage3.SelectedIndex != -1)
            {
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    var countGoldMedals = db.ResultParticipants
                        .Include(r => r.Discipline)
                        .Include(r => r.Participant)
                        .Include(r => r.Participant.Country)
                        .Where(r => r.Discipline.OlympiadYear == (comboBoxTabPage3.SelectedItem as Olympiad).Year && r.Position == 1)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, GoldMedals = r.Count() });
                    dataGridViewTabPage3.DataSource = countGoldMedals
                        .Where(m => m.GoldMedals == countGoldMedals.Max(m=>m.GoldMedals))
                        .ToList();
                }
            }
        }

        private void comboBoxTabPage4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTabPage4.SelectedIndex != -1)
            {
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    var countGoldMedals = db.ResultParticipants
                        .Include(r => r.Discipline)
                        .Include(r => r.Participant)
                        .Include(r => r.Participant.Country)
                        .AsEnumerable()
                        .Where(r => r.Discipline.TypeOfSportId == (comboBoxTabPage4.SelectedItem as TypeOfSport).Id && r.Position == 1)
                        .GroupBy(r => new
                        {
                            r.Participant.FullName,
                            r.Participant.Country.Name
                        })
                        .Select(r => new
                        {
                            Participant = r.Key.FullName,
                            Country = r.Key.Name,
                            GoldMedals = r.Count()
                        });
                    dataGridViewTabPage4.DataSource = countGoldMedals
                        .Where(m => m.GoldMedals == countGoldMedals.Max(m => m.GoldMedals))
                        .ToList();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((sender as TabControl).SelectedIndex == 4)
            {
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    var countHostCountry = db.Olympiads
                        .Include(o => o.HostCountry)
                        .GroupBy(o => o.HostCountry.Name)
                        .Select(o => new { Country = o.Key, AmountOlympiads = o.Count() });
                    dataGridViewTabPage5.DataSource = countHostCountry
                        .Where(o => o.AmountOlympiads == countHostCountry.Max(o => o.AmountOlympiads))
                        .ToList();
                }
            }
        }

        private void comboBoxTabPage6_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTabPage6_Olympiad.SelectedIndex != -1 && comboBoxTabPage6_Country.SelectedIndex != -1)
            {
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    dataGridViewTabPage6.DataSource = db.Disciplines
                        .Where(d => d.OlympiadYear == (comboBoxTabPage6_Olympiad.SelectedItem as Olympiad).Year)
                        .Join(db.DisciplineParticipants,
                            dis => dis.Id,
                            disPar => disPar.DisciplineId,
                            (dis, disPar) => disPar)
                        .Join(db.Participants,
                            disPar => disPar.ParticipantId,
                            p => p.Id,
                            (disPar, p) => p)
                        .Where(p => p.CountryId == (comboBoxTabPage6_Country.SelectedItem as Country).Id)
                        .Select(p => new
                        {
                            FullName = p.FullName,
                            DateOfBirth = p.DateOfBirth,
                            Country = p.Country.Name
                        })
                        .ToList();
                }
            }
        }

        private void comboBoxTabPage6_Olympiad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTabPage6_Olympiad.SelectedIndex != -1)
            {
                OlympiadContext db = new OlympiadContext(options);
                ComboBoxControl.UpdateComboBoxCountry(db, comboBoxTabPage6_Country, comboBoxTabPage6_Olympiad.SelectedItem as Olympiad);
            }
        }

        private void comboBoxTabPage7_Olympiad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTabPage7_Olympiad.SelectedIndex != -1)
            {
                OlympiadContext db = new OlympiadContext(options);
                ComboBoxControl.UpdateComboBoxCountry(db, comboBoxTabPage7_Country, comboBoxTabPage7_Olympiad.SelectedItem as Olympiad);
            }
        }

        private void comboBoxTabPage7_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTabPage7_Olympiad.SelectedIndex != -1 && comboBoxTabPage7_Country.SelectedIndex != -1)
            {
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    var countGoldMedals = db.ResultParticipants
                        .Include(r => r.Discipline)
                        .Include(r => r.Participant)
                        .Include(r => r.Participant.Country)
                        .Where(r => r.Discipline.OlympiadYear == (comboBoxTabPage7_Olympiad.SelectedItem as Olympiad).Year &&
                            r.Position == 1 &&
                            r.Participant.CountryId == (comboBoxTabPage7_Country.SelectedItem as Country).Id)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, GoldMedals = r.Count() });
                    var countSilverMedals = db.ResultParticipants
                        .Where(r => r.Discipline.OlympiadYear == (comboBoxTabPage7_Olympiad.SelectedItem as Olympiad).Year &&
                            r.Position == 2 &&
                            r.Participant.CountryId == (comboBoxTabPage7_Country.SelectedItem as Country).Id)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, SilverMedals = r.Count() });
                    var countBronzeMedals = db.ResultParticipants
                        .Where(r => r.Discipline.OlympiadYear == (comboBoxTabPage7_Olympiad.SelectedItem as Olympiad).Year &&
                            r.Position == 3 &&
                            r.Participant.CountryId == (comboBoxTabPage7_Country.SelectedItem as Country).Id)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, BronzeMedals = r.Count() });
                    dataGridViewTabPage7.DataSource = countGoldMedals.Outer()
                        .FullOuterJoin(countSilverMedals.Outer(),
                        gold => gold.Country,
                        silver => silver.Country,
                        (gold, silver) => new
                        {
                            Country = gold?.Country ?? silver?.Country,
                            GoldMedals = gold?.GoldMedals ?? 0,
                            SilverMedals = silver?.SilverMedals ?? 0
                        })
                        .FullOuterJoin(countBronzeMedals.Outer(),
                        g_s => g_s.Country,
                        bronze => bronze.Country,
                        (g_s, bronze) => new
                        {
                            Country = g_s?.Country ?? bronze?.Country,
                            GoldMedals = g_s?.GoldMedals ?? 0,
                            SilverMedals = g_s?.SilverMedals ?? 0,
                            BronzeMedals = bronze?.BronzeMedals ?? 0,
                            Total = (g_s?.GoldMedals ?? 0) + (g_s?.SilverMedals ?? 0) + (bronze?.BronzeMedals ?? 0)
                        })
                        .ToList();
                }
            }
        }
    }
}
