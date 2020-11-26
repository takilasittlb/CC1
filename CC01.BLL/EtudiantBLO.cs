using CC01.BO;
using CC01.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BLL
{

    public class EtudiantBLO
    {
        EtudiantBLO etudiantRepo;
        private object etudiants;
        private object etudiant;

        public EtudiantBLO(string dbFolder)
        {
            EtudiantDAO etudiantRepo = new EtudiantDAO(dbFolder);
        }
        public void CreateEtudiant(Etudiant etudiant)
        {
            etudiantRepo.Add(etudiant);
        }
        public void DeleteEtudiant(Etudiant etudiant)
        {
            etudiantRepo.Remove(etudiant);
        }
        public IEnumerable<Etudiant> GetAllEtudiants()
        {
            return etudiantRepo.Find();
        }

        public IEnumerable<Etudiant> GetByNom(string nom)
        {
            return etudiantRepo.Find(x=>x.Nom==nom);
        }

        public IEnumerable<Etudiant> GetBy(Func<Etudiant, bool> predicate)
        {
            return etudiantRepo.Find(predicate);
        }



        /* public IEnumerable<Etudiant> GetBy(Func<Etudiant, bool> predicate)
         {
             return etudiantRepo.Find(predicate);
         }*/




        private IEnumerable<Etudiant> Find()
        {
            throw new NotImplementedException();
        }
        private IEnumerable<Etudiant> Find(Func<Etudiant, bool> predicate)
        {
            return new List<Etudiant>(etudiants.Where(predicate).ToArray());
        }

        private void Remove(Etudiant etudiant)
        {
            throw new NotImplementedException();
        }

        private void Add(Etudiant etudiant)
        {
            throw new NotImplementedException();
        }

        public void EditEtudiant(Etudiant oldEtudiant, Etudiant newEtudiant)
        {
            etudiantRepo.Set(oldEtudiant, newEtudiant);
        }

        private void Set(Etudiant oldEtudiant, Etudiant newEtudiant)
        {
            throw new NotImplementedException();
        }

      
        public void CreateProduct(Etudiant etudiant)
        {
            throw new NotImplementedException();
        }
    }
}
