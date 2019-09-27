using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppComercial.Services.Exceptions
{
    public class NotFoundException : ApplicationException // exceção personalizada
    {
        public NotFoundException(string message) : base(message)
        { // exceção personalizada not found
            //isso é pra ter um controle maior sobre cada exceção que poderá ocorrer
        }
    }
}
