using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VodusDomainLayer.Model;

namespace VodusApplicationLayer.Services.Interfaces
{
    public interface IVodus:IDisposable
    {
        IEnumerable<PageContent> GetAll();
        PageContent GetById(int? id);
        void Add(PageContent vodus);
        void Remove(PageContent vodus);
        void Update(PageContent vodus);
        void SaveChanges();
    }
}
