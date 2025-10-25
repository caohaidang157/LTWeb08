using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LTWeb08_Bai03.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public void InsertOnSubmit(Employee employee)
        {
            Employees.Add(employee);
        }
        public void UpdateOnSubmit(Employee employee) 
        {
            Employees.AddOrUpdate(employee);
        }
        public void DeleteOnSubmit(Employee employee)
        {
            Employees.Remove(employee);
        }
        public void SubmitSaveChanges()
        {
            SaveChanges();
        }

    }
}
