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

        public void DecrementMovementQnt() {
            movementQnt--;
        }

        public bool IsTherePossibleMovements() {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < board.lines; i++) {
                for (int j = 0; j < board.columns; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        protected bool CanPieceMove(Position pos) {
            Piece p = board.ReturnPiece(pos);
            return p == null || p.color != color;
        }
        
        public bool CanItMoveTo(Position pos) {
            return PossibleMovements()[pos.line, pos.column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
