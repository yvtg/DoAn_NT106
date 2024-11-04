using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Server
{
    public enum PacketType
    {
        LOGIN_RESULT,
        REGISTER_RESULT,
        ROOM_INFO,
        OTHER_INFO,
        ROUND_UPDATE,
        GUESS_RESULT,
        LEADER_BOARD_INFO
    }
    public abstract class Packet
    {
        public PacketType Type { get; set; }
        public string Payload { get; set; }

        public Packet(PacketType type, string payload)
        {
            Type = type;
            Payload = payload;
        }

        public abstract byte[] ToBytes();
    }

    public class LoginResultPacket : Packet
    {
        public string result { get; set; }
        public string username { get; set; }
        public LoginResultPacket(string payload) : base(PacketType.LOGIN_RESULT, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 2)
            {
                result = parsePayload[0];
                username = parsePayload[1];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"LOGIN_RESULT;{result};{username}");
        }
    }

    public class RegisterResultPacket : Packet
    {
        public string result { get; set; }
        public RegisterResultPacket(string payload) : base(PacketType.REGISTER_RESULT, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 1)
            {
                result = parsePayload[0];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"REGISTER_RESULT;{result}");
        }
    }

    public class RoomInfoPacket : Packet
    {
        public string playerName { get; set; }
        public string RoomId { get; set; }
        public bool isDrawer { get; set; }
        public int playerCount { get; set; }
        public bool isHost { get; set; }
        public int Score { get; set; }
        public RoomInfoPacket(string payload) : base(PacketType.ROOM_INFO, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 6)
            {
                playerName = parsePayload[0];
                RoomId = parsePayload[1];
                isDrawer = bool.Parse(parsePayload[2]);
                playerCount = int.Parse(parsePayload[3]);
                isHost = bool.Parse(parsePayload[4]);
                Score = int.Parse(parsePayload[5]);
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"ROOM_INFO;{playerName};{RoomId};{isDrawer};{playerCount};{isHost};{Score}");
        }
    }

    public class OtherInfoPacket : Packet
    {
        public string RoomId { get; set; }
        public string playerName { get; set; }
        public int Score { get; set; }

        public OtherInfoPacket(string payload) : base(PacketType.OTHER_INFO, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 3)
            {
                RoomId = parsePayload[0];
                playerName = parsePayload[1];
                Score = int.Parse(parsePayload[2]);
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"OTHER_INFO;{RoomId};{playerName};{Score}");
        }
    }

    public class RoundUpdatePacket : Packet
    {
        public string RoomId { get; set; }
        public string word { get; set; }
        public RoundUpdatePacket(string payload) : base(PacketType.ROUND_UPDATE, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 2)
            {
                RoomId = parsePayload[0];
                word = parsePayload[1];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"ROUND_UPDATE;{RoomId};{word}");
        }
    }

    public class GuessWrongPacket : Packet
    {
        public string RoomId { get; set; }
        public string playerName { get; set; }
        public bool isRight { get; set; }
        public GuessWrongPacket(string payload) : base(PacketType.GUESS_RESULT, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 3)
            {
                RoomId = parsePayload[0];
                playerName = parsePayload[1];
                isRight = bool.Parse(parsePayload[2]);
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"GUESS_WRONG;{RoomId};{playerName};{isRight}");
        }
    }

    public class LeaderBoardInfoPacket : Packet
    {
        public string playerName1 { get; set; }
        public string playerName2 { get; set; }
        public string playerName3 { get; set; }
        public int Score { get; set; }
        public LeaderBoardInfoPacket(string payload) : base(PacketType.LEADER_BOARD_INFO, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 3)
            {
                playerName1 = parsePayload[0];
                playerName2 = parsePayload[1];
                playerName3 = parsePayload[2];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"LEADER_BOARD_INFO;{playerName1};{playerName2};{playerName3}");
        }
    }
}
