using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.Winform
{
    public class EtudiantListPrint
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Nee { get; set; }
        public string Lieu { get; set; }
        public string Identifiant { get; set; }

        public EtudiantListPrint(string nom, string prenom, string nee, string lieu, string identifiant)
        {
            Nom = nom;
            Prenom = prenom;
            Nee = nee;
            Lieu = lieu;
            Identifiant = identifiant;
        }
    }
}
