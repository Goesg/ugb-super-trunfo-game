using System;
using Core;
using Display;

namespace ConsoleApp
{

    public class Jogo
    {

        private Jogador _jogador;
        private Jogador _cpu;
        private bool _opcaoDeSairSelecionado = false;
        private readonly Random _random = new();

        private readonly TabuleiroJogoDisplay _tabuleiroJogoDisplay = ConstrutorDisplay.ConstrutirDisplayTabuleiro();
        private readonly GeradorImagemAscii _geradorImagemAscii = new();

        public void Iniciar()
        {
            Console.BackgroundColor = ConsoleColor.Black;

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

            DesenharTelaDoJogo();

            var cartaJogador = _jogador.JogarCartaDoTopo();
            var cartaCpu = _cpu.JogarCartaDoTopo();

            DesenharCartaComCarroDoJogador(cartaJogador);
            DesenharCartaComCarroDaCpu(cartaCpu);


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

        public void DesenharTelaDoJogo()
        {
            _tabuleiroJogoDisplay.ExibirNoConsole();
            TabuleiroJogoDisplay.ExibirPlacar(_jogador, _cpu);
        }

        public void DesenharCartaComCarroDoJogador(Carta carta)
        {
            var cartaAsciiDisplay = _geradorImagemAscii.DesenharCarta(carta.Atributos);
            var carroAsciiDisplay = _geradorImagemAscii.DesenharCarroAleatorio();

            _tabuleiroJogoDisplay.ExibirCartaComCarroJogador(cartaAsciiDisplay, carroAsciiDisplay);
        }

        public void DesenharCartaComCarroDaCpu(Carta carta)
        {
            var cartaAsciiDisplay = _geradorImagemAscii.DesenharCarta(carta.Atributos);
            var carroAsciiDisplay = _geradorImagemAscii.DesenharCarroAleatorio();

            _tabuleiroJogoDisplay.ExibirCartaComCarroCpu(cartaAsciiDisplay, carroAsciiDisplay);
        }
    }
}
