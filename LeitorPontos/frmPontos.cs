using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeitorPontos
{
    public partial class frmPontos : Form
    {
        public frmPontos()
        {
            InitializeComponent();
        }

        /// <summary>Está saindo do programa?
        /// </summary>
        public bool Saindo = false;

        private void frmPontos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saindo)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void frmPontos_Load(object sender, EventArgs e)
        {

        }
    }
}
