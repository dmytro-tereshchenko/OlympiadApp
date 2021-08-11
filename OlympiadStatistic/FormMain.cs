using Microsoft.EntityFrameworkCore;
using OlympiadApp;
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
        private DataGridView dataGridView1;
        public FormMain()
        {
            InitializeComponent();

            this.dataGridView1 = new DataGridView();
            ((ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 44);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(841, 328);
            this.dataGridView1.TabIndex = 0;

            this.tabPage1.Controls.Add(this.dataGridView1);
            ((ISupportInitialize)(this.dataGridView1)).EndInit();

            comboBox1.DisplayMember = "Year";
            Configures config = new Configures("appsettings.json");
            options = config.GetOptions("DefaultConnection");
            OlympiadContext db = new OlympiadContext(options);
            ComboBoxControl.UpdateComboBoxOlympiad(db, comboBox1, false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                using (OlympiadContext db = new OlympiadContext(options))
                {
                    var countGoldMedals = db.ResultParticipants
                        .Include(r => r.Discipline)
                        .Include(r => r.Participant)
                        .Include(r => r.Participant.Country)
                        .Where(r => r.Discipline.OlympiadYear == (comboBox1.SelectedItem as Olympiad).Year && r.Position == 1)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, GoldMedals = r.Count() });
                    var countSilverMedals = db.ResultParticipants
                        .Where(r => r.Discipline.OlympiadYear == (comboBox1.SelectedItem as Olympiad).Year && r.Position == 2)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, SilverMedals = r.Count() });
                    var countBronzeMedals = db.ResultParticipants
                        .Where(r => r.Discipline.OlympiadYear == (comboBox1.SelectedItem as Olympiad).Year && r.Position == 3)
                        .GroupBy(r => r.Participant.Country.Name)
                        .Select(r => new { Country = r.Key, BronzeMedals = r.Count() });
                    dataGridView1.DataSource = countGoldMedals.Outer()
                        .FullOuterJoin(countSilverMedals.Outer(),
                        gold => gold.Country,
                        silver => silver.Country,
                        (gold, silver) => new
                        {
                            Country = gold?.Country ?? silver?.Country,
                            GoldMedals = gold?.GoldMedals ?? 0,
                            SilverMedals = silver?.SilverMedals ?? 0
                        })
                        .FullOuterJoin(countBronzeMedals,
                        g_s => g_s.Country,
                        bronze => bronze.Country,
                        (g_s, bronze) => new
                        {
                            Country = g_s?.Country ?? bronze?.Country,
                            GoldMedals = g_s?.GoldMedals ?? 0,
                            SilverMedals = g_s?.SilverMedals ?? 0,
                            BronzeMedals = bronze?.BronzeMedals ?? 0
                        })
                        .OrderByDescending(m => m.GoldMedals)
                        .ThenByDescending(m => m.SilverMedals)
                        .ThenByDescending(m => m.BronzeMedals)
                    .ToList();
                }
            }
        }
    }
}
