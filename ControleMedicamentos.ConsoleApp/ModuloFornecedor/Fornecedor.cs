using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedor
{
    internal class Fornecedor : EntidadeBase

    {
        public Fornecedor(string nome, string telefone, string cnpj)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.cnpj = cnpj;
        }

        public string nome { get; set; }
        public string telefone { get; set; }
        public string cnpj { get; set; }


      

        public override ArrayList Validar() 
        {
            ArrayList erros = new ArrayList();
            int contadorErros = 0;

            if (string.IsNullOrEmpty(nome.Trim()))
                erros[contadorErros++] = ("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(telefone.Trim()))
                erros[contadorErros++] = ("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(cnpj.Trim()))
                erros[contadorErros++] = ("O campo \"CNPJ\" é obrigatório");                       

            

            return erros;             
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }
    }
}

