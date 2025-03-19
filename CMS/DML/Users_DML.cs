using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DML
{
    public class Users_DML
    {
        /*      UserId INT IDENTITY(1,1) PRIMARY KEY,
                Username VARCHAR(50) NOT NULL UNIQUE,
                PasswordHash NVARCHAR(256) NOT NULL,
                RoleUsers NVARCHAR(50) NOT NULL,
                Email NVARCHAR(100) NOT NULL UNIQUE,
                SecurityQuestion VARBINARY(MAX) NOT NULL,
                SecurityAnswerHash VARBINARY(MAX) NOT NULL,
                LastLogin DATETIME NULL,
                IsActive BIT DEFAULT 1 NOT NULL,
                CreatedDate DATETIME NOT NULL DEFAULT GETDATE()*/
        private int UserId;
        private string Username;
        private string PasswordHash;
        private string RoleUsers;
        private string Email;
        private byte[] SecurityQuestion;
        private byte[] SecurityAnswerHash;
        private DateTime? LastLogin;
        private bool IsActive;
        private DateTime CreatedDate;

        public Users_DML()
        {
        }

        public Users_DML(int userId, string username, string passwordHash, string roleUsers, string email, byte[] securityQuestion,
            byte[] securityAnswerHash, DateTime? lastLogin, bool isActive, DateTime createdDate)
        {
            UserId1 = userId;
            Username1 = username;
            PasswordHash1 = passwordHash;
            RoleUsers1 = roleUsers;
            Email1 = email;
            SecurityQuestion1 = securityQuestion;
            SecurityAnswerHash1 = securityAnswerHash;
            LastLogin1 = lastLogin;
            IsActive1 = isActive;
            CreatedDate1 = createdDate;
        }

        public int UserId1 { get => UserId; set => UserId = value; }
        public string Username1 { get => Username; set => Username = value; }
        public string PasswordHash1 { get => PasswordHash; set => PasswordHash = value; }
        public string RoleUsers1 { get => RoleUsers; set => RoleUsers = value; }
        public string Email1 { get => Email; set => Email = value; }
        public byte[] SecurityQuestion1 { get => SecurityQuestion; set => SecurityQuestion = value; }
        public byte[] SecurityAnswerHash1 { get => SecurityAnswerHash; set => SecurityAnswerHash = value; }
        public DateTime? LastLogin1 { get => LastLogin; set => LastLogin = value; }
        public bool IsActive1 { get => IsActive; set => IsActive = value; }
        public DateTime CreatedDate1 { get => CreatedDate; set => CreatedDate = value; }
    }
}
