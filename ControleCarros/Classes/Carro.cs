using System;

namespace ControleCarros.Classes
{
    public class Carro : EntidadeBase
    {
        //atributos
        private Genero Genero { get; set; }
        private string Marca {get; set;}
        private string Modelo {get; set;}
        private string Cor {get; set;}
        private int Ano {get; set;}
        private string Combustivel {get; set;} 
        private bool Excluido {get; set;}

        //metodos
        public Carro(int id, Genero genero, string marca, string modelo, string cor, int ano, string combustivel)
        {
            this.Id = id;
            this.Genero = genero;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Cor = cor;
            this.Ano = ano;
            this.Combustivel = combustivel;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Marca: " + this.Marca + Environment.NewLine;
            retorno += "Modelo " + this.Modelo + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Combustivel: " + this.Combustivel + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaMarca()
        {
            return this.Marca;
        }

        public string retornaCor()
        {
            return this.Cor;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir() 
        {
            this.Excluido = true;
        }
    }
}