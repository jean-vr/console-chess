using Tabuleiro;

namespace Xadrez {
    class Tower : Piece {
        public Tower(Board b, Color c) : base(b, c) { }

        public override string ToString() {
            return "T";
        }
    }
}
