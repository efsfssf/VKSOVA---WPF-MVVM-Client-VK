using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Models
{
    public class IDUser
    {
        public int? id { get; }
        public string? sity { get; }
        public string? name { get; }
        public DateTime? birthday { get; }

        public IDUser(int? id, string? sity, string? name, DateTime? birthday)
        {
            this.id = id;
            this.sity = sity;
            this.name = name;
            this.birthday = birthday;
        }

        public override string ToString()
        {
            return $"{birthday}";
        }

        public override bool Equals(object? obj)
        {
            // переопределяем
            return obj is IDUser idUser && 
                id == idUser.id &&
                sity == idUser.sity &&
                name == idUser.name &&
                birthday == idUser.birthday;
        }

        // Получем хеш-код
        public override int GetHashCode()
        {
            return HashCode.Combine(id, sity, name, birthday);
        }

        public static bool operator ==(IDUser IDuser1, IDUser IDUser2)
        {
            if (IDuser1 is null && IDUser2 is null)
            {
                return true;
            }

            return !(IDuser1 is null) && IDuser1.Equals(IDUser2);
        }

        public static bool operator !=(IDUser IDuser1, IDUser IDUser2)
        {
            return !(IDuser1 == IDUser2);
        }
    }
}
