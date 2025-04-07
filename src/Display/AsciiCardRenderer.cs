using System.Text;
using Core;

namespace Display
{

    public class AsciiCardRenderer
    {


        public string RenderCard(Atributos atributos)
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

            return cartaDisplay.ToString();
        }
    }
}