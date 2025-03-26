using ConsoleApp.Enum;

public static class Program
{

    private static readonly EstadoDoJogo _estadoInicialJogo = EstadoDoJogo.ExibirTelaInicial;
    private static EstadoDoJogo _estadoJogo = _estadoInicialJogo;


    public static void Main(string[] args)
    {
        while (DeveExecutarPrograma()){
            switch (_estadoJogo)
            {
                case EstadoDoJogo.ExibirTelaInicial:
                    //TODO: implementar exibicao tela inicial do jogo
                    break;
                case EstadoDoJogo.EmExecucao:
                    //TODO: implementar logica para rodar o jogo
                    break;
            }
        }
    }

    private static bool DeveExecutarPrograma()
    {
        return (!EstaEmEstadoDeEncerramento());
    }

    private static bool EstaEmEstadoDeEncerramento(){
        return EstadoDoJogo.Encerrado.Equals(_estadoJogo);
    }

    private static void ExibirTelaInicial()
    {
        
    }
}