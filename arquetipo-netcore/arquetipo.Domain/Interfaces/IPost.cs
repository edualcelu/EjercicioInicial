using arquetipo.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.Domain.Interfaces
{
    public interface IPost    
    {
       Task<IEnumerable<Post>> GetPosts();
        
    }
}