﻿using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Data
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
    }
}
