namespace FenConsole
{
    using nl.gn.Fen;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string fen = "1R6/P1PN1p2/kpPbpK1P/Bpp2R2/2PrP1Q1/N1P1p1np/bpq1P1r1/5Bn1 w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            if (result.Error)
            {
                Console.WriteLine("Error parsing FEN.");
            }
            else
            {
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 8; ++j)
                    {
                        if (result.Board[i, j] == '\0')
                        {
                            Console.Write('.');
                        }
                        else
                        {
                            Console.Write(result.Board[i, j]);
                        }
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
