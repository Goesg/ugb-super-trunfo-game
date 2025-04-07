using System;
using Display.util;

namespace Display;

public class TelaInicialDisplay: Display
{

    private readonly string _nomeArquivoTxtDoNomeDoJogoEmAscii = "logo-nome-jogo-ascii.txt";
    private readonly string _nomeArquivoTxtCarroEmAscii = "carro-ascii.txt";
        private readonly string _nomeArquivoTxtPressioneEnterEmAscii = "texto-pressione-enter-ascii.txt";


    private readonly GerenciadorArquivos _gerenciadorArquivos = new ();


    public override void ExibirNoConsole()
    {
        try
        {
            string nomeDoJogoEmAscii = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtDoNomeDoJogoEmAscii);
            string carroEmAscii = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtCarroEmAscii);
            string textoPressioneEnter = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtPressioneEnterEmAscii);

            LimparTerminal();
            RenderizadorTabuleiro.WriteAt(0, 2, nomeDoJogoEmAscii);
            Console.ForegroundColor = GeradorDeCores.ObterCorAleatoria();
            RenderizadorTabuleiro.WriteAt(0, 12, carroEmAscii);
            Console.ForegroundColor = ConsoleColor.White;

            RenderizadorTabuleiro.WriteAt(0, carroEmAscii.Split('\n').Length + nomeDoJogoEmAscii.Split('\n').Length + 10, textoPressioneEnter);

        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao exibir tela inicial do jogo. Msg: {e.Message}");
        }
    }
}
