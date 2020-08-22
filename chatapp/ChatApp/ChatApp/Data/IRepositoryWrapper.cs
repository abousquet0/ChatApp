using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Data
{
    public interface IRepositoryWrapper
    {
        IMessageRepository Message { get; }
        IChatRoomRepository ChatRoom { get; }
        void Save();
    }
}
