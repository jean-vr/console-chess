using Tabuleiro;

namespace Xadrez {
    class ChessPosition {
        public char column { get; set; }
        public int line { get; set; }

        public ChessPosition(char col, int lin) {
            column = col;
            line = lin;
        }

        public Position ToPosition() {
            return new Position(8 - line, column - 'a');
        }

        public override string ToString() {
            return "" + column + line;
        }
    }
}
