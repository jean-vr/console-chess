using Tabuleiro;

namespace Xadrez {
    class Queen : Piece {
        public Queen(Board board, Color color) : base(board, color) { }

        public override string ToString() {
            return "D";
        }

        public override bool[,] PossibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            // Esquerda
            pos.DefineValues(position.line, position.column - 1);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.DefineValues(pos.line, pos.column - 1);
            }

            // Direita
            pos.DefineValues(position.line, position.column + 1);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.DefineValues(pos.line, pos.column + 1);
            }

            // Acima
            pos.DefineValues(position.line - 1, position.column);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.DefineValues(pos.line - 1, pos.column);
            }

            // Abaixo
            pos.DefineValues(position.line + 1, position.column);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.DefineValues(pos.line + 1, pos.column);
            }

            // NO
            pos.DefineValues(position.line - 1, position.column - 1);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.DefineValues(pos.line - 1, pos.column - 1);
            }

            // NE
            pos.DefineValues(position.line - 1, position.column + 1);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.DefineValues(pos.line - 1, pos.column + 1);
            }

            // SE
            pos.DefineValues(position.line + 1, position.column + 1);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.DefineValues(pos.line + 1, pos.column + 1);
            }

            // SO
            pos.DefineValues(position.line + 1, position.column - 1);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.DefineValues(pos.line + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
