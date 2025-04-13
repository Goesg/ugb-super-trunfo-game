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
        private string _opcoesInputsValidos = "123456";

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

            string mensagemResultadoPartida = _jogador.Cartas.Count > _cpu.Cartas.Count ? "🎉 Você venceu o jogo!" : "💻 CPU venceu o jogo!";
            _tabuleiroJogoDisplay.ExibirMensagem(mensagemResultadoPartida);
            AguardarPor();
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
                int opcaoEscolhidaJogador = AguardarEscolhaOpcoesInput();

                if (opcaoEscolhidaJogador == 6)
                {
                    _opcaoDeSairSelecionado = true;
                    return;
                }

                var atributoEscolhidoPeloJogador = (AtributoInput)opcaoEscolhidaJogador;
                atributoEscolhidoDoTurno = atributoEscolhidoPeloJogador;
            }
            else
            {
                var atributoEscolhidoPelaCpu = EscolherAtributoAleatorio(cartaCpu);
                atributoEscolhidoDoTurno = atributoEscolhidoPelaCpu;

            }

            DesenharCartaComCarroDaCpu(cartaCpu);
            DeterminarVencedorDoTurno(atributoEscolhidoDoTurno, cartaJogador, cartaCpu);

            // Alternar turno
            _ehVezDoJogador = !_ehVezDoJogador;
        }

        public int AguardarEscolhaOpcoesInput()
        {
            while (true)
            {
                _tabuleiroJogoDisplay.ExibirMensagem("Escolha uma das opções abaixo: ");
                char inputOption = Console.ReadKey(intercept: true).KeyChar;
                _tabuleiroJogoDisplay.ApagarUltimaMensagem();

                try
                {

                    if (!_opcoesInputsValidos.Contains(inputOption))
                    {
                        throw new Exception("Entrada inválida.");
                    }

                    return ConveterParaInteiro(inputOption);
                }
                catch (FormatException)
                {
                    _tabuleiroJogoDisplay.ExibirMensagem("[FormatException] Entrada inválida. Por favor, digite um número.");
                    AguardarPor();
                }
                catch (OverflowException)
                {
                    _tabuleiroJogoDisplay.ExibirMensagem("[OverflowException] Entrada inválida. Insira um número válido.");
                    AguardarPor();
                }
                catch (Exception ex)
                {
                    _tabuleiroJogoDisplay.ExibirMensagem($"Entrada inválida: {ex.Message}");
                    AguardarPor();
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

        internal int ConveterParaInteiro(char opcaoInput)
        {
            if (char.IsDigit(opcaoInput))
            {
                return int.Parse(opcaoInput.ToString());
            }

            throw new Exception("Opcao invalida");
        }

        internal AtributoInput EscolherAtributoAleatorio(Carta carta)
        {
            var posicaoSortida = _random.Next(1, 5);
            return (AtributoInput)posicaoSortida;
        }

        internal void DeterminarVencedorDoTurno(AtributoInput atributoEscolhidoDoTurno, Carta cartaDoTurnoJogador, Carta cartaDoTurnoCpu)
        {
            double valorAtributoTurnoJogador = cartaDoTurnoJogador.ObterValorAtributoPorInput(atributoEscolhidoDoTurno);
            double valorAtributoTurnoCpu = cartaDoTurnoCpu.ObterValorAtributoPorInput(atributoEscolhidoDoTurno);

            string mensagemResultadoAtributoTurno = $"{atributoEscolhidoDoTurno}: {valorAtributoTurnoJogador} (Você) vs {valorAtributoTurnoCpu} (CPU)";
            _tabuleiroJogoDisplay.ExibirResultadoDoTurno(mensagemResultadoAtributoTurno);

            if (valorAtributoTurnoJogador > valorAtributoTurnoCpu)
            {
                _jogador.ReceberCarta(cartaDoTurnoJogador);
                _jogador.ReceberCarta(cartaDoTurnoCpu);

                var mensagem = _ehVezDoJogador ? "Você venceu a rodada!" : "CPU perdeu a rodada!";
                _tabuleiroJogoDisplay.ExibirMensagem(mensagem);
            }
            else
            {
                _cpu.ReceberCarta(cartaDoTurnoCpu);
                _cpu.ReceberCarta(cartaDoTurnoJogador);

                var mensagem = _ehVezDoJogador ? "Você perdeu a rodada!" : "CPU venceu a rodada!";
                _tabuleiroJogoDisplay.ExibirMensagem(mensagem);
            }

            AguardarPor();
        }

        internal char AguardarPor()
        {
            return Console.ReadKey(intercept: true).KeyChar;
        }

    }

}
