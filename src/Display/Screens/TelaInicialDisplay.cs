using System;
using Display.util;

namespace Display;

public class TelaInicialDisplay : Display
{

    private readonly string _nomeArquivoTxtDoNomeDoJogoEmAscii = "logo-nome-jogo-ascii.txt";
    private readonly string _nomeArquivoTxtCarroEmAscii = "carro-ascii.txt";
    private readonly string _nomeArquivoTxtPressioneEnterEmAscii = "texto-pressione-enter-ascii.txt";


    private readonly GerenciadorArquivos _gerenciadorArquivos = new();


    public override void ExibirNoConsole()
    {
        try
        {
            string nomeDoJogoEmAscii = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtDoNomeDoJogoEmAscii);
            string carroEmAscii = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtCarroEmAscii);
            string textoPressioneEnter = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtPressioneEnterEmAscii);

            LimparTerminal();
            RenderizadorTabuleiro.ImprimirNaTela(nomeDoJogoEmAscii, new PosicaoCursor(espacosAEsquerda: 0, espacosDoTopo: 2));
            Console.ForegroundColor = GeradorDeCores.ObterCorAleatoria();
            RenderizadorTabuleiro.ImprimirNaTela(carroEmAscii, new PosicaoCursor(espacosAEsquerda: 0, espacosDoTopo: 12));
            Console.ForegroundColor = ConsoleColor.White;


            RenderizadorTabuleiro.ImprimirNaTela(textoPressioneEnter, new PosicaoCursor(espacosAEsquerda: 0, espacosDoTopo: carroEmAscii.Split('\n').Length + nomeDoJogoEmAscii.Split('\n').Length + 10));

        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao exibir tela inicial do jogo. Msg: {e.Message}");
        }
    }
}
