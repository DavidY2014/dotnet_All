using Advanced.Framework.IInterfaces;

namespace Advanced.Framework.Services
{
    public class UserService : IUserService
    {
        public object Query(int id)
        {
            return new
            {
                Id = 1,
                Name = "jack"
            };
        }
    }
}
