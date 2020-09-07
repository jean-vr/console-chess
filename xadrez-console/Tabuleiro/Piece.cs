namespace Tabuleiro {
    class Piece {
        public Position postion { get; set; }
        public Color color { get; protected set; }
        public int movementQnt { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Position p, Board b, Color c) {
            postion = p;
            board = b;
            color = c;
            movementQnt = 0;
        }
    }
}
