namespace Display.Enum
{

    public enum RegiaoTabuleiro
    {
        AreaDoJogo,
        AreaDoInput
    }

    public static class RegiaoTabuleiroEnumUtil
    {
        public static CoordenadasConsole GerarCoordenadasEmTempoReal(this RegiaoTabuleiro regiao)
        {
            return regiao switch
            {
                RegiaoTabuleiro.AreaDoJogo => GerarCoordernadasAreaDoJogo(),
                RegiaoTabuleiro.AreaDoInput => GerarCoordenadasAreaInput(),
                _ => throw new Exception($"Coordernadas da Regiao - {regiao.ToString()} não encontrada")
            };
        }

        internal static int ObterLarguraConsole()
        {
            return Console.WindowWidth;
        }

        internal static int ObterAlturaConsole()
        {
            return Console.WindowHeight;
        }

        //criar classe geradora de coordernadas

        internal static CoordenadasConsole GerarCoordernadasAreaDoJogo()
        {
            return new CoordenadasConsole
            .CoordenadasConsoleBuilder()
            .ComEspacosAEsqueda(0)
            .ComEspacosDoTopo(0)
            .ComLargura(ObterLarguraConsole())
            .ComAltura(ObterAlturaConsole() - 6)
            .Build();
        }

        internal static CoordenadasConsole GerarCoordenadasAreaInput()
        {
            return new CoordenadasConsole
            .CoordenadasConsoleBuilder()
            .ComEspacosAEsqueda(0)
            .ComEspacosDoTopo(ObterAlturaConsole() - 8)
            .ComLargura(ObterLarguraConsole())
            .ComAltura(8)
            .Build();
        }
    }

}

