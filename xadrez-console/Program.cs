using System;
using Tabuleiro;
using Xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                while (!match.isFinished) {
                    try {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position from = Screen.ReadChessPosition();
                        match.ValidateOriginPosition(from);

                        bool[,] possiblePositions = match.board.ReturnPiece(from).PossibleMovements();
                        Console.Clear();
                        Screen.PrintBoard(match.board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position to = Screen.ReadChessPosition();
                        match.ValidateDestinyPosition(from, to);

                        match.PerformMove(from, to);
                    } catch (BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }  
                }
                
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
