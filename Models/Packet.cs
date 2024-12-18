using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace Models
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
        JOIN_RESULT,
        OTHER_INFO,
        ROUND_UPDATE,
        GUESS_RESULT,
        LEADER_BOARD_INFO,
        DISCONNECT,
        RESET_PASSWORD,
        RESET_PASSWORD_RESULT
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
            return Encoding.UTF8.GetBytes($"LOGIN_RESULT;{result}");
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
            return Encoding.UTF8.GetBytes($"REGISTER_RESULT;{result}");
        }
    }

    public class JoinResultPacket : Packet
    {
        public string result { get; set; }
        public JoinResultPacket(string payload) : base(PacketType.JOIN_RESULT, payload)
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
            return Encoding.UTF8.GetBytes($"JOIN_RESULT;{result}");
        }
    }


    public class ResetPasswordResultPacket : Packet
    {
        public string Status { get; set; }

        public ResetPasswordResultPacket(string payload) : base(PacketType.RESET_PASSWORD_RESULT, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 1)
            {
                Status = parsePayload[0];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes($"RESET_PASSWORD_RESULT;{Status}");
        }
    }

    public class RoomInfoPacket : Packet
    {
        public string RoomId { get; set; }
        public string Host { get; set; }
        public string Status { get; set; } // "WAITING", "PLAYING", "FINISHED"
        public int MaxPlayers { get; set; }
        public int CurrentPlayers { get; set; }
        public int CurrentRound { get; set; }

        public RoomInfoPacket(string payload) : base(PacketType.ROOM_INFO, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 6)
            {
                try
                {
                    RoomId = parsePayload[0];
                    Host = parsePayload[1];
                    Status = parsePayload[2];
                    MaxPlayers = int.Parse(parsePayload[3]);
                    CurrentPlayers = int.Parse(parsePayload[4]);
                    CurrentRound = int.Parse(parsePayload[5]);
                }
                catch (FormatException ex)
                {
                    throw new ArgumentException("Dữ liệu không hợp lệ trong payload", ex);
                }
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ. Thiếu dữ liệu.");
            }
        }


        public override byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes($"ROOM_INFO;{RoomId};{Host};{Status};{MaxPlayers};{CurrentPlayers};{CurrentRound}");
        }
    }



    public class OtherInfoPacket : Packet
    {
        public string RoomId { get; set; }
        public string playerName { get; set; }
        public int Score { get; set; }
        public string Status { get; set; } // "JOINING", "JOINED", "LEAVE", "GUESS_RIGHT"

        public OtherInfoPacket(string payload) : base(PacketType.OTHER_INFO, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 4)
            {
                RoomId = parsePayload[0];
                playerName = parsePayload[1];
                Score = int.Parse(parsePayload[2]);
                Status = parsePayload[3];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes($"OTHER_INFO;{RoomId};{playerName};{Score};{Status}");
        }
    }

    public class RoundUpdatePacket : Packet
    {
        public string RoomId { get; set; }
        public string Name { get; set; }
        public string IsDrawing { get; set; }
        public string Word { get; set; }
        public RoundUpdatePacket(string payload) : base(PacketType.ROUND_UPDATE, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 4)
            {
                RoomId = parsePayload[0];
                Name = parsePayload[1];
                IsDrawing = parsePayload[2];
                Word = parsePayload[3];
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes($"ROUND_UPDATE;{RoomId};{Name};{IsDrawing};{Word}");
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
            return Encoding.UTF8.GetBytes($"GUESS_WRONG;{RoomId};{playerName};{isRight}");
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
            return Encoding.UTF8.GetBytes($"LEADER_BOARD_INFO;{playerName1};{playerName2};{playerName3}");
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
            return Encoding.UTF8.GetBytes($"LOGIN;{Payload}");
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
            return Encoding.UTF8.GetBytes($"REGISTER;{Payload}");
        }
    }

    public class ResetPasswordPacket : Packet
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public ResetPasswordPacket(string email, string newPassword) : base(PacketType.RESET_PASSWORD, $"{email};{newPassword}")
        {
            Email = email;
            NewPassword = newPassword;
        }
        public override byte[] ToBytes()
        {
            string data = $"RESET_PASSWORD;{Email};{NewPassword}";
            return Encoding.UTF8.GetBytes(data);
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
            return Encoding.UTF8.GetBytes($"LOGOUT;{Username}");
        }
    }

    public class CreateRoomPacket : Packet
    {
        public string username { get; set; }
        public int Max_player { get; set; }
        public CreateRoomPacket(string payload) : base(PacketType.CREATE_ROOM, payload)
        {
            string[] parsePayload = payload.Split(';');
            if (parsePayload.Length >= 2)
            {
                username = parsePayload[0];
                Max_player = Int32.Parse(parsePayload[1]);
            }
            else
            {
                throw new ArgumentException("Payload không hợp lệ");
            }
        }

        public override byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes($"CREATE_ROOM;{username};{Max_player}");
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
            return Encoding.UTF8.GetBytes($"JOIN_ROOM;{RoomId};{Username}");
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
            return Encoding.UTF8.GetBytes($"LEAVE_ROOM;{RoomId};{Username}");
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
            return Encoding.UTF8.GetBytes($"START;{RoomId}");
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
            return Encoding.UTF8.GetBytes($"DESCRIBE;{RoomId};{playerName};{DescribeMessage}");
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
            return Encoding.UTF8.GetBytes($"GUESS;{RoomId};{playerName};{GuessMessage}");
        }
    }
    
    public class DisconnectPacket : Packet
    {
        public DisconnectPacket(string payload) : base(PacketType.DISCONNECT, payload)
        {
            
        }

        public override byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes($"DISCONNECT");
        }
    }
   
}
