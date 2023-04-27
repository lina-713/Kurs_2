using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_2
{
    public class Files
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public int FileSize { get; set; }
        public int UserId { get; set; }
    }

    public class Device
    {
        public int ID { get; set; }
        public string DeviceName { get; set; }
        public string Interface { get; set; }
        public int MemorySize { get; set; }

    }
    public class Users
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string LoginUser { get; set; }
        public string PasswordUser { get; set; }

    }
    public class AuditLog
    {
        public int ID { get; set; }
        public int FileId { get; set; }
        public int UserId { get; set; }
        public string Operation { get; set; }
        public DateTime ChangeDate { get; set; }
        
    }
}
