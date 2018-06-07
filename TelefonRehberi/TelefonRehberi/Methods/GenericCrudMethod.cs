using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TelefonRehberi.Models;

namespace TelefonRehberi.Methods
{
    public class GenericCrudMethod<T>where T : class
    {
        private Rehber db = null;
        private DbSet<T> table = null;

        public GenericCrudMethod()
        {
            this.db = new Rehber();
            table = db.Set<T>();
        }

        public T SelectByID(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> SelectList()
        {
            return table.ToList();
        }

        public void Ekle(T typeObject)
        {
            table.Add(typeObject);
            db.SaveChanges();            
        }

        public void Guncelle(T typeObject)
        {           
            db.Entry<T>(typeObject).State = EntityState.Modified;
            db.SaveChanges();  
        }

        public void Sil(int id)
        {
            T deletedRecord = table.Find(id);
            table.Remove(deletedRecord);
            db.SaveChanges();
        }


    }
}