using BLL.Models;
using System.Text.Json;

namespace ASPMVC_Demo01.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor context)
        {
            _session = context.HttpContext.Session;
        }

        public User? CurrentUser
        {
            get {
                if (string.IsNullOrEmpty(_session.GetString("user")))
                    return null;
                return JsonSerializer.Deserialize<User>(_session.GetString("user"));
            }
            set { 
                _session.SetString("user", JsonSerializer.Serialize(value));
            }
        }

        public void Logout()
        {
            _session.Clear();
        }


    }
}
