﻿using System;
using Tabuleiro;
using Xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                Board board = new Board(8, 8);

                board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Tower(board, Color.Black), new Position(1, 3));
                board.PutPiece(new King(board, Color.Black), new Position(2, 4));

                Screen.PrintBoard(board);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
