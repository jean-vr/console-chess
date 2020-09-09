using Tabuleiro;

namespace Xadrez {
    class Rook : Piece {
        public Rook(Board b, Color c) : base(b, c) { }

        public override string ToString() {
            return "T";
        }

        public override bool[,] PossibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            // Acima
            pos.DefineValues(position.line - 1, position.column);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.line--;
            }

            // Abaixo
            pos.DefineValues(position.line + 1, position.column);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.line++;
            }

            // Direita
            pos.DefineValues(position.line, position.column + 1);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.column++;
            }

            // Esquerda
            pos.DefineValues(position.line, position.column - 1);
            while (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;

                if (board.ReturnPiece(pos) != null && board.ReturnPiece(pos).color != color) {
                    break;
                }
                pos.column--;
            }

            return mat;
        }
    }
}
