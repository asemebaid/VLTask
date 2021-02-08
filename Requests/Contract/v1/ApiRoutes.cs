using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Contract.v1
{/// <summary>
/// 
/// </summary>
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";

        public const  string Base =    Root ;
        public static class Posts
        {
            public const string GetAll = Base + "/posts";
            public const string Create = Base + "/posts";
            public const string Get = Base + "/posts/{postId}";
            public const string ReceiveRequest = Base + "/ReceiveRequest";
            public const string Login = Base + "/Login";

        }
    }
}
