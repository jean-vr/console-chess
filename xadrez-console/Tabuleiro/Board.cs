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
    }
}
