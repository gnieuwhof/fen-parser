namespace nl.gn.Fen
{
    class ActiveColor : IProcess
    {
        private bool found;
        private readonly FenResult result;


        public ActiveColor(FenResult result)
        {
            this.result = result;
        }


        public void Process(char c, ref IProcess step)
        {
            switch (c)
            {
                case 'w':
                case 'b':
                    this.found = true;
                    this.result.ActiveColor = c;
                    break;
                case ' ':
                    if (!this.found)
                    {
                        this.result.Error = true;
                        step = null;
                    }
                    else
                    {
                        step = new Castling(this.result);
                    }
                    break;
                default:
                    // Unexpected char.
                    this.result.Error = true;
                    step = null;
                    break;
            }
        }
    }
}
