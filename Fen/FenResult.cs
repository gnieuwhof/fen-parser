namespace nl.gn.Fen
{
    public class FenResult
    {
        public char[,] Board = new char[8,8];

        public char ActiveColor;

        public bool WhiteCanCastleKingside;
        public bool WhiteCanCastleQueenside;
        public bool BlackCanCastleKingside;
        public bool BlackCanCastleQueenside;

        public string EnPassantSquare;

        public string HalfMoveCount;
        public string FullMoveCount;

        public bool Error = false;
    }
}
