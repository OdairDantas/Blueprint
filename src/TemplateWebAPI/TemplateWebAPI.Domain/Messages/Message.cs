using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.Messages
{
    public abstract class Message
    {
        public Message()
        {
            MessageType = GetType().Name;

            Id = Guid.NewGuid();
        }

        public string MessageType { get; protected set; }
        public Guid Id { get; set; }
    }

}
