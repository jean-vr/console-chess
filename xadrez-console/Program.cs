using System;
using Tabuleiro;
using Xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                while (!match.isFinished) {
                    Console.Clear();
                    Screen.PrintBoard(match.board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position from = Screen.ReadChessPosition();
                    Console.Write("Destino: ");
                    Position to = Screen.ReadChessPosition();

                    match.ExcuteMovement(from, to);
                }
                
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
