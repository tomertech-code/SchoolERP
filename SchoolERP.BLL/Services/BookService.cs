using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;
using SchoolERP.Data.Interfaces;

namespace SchoolERP.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<Book>>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.Repository<Book>().GetAllAsync();
            return ApiResponse<IEnumerable<Book>>.Ok(books);
        }

        public async Task<ApiResponse<Book>> GetBookByIdAsync(int id)
        {
            var book = await _unitOfWork.Repository<Book>().GetByIdAsync(id);
            return book == null
                ? ApiResponse<Book>.Fail("Book not found")
                : ApiResponse<Book>.Ok(book);
        }

        public async Task<ApiResponse<bool>> AddBookAsync(Book book)
        {
            await _unitOfWork.Repository<Book>().AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Book added successfully");
        }

        public async Task<ApiResponse<bool>> UpdateBookAsync(Book book)
        {
            _unitOfWork.Repository<Book>().Update(book);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Book updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteBookAsync(int id)
        {
            var book = await _unitOfWork.Repository<Book>().GetByIdAsync(id);
            if (book == null)
                return ApiResponse<bool>.Fail("Book not found");

            _unitOfWork.Repository<Book>().Remove(book);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Book deleted successfully");
        }
    }
}
