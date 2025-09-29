using Microsoft.AspNetCore.Authorization;

namespace SchoolERP.UI.Helper
{
    [AllowAnonymous]
    public class Login
    {
        public string? UserName { get; set; }
        public string? Unit { get; set; }
        public string? Role { get; set; }
        public int? Comdid { get; set; }
        public int? Corpsid { get; set; }
        public string? Iamuserid { get; set; }
        public string? Appontment { get; set; }
        public string? ActualUserName { get; set; }
        public int? unitid { get; set; }
        public int? totmsgin { get; set; }
        public int? tocommentin { get; set; }
        public int? typeid { get; set; }
        public int UserIntId { get; set; }
        public string? IcNo { get; set; }
        public string? Offr_Name { get; set; }
        public string? Rank { get; set; }
        public string? IpAddress { get; set; }
        public int cla { get; set; }
    }
}
