using CC01.BLL;
using CC01.BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = "y";
            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------create a etudiant--------------------------------------------------");
                Console.Write("entrer votre nom");
                string nom = Console.ReadLine();
                Console.Write("entrer votre prenom");
                string prenom = Console.ReadLine();
                Console.Write("entrer votre lieu de naissance");
                string lieu = Console.ReadLine();
                Console.Write("entrer votre annee de naissance");
                double nee = double.Parse(Console.ReadLine());
                Console.Write("entrer votre identifiant");
                double identifiant = double.Parse(Console.ReadLine());
                Console.Write("entrer votre contact");
                double contact = double.Parse(Console.ReadLine());



                Etudiant etudiant = new Etudiant(nom, prenom, nee, lieu, identifiant, contact);
                EtudiantBLO etudiantBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]) ;
                etudiantBLO.CreateProduct(etudiant);

                IEnumerable<Etudiant> etudiants = etudiantBLO.GetAllEtudiants();
                foreach (Etudiant e in etudiants)
                {
                    Console.WriteLine($"{ e.Identifiant}\t{e.Nom }");
                }
                Console.WriteLine("Create another etudiant?[y/n];");
            }
            while (choice.ToLower() != "n");
            Console.WriteLine("Program end!");

            Console.ReadKey();
        }
    }
}
