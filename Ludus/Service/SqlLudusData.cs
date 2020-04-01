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

        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public Student getDetails(int Id)
        {
            return db.Students.FirstOrDefault(r => r.Id == Id);
        }

        public List<Student> getAll()
        {
            return db.Students.OrderBy(x => x.Name).ToList();
        }

        public void update(Student student)
        {
            var existing = getDetails(student.Id);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.surname = student.surname;
                existing.KNumber = student.KNumber;
            }
        }
        public void Remove(Student student)
        {
            var target = db.Students.Find(student.Id);
            db.Students.Remove(target ?? throw new InvalidOperationException());
            db.SaveChanges();
        }
    }
}
