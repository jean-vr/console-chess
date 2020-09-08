using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez {
    class ChessMatch {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool isFinished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            isFinished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public void ExcuteMovement(Position from, Position to) {
            Piece p = board.RemovePiece(from);
            p.IncrementMovementQnt();
            Piece capturedPiece = board.RemovePiece(to);
            
            board.PutPiece(p, to);

            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> ReturnCapturedPieces(Color c) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in captured) {
                if (p.color == c) {
                    aux.Add(p);
                }
            }

            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color c) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in captured) {
                if (p.color == c) {
                    aux.Add(p);
                }
            }

            aux.ExceptWith(ReturnCapturedPieces(c));
            return aux;
        }

        public void PutNewPiece(char col, int line, Piece p) {
            board.PutPiece(p, new ChessPosition(col, line).ToPosition());
            pieces.Add(p);
        }

        private void PutPieces() {
            PutNewPiece('c', 1, new Tower(board, Color.Branca));
            PutNewPiece('c', 2, new Tower(board, Color.Branca));
            PutNewPiece('d', 2, new Tower(board, Color.Branca));
            PutNewPiece('e', 2, new Tower(board, Color.Branca));
            PutNewPiece('e', 1, new Tower(board, Color.Branca));
            PutNewPiece('d', 1, new King(board, Color.Branca));

            PutNewPiece('c', 7, new Tower(board, Color.Preta));
            PutNewPiece('c', 8, new Tower(board, Color.Preta));
            PutNewPiece('d', 7, new Tower(board, Color.Preta));
            PutNewPiece('e', 7, new Tower(board, Color.Preta));
            PutNewPiece('e', 8, new Tower(board, Color.Preta));
            PutNewPiece('d', 8, new King(board, Color.Preta));
        }
    }
}
