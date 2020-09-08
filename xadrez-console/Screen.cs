using System;
using Tabuleiro;
using Xadrez;

namespace xadrez_console {
    class Screen {
        public static void PrintBoard(Board board) {
            for (int i = 0; i < board.lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    if (board.ReturnPiece(i, j) == null) {
                        Console.Write("- ");
                    } else {
                        PrintPiece(board.ReturnPiece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPiece(Piece p) {
            if (p.color == Color.White) {
                Console.Write(p);
            }
            else {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p);
                Console.ForegroundColor = defaultColor;
            }
        }

        public static Position ReadChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line).ToPosition();
        }
    }
}
