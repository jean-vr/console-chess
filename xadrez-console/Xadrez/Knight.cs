using Tabuleiro;

namespace Xadrez {
    class Knight : Piece {
        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString() {
            return "C";
        }

        public override bool[,] PossibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            pos.DefineValues(position.line - 1, position.column - 2);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            pos.DefineValues(position.line - 2, position.column - 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            pos.DefineValues(position.line - 2, position.column + 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            pos.DefineValues(position.line - 1, position.column + 2);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            pos.DefineValues(position.line + 1, position.column + 2);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            pos.DefineValues(position.line + 2, position.column + 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            pos.DefineValues(position.line + 2, position.column - 1);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            pos.DefineValues(position.line + 1, position.column - 2);
            if (board.IsValidPosition(pos) && CanPieceMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }

    }
}
