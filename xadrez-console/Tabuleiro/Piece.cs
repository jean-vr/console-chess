namespace Tabuleiro {
    class Piece {
        public Position postion { get; set; }
        public Color color { get; protected set; }
        public int movementQnt { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board b, Color c) {
            postion = null;
            board = b;
            color = c;
            movementQnt = 0;
        }
    }
}
