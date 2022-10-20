using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens_WEBAPI.Models
{
    public class Cidade
    {
        public Cidade(){}
        
        public Cidade(int id, String nome, String estado) 
        {
            this.id = id;
            this.nome = nome;
            this.estado = estado;
   
        }
        public int id { get; set; }
        public String nome { get; set; }
        public String estado { get; set; } 
        public IEnumerable<Cliente> Clientes { get; set;}
    }
}