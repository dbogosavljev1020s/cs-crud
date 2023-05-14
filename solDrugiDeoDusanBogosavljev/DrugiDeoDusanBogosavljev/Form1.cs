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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit program?", "Exit program", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovog klijenta?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    clsDataAccess dataAccess = new clsDataAccess();
                    int Ret = dataAccess.KlijentDelete(Convert.ToInt32(dgKlijenti.SelectedRows[0].Cells[0].Value));

                    if (Ret == 0)
                    {
                        MessageBox.Show("Klijent obrisan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Insert forma = new Insert();
                forma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Update forma = new Update
                                (
                                    Convert.ToInt32(dgKlijenti.SelectedRows[0].Cells[0].Value),
                                    dgKlijenti.SelectedRows[0].Cells[1].Value.ToString(),
                                    dgKlijenti.SelectedRows[0].Cells[2].Value.ToString(),
                                    dgKlijenti.SelectedRows[0].Cells[3].Value.ToString(),
                                    dgKlijenti.SelectedRows[0].Cells[4].Value.ToString()
                                );
                forma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dgKlijenti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgKlijenti.MultiSelect = false;
            dgKlijenti.ReadOnly = true;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var data = clsDataAccess.selectAll();
                dgKlijenti.DataSource = data.Tables[0];

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
