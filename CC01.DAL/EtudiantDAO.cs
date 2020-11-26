﻿using CC01.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.DAL
{
    public class EtudiantDAO
    {
        private static List<Etudiant> etudiants;
        private const string FILE_NAME = @"etudiants.json";
        private readonly string dbFolder;
        private FileInfo file;
        public EtudiantDAO(string dbFolder)
        {
            this.dbFolder = dbFolder;
            file = new FileInfo(Path.Combine(this.dbFolder,FILE_NAME));
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            if(!file.Exists)
            {
                file.Create().Close();
                file.Refresh();
            }
            if (file.Length > 0)
            {
                using(StreamReader sr= new StreamReader(file.FullName))
                {
                    string json = sr.ReadToEnd();
                    etudiants = JsonConvert.DeserializeObject<List<Etudiant>>(json);
                }
            }
            if(etudiants== null)
            {
                etudiants = new List<Etudiant>();
            }
        }

        private void Set(Etudiant oldEtudiant, Etudiant newEtudiant)
        {

            var oldIndex = etudiants.IndexOf(oldEtudiant);
            var newIndex = etudiants.IndexOf(newEtudiant);
            if (oldIndex < 0)
                throw new KeyNotFoundException("l'etudiant n'existe pas");
            if (newIndex >= 0 && oldIndex != newIndex)
                throw new DuplicateNameException("Ce nom existe deja");
            etudiants[oldIndex] = newEtudiant;
            Save();

        }

        public void Add(Etudiant etudiant)
        {

            var index= etudiants.IndexOf(etudiant);
            if (index >= 0)
                throw new DuplicateNameException("Ce nom existe deja");
            etudiants.Add(etudiant);
            Save();
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(file.FullName, false))
            {
                string json = JsonConvert.SerializeObject(etudiants);
                sw.WriteLine(json);
            }
        }

        public void Remove(Etudiant etudiant)
        {
            etudiants.Remove(etudiant);
            Save();
        }
        public IEnumerable<Etudiant> Find()
        {
            return new List<Etudiant>(etudiants);
        }
        public IEnumerable<Etudiant> Find(Func<Etudiant,bool> predicate)
        {
            return new List<Etudiant>(etudiants.Where(predicate).ToArray());
        }
    }
}
