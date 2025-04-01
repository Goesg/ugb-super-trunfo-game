using System;
using Core;
using Display;

namespace ConsoleApp
{

    public class Jogo
    {

        private Jogador? _jogador;
        private Jogador? _cpu;
        private bool _opcaoDeSairSelecionado = false;
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
            return OpcaoDeSairNaoFoiSelecionada() && JogadoresPossuemCartas();
        }

        internal bool JogadoresPossuemCartas()
        {
            return (_jogador != null && _cpu != null)
            && (_jogador.PossuiCartas() && _cpu.PossuiCartas());
        }

        internal bool OpcaoDeSairNaoFoiSelecionada()
        {
            return !_opcaoDeSairSelecionado;
        }

        internal void ExecutarJogoSuperTrunfo()
        {
            bool EhVezDoJogador = true;

            _tabuleiroJogoDisplay.ExibirNoConsole();
            _tabuleiroJogoDisplay.ExibirPlacar(_jogador, _cpu);

            var cartaJogador = _jogador.JogarCartaDoTopo();
            var cartaCpu = _cpu.JogarCartaDoTopo();
            
            _tabuleiroJogoDisplay.ExibirCarta(cartaJogador);
            _tabuleiroJogoDisplay.ExibirOpcoesAtributos();

            if (EhVezDoJogador)
            {
                char opcao = Console.ReadKey(intercept: true).KeyChar;

                if ('5'.Equals(opcao))
                {
                    _opcaoDeSairSelecionado = true;
                    return;
                }

                if (!"123".Contains(opcao))
                {
                    /*                     ConsoleRenderer.UpdateStatus("Atributo inválido. Pressione ENTER para continuar...");
                     */
                    return;
                }
            }
        }

    }
}
