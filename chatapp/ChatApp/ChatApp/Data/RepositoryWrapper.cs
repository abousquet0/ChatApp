using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IMessageRepository _message;
        private IChatRoomRepository _chatRoom;

        public IMessageRepository Message
        {
            get
            {
                if (_message == null)
                {
                    _message = new MessageRepository(_context);
                }
                return _message;
            }
        }

        public IChatRoomRepository ChatRoom
        {
            get
            {
                if (_chatRoom == null)
                {
                    _chatRoom = new ChatRoomRepository(_context);
                }
                return _chatRoom;
            }
        }

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
