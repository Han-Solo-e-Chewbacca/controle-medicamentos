using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class Medicamento : EntidadeBase
    {
        public Medicamento(string nome, string descricao, string lote, DateTime dataValidade,int quantidade, Fornecedor fornecedor)
        {
            Nome = nome;
            Descricao = descricao;
            Lote = lote;
            DataValidade = dataValidade;
            Quantidade = quantidade;
            Fornecedor = fornecedor;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lote { get; set; }
        private DateTime DataValidade { get; set; }
        public int Quantidade { get; set; } 
        public Fornecedor Fornecedor { get; set; }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros[contadorErros++] = ("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Descricao.Trim()))
                erros[contadorErros++] = ("O campo \"descrição\" é obrigatório");

            if (string.IsNullOrEmpty(Lote.Trim()))
                erros[contadorErros++] = ("O campo \"lote\" é obrigatório");

         
            DateTime hoje = DateTime.Now.Date;

            if (DataValidade < hoje)
                erros[contadorErros++] = ("O campo \"data de validade\" não pode ser menor que a data atual");

            

            return erros;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

    }
}
