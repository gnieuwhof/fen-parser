namespace nl.gn.Fen
{
    class FullMoves : IProcess
    {
        private readonly FenResult result;


        public FullMoves(FenResult result)
        {
            this.result = result;
        }


        public bool Found
        {
            get;
            private set;
        }


        public void Process(char c, ref IProcess step)
        {
            if (char.IsDigit(c))
            {
                if (this.result.FullMoveCount == null)
                {
                    if (c == '0')
                    {
                        this.result.Error = true;
                        step = null;
                        return;
                    }
                    this.result.FullMoveCount = $"{c}";
                    this.Found = true;
                }
                else
                {
                    this.result.FullMoveCount += $"{c}";
                }
            }
            else if (c == ' ')
            {
                this.result.Error = true;
                step = null;
            }
            else
            {
                // Unexpected char.
                this.result.Error = true;
                step = null;
            }
        }
    }
}
