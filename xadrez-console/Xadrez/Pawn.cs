using Tabuleiro;

namespace Xadrez {
    class Pawn : Piece {
        private ChessMatch match;

        public Pawn(Board board, Color color, ChessMatch m) : base (board, color) {
            match = m;
        }

        public override string ToString() {
            return "P";
        }

        private bool IsThereEnemy(Position pos) {
            Piece p = board.ReturnPiece(pos);
            return p != null && p.color != color;
        }

        private bool IsFree(Position pos) {
            return board.ReturnPiece(pos) == null;
        }

        public override bool[,] PossibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.Branca) {
                pos.DefineValues(position.line - 1, position.column);
                if (board.IsValidPosition(pos) && IsFree(pos)) {
                    mat[pos.line, pos.column] = true;
                }

                pos.DefineValues(position.line - 2, position.column);

                Position p2 = new Position(position.line - 1, position.column);
                if (board.IsValidPosition(pos) && IsFree(pos) && board.IsValidPosition(p2) && IsFree(p2) && movementQnt == 0) {
                    mat[pos.line, pos.column] = true;
                }

                pos.DefineValues(position.line - 1, position.column - 1);
                if (board.IsValidPosition(pos) && IsThereEnemy(pos)) {
                    mat[pos.line, pos.column] = true;
                }

                pos.DefineValues(position.line - 1, position.column + 1);
                if (board.IsValidPosition(pos) && IsThereEnemy(pos)) {
                    mat[pos.line, pos.column] = true;
                }

                // Jogada especial "en passant"
                if (position.line == 3) {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.IsValidPosition(left) && IsThereEnemy(left) && board.ReturnPiece(left) == match.isVulnerableEnPassant) {
                        mat[left.line - 1, left.column] = true;
                    }

                    Position right = new Position(position.line, position.column + 1);
                    if (board.IsValidPosition(right) && IsThereEnemy(right) && board.ReturnPiece(right) == match.isVulnerableEnPassant) {
                        mat[right.line - 1, right.column] = true;
                    }
                }
            } else {
                pos.DefineValues(position.line + 1, position.column);
                if (board.IsValidPosition(pos) && IsFree(pos)) {
                    mat[pos.line, pos.column] = true;
                }

                pos.DefineValues(position.line + 2, position.column);
                Position p2 = new Position(position.line + 1, position.column);
                if (board.IsValidPosition(p2) && IsFree(p2) && board.IsValidPosition(pos) && IsFree(pos) && movementQnt == 0) {
                    mat[pos.line, pos.column] = true;
                }

                pos.DefineValues(position.line + 1, position.column - 1);
                if (board.IsValidPosition(pos) && IsThereEnemy(pos)) {
                    mat[pos.line, pos.column] = true;
                }

                pos.DefineValues(position.line + 1, position.column + 1);
                if (board.IsValidPosition(pos) && IsThereEnemy(pos)) {
                    mat[pos.line, pos.column] = true;
                }

                // Jogada especial "en passant"
                if (position.line == 4) {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.IsValidPosition(left) && IsThereEnemy(left) && board.ReturnPiece(left) == match.isVulnerableEnPassant) {
                        mat[left.line + 1, left.column] = true;
                    }

                    Position right = new Position(position.line, position.column + 1);
                    if (board.IsValidPosition(right) && IsThereEnemy(right) && board.ReturnPiece(right) == match.isVulnerableEnPassant) {
                        mat[right.line + 1, right.column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
