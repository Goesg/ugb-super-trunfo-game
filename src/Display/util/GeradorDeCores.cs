using System;

namespace Display.util
{
    public class GeradorDeCores
    {
        private static readonly ConsoleColor[] _todasAsCores = new[]
         {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Gray,
            ConsoleColor.DarkGray,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.White
        };

                private static readonly ConsoleColor[] _coresTelaInicial = new[]
         {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.DarkGray,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
        };

        private static readonly Random _random = new();

        public static ConsoleColor ObterCorDeFundoConsoleAleatoria()
        {
            return _coresTelaInicial[_random.Next(_coresTelaInicial.Length)];
        }
    }
}
