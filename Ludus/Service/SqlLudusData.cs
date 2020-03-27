using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ludus_web.Models;

namespace Ludus.Service
{
    public class SqlLudusData
    {
        private LudusDBContext db;

        public SqlLudusData(LudusDBContext db)
        {
            this.db = db;
        }

        public void Add(Students student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public Students getDetails(int Id)
        {
            return db.Students.FirstOrDefault(r => r.Id == Id);
        }

        public List<Students> getAll()
        {
            return db.Students.OrderBy(x => x.Name).ToList();
        }

        public void update(Students student)
        {
            var existing = getDetails(student.Id);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.surname = student.surname;
                existing.KNumber = student.KNumber;
            }
        }

        public void Remove(Students student)
        {
            var target = db.Students.Find(student.Id);
            db.Students.Remove(target ?? throw new InvalidOperationException());
            db.SaveChanges();
        }
    }
}
