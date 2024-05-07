using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    internal class RequisicaoSaida : EntidadeBase
    {

        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeRetirada { get; set; }

        public RequisicaoSaida(Medicamento medicamentoSelecionado, Paciente pacienteSelecionado, int quantidade)
        {
            Medicamento = medicamentoSelecionado;
            Paciente = pacienteSelecionado;

            DataRequisicao = DateTime.Now;
            QuantidadeRetirada = quantidade;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();
            int contadorErros = 0;

            if (Medicamento == null)
                erros[contadorErros++] = "O medicamento precisa ser preenchido";

            if (Paciente == null)
                erros[contadorErros++] = "O paciente precisa ser informado";

            if (QuantidadeRetirada < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            

            return erros;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }
        public bool RetirarMedicamento()
        {
            

            Medicamento.Quantidade -= QuantidadeRetirada;
            return true;
        }
    }
}
