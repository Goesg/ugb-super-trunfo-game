using System;

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

}
