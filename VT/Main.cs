using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VT
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            comboBox1.DisplayMember = "From";
            comboBox1.ValueMember = "FullName";
            var list = VT.ExternalLib.eService.GetProducts(comboBox2.Text);
            list.ToList().Add(new ExternalLib.eProduct() { From = "- Tout -", FullName = "-Tout-" });
            comboBox1.DataSource = list;

            dataGridView1.DataSource = ExternalLib.eService.GetProducts("- Tout - ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ExternalLib.eService.GetProducts(comboBox2.Text).Where(x => x.From == comboBox1.Text);
        }
    }
}
