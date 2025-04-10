using System.Text;
using Core;
using Display.util;

namespace Display
{

    public class GeradorImagemAscii
    {
        private readonly string _nomeArquivoTxtCarroMiniaturaEmAscii = "carro-2-ascii.txt";
        private readonly string _nomeArquivoTxtCarroMiniatura2EmAscii = "carro-3-ascii.txt";

        private List<String> _desenhosAsciiCarrosDoJogo = [];
        private readonly GerenciadorArquivos _gerenciadorArquivos = new();
        private readonly Random _random = new();

        internal void CarregarDesenhosDosCarros()
        {
            string carroModelo1 = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtCarroMiniaturaEmAscii);
            string carroModelo2 = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtCarroMiniatura2EmAscii);

            _desenhosAsciiCarrosDoJogo = [
                carroModelo1,
                carroModelo2
            ];
        }

        public string DesenharCarroAleatorio()
        {

            if (_desenhosAsciiCarrosDoJogo == null || _desenhosAsciiCarrosDoJogo.Count <= 0)
            {
                CarregarDesenhosDosCarros();
            }

            int posicaoCarroSortido = _random.Next(_desenhosAsciiCarrosDoJogo.Count);
            string carroSortido = _desenhosAsciiCarrosDoJogo[posicaoCarroSortido];
            return carroSortido;
        }

        public string DesenharCarta(Atributos atributos)
        {
            StringBuilder cartaDisplay = new();
            string moldura = "+---------------------------------------+";
            string espacamentoCabecalhoCarta = atributos.Modelo.PadRight(30); // Para garantir alinhamento

            cartaDisplay.AppendLine(moldura);
            cartaDisplay.AppendLine($"│     🏎️   {espacamentoCabecalhoCarta}|");
            cartaDisplay.AppendLine(moldura);
            cartaDisplay.AppendLine($"| Velocidade:  {atributos.VelocidadeMax.ToString() + " km/h"}");
            cartaDisplay.AppendLine($"| Potência:  {atributos.Potencia.ToString() + " HP"}");
            cartaDisplay.AppendLine($"| 0 - 100Km/h:  {atributos.Aceleracao.ToString() + " seg"}");
            cartaDisplay.AppendLine($"| Consumo:  {atributos.Consumo.ToString() + " Km/l"}");
            cartaDisplay.AppendLine($"| Peso:  {atributos.Peso.ToString() + " kg"}");
            cartaDisplay.AppendLine(moldura);
            return cartaDisplay.ToString();
        }
    }
}