namespace nl.gn.Fen
{
    class Pieces : IProcess
    {
        private readonly FenResult result;
        private int x = 0;
        private int y = 0;


        public Pieces(FenResult result)
        {
            this.result = result;
        }


        public void Process(char c, ref IProcess step)
        {
            if (char.IsDigit(c))
            {
                int count = int.Parse($"{c}");
                this.y += count;
                return;
            }

            switch (char.ToLower(c))
            {
                case 'p':
                case 'n':
                case 'b':
                case 'r':
                case 'q':
                case 'k':
                    if ((this.x >= 8) || (this.y >= 8))
                    {
                        this.result.Error = true;
                        step = null;
                        return;
                    }
                    this.result.Board[this.x, this.y] = c;
                    ++this.y;
                    break;
                case '/':
                    if (this.y != 8)
                    {
                        this.result.Error = true;
                        step = null;
                    }
                    this.y = 0;
                    ++this.x;
                    break;
                case ' ':
                    if ((this.x != 7) ||(this.y != 8))
                    {
                        this.result.Error = true;
                        step = null;
                    }
                    step = new ActiveColor(this.result);
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
