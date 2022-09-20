using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Models;

namespace TestWPF.Exceptions
{
    public class UserConflictException : Exception
    {
        // Существующий пользователь
        public User ExistingUser { get; }
        public User AddUser { get; }
        public UserConflictException(User existingUser, User addUser)
        {
            ExistingUser = existingUser;
            AddUser = addUser;
        }

        public UserConflictException(string? message, User existingUser, User addUser) : base(message)
        {
            ExistingUser = existingUser;
            AddUser = addUser;
        }

        public UserConflictException(string? message, Exception? innerException, User existingUser, User addUser) : base(message, innerException)
        {
            ExistingUser = existingUser;
            AddUser = addUser;
        }

        protected UserConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
