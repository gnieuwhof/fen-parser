namespace nl.gn.Fen
{
    class EnPassant : IProcess
    {
        private bool processedChar;
        private readonly FenResult result;


        public EnPassant(FenResult result)
        {
            this.result = result;
        }


        public void Process(char c, ref IProcess step)
        {
            if ((c >= 'a') && (c <= 'h'))
            {
                if (this.result.EnPassantSquare != null)
                {
                    this.result.Error = true;
                    step = null;
                }
                this.result.EnPassantSquare = $"{c}";
            }
            else if ((c >= '1') && (c <= '8'))
            {
                if ((this.result.EnPassantSquare == null) ||
                    (this.result.EnPassantSquare.Length != 1)
                    )
                {
                    this.result.Error = true;
                    step = null;
                    return;
                }
                char ep = this.result.EnPassantSquare[0];
                if ((ep < 'a') || (ep > 'h'))
                {
                    this.result.Error = true;
                    step = null;
                }
                this.result.EnPassantSquare += $"{c}";
            }
            else if (c == '-')
            {
                if (this.processedChar)
                {
                    this.result.Error = true;
                    step = null;
                }
                this.result.EnPassantSquare = "-";
            }
            else if (c == ' ')
            {
                step = new HalfMoves(this.result);
            }
            else
            {
                this.result.Error = true;
                step = null;
            }

            this.processedChar = true;
        }
    }
}
