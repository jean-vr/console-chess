using System;
using Tabuleiro;

namespace Xadrez {
    class ChessMatch {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool isFinished { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            isFinished = false;
            PutPieces();
        }

        public void ExcuteMovement(Position from, Position to) {
            Piece p = board.RemovePiece(from);
            p.IncrementMovementQnt();
            Piece capturedPiece = board.RemovePiece(to);

            board.PutPiece(p, to);
        }

        public void PerformMove(Position from, Position to) {
            ExcuteMovement(from, to);
            turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos) {
            if (board.ReturnPiece(pos) == null) {
                throw new BoardException("Não existe peça na posição escolhida!");
            }
            if (currentPlayer != board.ReturnPiece(pos).color) {
                throw new BoardException("A peça escolhida pertence ao adversário!");
            }
            if (!board.ReturnPiece(pos).IsTherePossibleMovements()) {
                throw new BoardException("Não há movimentos possíveis para a peça escolhida!");
            }
        }

        public void ValidateDestinyPosition(Position from, Position to) {
            if (!board.ReturnPiece(from).CanItMoveTo(to)) {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        private void ChangePlayer() {
            if (currentPlayer == Color.Branca) {
                currentPlayer = Color.Preta;
            } else {
                currentPlayer = Color.Branca;
            }
        }

        private void PutPieces() {
            board.PutPiece(new Tower(board, Color.Branca), new ChessPosition('c', 1).ToPosition());
            board.PutPiece(new Tower(board, Color.Branca), new ChessPosition('c', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.Branca), new ChessPosition('d', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.Branca), new ChessPosition('e', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.Branca), new ChessPosition('e', 1).ToPosition());
            board.PutPiece(new King(board, Color.Branca), new ChessPosition('d', 1).ToPosition());

            board.PutPiece(new Tower(board, Color.Preta), new ChessPosition('c', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Preta), new ChessPosition('c', 8).ToPosition());
            board.PutPiece(new Tower(board, Color.Preta), new ChessPosition('d', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Preta), new ChessPosition('e', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Preta), new ChessPosition('e', 8).ToPosition());
            board.PutPiece(new King(board, Color.Preta), new ChessPosition('d', 8).ToPosition());
        }
    }
}
