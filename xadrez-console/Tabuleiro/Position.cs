namespace Tabuleiro {
    class Position {
        public int line { get; set; }
        public int column { set; get; }

        public Position(int lin, int col) {
            line = lin;
            column = col;
        }
    }
}
