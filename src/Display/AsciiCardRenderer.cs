using System.Text;

namespace Display
{

    public class AsciiCardRenderer
    {


        public string RenderCard(string modelo, string velocidade, string potencia, string peso)
        {
            StringBuilder cartaDisplay = new StringBuilder();
            string middleBorder = "+---------------------------------------+";
            string bottomBorder = "+---------------------------------------+";
            string modeloFormatado = modelo.PadRight(30); // Para garantir alinhamento

            cartaDisplay.AppendLine(middleBorder);
            cartaDisplay.AppendLine($"│     🏎️   {modeloFormatado}|");

            cartaDisplay.AppendLine(middleBorder);
            cartaDisplay.AppendLine($"| Velocidade:     {velocidade.PadRight(22)}|");
            cartaDisplay.AppendLine($"| Potência:       {potencia.PadRight(22)}|");
            cartaDisplay.AppendLine($"| Peso:           {peso.PadRight(22)}|");
            cartaDisplay.AppendLine(bottomBorder);

            return cartaDisplay.ToString();
        }
    }
}