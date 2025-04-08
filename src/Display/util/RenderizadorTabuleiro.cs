using System;
using Display.util;

namespace Display;

public class RenderizadorTabuleiro
{

    public static void DesenharMoldura(CoordenadasConsole coordenadasConsole, string? texto = null)
    {
        string parteCimaMoldura = "╔" + new string('═', coordenadasConsole.ObterLargura() - 2) + "╗";
        string lateralEsquerdaEDireitaMoldura = "║" + new string(' ', coordenadasConsole.ObterLargura() - 2) + "║";
        string parteBaixaMoldura = "╚" + new string('═', coordenadasConsole.ObterLargura() - 2) + "╝";

        if (!string.IsNullOrEmpty(texto))
        {
            string labelText = $" {texto} ";
            int padLeft = (coordenadasConsole.ObterLargura() - 2 - labelText.Length) / 2;
            parteCimaMoldura = "╔" + new string('═', padLeft) + labelText + new string('═', coordenadasConsole.ObterLargura() - 2 - padLeft - labelText.Length) + "╗";
        }

        ImprimirNaTela(parteCimaMoldura, coordenadasConsole.PosicaoInicialCursor);
        for (int i = 1; i < coordenadasConsole.AreaOcupadaConsole.Altura - 1; i++)
        {
            coordenadasConsole.IncrementarEspacosDoTopo(1);
            ImprimirNaTela(lateralEsquerdaEDireitaMoldura, coordenadasConsole.PosicaoCursor);
        }
        coordenadasConsole.IncrementarEspacosDoTopoTemporariamente(coordenadasConsole.AreaOcupadaConsole.Altura - 1);
        ImprimirNaTela(parteBaixaMoldura, coordenadasConsole.PosicaoCursor);
    }

    public static void ImprimirNaTela(string texto, PosicaoCursor posicaoCursor)
    {
        if (posicaoCursor.EspacosDoTopo >= 0 && posicaoCursor.EspacosDoTopo < Console.WindowHeight && posicaoCursor.EspacosAEsquerda >= 0 && posicaoCursor.EspacosAEsquerda < Console.WindowWidth)
        {
            Console.SetCursorPosition(posicaoCursor.EspacosAEsquerda, posicaoCursor.EspacosDoTopo);
            Console.Write(texto);
        }
    }

    public static void WriteAtV2InBlue(int x, int y, string text)
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        if (y >= 0 && y < Console.WindowHeight && x >= 0 && x < Console.WindowWidth)
        {
            string[] linhasDoTexto = text.Split('\n');

            foreach (var linha in linhasDoTexto)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(linha);
                y++; // para a próxima linha não sobrescrever a anterior
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteAtV2InRed(int x, int y, string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        if (y >= 0 && y < Console.WindowHeight && x >= 0 && x < Console.WindowWidth)
        {
            string[] linhasDoTexto = text.Split('\n');

            foreach (var linha in linhasDoTexto)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(linha);
                y++; // para a próxima linha não sobrescrever a anterior
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteAtV2WithRandomColor(int x, int y, string text)
    {
        Console.ForegroundColor = GeradorDeCores.ObterCorAleatoria();

        if (y >= 0 && y < Console.WindowHeight && x >= 0 && x < Console.WindowWidth)
        {
            string[] linhasDoTexto = text.Split('\n');

            foreach (var linha in linhasDoTexto)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(linha);
                y++; // para a próxima linha não sobrescrever a anterior
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void ShowInputOptions()
    {
        int x = 2;
        int y = Console.WindowHeight - 1;
        string[] options = {
        "[1] Velocidade",
        "[2] Potência",
        "[3] 0 a 100Km/h",
        "[4] Consumo",
        "[5] Peso",
        "[6] Fechar Jogo"
        };

        for (int i = 0; i < options.Length; i++)
        {
            var opcaoJogo = options[i].PadRight(Console.WindowWidth - 4); //vboltar aqui
            var posicaoCursor = new PosicaoCursor(x, y - options.Length + i);
            ImprimirNaTela(opcaoJogo, posicaoCursor);
        }
    }

}
