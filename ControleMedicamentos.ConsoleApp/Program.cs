using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();

            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.tipoEntidade = "Paciente";
            telaPaciente.repositorio = repositorioPaciente;

            telaPaciente.CadastrarEntidadeTeste();

            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.repositorio = repositorioMedicamento;
            telaMedicamento.tipoEntidade = "Medicamento";
           
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            telaFornecedor.repositorio = repositorioFornecedor;
            telaFornecedor.tipoEntidade = "Fornecedor";

            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            telaFuncionario.repositorio = repositorioFuncionario;
            telaFuncionario.tipoEntidade = "Funcionario";

            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new RepositorioRequisicaoSaida();

            TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida();
            telaRequisicaoSaida.repositorio = repositorioRequisicaoSaida;
            telaRequisicaoSaida.tipoEntidade = "Requisição";

            telaRequisicaoSaida.telaPaciente = telaPaciente;
            telaRequisicaoSaida.telaMedicamento = telaMedicamento;

            telaRequisicaoSaida.repositorioPaciente = repositorioPaciente;
            telaRequisicaoSaida.repositorioMedicamento = repositorioMedicamento;

            RepositorioRequesicaoEntrada repositorioRequesicaoEntrada = new RepositorioRequesicaoEntrada();

            TelaRequisicaoEntrada telaRequisicaoEntrada = new TelaRequisicaoEntrada();
            telaRequisicaoEntrada.repositorio = repositorioRequesicaoEntrada;
            telaRequisicaoEntrada.tipoEntidade = "Requisição";
            telaRequisicaoEntrada.repositorioFornecedor = repositorioFornecedor;
            telaRequisicaoEntrada.telaPaciente = telaPaciente;
            telaRequisicaoEntrada.telaMedicamento = telaMedicamento;
            telaRequisicaoEntrada.telaFornecedor = telaFornecedor;
            telaRequisicaoEntrada.repositorioPaciente = repositorioPaciente;
            telaRequisicaoEntrada.repositorioMedicamento = repositorioMedicamento;


            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaPaciente;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaMedicamento;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaRequisicaoSaida;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaRequisicaoEntrada;

                else if (opcaoPrincipalEscolhida == '5')
                    tela = telaFornecedor;

                else if ((opcaoPrincipalEscolhida == '6'))
                    tela = telaFuncionario;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
            }

            Console.ReadLine();
        }
    }
}
