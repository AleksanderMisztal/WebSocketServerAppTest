﻿using System.Collections.Generic;

namespace GameServer.GameLogic
{
    public class TroopSpawns
    {
        public static Dictionary<int, List<TroopTemplate>> BasicPlanes(out int maxBlueWave, out int maxRedWave)
        {
            TroopTemplate blueTroop = new TroopTemplate(PlayerId.Blue, 5, 2, 0);
            TroopTemplate redTroop = new TroopTemplate(PlayerId.Red, 5, 2, 3);

            List<TroopTemplate> wave1 = new List<TroopTemplate>
            {
                blueTroop.Deploy(8, 7), 
                blueTroop.Deploy(8, 8), 
                blueTroop.Deploy(8, 9),
                blueTroop.Deploy(8, 10),
                redTroop.Deploy(18, 6),
                redTroop.Deploy(18, 7),
                redTroop.Deploy(18, 8),
                redTroop.Deploy(18, 9),
                redTroop.Deploy(18, 10)
            };
            List<TroopTemplate> wave3 = new List<TroopTemplate>
            {
                blueTroop.Deploy(8, 7),
                blueTroop.Deploy(8, 8),
                blueTroop.Deploy(8, 9),
                blueTroop.Deploy(8, 10)
            };
            List<TroopTemplate> wave4 = new List<TroopTemplate>
            {
                redTroop.Deploy(18, 6),
                redTroop.Deploy(18, 7),
                redTroop.Deploy(18, 8),
                redTroop.Deploy(18, 9)
            };
            List<TroopTemplate> wave5 = new List<TroopTemplate>
            {
                blueTroop.Deploy(8, 7),
                blueTroop.Deploy(8, 8),
                blueTroop.Deploy(8, 9),
                blueTroop.Deploy(8, 10)
            };
            List<TroopTemplate> wave6 = new List<TroopTemplate>
            {
                redTroop.Deploy(18, 7),
                redTroop.Deploy(18, 8),
                redTroop.Deploy(18, 9)
            };

            maxBlueWave = 5;
            maxRedWave = 6;

            return new Dictionary<int, List<TroopTemplate>>
            {
                {1, wave1 },
                {3, wave3 },
                {4, wave4 },
                {5, wave5 },
                {6, wave6 },
            };
        }
    }
}