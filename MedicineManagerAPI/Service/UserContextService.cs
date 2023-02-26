using System.Security.Claims;
using MedicineManagerAPI.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MedicineManagerAPI.Service
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? GetUserId { get; }
        public int GetIntUserID();
    }

    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int? GetUserId =>
            User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public int GetIntUserID()
        {
            if (User==null)
            {
                throw new NotFoundException("Claims are bad ;(");
            }
            var userId = (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (userId ==null)
            {
                throw new NotFoundException("Claims are bad ;(");
            }
            return (int)userId;    
        }
    }
}
