namespace Tabuleiro {
    class Board {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lin, int col) {
            lines = lin;
            columns = col;
            pieces = new Piece[lin, col];
        }

        public Piece ReturnPiece(int line, int col) {
            return pieces[line, col];
        }

        public Piece ReturnPiece(Position pos) {
            return pieces[pos.line, pos.column];
        }

        public void PutPiece(Piece p, Position pos) {
            if (IsThereAPiece(pos)) {
                throw new BoardException("Já existe uma peça nesta posição!");
            }

            pieces[pos.line, pos.column] = p;
            p.postion = pos;
        }

        public Piece RemovePiece(Position pos) {
            if (ReturnPiece(pos) == null) {
                return null;
            }

            Piece aux = ReturnPiece(pos);
            aux.postion = null;
            pieces[pos.line, pos.column] = null;
            return aux;
        }

        public bool IsThereAPiece(Position pos) {
            ValidatePostion(pos);
            return ReturnPiece(pos) != null;
        }

        public bool IsValidPosition(Position pos) {
            if (pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns) {
                return false;
            }

            return true;
        }

        public void ValidatePostion(Position pos) {
            if (!IsValidPosition(pos)) {
                throw new BoardException("Posição inválida!");
            }
        }
    }
}
