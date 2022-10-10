using KaplanBooksAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaplanBooksAPI.Services
{
    public interface IGoogleBookService
    {
        Task<IEnumerable<KaplanBooks>> GetKaplanBooks();



    }
}
