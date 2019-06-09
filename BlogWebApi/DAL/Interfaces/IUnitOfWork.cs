using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IPostRepository PostRepository { get; }
        void Save();
    }
}
