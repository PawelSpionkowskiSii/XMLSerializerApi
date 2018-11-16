using Optional;
using System;

namespace XMLSerializerApi.Helpers
{
    public static class OptionException
    {
        public static TException ExceptionOr<TValue, TException>(this Option<TValue, TException> option, Func<TException> alternativeFactory) =>
            option.Match(_ => alternativeFactory(), exception => exception);

        public static TException ExceptionOr<TValue, TException>(this Option<TValue, TException> option, Func<TValue, TException> alternativeFactory) =>
            option.Match(alternativeFactory, exception => exception);
    }
}