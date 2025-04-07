using System.Text;
using Core;
using Display.util;

namespace Display
{

    public class AsciiCardRenderer
    {
        private readonly string _nomeArquivoTxtCarroMiniaturaEmAscii = "carro-2-ascii.txt";
        private readonly string _nomeArquivoTxtCarroMiniatura2EmAscii = "carro-3-ascii.txt";

        private readonly GerenciadorArquivos _gerenciadorArquivos = new();


        public (string cartaAscii, string carroAscii) RenderCard(Atributos atributos)
        {
            StringBuilder cartaDisplay = new StringBuilder();
            string middleBorder = "+---------------------------------------+";
            string bottomBorder = "+---------------------------------------+";
            string modeloFormatado = atributos.Modelo.PadRight(30); // Para garantir alinhamento

            cartaDisplay.AppendLine(middleBorder);
            cartaDisplay.AppendLine($"│     🏎️   {modeloFormatado}|");

            cartaDisplay.AppendLine(middleBorder);
            cartaDisplay.AppendLine($"| Velocidade:  {atributos.VelocidadeMax.ToString() + " km/h"}");
            cartaDisplay.AppendLine($"| Potência:  {atributos.Potencia.ToString() + " HP"}");
            cartaDisplay.AppendLine($"| Acelaração:  {atributos.Aceleracao.ToString() + " seg - 100Km/h"}");
            cartaDisplay.AppendLine($"| Consumo:  {atributos.Consumo.ToString() + " Km/l"}");
            cartaDisplay.AppendLine($"| Peso:  {atributos.Peso.ToString() + " kg"}");
            cartaDisplay.AppendLine(bottomBorder);

            string carroAscii = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtCarroMiniaturaEmAscii);
            string carroAscii2 = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtCarroMiniatura2EmAscii);

            string[] carrosAscii = [carroAscii, carroAscii2];

            return (cartaDisplay.ToString(), carrosAscii[new Random().Next(carrosAscii.Length)]);
        }
    }
}