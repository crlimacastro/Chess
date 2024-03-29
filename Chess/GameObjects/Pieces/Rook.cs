﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

using MonoGameEngine;

namespace Chess
{
    class Rook : Piece
    {
        public Rook() : base()
        {

        }

        protected override void OnLoad(MonoGameApp app)
        {
            base.OnLoad(app);

            if (Team == Team.White)
            {
                Texture = app.Content.Load<Texture2D>("Pieces/wr");
            }
            else
            {
                Texture = app.Content.Load<Texture2D>("Pieces/br");
            }
        }

        public override IEnumerable<Tile> GetPossibleMoves(TileBoard board)
        {
            List<Tile> possibleMoves = new List<Tile>();
            Tile tileBeingChecked;

            // Check right
            for (int i = TilePosition.Coordinate.X; i < board.Tiles.GetLength(0); i++)
            {
                tileBeingChecked = board[i, TilePosition.Coordinate.Y];

                if (IsPossibleMove(tileBeingChecked))
                    possibleMoves.Add(tileBeingChecked);

                if (tileBeingChecked.Piece != null && tileBeingChecked.Piece != this)
                    break;
            }
            // Check left
            for (int i = TilePosition.Coordinate.X; i >= 0; i--)
            {
                tileBeingChecked = board[i, TilePosition.Coordinate.Y];

                if (IsPossibleMove(tileBeingChecked))
                    possibleMoves.Add(tileBeingChecked);

                if (tileBeingChecked.Piece != null && tileBeingChecked.Piece != this)
                    break;
            }
            // Check above
            for (int i = TilePosition.Coordinate.Y; i < board.Tiles.GetLength(1); i++)
            {
                tileBeingChecked = board[TilePosition.Coordinate.X, i];

                if (IsPossibleMove(tileBeingChecked))
                    possibleMoves.Add(tileBeingChecked);

                if (tileBeingChecked.Piece != null && tileBeingChecked.Piece != this)
                    break;
            }
            // Check below
            for (int i = TilePosition.Coordinate.Y; i >= 0; i--)
            {
                tileBeingChecked = board[TilePosition.Coordinate.X, i];

                if (IsPossibleMove(tileBeingChecked))
                    possibleMoves.Add(tileBeingChecked);

                if (tileBeingChecked.Piece != null && tileBeingChecked.Piece != this)
                    break;
            }

            return possibleMoves;
        }
    }
}
