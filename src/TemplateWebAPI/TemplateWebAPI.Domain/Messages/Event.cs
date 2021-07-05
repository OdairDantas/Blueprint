using MediatR;
using System;

namespace $safeprojectname$.Messages
{
    public class Event : Message, INotification
    {
        public Event(Guid entityId)
        {
            Timestamp = DateTime.Now;
            EntityId = entityId;
        }

        public DateTime Timestamp { get; private set; }
        public Guid EntityId { get; set; }
    }
}
