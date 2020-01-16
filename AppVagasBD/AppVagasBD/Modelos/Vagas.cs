using System;
using System.Collections.Generic;
using System.Text;
using SQLite;//Primeiro devemos chamar a biblioteca do banco

namespace AppVagasBD.Modelos
{
    [Table ("Vaga")]//Segundo devemos criar o nome da tabela
   public class Vagas
    {
        //Terceiro devemos instanciar os elementos da tabela do banco de dados
        [PrimaryKey, AutoIncrement]//Quarto passo criar uma chave primaria para não ocorre expction e 
        //AutoIncrement para incrementa automaticamente
        public int Id { get; set; }//Toda tabela necessita deste ID
        public string NomeVagas { get; set; }
        public short Quantidade { get; set; }
        public string Empresa { get; set; }
        public string Cidade { get; set; }
        public double Salario { get; set; }
        public string Descricao { get; set; }
        public string TipoDeContato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
