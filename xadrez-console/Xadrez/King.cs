using Tabuleiro;

namespace Xadrez {
    class King : Piece {

        private ChessMatch match;

        public King(Board b, Color c, ChessMatch m) : base(b, c) {
            match = m;
        }

        public override string ToString() {
            return "R";
        }

        private bool IsTowerAbleToRoque(Position pos) {
            Piece p = board.ReturnPiece(pos);
            return p != null && p is Rook && p.color == color && movementQnt == 0;
        }

        public override bool[,] PossibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            // Acima
            pos.DefineValues(position.line - 1, position.column);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // NE
            pos.DefineValues(position.line - 1, position.column + 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Direita
            pos.DefineValues(position.line, position.column + 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // SE
            pos.DefineValues(position.line + 1, position.column + 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Abaixo
            pos.DefineValues(position.line + 1, position.column);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // SO
            pos.DefineValues(position.line + 1, position.column - 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Esquerda
            pos.DefineValues(position.line, position.column - 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // NO
            pos.DefineValues(position.line - 1, position.column - 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Jogada especial "roque"
            if (movementQnt == 0 && !match.isInCheck) {
                // Jogada especial "roque pequeno"
                // R1 = Rook 1 (Torre 1)
                Position posR1 = new Position(position.line, position.column + 3);
                if (IsTowerAbleToRoque(posR1)) {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (board.ReturnPiece(p1) == null && board.ReturnPiece(p2) == null) {
                        mat[position.line, position.column + 2] = true;
                    }
                }

                // Jogada especial "roque grande"
                Position posR2 = new Position(position.line, position.column - 4);
                if (IsTowerAbleToRoque(posR2)) {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.ReturnPiece(p1) == null && board.ReturnPiece(p2) == null && board.ReturnPiece(p3) == null) {
                        mat[position.line, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
