using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestButtons
{
    public partial class Form1 : Form
    {
        //private List<UserControl1> userControl11List = new List<UserControl1>();
        staff st = new staff();
        public Form1()
        {
            InitializeComponent();
 //           listView1.DataBindings.Add("Person", st, "Persons");

            try
            {
                listView1.Items.Clear();


                foreach (var per in st.Persons)
                {
                //DataRow dr = dt.Rows[i];
                    ListViewItem listitem = new ListViewItem(per.Name);
//                    listitem.SubItems.Add(per.Name);
                    listitem.SubItems.Add(per.Famly);
                    listView1.Items.Add(listitem);
                }

                listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);
//       MyListView_SelectedIndexChanged);
                //listView1.ColumnClick += new ColumnClickEventHandler(
                  //                 MyListView_ColumnClick);

              }
              catch (Exception ms) { }

        //    listView1.DataBindings.Add(new Binding())
            
            /*
            for (uint i = 0; i < 4; i++)
            {
                UserControl1 userControl11 = new UserControl1();
                userControl11 = new TestButtons.UserControl1();
                userControl11.Location = new System.Drawing.Point((int)(10 + i* 100), (int)(10 + i * 100));
                userControl11.BackColor = Color.Blue;
                userControl11.Name = "userControl11" + i.ToString();
                userControl11.Size = new System.Drawing.Size(247, 43);
                userControl11.TabIndex = 0;
                userControl11.Param1 = i;
                userControl11List.Add(userControl11);
                this.Controls.Add(userControl11);
            }*/
        }

        private Object source;

[Bindable(true)]
[TypeConverter("System.Windows.Forms.Design.DataSourceConverter,System.Design")]
[Category("Data")]
public Object DataSource
{
    get
    {
        return source;
    }
    set
    {
        source = value;
    }
}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //st.Persons.Add(e.)
        }
    }
}
