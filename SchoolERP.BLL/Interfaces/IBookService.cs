using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IBookService
    {
        Task<ApiResponse<IEnumerable<Book>>> GetAllBooksAsync();
        Task<ApiResponse<Book>> GetBookByIdAsync(int id);
        Task<ApiResponse<bool>> AddBookAsync(Book book);
        Task<ApiResponse<bool>> UpdateBookAsync(Book book);
        Task<ApiResponse<bool>> DeleteBookAsync(int id);
    }
}
