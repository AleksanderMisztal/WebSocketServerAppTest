﻿using System.Threading.Tasks;
using GameJudge.Utils;
using GameServer.Networking.Packets;

namespace GameServer.Networking
{
    public static class ServerHandle
    {
        public static async Task JoinGame(int fromClient, Packet packet)
        {
            string username = packet.ReadString();
            User newUser = new User(fromClient, username);
            await GameHandler.SendToGame(newUser);
        }

        public static Task MoveTroop(int fromClient, Packet packet)
        {
            VectorTwo position = packet.ReadVector2Int();
            int direction = packet.ReadInt();

            GameHandler.MoveTroop(fromClient, position, direction);
            return Task.CompletedTask;
        }

        public static async Task SendMessage(int fromClient, Packet packet)
        {
            string message = packet.ReadString();

            await GameHandler.SendMessage(fromClient, message);
        }
    }
}
