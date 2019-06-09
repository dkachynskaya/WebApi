using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.DAL.Interfaces;
using BlogWebApi.Models;
using BlogWebApi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogWebApi.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BlogDBContext context;
        private IPostRepository postRepository;

        public UnitOfWork(BlogDBContext context)
        {
            this.context = context;
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository(context);
                return postRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
