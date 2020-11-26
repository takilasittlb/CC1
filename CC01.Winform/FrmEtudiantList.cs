using CC01.BLL;
using CC01.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.Winform
{
    public partial class FrmEtudiantList : Form
    {
        private EtudiantBLO etudiantBLO;
        private int i;
        private object etudiants;

        public FrmEtudiantList()
        {
            InitializeComponent();
            dataGridView1.DataSource = false;
            etudiantBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadData()
        {
            string value = txtSearch.Text.ToLower();
            var etudiant = etudiantBLO.GetBy
                (
                x =>
                x.Nom.ToLower().Contains(value) ||
                x.Prenom.ToLower().Contains(value)
                ).OrderBy(x=> x.Nom).ToArray();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = etudiants;
            lblRowCount.Text = $"{dataGridView1.RowCount} rows";
            dataGridView1.ClearSelection();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form f = new FrmEditEtudiant(loadData);
            f.Show();
        }

        private class FrmEditEtudiant : Form
        {
            private Action loadData;

            public FrmEditEtudiant(Action loadData)
            {
                this.loadData = loadData;
            }

            public FrmEditEtudiant(Etudiant etudiant, Action loadData)
            {
                this.loadData = loadData;
            }
        }

        private void FrmEtudiantList_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))           
                loadData();
                else 
                txtSearch.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for(int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    Form f = new FrmEditEtudiant
                        (
                        dataGridView1.SelectedRows[i].DataBoundItem as Etudiant,
                        loadData
                        );
                    f.ShowDialog(); 
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    etudiantBLO.DeleteEtudiant(dataGridView1.SelectedRows[i].DataBoundItem as Etudiant);         
                }
                loadData();
            }
        }
    }
}
