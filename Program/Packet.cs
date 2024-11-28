using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Program
{
    public enum PacketType
    {
        LOGIN,
        REGISTER,
        LOGOUT,
        CREATE_ROOM,
        JOIN_ROOM,
        LEAVE_ROOM,
        START,
        DESCRIBE,
        GUESS,
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
        public string RoomId { get; set; }
        public string playerName { get; set; }
        public bool isDrawer { get; set; }
        public int playerCount { get; set; }
        public bool isHost { get; set; }
        public int Score { get; set; }
        public RoomInfoPacket(string payload) : base(PacketType.ROOM_INFO, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 6)
            {
                RoomId = parsePayload[0];
                playerName = parsePayload[1];
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
            return Encoding.ASCII.GetBytes($"ROOM_INFO;{RoomId};{playerName};{isDrawer};{playerCount};{isHost};{Score}");
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
        public string Word { get; set; }
        public RoundUpdatePacket(string payload) : base(PacketType.ROUND_UPDATE, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 2)
            {
                RoomId = parsePayload[0];
                Word = parsePayload[1];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"ROUND_UPDATE;{RoomId};{Word}");
        }
    }

    public class GuessResultPacket : Packet
    {
        public string RoomId { get; set; }
        public string playerName { get; set; }
        public bool isRight { get; set; }
        public GuessResultPacket(string payload) : base(PacketType.GUESS_RESULT, payload)
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

    public class LoginPacket : Packet
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginPacket(string payload) : base(PacketType.LOGIN, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 2)
            {
                Username = parsePayload[0];
                Password = parsePayload[1];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"LOGIN;{Payload}");
        }
    }

    public class RegisterPacket : Packet
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RegisterPacket(string payload) : base(PacketType.REGISTER, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 3)
            {
                Username = parsePayload[0];
                Email = parsePayload[1];
                Password = parsePayload[2];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }
        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"REGISTER;{Payload}");
        }
    }

    public class LogoutPacket : Packet
    {
        public string Username { get; set; }
        public LogoutPacket(string payload) : base(PacketType.LOGOUT, payload)
        {
            Username = payload;
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"LOGOUT;{Username}");
        }
    }
    public class CreateRoomPacket : Packet
    {
        public int Max_player { get; set; }
        public CreateRoomPacket(string payload) : base(PacketType.CREATE_ROOM, payload)
        {
            Max_player = Int32.Parse(payload);
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"CREATE_ROOM;{Max_player}");
        }
    }

    public class JoinRoomPacket : Packet
    {
        public string RoomId { get; set; }
        public string Username { get; set; }
        public JoinRoomPacket(string payload) : base(PacketType.JOIN_ROOM, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 2)
            {
                Username = parsePayload[0];
                RoomId = parsePayload[1];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }
        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"JOIN_ROOM;{RoomId};{Username}");
        }
    }

    public class LeaveRoomPacket : Packet
    {
        public string RoomId { get; set; }
        public string Username { get; set; }
        public LeaveRoomPacket(string payload) : base(PacketType.LEAVE_ROOM, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 2)
            {
                Username = parsePayload[0];
                RoomId = parsePayload[1];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }
        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"LEAVE_ROOM;{RoomId};{Username}");
        }
    }

    public class StartPacket : Packet
    {
        public string RoomId { get; set; }
        public StartPacket(string payload) : base(PacketType.START, payload)
        {
            RoomId = payload;
        }
        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"START;{RoomId}");
        }
    }

    public class DescribePacket : Packet
    {
        public string RoomId { get; set; }
        public string playerName { get; set; }
        public string DescribeMessage { get; set; }
        public DescribePacket(string payload) : base(PacketType.DESCRIBE, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 3)
            {
                RoomId = parsePayload[0];
                playerName = parsePayload[1];
                DescribeMessage = parsePayload[2];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }
        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"DESCRIBE;{RoomId};{playerName};{DescribeMessage}");
        }
    }

    public class GuessPacket : Packet
    {
        public string RoomId { get; set; }
        public string playerName { get; set; }
        public string GuessMessage { get; set; }
        public GuessPacket(string payload) : base(PacketType.GUESS, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 3)
            {
                RoomId = parsePayload[0];
                playerName = parsePayload[1];
                GuessMessage = parsePayload[2];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }
        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"GUESS;{RoomId};{playerName};{GuessMessage}");
        }
    }
}
