using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GSM
{
    public partial class Main : Form
    {
        private Enquete EN = new Enquete();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtHoeveel.Focus();
        }

        private void btnHoeveel_Click(object sender, EventArgs e)
        {
            UInt32 getal;
            string invoer = txtHoeveel.Text;
            if (!UInt32.TryParse(invoer,out getal)){reset();return;}

            EN.Count = (int)getal;

            txtVraag.Enabled = !txtVraag.Enabled;
            btnVraag.Enabled = !btnVraag.Enabled;
            txtHoeveel.Enabled = !txtHoeveel.Enabled;
            btnHoeveel.Enabled = !btnHoeveel.Enabled;          
            this.Height = 380;

            this.AcceptButton = btnVraag;
        }

        private void btnEinde_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reset()
        {
            txtHoeveel.Enabled = true;
            btnHoeveel.Enabled = true;
            btnVraag.Enabled = false;
            txtVraag.Enabled = false;
            foreach (Control item in Controls)
            {
                if (item is TextBox)                
                    (item as TextBox).Text = "";                
            }
            lblWeergave.Text = "";
            this.AcceptButton = btnHoeveel;
            EN.Reset();
            this.Height = 120;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnVraag_Click(object sender, EventArgs e)
        {
            string invoer = txtVraag.Text.ToUpper();

            if (!EN.Verwerk(invoer))
            {
                btnVraag.Enabled = false;
                txtVraag.Enabled = false;
            }
            
            lblWeergave.Text = EN.GeefWeer(); 
            txtVraag.Text = "";
            txtVraag.Focus();
            lblWeergave.BackColor = EN.Color;

            if (EN.IsBereikt())
            {
                btnVraag.Enabled = false;
                txtVraag.Enabled = false;
                return;
            }
        }
    }
}
