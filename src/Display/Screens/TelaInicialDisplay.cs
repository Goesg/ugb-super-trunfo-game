using System;
using Display.util;

namespace Display;

public class TelaInicialDisplay: Display
{

    private readonly string _nomeArquivoTxtDoNomeDoJogoEmAscii = "logo-nome-jogo-ascii.txt";
    private readonly GerenciadorArquivos _gerenciadorArquivos = new ();

    private readonly string _fraseTelaInicial = "\n\n\n Pressione Enter para inicar...";

    public override void ExibirNoConsole()
    {
        try
        {
            string nomeDoJogoEmAscii = _gerenciadorArquivos.ObterConteudoArquivoPorNome(_nomeArquivoTxtDoNomeDoJogoEmAscii);
            LimparTerminal();
            Console.WriteLine(nomeDoJogoEmAscii);
            Console.WriteLine(_fraseTelaInicial);
            Console.BackgroundColor = GeradorDeCores.ObterCorDeFundoConsoleAleatoria();

        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao exibir tela inicial do jogo. Msg: {e.Message}");
        }
    }
}
