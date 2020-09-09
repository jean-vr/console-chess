using Tabuleiro;

namespace Xadrez {
    class Bishop : Piece {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString() {
            return "B";
        }

        public override bool[,] PossibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

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
