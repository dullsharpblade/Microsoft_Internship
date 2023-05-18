using Microsoft.Extensions.Primitives;

namespace MyOtherStore.Objects
{
    public class AccountInfo
    {
        public static StringValues password { get; internal set; }
        public static StringValues username { get; internal set; }
    }
}
