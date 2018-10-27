namespace nl.gn.Fen
{
    class HalfMoves : IProcess
    {
        private bool found;
        private readonly FenResult result;


        public HalfMoves(FenResult result)
        {
            this.result = result;
        }

        public void Process(char c, ref IProcess step)
        {
            if (char.IsDigit(c))
            {
                if (this.result.HalfMoveCount == null)
                {
                    this.result.HalfMoveCount = $"{c}";
                    this.found = true;
                }
                else
                {
                    this.result.HalfMoveCount += $"{c}";
                }
            }
            else if (c == ' ')
            {
                if (!this.found)
                {
                    this.result.Error = true;
                    step = null;
                }
                else
                {
                    step = new FullMoves(this.result);
                }
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
