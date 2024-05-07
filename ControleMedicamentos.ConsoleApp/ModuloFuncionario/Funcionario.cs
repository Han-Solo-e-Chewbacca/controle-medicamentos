using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class Funcionario : EntidadeBase
    {
      

        public Funcionario(string nome, string login, string senha, string cpf)
        {
            this.nome = nome;
            this.login = login;
            this.senha = senha;
            this.cpf = cpf;
        }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; } 

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();
            int contadorErros = 0;

            if (string.IsNullOrEmpty(nome.Trim()))
                erros[contadorErros++] = ("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(cpf.Trim()))
                erros[contadorErros++] = ("O campo \"cpf\" é obrigatório");

            if (string.IsNullOrEmpty(login.Trim()))
                erros[contadorErros++] = ("O campo \"login\" é obrigatório");

            if (string.IsNullOrEmpty(senha.Trim()))
                erros[contadorErros++] = ("O campo \"senha\" é obrigatório");           

            

            return erros;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }


    }
}