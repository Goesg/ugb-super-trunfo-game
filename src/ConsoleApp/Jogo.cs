using System;
using Core;
using Display;

namespace ConsoleApp
{

    public class Jogo
    {

        private Jogador _jogador;
        private Jogador _cpu;
        private readonly Random _random = new();


        private readonly TabuleiroJogoDisplay _tabuleiroJogoDisplay = ConstrutorDisplay.ConstrutirDisplayTabuleiro();

        public void Iniciar()
        {
            var baralho = new Baralho();
            baralho.Embaralhar();

            var (cartasJogador, cartasCpu) = baralho.DistribuirEntreJogadores();
            _jogador = new Jogador("Aluno UGB", cartasJogador);
            _cpu = new Jogador("CPU", cartasCpu);

            do
            {
                ExecutarJogoSuperTrunfo();
            }
            while (JogoEstiverEmAndamento());

        }

        internal bool JogoEstiverEmAndamento()
        {
            return _jogador.PossuiCartas() && _cpu.PossuiCartas();
        }


        internal void ExecutarJogoSuperTrunfo()
        {
            _tabuleiroJogoDisplay.ExibirNoConsole();
            ConsoleKey teclaPressionada = Console.ReadKey(intercept: true).Key;
        }

    }
}
