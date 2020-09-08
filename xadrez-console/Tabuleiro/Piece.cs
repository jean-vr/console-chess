namespace Tabuleiro {
    abstract class Piece {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movementQnt { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board b, Color c) {
            position = null;
            board = b;
            color = c;
            movementQnt = 0;
        }

        public void IncrementMovementQnt() {
            movementQnt++;
        }

        public abstract bool[,] PossibleMovements();
    }
}
