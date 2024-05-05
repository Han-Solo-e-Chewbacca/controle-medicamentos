﻿using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    internal class RequesicaoEntrada : EntidadeBase
    {
        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeRetirada { get; set; }

        public  RequesicaoEntrada(Medicamento medicamentoSelecionado, Fornecedor fornecedorSelecionado, int quantidade)
        {
            Medicamento = medicamentoSelecionado;
            Fornecedor = fornecedorSelecionado;

            DataRequisicao = DateTime.Now;
            QuantidadeRetirada = quantidade;
            
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (Medicamento == null)
                erros[contadorErros++] = "O medicamento precisa ser preenchido";

            if (Fornecedor == null)
                erros[contadorErros++] = "O paciente precisa ser informado";

            if (QuantidadeRetirada < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }

        public bool AdicionarMedicamento()
        {
           

            Medicamento.Quantidade += QuantidadeRetirada;
            return true;
        }
    }
}
