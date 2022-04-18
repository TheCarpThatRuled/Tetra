using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T, TReturn>(T                        expected,
                                                     FakeFunction<T, TReturn> function)
      => WasInvokedOnce(actual => Equals(expected,
                                         actual),
                        expected?.ToString() ?? string.Empty,
                        function);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<TReturn>(Message                        expected,
                                                  FakeFunction<Failure, TReturn> function)
      => WasInvokedOnce(actual => Equals(expected,
                                         actual.Content()),
                        expected.ToString(),
                        function);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T, TReturn>(T                                 expected,
                                                     FakeFunction<Success<T>, TReturn> function)
      => WasInvokedOnce(actual => Equals(expected,
                                         actual.Content()),
                        expected?.ToString() ?? string.Empty,
                        function);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T, TReturn>(Func<T, bool>            property,
                                                     string                   expectedString,
                                                     FakeFunction<T, TReturn> function)
      => function.Invocations().Count == 0
            ? False($"The {Name<T, TReturn>()} was not invoked, when we expected it to be. Expected:\n {expectedString}")
            : function.Invocations().Count != 1
               ? False($"The {Name<T, TReturn>()} was invoked more than once."
                     + "\nExpected:"
                     + $"\n{expectedString}"
                     + "\nActual:"
                     + $"\n{function.Invocations().Count}")
               : AsProperty(() => property(function.Invocations()[0]!))
                 .Label($"The {Name<T, TReturn>()} was invoked with an unexpected argument"
                      + $"\nExpected: {expectedString}"
                      + $"\nActual: {function.Invocations()[0]}");

   /* ------------------------------------------------------------ */

   public static Property WasNotInvoked<T, TReturn>(FakeFunction<T, TReturn> function)
      => AsProperty(() => function
                         .Invocations()
                         .Count
                       == 0)
        .Label(
            $"The {Name<T, TReturn>()} was invoked, when we expected it not to be. Actual: {function.Invocations().Count}");

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string Name<T, TReturn>()
      => $"FakeFunction <{typeof(T).Namespace},{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */
}