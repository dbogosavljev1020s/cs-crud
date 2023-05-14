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
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string naziv = txtNaziv.Text;
            string kontakt = txtKontakt.Text;
            string grad = txtGrad.Text;
            string zemlja = txtZemlja.Text;

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
                    dataAccess.KlijentInsert(naziv, kontakt, grad, zemlja);

                    MessageBox.Show("Klijent dodat!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
