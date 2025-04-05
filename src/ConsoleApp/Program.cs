using ConsoleApp;
using ConsoleApp.Enum;
using Display;

public static class Program
{

    private static readonly EstadoDoJogo _estadoInicialJogo = EstadoDoJogo.ExibirTelaInicial;
    private static EstadoDoJogo _estadoJogo = _estadoInicialJogo;

    private static readonly TelaInicialDisplay _telaInicialDisplay = ConstrutorDisplay.ConstrutirDisplayTelaInicial();
    private static readonly Jogo _jogo = new();

    public static void Main(string[] args)
    {
        while (DeveExecutarPrograma())
        {
            switch (_estadoJogo)
            {
                case EstadoDoJogo.ExibirTelaInicial:
                    ExibirTelaInicial();
                    break;
                case EstadoDoJogo.EmExecucao:
                    IniciarJogoSuperTrunfoUgb();
                    break;
            }
        }
    }

    private static bool DeveExecutarPrograma()
    {
        return (!EstaEmEstadoDeEncerramento());
    }

    private static bool EstaEmEstadoDeEncerramento()
    {
        return EstadoDoJogo.Encerrado.Equals(_estadoJogo);
    }

    internal static void ExibirTelaInicial()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        _telaInicialDisplay.ExibirNoConsole();
        AguardarTeclaSerPressionadaEMudarEstadoJogo(ConsoleKey.Enter, EstadoDoJogo.EmExecucao);
    }

    internal static void AguardarTeclaSerPressionadaEMudarEstadoJogo(ConsoleKey teclaEsperada, EstadoDoJogo novoEstado)
    {
        while (true)
        {
            ConsoleKey teclaPressionada = Console.ReadKey(intercept: true).Key;
            if (teclaEsperada.Equals(teclaPressionada))
            {
                MudarEstadoJogoPara(novoEstado);
                break;
            }
        }
    }

    internal static void IniciarJogoSuperTrunfoUgb()
    {
        _jogo.Iniciar();
        _estadoJogo = EstadoDoJogo.Encerrado;
    }

    internal static void MudarEstadoJogoPara(EstadoDoJogo novoEstado)
    {
        _estadoJogo = novoEstado;
    }

}