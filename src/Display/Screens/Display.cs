using System;
using Display.Enum;

namespace Display;

public abstract class Display
{
    public abstract void ExibirNoConsole();

    internal void LimparTerminal()
    {
        Console.Clear();
    }


}
