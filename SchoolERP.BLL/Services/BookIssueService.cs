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
    public class BookIssueService : IBookIssueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookIssueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<BookIssue>>> GetAllIssuesAsync()
        {
            var issues = await _unitOfWork.Repository<BookIssue>().GetAllAsync();
            return ApiResponse<IEnumerable<BookIssue>>.Ok(issues);
        }

        public async Task<ApiResponse<BookIssue>> GetIssueByIdAsync(int id)
        {
            var issue = await _unitOfWork.Repository<BookIssue>().GetByIdAsync(id);
            return issue == null
                ? ApiResponse<BookIssue>.Fail("Issue not found")
                : ApiResponse<BookIssue>.Ok(issue);
        }

        public async Task<ApiResponse<bool>> IssueBookAsync(BookIssue issue)
        {
            await _unitOfWork.Repository<BookIssue>().AddAsync(issue);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Book issued successfully");
        }

        public async Task<ApiResponse<bool>> ReturnBookAsync(int issueId)
        {
            var issue = await _unitOfWork.Repository<BookIssue>().GetByIdAsync(issueId);
            if (issue == null) return ApiResponse<bool>.Fail("Issue not found");

            issue.IsReturn = true;
            issue.ReturnDate = DateTime.Now;

            _unitOfWork.Repository<BookIssue>().Update(issue);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<bool>.Ok(true, "Book returned successfully");
        }

        public async Task<ApiResponse<bool>> DeleteIssueAsync(int id)
        {
            var issue = await _unitOfWork.Repository<BookIssue>().GetByIdAsync(id);
            if (issue == null) return ApiResponse<bool>.Fail("Issue not found");

            _unitOfWork.Repository<BookIssue>().Remove(issue);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<bool>.Ok(true, "Issue deleted successfully");
        }
    }
}
