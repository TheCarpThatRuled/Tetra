using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasInvoked<TReturn>(FakeFunction<TReturn> function,
                                              int numberOfInvocations)
      => AsProperty(() => function.Invocations() == numberOfInvocations)
        .Label(Failed.Message($"The FakeFunction<{typeof(TReturn).Name}> was invoked an unexpected number of times",
                              numberOfInvocations,
                              function.Invocations()));

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<TReturns>(FakeFunction<TReturns> function)
      => WasInvoked(function,
                    1);

   /* ------------------------------------------------------------ */

   public static Property WasNotInvoked<TReturns>(FakeFunction<TReturns> function)
      => WasInvoked(function,
                    0);

   /* ------------------------------------------------------------ */
}