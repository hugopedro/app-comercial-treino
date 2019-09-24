using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComercial.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } //ISSO É MUITO IMPORTANTE, AQUI ELE TA LIGADO AS CLASSES DE ACORDO COM UML, MAS NAO USA COLLECTION PQ É "UM"
        public int DepartmentId { get; set; } // <<< isso é necessario para avisar ao Entity Framework que o Id tem que existir, uma vez que o tipo int nao pode ser nulo(negocio do null no banco sql)
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        { // calcula o total de vendas de um vendedor em um intervalo de datas
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
