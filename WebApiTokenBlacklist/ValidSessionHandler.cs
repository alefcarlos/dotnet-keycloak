using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSessionToken
{
    public class ValidSessionHandler : AuthorizationHandler<ValidSessionRequirement>
    {
        private readonly IDistributedCache _distributedCache;

        public ValidSessionHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ValidSessionRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                return;
            }

            var identifier = context.User.FindFirst("jti").Value;
            var key = await _distributedCache.GetStringAsync(identifier);

            if (string.IsNullOrEmpty(key))
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
