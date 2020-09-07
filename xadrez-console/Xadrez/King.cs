using Tabuleiro;

namespace Xadrez {
    class King : Piece {
        public King(Board b, Color c) : base(b, c) {}

        public override string ToString() {
            return "K";
        }
    }
}
