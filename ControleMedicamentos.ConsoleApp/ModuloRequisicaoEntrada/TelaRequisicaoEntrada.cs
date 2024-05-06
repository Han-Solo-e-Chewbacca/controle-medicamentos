using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    internal class TelaRequisicaoEntrada : TelaBase
    {
        public TelaPaciente telaPaciente = null;
        public TelaMedicamento telaMedicamento = null;
        public TelaFornecedor telaFornecedor = null;
        public TelaFuncionario telaFuncionario = null;
        public RepositorioPaciente repositorioPaciente = null;
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioFuncionario repositorioFuncionario = null;

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            RequesicaoEntrada entidade = (RequesicaoEntrada)ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuRetirar = entidade.AdicionarMedicamento();

            if (!conseguiuRetirar)
            {
                ExibirMensagem("A quantidade de retirada informada não está disponível.", ConsoleColor.DarkYellow);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Requisições de Entrada...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                "Id", "Medicamento", "Funcionario", "Data de Requisição", "Quantidade"
            );

            EntidadeBase[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (RequesicaoEntrada requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                    requisicao.Id,
                    requisicao.Medicamento.Nome,
                    requisicao.Funcionario.nome,
                    requisicao.DataRequisicao.ToShortDateString(),
                    requisicao.QuantidadeRetirada
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite o ID do medicamento requisitado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            telaFuncionario.VisualizarRegistros(false);

            Console.Write("Digite o ID do funcionário requisitante: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioSelecionado = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            Console.Write("Digite a quantidade do medicamente que deseja adicionar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o ID do fu");

            RequesicaoEntrada novaRequisicao = new RequesicaoEntrada(medicamentoSelecionado, funcionarioSelecionado, quantidade);

            return novaRequisicao;
        }
    }
}
