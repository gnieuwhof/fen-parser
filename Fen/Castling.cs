﻿namespace nl.gn.Fen
{
    class Castling : IProcess
    {
        private bool processedChar;
        private readonly FenResult result;


        public Castling(FenResult result)
        {
            this.result = result;
        }


        public void Process(char c, ref IProcess step)
        {
            switch (c)
            {
                case 'K':
                    if(this.result.WhiteCanCastleKingside)
                    {
                        this.result.Error = true;
                        step = null;
                    }
                    this.result.WhiteCanCastleKingside = true;
                    break;
                case 'Q':
                    if (this.result.WhiteCanCastleQueenside)
                    {
                        this.result.Error = true;
                        step = null;
                    }
                    this.result.WhiteCanCastleQueenside = true;
                    break;
                case 'k':
                    if (this.result.BlackCanCastleKingside)
                    {
                        this.result.Error = true;
                        step = null;
                    }
                    this.result.BlackCanCastleKingside = true;
                    break;
                case 'q':
                    if (this.result.BlackCanCastleQueenside)
                    {
                        this.result.Error = true;
                        step = null;
                    }
                    this.result.BlackCanCastleQueenside = true;
                    break;
                case '-':
                    if(this.processedChar)
                    {
                        this.result.Error = true;
                        step = null;
                    }
                    break;
                case ' ':
                    step = new EnPassant(this.result);
                    break;
                default:
                    // Unexpected char.
                    this.result.Error = true;
                    step = null;
                    break;
            }

            this.processedChar = true;
        }
    }
}
