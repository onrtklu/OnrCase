using Std.Core;
using Std.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Application.User
{
    public interface IUserService : IAppService<UserDto>, IService
    {
        bool Login(string userName, string password);
    }
}
