using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
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
        GUESS
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
        public string Password { get; set; }
        public string Email { get; set; }
        public RegisterPacket(string payload) : base(PacketType.REGISTER, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 2)
            {
                Username = parsePayload[0];
                Password = parsePayload[1];
                Email = parsePayload[2];
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
        public string Username { get; set; }
        public CreateRoomPacket(string payload) : base(PacketType.CREATE_ROOM, payload)
        {
            Username = payload;
        }

        public override byte[] ToBytes()
        {
            return Encoding.ASCII.GetBytes($"CREATE_ROOM;{Username}");
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
                RoomId = parsePayload[0];
                Username = parsePayload[1];
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
                RoomId = parsePayload[0];
                Username = parsePayload[1];
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

