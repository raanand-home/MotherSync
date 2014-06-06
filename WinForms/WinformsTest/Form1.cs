using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsTest
{

    public partial class Form1 : Form
    {
        Repository rep = new Repository();
        public Form1()
        {
            InitializeComponent();
            var bindinglist = new BindingList<Person>(rep.Persons);
            var source = new BindingSource(bindinglist, null);
            this.dataGridView1.DataSource = source;

            this.listBox1.DataSource = source;
            this.listBox1.DisplayMember = "Price";
            

        }

       

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

  
   

    }
}
