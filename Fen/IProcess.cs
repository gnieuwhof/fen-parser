namespace nl.gn.Fen
{
    interface IProcess
    {
        void Process(char c, ref IProcess step);
    }
}
