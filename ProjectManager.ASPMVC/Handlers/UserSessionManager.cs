using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.ASPMVC.Handlers
{
    public class UserSessionManager
    {
        private readonly ISession _session;
        public UserSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public Guid? EmployeeId
        {
            get
            {
                return JsonSerializer.Deserialize<Guid?>(_session.GetString(nameof(EmployeeId)) ?? "null");
            }
            set
            {
                if (value is null) _session.Remove(nameof(EmployeeId));
                else _session.SetString(nameof(EmployeeId), JsonSerializer.Serialize(value));
            }
        }
        public bool? IsProjectManager
        {
            get
            {
                return JsonSerializer.Deserialize<bool?>(_session.GetString(nameof(IsProjectManager)) ?? "null");
            }
            set
            {
                if (value is null) _session.Remove(nameof(IsProjectManager));
                else _session.SetString(nameof(IsProjectManager), JsonSerializer.Serialize(value));
            }
        }

    }
}
