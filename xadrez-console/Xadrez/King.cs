using Tabuleiro;

namespace Xadrez {
    class King : Piece {
        public King(Board b, Color c) : base(b, c) {}

        public override string ToString() {
            return "K";
        }

        private bool CanItMove(Position pos) {
            Piece p = board.ReturnPiece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMovements() {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            // Acima
            pos.DefineValues(position.line - 1, position.column);
            if (board.IsValidPosition(pos) && CanItMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Nordeste
            pos.DefineValues(position.line - 1, position.column + 1);
            if (board.IsValidPosition(pos) && CanItMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Direita
            pos.DefineValues(position.line, position.column + 1);
            if (board.IsValidPosition(pos) && CanItMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Sudeste
            pos.DefineValues(position.line + 1, position.column + 1);
            if (board.IsValidPosition(pos) && CanItMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Abaixo
            pos.DefineValues(position.line + 1, position.column);
            if (board.IsValidPosition(pos) && CanItMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Sudoeste
            pos.DefineValues(position.line - 1, position.column - 1);
            if (board.IsValidPosition(pos) && CanItMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Esquerda
            pos.DefineValues(position.line, position.column - 1);
            if (board.IsValidPosition(pos) && CanItMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            // Noroeste
            pos.DefineValues(position.line - 1, position.column - 1);
            if (board.IsValidPosition(pos) && CanItMove(pos)) {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }
    }
}
