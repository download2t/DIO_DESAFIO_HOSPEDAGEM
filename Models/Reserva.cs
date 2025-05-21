namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        // Construtores
        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        // Cadastrar hóspedes, verificando a capacidade da suíte
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }

        // Cadastrar uma suíte
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        // Retornar a quantidade de hóspedes
        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        // Calcular o valor total da diária, com desconto de 10% para 10 ou mais dias
        public decimal CalcularValorDiaria()
        {
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valorTotal *= 0.90M; // Aplica 10% de desconto
            }

            return valorTotal;
        }
    }
}
