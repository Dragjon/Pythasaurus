using System.Linq;
using System;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    int[,,] mgPst = {

        {
        { 82, 82, 82, 82, 82, 82, 82, 82 },
        { 180, 216, 143, 177, 150, 208, 116, 71 },
        { 76, 89, 108, 113, 147, 138, 107, 62 },
        { 68, 95, 88, 103, 105, 94, 99, 59 },
        { 55, 80, 77, 94, 99, 88, 92, 57 },
        { 56, 78, 78, 72, 85, 85, 115, 70 },
        { 47, 81, 62, 59, 67, 106, 120, 60 },
        { 82, 82, 82, 82, 82, 82, 82, 82 },
        },
        {
        {   170,   248,   303,   288,   398,   240,   322,   230,},
        {   264,   296,   409,   373,   360,   399,   344,   320,},
        {   290,   397,   374,   402,   421,   466,   410,   381,},
        {   328,   354,   356,   390,   374,   406,   355,   359,},
        {   324,   341,   353,   350,   365,   356,   358,   329,},
        {   314,   328,   349,   347,   356,   354,   362,   321,},
        {   308,   284,   325,   334,   336,   355,   323,   318,},
        {   232,   316,   279,   304,   320,   309,   318,   314,},
        },
        {
        {   336,   369,   283,   328,   340,   323,   372,   357,},
        {   339,   381,   347,   352,   395,   424,   383,   318,},
        {   349,   402,   408,   405,   400,   415,   402,   363,},
        {   361,   370,   384,   415,   402,   402,   372,   363,},
        {   359,   378,   378,   391,   399,   377,   375,   369,},
        {   365,   380,   380,   380,   379,   392,   383,   375,},
        {   369,   380,   381,   365,   372,   386,   398,   366,},
        {   332,   362,   351,   344,   352,   353,   326,   344,},
        },
        {
        {   509,   519,   509,   528,   540,   486,   508,   520,},
        {   504,   509,   535,   539,   557,   544,   503,   521,},
        {   472,   496,   503,   513,   494,   522,   538,   493,},
        {   453,   466,   484,   503,   501,   512,   469,   457,},
        {   441,   451,   465,   476,   486,   470,   483,   454,},
        {   432,   452,   461,   460,   480,   477,   472,   444,},
        {   433,   461,   457,   468,   476,   488,   471,   406,},
        {   458,   464,   478,   494,   493,   484,   440,   451,},
        },
        {
        {   997,  1025,  1054,  1037,  1084,  1069,  1068,  1070,},
        {  1001,   986,  1020,  1026,  1009,  1082,  1053,  1079,},
        {  1012,  1008,  1032,  1033,  1054,  1081,  1072,  1082,},
        {   998,   998,  1009,  1009,  1024,  1042,  1023,  1026,},
        {  1016,   999,  1016,  1015,  1023,  1021,  1028,  1022,},
        {  1011,  1027,  1014,  1023,  1020,  1027,  1039,  1030,},
        {   990,  1017,  1036,  1027,  1033,  1040,  1022,  1026,},
        {  1024,  1007,  1016,  1035,  1010,  1000,   994,   975,},
        },
        {
        { 29935, 30023, 30016, 29985, 29944, 29966, 30002, 30013,},
        { 30029, 29999, 29980, 29993, 29992, 29996, 29962, 29971,},
        { 29991, 30024, 30002, 29984, 29980, 30006, 30022, 29978,},
        { 29983, 29980, 29988, 29973, 29970, 29975, 29986, 29964,},
        { 29951, 29999, 29973, 29961, 29954, 29956, 29967, 29949,},
        { 29986, 29986, 29978, 29954, 29956, 29970, 29985, 29973,},
        { 30001, 30007, 29992, 29936, 29957, 29984, 30009, 30008,},
        { 29985, 30036, 30012, 29946, 30008, 29972, 30024, 30014,},
        }

        };

    int[,,] egPst = {
            {
        {    94,    94,    94,    94,    94,    94,    94,    94,},
        {   272,   267,   252,   228,   241,   226,   259,   281,},
        {   188,   194,   179,   161,   150,   147,   176,   178,},
        {   126,   118,   107,    99,    92,    98,   111,   111,},
        {   107,   103,    91,    87,    87,    86,    97,    93,},
        {    98,   101,    88,    95,    94,    89,    93,    86,},
        {   107,   102,   102,   104,   107,    94,    96,    87,},
        {    94,    94,    94,    94,    94,    94,    94,    94,},
            },

            {
        {   223,   243,   268,   253,   250,   254,   218,   182,},
        {   256,   273,   256,   279,   272,   256,   257,   229,},
        {   257,   261,   291,   290,   280,   272,   262,   240,},
        {   264,   284,   303,   303,   303,   292,   289,   263,},
        {   263,   275,   297,   306,   297,   298,   285,   263,},
        {   258,   278,   280,   296,   291,   278,   261,   259,},
        {   239,   261,   271,   276,   279,   261,   258,   237,},
        {   252,   230,   258,   266,   259,   263,   231,   217,},
            },
            {
        {   283,   276,   286,   289,   290,   288,   280,   273,},
        {   289,   293,   304,   285,   294,   284,   293,   283,},
        {   299,   289,   297,   296,   295,   303,   297,   301,},
        {   294,   306,   309,   306,   311,   307,   300,   299,},
        {   291,   300,   310,   316,   304,   307,   294,   288,},
        {   285,   294,   305,   307,   310,   300,   290,   282,},
        {   283,   279,   290,   296,   301,   288,   282,   270,},
        {   274,   288,   274,   292,   288,   281,   292,   280,},
            },
            {
        {   525,   522,   530,   527,   524,   524,   520,   517,},
        {   523,   525,   525,   523,   509,   515,   520,   515,},
        {   519,   519,   519,   517,   516,   509,   507,   509,},
        {   516,   515,   525,   513,   514,   513,   511,   514,},
        {   515,   517,   520,   516,   507,   506,   504,   501,},
        {   508,   512,   507,   511,   505,   500,   504,   496,},
        {   506,   506,   512,   514,   503,   503,   501,   509,},
        {   503,   514,   515,   511,   507,   499,   516,   492,},
            },
            {
        {   927,   958,   958,   963,   963,   955,   946,   956,},
        {   919,   956,   968,   977,   994,   961,   966,   936,},
        {   916,   942,   945,   985,   983,   971,   955,   945,},
        {   939,   958,   960,   981,   993,   976,   993,   972,},
        {   918,   964,   955,   983,   967,   970,   975,   959,},
        {   920,   909,   951,   942,   945,   953,   946,   941,},
        {   914,   913,   906,   920,   920,   913,   900,   904,},
        {   903,   908,   914,   893,   931,   904,   916,   895,},
            },
            {
        { 29926, 29965, 29982, 29982, 29989, 30015, 30004, 29983,},
        { 29988, 30017, 30014, 30017, 30017, 30038, 30023, 30011,},
        { 30010, 30017, 30023, 30015, 30020, 30045, 30044, 30013,},
        { 29992, 30022, 30024, 30027, 30026, 30033, 30026, 30003,},
        { 29982, 29996, 30021, 30024, 30027, 30023, 30009, 29989,},
        { 29981, 29997, 30011, 30021, 30023, 30016, 30007, 29991,},
        { 29973, 29989, 30004, 30013, 30014, 30004, 29995, 29983,},
        { 29947, 29966, 29979, 29989, 29972, 29986, 29976, 29957,},
            },

        };

    public double Evaluate(Board board)
    {
        double mgScore = 0, egScore = 0, gamePhase = 0;
        double[] gamePhaseInc = { 0, 0, 1, 1, 2, 4, 0 };
        foreach (var pl in board.GetAllPieceLists())
        {
            foreach (var p in pl)
            {
                gamePhase += gamePhaseInc[(int)p.PieceType];
                int rank = p.Square.Rank, file = p.Square.File, pceIndex = (int)p.PieceType - 1;
                if (pl.IsWhitePieceList)
                {
                    mgScore += mgPst[pceIndex, 7 - rank, file];
                    egScore += egPst[pceIndex, 7 - rank, file];
                }
                else
                {
                    mgScore -= mgPst[pceIndex, rank, file];
                    egScore -= egPst[pceIndex, rank, file];
                }
            }

        }

        if (gamePhase > 24) gamePhase = 24;
        return (mgScore * gamePhase + egScore * (24 - gamePhase)) / 24;
    }

    int nodes = 0, maxMoveTime;
    Move[] TT = new Move[8388608];
    public Move Think(Board board, Timer timer)
    {

        maxMoveTime = timer.MillisecondsRemaining / 40;
        int perspective = board.IsWhiteToMove ? 1 : -1, depth = 1;
        Move bestMove = Move.NullMove, currBestMove = Move.NullMove;
        var key = board.ZobristKey % 8388608;
        nodes = 0;

        Move[] moves = board.GetLegalMoves();

        do
            try
            {
                double alpha = -100000, beta = 100000;
                foreach (Move move in board.GetLegalMoves().OrderByDescending(move => (move == TT[key], move.CapturePieceType, 0 - move.MovePieceType)))
                {

                    board.MakeMove(move);
                    nodes++;
                    if (board.IsInCheckmate()) return move;
                    var eval = -Negamax(board, depth - 1, -beta, -alpha, -perspective, timer);

                    if (eval > alpha)
                    {
                        alpha = eval;
                        TT[key] = move;
                        currBestMove = move;
                    }

                    board.UndoMove(move);
                }
                bestMove = currBestMove;
                Console.WriteLine($"info depth {depth} time {timer.MillisecondsElapsedThisTurn} score cp {(int)alpha} nodes {nodes} nps {Convert.ToInt32(1000 * (ulong)nodes / ((ulong)timer.MillisecondsElapsedThisTurn + 1))} pv {bestMove.ToString().Substring(7, bestMove.ToString().Length - 8)}");
            }
            catch
            {
                break;
            }
        while (++depth <= 200 && timer.MillisecondsElapsedThisTurn < maxMoveTime);

        return bestMove;
    }

    private double Negamax(Board board, int depth, double alpha, double beta, int perspective, Timer timer)
    {
        // abort search if out of time, but we must search at least depth 1
        if (timer.MillisecondsElapsedThisTurn >= maxMoveTime)
            throw new Exception();

        bool isQuise = depth < 1;
        var key = board.ZobristKey % 8388608;

        if (isQuise)
        {
            double standPat = perspective * Evaluate(board);
            if (standPat >= beta) return beta;
            if (alpha < standPat) alpha = standPat;
        }

        if (board.IsInCheckmate()) return -30000 + board.PlyCount;
        if (board.IsDraw()) return 0;

        if (depth > 2 && !board.IsInCheck())
        {
            board.TrySkipTurn();
            var nullVal = -Negamax(board, depth - 3, -beta, -beta + 1, -perspective, timer);
            board.UndoSkipTurn();
            if (nullVal >= beta) return beta;
        }

        foreach (Move move in board.GetLegalMoves(isQuise).OrderByDescending(move => (move == TT[key], move.CapturePieceType, 0 - move.MovePieceType)))
        {
            if (isQuise && Evaluate(board) * perspective + (0b1_0100110100_1011001110_0110111010_0110000110_0010110100_0000000000 >> (int)move.CapturePieceType * 10 & 0b1_11111_11111) <= alpha) break;
            nodes++;
            board.MakeMove(move);
            var eval = -Negamax(board, depth - 1, -beta, -alpha, -perspective, timer);
            board.UndoMove(move);
            if (eval > alpha)
            {
                TT[key] = move;
                alpha = eval;
            }
            if (depth < 7 && alpha - depth * 75 > beta)
                return alpha;
            if (alpha >= beta) break;

        }

        return alpha;
    }



}

