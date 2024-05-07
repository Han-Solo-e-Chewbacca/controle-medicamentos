using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    internal class RequesicaoEntrada : EntidadeBase
    {
        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeRetirada { get; set; }

        public  RequesicaoEntrada(Medicamento medicamentoSelecionado, Funcionario funcionarioSelecionado, int quantidade)
        {
            Medicamento = medicamentoSelecionado;
            Funcionario =funcionarioSelecionado;

            DataRequisicao = DateTime.Now;
            QuantidadeRetirada = quantidade;
            
        }

        public override ArrayList Validar()
        {
            ArrayList erros = ArrayList();
            int contadorErros = 0;

            if (Medicamento == null)
                erros[contadorErros++] = "O medicamento precisa ser preenchido";

            if (Funcionario == null)
                erros[contadorErros++] = "O funcionário precisa ser informado";

            if (QuantidadeRetirada < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            

            return erros;
        }

        private ArrayList ArrayList()
        {
            throw new NotImplementedException();
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public bool AdicionarMedicamento()
        {
           

            Medicamento.Quantidade += QuantidadeRetirada;
            return true;
        }
    }
}

