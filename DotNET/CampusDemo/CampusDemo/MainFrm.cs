using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CampusDemo
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnLWL_Click(object sender, EventArgs e)
        {
            CampusDemo.Member.LiWeiLiang.LWLForm myForm = new CampusDemo.Member.LiWeiLiang.LWLForm();
            myForm.ShowDialog();
        }   
    }
}