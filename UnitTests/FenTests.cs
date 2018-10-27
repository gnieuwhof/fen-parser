namespace UnitTests
{
    using nl.gn.Fen;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class FenTests
    {
        [Test]
        public void AllWhiteKings()
        {
            string fen =
                "KKKKKKKK/" +
                "KKKKKKKK/" +
                "KKKKKKKK/" +
                "KKKKKKKK/" +
                "KKKKKKKK/" +
                "KKKKKKKK/" +
                "KKKKKKKK/" +
                "KKKKKKKK w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsFalse(result.Error);

            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    Assert.AreEqual('K', result.Board[i, j]);
                }
            }
        }

        [Test]
        public void CastlingHyphen()
        {
            string fen = "8/8/8/8/8/8/8/8 w Kq- - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void DoubleCastling()
        {
            string fen = "8/8/8/8/8/8/8/8 w KK - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void EmptyBoard()
        {
            string fen = "8/8/8/8/8/8/8/8 w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsFalse(result.Error);

            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    Assert.AreEqual('\0', result.Board[i, j]);
                }
            }
        }

        [Test]
        public void EmptyFen()
        {
            string fen = "";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void EmptyValueOnFirstRank()
        {
            string fen = "8/8/8/8/8/8/8/ w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void EnPassantHyphen()
        {
            string fen = "8/8/8/8/8/8/8/8 w - c4- 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void InvalidActiveColor()
        {
            string fen = "8/8/8/8/8/8/8/8 X - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void InvalidCastling()
        {
            string fen = "8/8/8/8/8/8/8/8 w X - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void InvalidEnPassant()
        {
            string fen = "8/8/8/8/8/8/8/8 w - X 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void InvalidEnPassantOrder()
        {
            string fen = "8/8/8/8/8/8/8/8 w - 1a 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void InvalidFullMoves()
        {
            string fen = "8/8/8/8/8/8/8/8 w - - 0 X";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void InvalidHalfMoves()
        {
            string fen = "8/8/8/8/8/8/8/8 w - - X 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void InvalidPiece()
        {
            string fen = "7X/8/8/8/8/8/8/8 w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void NegativeFullMoves()
        {
            string fen = "8/8/8/8/8/8/8/8 w - - 0 -1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void NegativeHalfMoves()
        {
            string fen = "8/8/8/8/8/8/8/8 w - - -1 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void NoActiveColor()
        {
            string fen = "8/8/8/8/8/8/8/8   - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void NoCastling()
        {
            string fen = "8/8/8/8/8/8/8/8 w   - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void NoEnPassant()
        {
            string fen = "8/8/8/8/8/8/8/8 w -   0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void NoFullMoves()
        {
            string fen = "8/8/8/8/8/8/8/8 w - - 0";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }
        
        [Test]
        public void NoMoves()
        {
            string fen = "8/8/8/8/8/8/8/8 w - -";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void NoSpaces()
        {
            string fen = "8/8/8/8/8/8/8/8w--01";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void NullFen()
        {
            string fen = null;

            Assert.Throws<ArgumentNullException>(
                () => FenParser.Parse(fen));
        }

        [Test]
        public void PieceShort()
        {
            string fen = "ppppppp/8/8/8/8/8/8/8 w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void PawnTooMuch()
        {
            string fen = "ppppppppp/8/8/8/8/8/8/8 w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void PieceTooMuch()
        {
            string fen = "9/8/8/8/8/8/8/8 w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void RankShort()
        {
            string fen = "8/8/8/8/8/8/8 w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void RandomPositions()
        {
            var fens = new[]
            {
                "3Nr1b1/pq1pRP1n/1bpPQ3/pP1PP3/Kpnp1kBR/B4PpP/P3p1r1/6N1 w - - 0 1",
                "4Nr1q/B3QPPp/P1p1P2P/1pppR1nR/prP2PB1/npk1bNK1/6pP/3b4 w - - 0 1",
                "4Bb2/1bRpp1PP/rN1Prpp1/p1n1k2P/6KB/1pP4P/pnP1pRP1/QN4q1 w - - 0 1",
                "7b/B1PKPpkp/PPpPP1p1/p2nPB2/p7/Rp4n1/P2RqpQ1/N1r1N1rb w - - 0 1",
                "n1k3NB/1qrbn1pp/1RPrP1PP/QP1Pb3/KpB1P2p/p4pPp/7p/1R5N w - - 0 1",
                "8/1rN1Kn1P/1RBpP2P/5NB1/PPr1QpRp/np1pp1Pk/PPp3qp/2b2b2 w - - 0 1",
                "n2N3b/1ppbPNpP/Pn5Q/2Rp1BBP/p1pq2Pr/k1P3rP/2pPK2p/1R6 w - - 0 1",
                "3b4/QbPPPPnp/1NppRNnR/1pP4r/pp2B1qP/Bp1r3p/2PP3k/K7 w - - 0 1",
                "1NR3K1/p5Rp/3nk2p/b1P2p1B/Pn1Qr1Pp/P1pP2pb/PpNrPPqB/8 w - - 0 1",
                "3nB1r1/qPR5/pP2N1pp/1Qpp2Rb/PP1pkPPK/Bp1NP3/rb4Pp/n7 w - - 0 1"
            };

            foreach (string fen in fens)
            {
                FenResult result = FenParser.Parse(fen);

                Assert.IsFalse(result.Error);
            }
        }

        [Test]
        public void RankTooMuch()
        {
            string fen = "8/8/8/8/8/8/8/8/8 w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }

        [Test]
        public void StartPosition()
        {
            string fen =
                "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w - - 0 1";

            FenResult result = FenParser.Parse(fen);

            Assert.IsFalse(result.Error);

            Assert.AreEqual('r', result.Board[0, 0]);
            Assert.AreEqual('n', result.Board[0, 1]);
            Assert.AreEqual('b', result.Board[0, 2]);
            Assert.AreEqual('q', result.Board[0, 3]);
            Assert.AreEqual('k', result.Board[0, 4]);
            Assert.AreEqual('b', result.Board[0, 5]);
            Assert.AreEqual('n', result.Board[0, 6]);
            Assert.AreEqual('r', result.Board[0, 7]);

            for (int i = 0; i < 8; ++i)
            {
                Assert.AreEqual('p', result.Board[1, i]);
                Assert.AreEqual('\0', result.Board[2, i]);
                Assert.AreEqual('\0', result.Board[3, i]);
                Assert.AreEqual('\0', result.Board[4, i]);
                Assert.AreEqual('\0', result.Board[5, i]);
                Assert.AreEqual('P', result.Board[6, i]);
            }

            Assert.AreEqual('R', result.Board[7, 0]);
            Assert.AreEqual('N', result.Board[7, 1]);
            Assert.AreEqual('B', result.Board[7, 2]);
            Assert.AreEqual('Q', result.Board[7, 3]);
            Assert.AreEqual('K', result.Board[7, 4]);
            Assert.AreEqual('B', result.Board[7, 5]);
            Assert.AreEqual('N', result.Board[7, 6]);
            Assert.AreEqual('R', result.Board[7, 7]);
        }

        [Test]
        public void ZeroFullMoves()
        {
            string fen = "8/8/8/8/8/8/8/8 w - - 0 0";

            FenResult result = FenParser.Parse(fen);

            Assert.IsTrue(result.Error);
        }
    }
}
