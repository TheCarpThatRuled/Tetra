using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T, TReturn>(T expected,
                                                     FakeFunction<T, TReturn> function)
      => AsProperty(() => function
                         .Invocations()
                         .Count
                       != 0)
        .Label($"The {Name<T, TReturn>()} was not invoked, when we expected it to be. Expected:\n {expected}")
        .And(AsProperty(() => function
                             .Invocations()
                             .Count()
                           == 1)
               .Label($"The {Name<T, TReturn>()} was invoked more than once."
                    + "\nExpected:"
                    + $"\n{expected}"
                    + "\nActual:"
                    + $"\n{function.Invocations().Count}"))
        .And(AsProperty(() => function
                             .Invocations()
                             .First()!
                             .Equals(expected))
               .Label($"The {Name<T, TReturn>()} was invoked with an unexpected argument"
                    + $"\nExpected: {expected}"
                    + $"\nActual: {function.Invocations().First()}"));

   /* -------------------------------------------------- */

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