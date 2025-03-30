using System;
using Display;

namespace ConsoleApp
{

    public class Jogo
    {

        private readonly TabuleiroJogoDisplay _tabuleiroJogoDisplay = ConstrutorDisplay.ConstrutirDisplayTabuleiro();

        public void Iniciar()
        {

            while (JogoEstiverEmAndamento())
            {
                ExecutarJogoSuperTrunfo();
            }

        }

        internal bool JogoEstiverEmAndamento()
        {
            //implementar a logica
            return true;
        }

        internal void ExecutarJogoSuperTrunfo()
        {
            _tabuleiroJogoDisplay.ExibirNoConsole();
            ConsoleKey teclaPressionada = Console.ReadKey(intercept: true).Key;
        }

    }
}
