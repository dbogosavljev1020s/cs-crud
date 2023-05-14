using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugiDeoDusanBogosavljev
{
    public partial class Update : Form
    {

        int klijentid;
        string naziv;
        string kontakt;
        string grad;
        string zemlja;
        public Update()
        {
            InitializeComponent();
        }

        public Update(int klijentid, string naziv, string kontakt, string grad, string zemlja)
        {
            this.klijentid = klijentid;
            this.naziv = naziv;
            this.kontakt = kontakt;
            this.grad = grad;
            this.zemlja = zemlja;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            naziv = txtNaziv.Text;
            kontakt = txtKontakt.Text;
            grad = txtGrad.Text;
            zemlja = txtZemlja.Text;

            if (naziv.Trim() == "")
            {
                MessageBox.Show("Unesite naziv klijenta", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return;
            }
            else if (naziv.Length >= 40)
            {
                MessageBox.Show("Naziv klijenta moze da ima do 40 karaktera!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return;
            }
            else if (kontakt.Trim() == "")
            {
                MessageBox.Show("Unesite kontakt klijenta", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKontakt.Focus();
                return;
            }
            else if (kontakt.Length >= 40)
            {
                MessageBox.Show("Kontakt klijenta moze da ima do 30 karaktera!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKontakt.Focus();
                return;
            }
            else if (grad.Trim() == "")
            {
                MessageBox.Show("Unesite grad klijenta", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrad.Focus();
                return;
            }
            else if (grad.Length >= 15)
            {
                MessageBox.Show("Grad klijenta moze da ima do 15 karaktera!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrad.Focus();
                return;
            }
            else if (zemlja.Trim() == "")
            {
                MessageBox.Show("Unesite zemlju klijenta", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtZemlja.Focus();
                return;
            }
            else if (zemlja.Length >= 15)
            {
                MessageBox.Show("Zemlja klijenta moze da ima do 15 karaktera!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtZemlja.Focus();
                return;
            }
            else
            {
                try
                {
                    clsDataAccess dataAccess = new clsDataAccess();
                    int Ret = dataAccess.KlijentUpdate(klijentid, naziv, kontakt, grad, zemlja);

                    if (Ret == 0)
                    {
                        MessageBox.Show("Klijent izmenjen!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (Ret == -1)
                    {
                        MessageBox.Show("Klijent ne postoji!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Greska: " + Ret.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Update_Load(object sender, EventArgs e)
        {
            this.txtKontakt.Text = this.kontakt;
            this.txtNaziv.Text = this.naziv;
            this.txtGrad.Text = this.grad;
            this.txtZemlja.Text = this.zemlja;
        }
    }
}
