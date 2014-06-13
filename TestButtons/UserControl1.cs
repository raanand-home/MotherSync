using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestButtons
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            

        }
        int numberOfcell()
        {
            return 32;
        }
        List<Panel> pan = new List<Panel>();
        void InitColumns()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.ColumnCount = numberOfcell();
            for (int i = 0; i < numberOfcell(); i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent,
                    100F));
                
            }
            for (int i = 0; i < numberOfcell(); i++)
            {
                var p= new Panel();
                p.Name = "Panel" + i.ToString();
                p.Dock = DockStyle.Fill;
                p.BackColor = Color.White;
                p.Width = 10;
                p.Height = 10;
                p.Margin = new System.Windows.Forms.Padding(0);
                p.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                p.Controls.Add(new Label() { Text = "x" });
                pan.Insert(0,p);
                this.tableLayoutPanel1.Controls.Add(p, i, 0);
            }
            this.tableLayoutPanel1.AutoSizeMode =  System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.TabIndex = 0;
            this.Controls.Add(this.tableLayoutPanel1);
        }
        void UpdateValue()
        {
            int i =0;
            foreach (var p in pan) 
            {
                var IsOn = false;
                if(((Param1 >> i) & 1) == 1)
                {
                    IsOn = true;
                }
                ((Label)p.Controls[0]).Text = ((IsOn) ? 1 : 0).ToString();
                i++;
            }
        }
        UInt32 _value = 0;

        [CategoryAttribute("Mother"), DefaultValueAttribute(1)]
        public System.UInt32 Param2
        {
            get;
            set;
        }

        [CategoryAttribute("Mother"), DefaultValueAttribute(1)]
        public System.UInt32 Param1
        {
            get
            {
                return _value;
            }
            set
            {
                UpdateValue();
                _value = value;
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            InitColumns();
            UpdateValue();
        }
    }
}
