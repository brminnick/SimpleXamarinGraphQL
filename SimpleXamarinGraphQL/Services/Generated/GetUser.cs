using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace SimpleXamarinGraphQL
{
    public class GetUser
        : IGetUser
    {
        public GetUser(
            IUser user)
        {
            User = user;
        }

        public IUser User { get; }
    }
}
