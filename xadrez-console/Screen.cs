﻿using System;
using Tabuleiro;
using Xadrez;

namespace xadrez_console {
    class Screen {
        public static void PrintBoard(Board board) {
            for (int i = 0; i < board.lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    PrintPiece(board.ReturnPiece(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions) {
            ConsoleColor defaultBg = Console.BackgroundColor;
            ConsoleColor grayBg = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    if (possiblePositions[i, j]) {
                        Console.BackgroundColor = grayBg;
                    } else {
                        Console.BackgroundColor = defaultBg;
                    }

                    PrintPiece(board.ReturnPiece(i, j));
                    Console.BackgroundColor = defaultBg;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPiece(Piece p) {
            if (p == null) {
                Console.Write("- ");
            } else {
                if (p.color == Color.Branca) {
                    Console.Write(p);
                }
                else {
                    ConsoleColor defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(p);
                    Console.ForegroundColor = defaultColor;
                }
                Console.Write(" ");
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
