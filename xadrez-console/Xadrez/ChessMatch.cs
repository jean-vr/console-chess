using System;
using Tabuleiro;

namespace Xadrez {
    class ChessMatch {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool isFinished { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            isFinished = false;
            PutPieces();
        }

        public void ExcuteMovement(Position from, Position to) {
            Piece p = board.RemovePiece(from);
            p.IncrementMovementQnt();
            Piece capturedPiece = board.RemovePiece(to);

            board.PutPiece(p, to);
        }

        private void PutPieces() {
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('c', 1).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('c', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('d', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('e', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('e', 1).ToPosition());
            board.PutPiece(new King(board, Color.White), new ChessPosition('d', 1).ToPosition());

            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).ToPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).ToPosition());
            board.PutPiece(new King(board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
