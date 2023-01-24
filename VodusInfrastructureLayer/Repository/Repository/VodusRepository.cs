using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VodusApplicationLayer.Services.Interfaces;
using VodusDomainLayer.Model;
using VodusInfrastructureLayer.Services;

namespace VodusInfrastructureLayer.Repository
{
    public class VodusRepository : IVodus,IDisposable
    {
        private readonly DataContext _dataContext;
        private bool disposed = false;

        public VodusRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(PageContent vodus)
        {
            _dataContext.vodus.Add(vodus);
        }

       

        public IEnumerable<PageContent> GetAll()
        {
            return _dataContext.vodus.ToList();
        }

        public PageContent GetById(int? id)
        {
            return _dataContext.vodus.Find(id);
        }

        public void Remove(PageContent vodus)
        {
            _dataContext.vodus.Remove(vodus);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void Update(PageContent vodus)
        {
             _dataContext.vodus.Update(vodus);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
