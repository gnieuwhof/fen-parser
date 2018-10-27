namespace nl.gn.Fen
{
    using System;

    public class FenParser
    {
        public static FenResult Parse(string fen)
        {
            if (fen == null)
                throw new ArgumentNullException(nameof(fen));

            var result = new FenResult();

            if(fen == "")
            {
                result.Error = true;
                return result;
            }

            IProcess step = new Pieces(result);

            foreach (char c in fen)
            {
                if (step != null)
                {
                    step.Process(c, ref step);
                }
            }

            var fullMoves = step as FullMoves;

            if((fullMoves == null) || (!fullMoves.Found))
            {
                result.Error = true;
            }
            
            return result;
        }
    }
}
