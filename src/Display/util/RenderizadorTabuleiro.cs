using System;
using Display.util;

namespace Display;

public class RenderizadorTabuleiro
{
    public static void MoverCursorNoConsole(PosicaoCursor posicaoCursor)
    {
        Console.SetCursorPosition(posicaoCursor.EspacosAEsquerda, posicaoCursor.EspacosDoTopo);
    }

    public static void MudarCorDoTextoConsole(ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
    }

    public static void DesenharMoldura(CoordenadasConsole coordenadasDesenhoMoldura)
    {
        string parteCimaMoldura = "╔" + new string('═', coordenadasDesenhoMoldura.ObterLargura() - 2) + "╗";
        string lateralEsquerdaEDireitaMoldura = "║" + new string(' ', coordenadasDesenhoMoldura.ObterLargura() - 2) + "║";
        string parteBaixaMoldura = "╚" + new string('═', coordenadasDesenhoMoldura.ObterLargura() - 2) + "╝";

        ImprimirNaTela(parteCimaMoldura, coordenadasDesenhoMoldura.PosicaoInicialCursor);

        for (int i = 0; i < coordenadasDesenhoMoldura.AreaOcupadaConsole.Altura; i++)
        {
            coordenadasDesenhoMoldura.IncrementarEspacosDoTopo(1);
            ImprimirNaTela(lateralEsquerdaEDireitaMoldura, coordenadasDesenhoMoldura.PosicaoCursor);
        }
        coordenadasDesenhoMoldura.IncrementarEspacosDoTopoTemporariamente(coordenadasDesenhoMoldura.AreaOcupadaConsole.Altura - 1);
        ImprimirNaTela(parteBaixaMoldura, coordenadasDesenhoMoldura.PosicaoCursor);
    }

    public static void ImprimirNaTela(string texto, PosicaoCursor posicaoCursor)
    {
        if (posicaoCursor.EspacosDoTopo >= 0 && posicaoCursor.EspacosDoTopo < Console.WindowHeight && posicaoCursor.EspacosAEsquerda >= 0 && posicaoCursor.EspacosAEsquerda < Console.WindowWidth)
        {
            bool textoPossuiQuebraDeLinhas = texto.Contains('\n');

            if (textoPossuiQuebraDeLinhas)
            {
                string[] linhasDoTexto = texto.Split('\n');

                foreach (var linhaTexto in linhasDoTexto)
                {
                    MoverCursorNoConsole(posicaoCursor);
                    Console.Write(linhaTexto);
                    posicaoCursor.IncrementarEspacosDoTopo(1); // para a próxima linha do texto não sobrescrever a anterior
                }
            }
            else
            {
                MoverCursorNoConsole(posicaoCursor);
                Console.Write(texto);
            }
        }
    }

    public static void ImprimirNaTelaComCor(string texto, PosicaoCursor posicaoCursor, ConsoleColor cor)
    {
        try
        {
            MudarCorDoTextoConsole(cor);
            ImprimirNaTela(texto, posicaoCursor);
        }
        finally
        {
            MudarCorDoTextoConsole(ConsoleColor.White);
        }
    }

    public static void ImprimirNaTelaComCorAleatoria(string texto, PosicaoCursor posicaoCursor)
    {
        ImprimirNaTelaComCor(texto, posicaoCursor, GeradorDeCores.ObterCorAleatoria());
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
