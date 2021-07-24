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


namespace Ado_hw_15
{
    public partial class Form1 : Form
    {
        private DbContextOptions<OlympiadContext> options;
        public Form1()
        {
            InitializeComponent();
            Configures config = new Configures("appsettings.json");
            options = config.GetOptions("DefaultConnection");
            string picturesDirectoryPath = config.GetStringParameter("PicturesDirectoryPath");

            dataGridView1.DataSource = new List<Customer>
            {
                new Customer { Id = 1, Name = "The Very Big Corporation of America" },
                new Customer { Id = 2, Name = "Old Accountants Ltd" }
            };
            using(OlympiadContext db = new OlympiadContext(options))
            {

            }

            pictureBox1.Image = PictureCreator.GetImage($"{picturesDirectoryPath}1.jpg");
        }

    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
