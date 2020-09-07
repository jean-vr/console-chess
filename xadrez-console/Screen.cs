using System;
using Tabuleiro;

namespace xadrez_console {
    class Screen {
        public static void PrintBoard(Board board) {
            for (int i = 0; i < board.lines; i++) {
                for (int j = 0; j < board.columns; j++) {
                    if (board.ReturnPiece(i, j) == null) {
                        Console.Write("- ");
                    } else {
                        Console.Write(board.ReturnPiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
