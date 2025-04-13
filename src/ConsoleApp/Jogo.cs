using System;
using Core;
using Core.ArquivosCore;
using Display;

namespace ConsoleApp
{

    public class Jogo
    {

        private Jogador _jogador;
        private Jogador _cpu;
        private bool _opcaoDeSairSelecionado = false;
        private readonly Random _random = new();

        private bool _ehVezDoJogador = true;

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
                ExecutarTurnoDoJogo();
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

        internal void ExecutarTurnoDoJogo()
        {
            DesenharTelaDoJogo();
            var cartaJogador = _jogador.JogarCartaDoTopo();
            DesenharCartaComCarroDoJogador(cartaJogador);
            _tabuleiroJogoDisplay.ExibirOpcoesAtributos();

            var cartaCpu = _cpu.JogarCartaDoTopo();

            AtributoInput atributoEscolhidoDoTurno;

            if (_ehVezDoJogador)
            {
                char opcao = Console.ReadKey(intercept: true).KeyChar;

                if ('6'.Equals(opcao))
                {
                    _opcaoDeSairSelecionado = true;
                    return;
                }

                if (!"12345".Contains(opcao))
                {
                    // feedback para informar opção invalida
                    return;

                }

                var opcaoAtributo = ConveterParaInteiro(opcao);
                var atributoEscolhidoPeloJogador = (AtributoInput)opcaoAtributo;
                atributoEscolhidoDoTurno = atributoEscolhidoPeloJogador;
            }
            else
            {
                var atributoEscolhidoPelaCpu = EscolherAtributoAleatorio(cartaCpu);
                atributoEscolhidoDoTurno = atributoEscolhidoPelaCpu;

            }

            DesenharCartaComCarroDaCpu(cartaCpu);

            DeterminarVencedorDoTurno(atributoEscolhidoDoTurno, cartaJogador, cartaCpu);
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

        internal int ConveterParaInteiro(char opcaoInput)
        {
            if (char.IsDigit(opcaoInput))
            {
                return int.Parse(opcaoInput.ToString());
            }

            return 999;
            // feedback para informar que não é um digito
        }

        internal AtributoInput EscolherAtributoAleatorio(Carta carta)
        {
            var posicaoSortida = _random.Next(4);
            return (AtributoInput)posicaoSortida;
        }

        internal char AguardarPor()
        {
            return Console.ReadKey(intercept: true).KeyChar;
        }

        internal void DeterminarVencedorDoTurno(AtributoInput atributoEscolhidoDoTurno, Carta cartaDoTurnoJogador, Carta cartaDoTurnoCpu)
        {
            double valorAtributoTurnoJogador = cartaDoTurnoJogador.ObterValorAtributoPorInput(atributoEscolhidoDoTurno);
            double valorAtributoTurnoCpu = cartaDoTurnoCpu.ObterValorAtributoPorInput(atributoEscolhidoDoTurno);

            if (valorAtributoTurnoJogador > valorAtributoTurnoCpu)
            {
                _jogador.ReceberCarta(cartaDoTurnoJogador);
                _jogador.ReceberCarta(cartaDoTurnoCpu);

                var mensagem = _ehVezDoJogador ? "Você venceu a rodada!" : "CPU perdeu a rodada!";
                _tabuleiroJogoDisplay.ExibirMensagem(mensagem);

            }

            AguardarPor();
        }

    }

}
