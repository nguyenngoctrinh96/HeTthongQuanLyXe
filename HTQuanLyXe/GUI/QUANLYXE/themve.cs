﻿using HTQuanLyXe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQuanLyXe.GUI.QUANLYXE
{
    public partial class themve : Form
    {
        public themve()
        {
            InitializeComponent();
            txtmave.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtmave.Text = "";
            if (txtmave.Text.Length>10|| textBoxma.Text == "" || quanlyveDAO.Instance.tontaive(textBoxma.Text))
            {
                if (textBoxma.Text == "")
                    txtmave.Text = "Mã số vế không được để trống!";
                if (quanlyveDAO.Instance.tontaive(textBoxma.Text))
                    txtmave.Text = "Vé đã tồn tại!";
                if (textBoxma.Text.Length > 10)
                    txtmave.Text = "mã xe không quá 10 ký tự.";
                return;
            }
            try
            {
                quanlyveDAO.Instance.themve(textBoxma.Text);
                MessageBox.Show("Thêm thành công vé có mã: "+textBoxma.Text+".");
            }
            catch
            {
                MessageBox.Show("không thể thêm!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
