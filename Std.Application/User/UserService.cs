using Std.Core;
using Std.Data.Domain;
using Std.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Std.Application.User
{
    public class UserService : BaseAppService<UserDto, Data.Domain.User>, IUserService
    {
        public UserService(IRepository<Data.Domain.User, int> repository) : base(repository)
        {
        }

        public bool Login(string userName, string password)
        {
            var user = _repository.Where(s => s.Name == userName && s.Password == password).SingleOrDefault();
            return user == null ? false : true;
        }
    }
}
