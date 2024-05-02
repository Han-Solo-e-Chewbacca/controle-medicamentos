using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionario : TelaBase
    {
        public TelaFuncionario(RepositorioBase repositorio, string nome)
        {
            this.repositorio = repositorio;
            tipoEntidade = nome;
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();
                Console.WriteLine("Visualizando Funcionários...");
            }

            Console.WriteLine(
                "\n{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                "Id", "Nome", "CPF", "Login", "Senha"
            );

            EntidadeBase[] funcionariosCadastrados = repositorio.SelecionarTodos();

            foreach (Funcionario funcionario in funcionariosCadastrados)
            {
                if (funcionario == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                    funcionario.Id, funcionario.nome, funcionario.cpf, funcionario.login, funcionario.senha
                );
            }
            Console.ReadKey(true);
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite o login: ");
            string login = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();



            Funcionario funcionario = new Funcionario(nome, cpf, login, senha);

            return funcionario;
        }
    }
}