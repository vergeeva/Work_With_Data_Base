using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Form2 : Form
    {
        bool _Rc;
        public bool Rc { get { return _Rc; } }
        public string Type
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }
        public int Number
        {
            get { return Convert.ToInt32(textBox1.Text); }
            set { textBox1.Text = Convert.ToString(value); }
        }
        public string Comment
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public Form2()
        {
            _Rc = false;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Rc = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Rc = false;
            Close();
        }
    }
}
