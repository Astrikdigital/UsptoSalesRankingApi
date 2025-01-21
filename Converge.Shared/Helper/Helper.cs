 
using ErrorLog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;



namespace Converge.Shared.Helper
{
    public static class Helper
    {
        public static string GenerateEntityId(int EntityId)
        {
            var year = DateTime.Now.Year % 100;
            var randomDigits = new Random().Next(1000, 9999);
            return EntityId == (int)EnumHelper.Role.Faculty
                ? $"CF{year}{randomDigits}"
                : EntityId == (int)EnumHelper.Role.Student
                ? $"CS{year}{randomDigits}"
                : "";
        }

        public static int UserId(IHttpContextAccessor? _httpContextAccessor)
        {
            if (_httpContextAccessor?.HttpContext?.User == null)
            {
                return 0;
            }

            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out var parsedUserId))
            {
                return parsedUserId;
            }
            return 0;
        }

     }
}
