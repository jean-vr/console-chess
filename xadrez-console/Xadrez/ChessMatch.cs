using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez {
    class ChessMatch {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool isFinished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool isInCheck { get; private set; }
        public Piece isVulnerableEnPassant { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            isFinished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            isInCheck = false;
            isVulnerableEnPassant = null;
            PutPieces();
        }

        public Piece ExcuteMovement(Position from, Position to) {
            Piece p = board.RemovePiece(from);
            p.IncrementMovementQnt();
            Piece capturedPiece = board.RemovePiece(to);
            
            board.PutPiece(p, to);

            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }

            // Jogada especial "roque pequeno"
            if (p is King && to.column == from.column + 2) {
                Position originRook = new Position(from.line, from.column + 3);
                Position destinyRook = new Position(from.line, from.column + 1);

                Piece rook = board.RemovePiece(originRook);
                rook.IncrementMovementQnt();
                board.PutPiece(rook, destinyRook);
            }

            // Jogada especial "roque grande"
            if (p is King && to.column == from.column - 2) {
                Position originRook = new Position(from.line, from.column - 4);
                Position destinyRook = new Position(from.line, from.column - 1);

                Piece rook = board.RemovePiece(originRook);
                rook.IncrementMovementQnt();
                board.PutPiece(rook, destinyRook);
            }

            // Jogada especial "en passant"
            if (p is Pawn) {
                if (from.column != to.column && capturedPiece == null) {
                    Position posP;

                    if (p.color == Color.Branca) {
                        posP = new Position(to.line + 1, to.column);
                    } else {
                        posP = new Position(to.line - 1, to.column);
                    }

                    capturedPiece = board.RemovePiece(posP);
                    captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void PerformMove(Position from, Position to) {
            Piece capturedPiece = ExcuteMovement(from, to);
            
            if (IsInCheck(currentPlayer)) {
                UndoMovement(from, to, capturedPiece);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (IsInCheck(Enemy(currentPlayer))) {
                isInCheck = true;
            } else {
                isInCheck = false;
            }

            if (CheckMateTest(Enemy(currentPlayer))) {
                isFinished = true;
            } else {
                turn++;
                ChangePlayer();
            }

            Piece p = board.ReturnPiece(to);

            // Jogada especial "en passant"
            if (p is Pawn && (to.line == from.line - 2 || to.line == from.line + 2)) {
                isVulnerableEnPassant = p;
            } else {
                isVulnerableEnPassant = null;
            }
        }

        public void UndoMovement(Position from, Position to, Piece capturedPiece) {
            Piece p = board.RemovePiece(to);
            p.DecrementMovementQnt();

            if (capturedPiece != null) {
                board.PutPiece(capturedPiece, to);
                captured.Remove(capturedPiece);
            }

            board.PutPiece(p, from);

            // Jogada especial "roque pequeno"
            if (p is King && to.column == from.column + 2) {
                Position originRook = new Position(from.line, from.column + 3);
                Position destinyRook = new Position(from.line, from.column + 1);

                Piece rook = board.RemovePiece(destinyRook);
                rook.DecrementMovementQnt();
                board.PutPiece(rook, originRook);
            }

            // Jogada especial "roque grande"
            if (p is King && to.column == from.column - 2) {
                Position originRook = new Position(from.line, from.column - 4);
                Position destinyRook = new Position(from.line, from.column - 1);

                Piece rook = board.RemovePiece(destinyRook);
                rook.DecrementMovementQnt();
                board.PutPiece(rook, originRook);
            }

            // Jogada especial "en passant"
            if (p is Pawn) {
                if (from.column != to.column && capturedPiece == isVulnerableEnPassant) {
                    Piece pawn = board.RemovePiece(to);
                    Position posP;

                    if (p.color == Color.Branca) {
                        posP = new Position(3, to.column);
                    } else {
                        posP = new Position(4, to.column);
                    }

                    board.PutPiece(pawn, posP);
                }
            }
        }

        public void ValidateOriginPosition(Position pos) {
            if (board.ReturnPiece(pos) == null) {
                throw new BoardException("Não existe peça na posição escolhida!");
            }
            if (currentPlayer != board.ReturnPiece(pos).color) {
                throw new BoardException("A peça escolhida pertence ao adversário!");
            }
            if (!board.ReturnPiece(pos).IsTherePossibleMovements()) {
                throw new BoardException("Não há movimentos possíveis para a peça escolhida!");
            }
        }

        public void ValidateDestinyPosition(Position from, Position to) {
            if (!board.ReturnPiece(from).CanItMoveTo(to)) {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        private void ChangePlayer() {
            if (currentPlayer == Color.Branca) {
                currentPlayer = Color.Preta;
            } else {
                currentPlayer = Color.Branca;
            }
        }

        public HashSet<Piece> ReturnCapturedPieces(Color c) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in captured) {
                if (p.color == c) {
                    aux.Add(p);
                }
            }

            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color c) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in pieces) {
                if (p.color == c) {
                    aux.Add(p);
                }
            }

            aux.ExceptWith(ReturnCapturedPieces(c));
            return aux;
        }

        private Color Enemy(Color c) {
            if (c == Color.Branca) {
                return Color.Preta;
            } else {
                return Color.Branca;
            }
        }

        private Piece ReturnKing(Color c) {
            foreach (Piece p in PiecesInGame(c)) {
                if (p is King) {
                    return p;
                }
            }

            return null;
        }

        public bool IsInCheck(Color c) {
            Piece K = ReturnKing(c);
            if (K == null) {
                throw new BoardException("Não há King da cor " + c + " no tabuleiro!");
            }

            foreach (Piece p in PiecesInGame(Enemy(c))) {
                bool[,] mat = p.PossibleMovements();
                
                // Caso dentro das posições possíveis de cada peça exista a posição do King
                if (mat[K.position.line, K.position.column]) {
                    return true;
                }
            }

            return false;
        }

        public bool CheckMateTest(Color c) {
            if (!IsInCheck(c)) {
                return false;
            }

            foreach (Piece p in PiecesInGame(c)) {
                bool[,] mat = p.PossibleMovements();

                for (int i = 0; i < board.lines; i++) {
                    for (int j = 0; j < board.columns; j++) {
                        if (mat[i, j]) {
                            Position from = p.position;
                            Position to = new Position(i, j);
                            Piece capturedPiece = ExcuteMovement(from, to);
                            bool checkTest = IsInCheck(c);
                            UndoMovement(from, to, capturedPiece);

                            if (!checkTest) {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
             
        public void PutNewPiece(char col, int line, Piece p) {
            board.PutPiece(p, new ChessPosition(col, line).ToPosition());
            pieces.Add(p);
        }

        private void PutPieces() {
            PutNewPiece('a', 1, new Rook(board, Color.Branca));
            PutNewPiece('b', 1, new Knight(board, Color.Branca));
            PutNewPiece('c', 1, new Bishop(board, Color.Branca));
            PutNewPiece('d', 1, new Queen(board, Color.Branca));
            PutNewPiece('e', 1, new King(board, Color.Branca, this));
            PutNewPiece('f', 1, new Bishop(board, Color.Branca));
            PutNewPiece('g', 1, new Knight(board, Color.Branca));
            PutNewPiece('h', 1, new Rook(board, Color.Branca));
            PutNewPiece('a', 2, new Pawn(board, Color.Branca, this));
            PutNewPiece('b', 2, new Pawn(board, Color.Branca, this));
            PutNewPiece('c', 2, new Pawn(board, Color.Branca, this));
            PutNewPiece('d', 2, new Pawn(board, Color.Branca, this));
            PutNewPiece('e', 2, new Pawn(board, Color.Branca, this));
            PutNewPiece('f', 2, new Pawn(board, Color.Branca, this));
            PutNewPiece('g', 2, new Pawn(board, Color.Branca, this));
            PutNewPiece('h', 2, new Pawn(board, Color.Branca, this));

            PutNewPiece('a', 8, new Rook(board, Color.Preta));
            PutNewPiece('b', 8, new Knight(board, Color.Preta));
            PutNewPiece('c', 8, new Bishop(board, Color.Preta));
            PutNewPiece('d', 8, new Queen(board, Color.Preta));
            PutNewPiece('e', 8, new King(board, Color.Preta, this));
            PutNewPiece('f', 8, new Bishop(board, Color.Preta));
            PutNewPiece('g', 8, new Knight(board, Color.Preta));
            PutNewPiece('h', 8, new Rook(board, Color.Preta));
            PutNewPiece('a', 7, new Pawn(board, Color.Preta, this));
            PutNewPiece('b', 7, new Pawn(board, Color.Preta, this));
            PutNewPiece('c', 7, new Pawn(board, Color.Preta, this));
            PutNewPiece('d', 7, new Pawn(board, Color.Preta, this));
            PutNewPiece('e', 7, new Pawn(board, Color.Preta, this));
            PutNewPiece('f', 7, new Pawn(board, Color.Preta, this));
            PutNewPiece('g', 7, new Pawn(board, Color.Preta, this));
            PutNewPiece('h', 7, new Pawn(board, Color.Preta, this));
        }
    }
}
