using System;
using Display.util;

namespace Display;

public class TelaInicialDisplay: Display
{

    private readonly string _nomeArquivoTxtDoNomeDoJogoEmAscii = "logo-nome-jogo-ascii.txt";
    private readonly string _nomeArquivoTxtCarroEmAscii = "carro-ascii.txt";

    private readonly GerenciadorArquivos _gerenciadorArquivos = new ();

    private readonly string _fraseTelaInicial = "\n\n\n\nPressione Enter para inicar...";

    public override void ExibirNoConsole()
    {
        try
        {
            string nomeDoJogoEmAscii = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtDoNomeDoJogoEmAscii);
            string carroEmAscii = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtCarroEmAscii);

            LimparTerminal();
            RenderizadorTabuleiro.WriteAt(0, 2, nomeDoJogoEmAscii);
            Console.ForegroundColor = GeradorDeCores.ObterCorAleatoria();
            RenderizadorTabuleiro.WriteAt(0, 12, carroEmAscii);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(_fraseTelaInicial);

        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao exibir tela inicial do jogo. Msg: {e.Message}");
        }
    }
}
