﻿using GameServer.Utils;

namespace GameServer.GameLogic
{
    public class Troop
    {
        public PlayerId Player { get; }

        public int InitialMovePoints { get; private set; }
        public int MovePoints { get; private set; }

        public Vector2Int Position { get; private set; }
        public Vector2Int StartingPosition { get; set; }
        public int Orientation { get; private set; }

        public int Health { get; private set; }


        public Troop(TroopTemplate template)
        {
            Player = template.player;
            InitialMovePoints = template.movePoints;
            Health = template.health;
            Orientation = template.orientation;

            Position = template.position;
            StartingPosition = template.position;
        }

        public void MoveForward()
        {
            Position = Hex.GetAdjacentHex(Position, Orientation);
        }

        public void MoveInDirection(int direction)
        {
            if (MovePoints < 0)
            {
                throw new IllegalMoveException("Attempting to move a troop with no move points!");
            }
            if (MovePoints > 0) MovePoints--;

            Orientation = (6 + Orientation + direction) % 6;
            Position = Hex.GetAdjacentHex(Position, Orientation);
        }

        public Vector2Int GetAdjacentHex(int direction)
        {
            direction = (6 + Orientation + direction) % 6;
            return Hex.GetAdjacentHex(Position, direction);
        }

        public void ApplyDamage()
        {
            Health--;
            InitialMovePoints--;
            if (MovePoints > 0)
                MovePoints--;
        }

        public Vector2Int[] ControllZone => Hex.GetControllZone(Position, Orientation);

        public bool InControlZone(Vector2Int position)
        {
            foreach (var cell in ControllZone)
                if (cell == position)
                    return true;

            return false;
        }

        public void ResetMovePoints()
        {
            MovePoints = InitialMovePoints;
        }


        public override string ToString()
        {
            return $"cp: {Player}, p: {Position}, o: {Orientation}, imp: {InitialMovePoints}, mp: {MovePoints}, h: {Health}";
        }
    }
}
