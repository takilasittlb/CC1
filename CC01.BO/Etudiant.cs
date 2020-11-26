using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BO
{
   public class Etudiant
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Lieu { get; set; }
        public double Nee { get; set; }
        public double Identifiant { get; set; }
        public double Contact { get; set; }
        public byte[] Picture { get; set; }

        public Etudiant(string nom, string prenom, double nee, string lieu)
        {

        }

        public Etudiant(string nom, string prenom, string lieu, double nee, double identifiant, double contact, byte[] picture)
        {
            Nom = nom;
            Prenom = prenom;
            Lieu = lieu;
            Nee = nee;
            Identifiant = identifiant;
            Contact = contact;
            Picture = picture;
        }

        public Etudiant(string nom, string prenom, double nee, string lieu, double identifiant, double contact)
        {
            Nom = nom;
            Prenom = prenom;
            Nee = nee;
            Lieu = lieu;
            Identifiant = identifiant;
            Contact = contact;
        }

        public override bool Equals(object obj)
        {
            return obj is Etudiant etudiant &&
                   Nom.Equals(etudiant.Nom, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return 574969646 + Identifiant.GetHashCode();
        }
    }
}
