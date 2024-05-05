using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedor
{
    internal class TelaFornecedor : TelaBase
    {     
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Fornecedores...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20}| {3, -20}",
                "Id", "Nome", "CNPJ", "Telefone"
            );

            EntidadeBase[] fornecedoresCadastrados = repositorio.SelecionarTodos();

            foreach (Fornecedor fornecedor in fornecedoresCadastrados)
            {
                if (fornecedor == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                    fornecedor.Id, fornecedor.nome, fornecedor.cnpj, fornecedor.telefone
                );
            }

            Console.ReadLine( );
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CNPJ: ");
            string cnpj = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();


            Fornecedor fornecedor = new Fornecedor(nome, cnpj, telefone);

            return fornecedor;
        }
    }
}