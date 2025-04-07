using System;
using Display.util;

namespace Display;

public class RenderizadorTabuleiro
{

    public static void DrawBox(int x, int y, int width, int height, string? label = null)
    {
        string top = "╔" + new string('═', width - 2) + "╗";
        string bottom = "╚" + new string('═', width - 2) + "╝";
        string side = "║" + new string(' ', width - 2) + "║";

        if (!string.IsNullOrEmpty(label))
        {
            string labelText = $" {label} ";
            int padLeft = (width - 2 - labelText.Length) / 2;
            top = "╔" + new string('═', padLeft) + labelText + new string('═', width - 2 - padLeft - labelText.Length) + "╗";
        }

        WriteAt(x, y, top);
        for (int i = 1; i < height - 1; i++)
        {
            WriteAt(x, y + i, side);
        }
        WriteAt(x, y + height - 1, bottom);
    }

    public static void WriteAt(int x, int y, string text)
    {
        if (y >= 0 && y < Console.WindowHeight && x >= 0 && x < Console.WindowWidth)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
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
            WriteAt(x, y - options.Length + i, options[i].PadRight(Console.WindowWidth - 4));
        }
    }

}
