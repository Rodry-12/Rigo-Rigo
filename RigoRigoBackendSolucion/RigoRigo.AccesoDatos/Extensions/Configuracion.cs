using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.AccesoDatos.Extensions
{
    public class Configuracion
    {
        private readonly string _connectionString;
        public Configuracion(IConfiguration configuration) 
        { 
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public string CadenaConexion()
        {
            return _connectionString;
        }
    }
}
