using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens_WEBAPI.Models
{
    public class Cliente
    {
        public Cliente(){}
        
        public Cliente(int id, String nome, String sexo, String dataNasc, int idade, int CidadeId) 
        {
            this.id = id;
            this.nome = nome;
            this.sexo = sexo;
            this.dataNasc = dataNasc;
            this.idade = idade;
            this.CidadeId = CidadeId;
        }

        public int id { get; set; }
        public String nome { get; set; }
        public String sexo { get; set; }    
        public String dataNasc { get; set; }
        public int idade { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get;set; }
    }
}