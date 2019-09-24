using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComercial.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department()
        { // o construtor vazio só deve existir pq será usado um construtor com parametros
        }
        //lembrando que nao se deve por argumentos que sao coleções no construtor
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
