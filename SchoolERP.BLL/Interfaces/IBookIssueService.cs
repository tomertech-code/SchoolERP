using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IBookIssueService
    {
        Task<ApiResponse<IEnumerable<BookIssue>>> GetAllIssuesAsync();
        Task<ApiResponse<BookIssue>> GetIssueByIdAsync(int id);
        Task<ApiResponse<bool>> IssueBookAsync(BookIssue issue);
        Task<ApiResponse<bool>> ReturnBookAsync(int issueId);
        Task<ApiResponse<bool>> DeleteIssueAsync(int id);
    }
}
