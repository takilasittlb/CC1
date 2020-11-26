using CC01.BLL;
using CC01.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.Winform
{
    public partial class Student : Form
    {
        private Action callBack;
        private Etudiant oldEtudiant;
        public Student()
        {
            InitializeComponent();
        }
        public Student(Action callBack):this()
        {
            this.callBack = callBack;
        }

        public Student(Etudiant etudiant, Action callBack) : this(callBack)
        {
            this.oldEtudiant = etudiant;
            txtNom.Text = etudiant.Nom;
            txtPrenom.Text = etudiant.Prenom;
            txtNee.Text = etudiant.Nee.ToString();
            txtLieu.Text = etudiant.Lieu;
            txtIdentifiant.Text = etudiant.Identifiant.ToString();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                checkForm();
                Etudiant newEtudiant = new Etudiant
                    (txtNom.Text,
                    txtPrenom.Text,
                    txtNee.Text,
                    double.Parse(txtLieu.Text),
                    double.Parse(txtIdentifiant.Text),
                    double.Parse(txtContact.Text)
                    );
                EtudiantBLO etudiantBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]);

                if (this.oldEtudiant == null)
                    etudiantBLO.CreateProduct(oldEtudiant);
                else
                    etudiantBLO.EditEtudiant(oldEtudiant, newEtudiant);

                MessageBox.Show(
                    "save done!",
                    "confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (callBack != null)
                    callBack();

                if (oldEtudiant != null)
                    Close();

                txtContact.Clear();
                txtIdentifiant.Clear();
                txtLieu.Clear();
                txtNee.Clear();
                txtNom.Clear();
                txtPrenom.Clear();
                txtNom.Focus();
            }
            catch (TypingException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "erreur de saisie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "duplicate error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ex.WriteToFile();
                MessageBox.Show(
                    " une erreur est survenue svp reessayer",
                    "erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    " une erreur est survenue svp reessayer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
        private void checkForm()
        {
            string text = string.Empty;
            txtNom.BackColor = Color.White;
            txtNom.BackColor = Color.Pink;
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                text +="- svp entrez un nom! \n";
                txtNom.BackColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                text += "- svp entrez un prenom! \n";
                txtNom.BackColor = Color.Pink;
            }

            if (string.IsNullOrWhiteSpace(txtNee.Text))
                text += "- svp entrez votre date de naissance! \n";
            if (string.IsNullOrWhiteSpace(txtLieu.Text))
                text += "- svp entrez un lieu de naissance! \n";
            if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
                text += "- svp entrez un identifiant! \n";
            if (string.IsNullOrWhiteSpace(txtContact.Text))
                text += "- svp entrez un Contact! \n";

            if (!string.IsNullOrEmpty(text))
                throw new TypingException(text);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }
    }
}
