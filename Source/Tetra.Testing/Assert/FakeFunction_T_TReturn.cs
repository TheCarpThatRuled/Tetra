using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce<T, TReturn>(this Assert assert,
                                                   T expected,
                                                   FakeFunction<T, TReturn> function)
   {
      if (function
         .Invocations()
         .Count
       == 0)
      {
         throw Failed.Assert($"The {Name<T, TReturn>()} was invoked more than once."
                           + "\nExpected:"
                           + $"\n{expected}"
                           + "\nActual:"
                           + $"\n{function.Invocations().Count}");
      }

      if (function
         .Invocations()
         .Count
       != 1)
      {
         throw Failed.Assert(
            $"The {Name<T, TReturn>()} was not invoked, when we expected it to be. Expected:\n {expected}");
      }

      if (!function
          .Invocations()[0]!
          .Equals(expected))
      {
         throw Failed.Assert($"The {Name<T, TReturn>()} was invoked with an unexpected argument"
                           + $"\nExpected: {expected}"
                           + $"\nActual: {function.Invocations()[0]}");
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked<T, TReturn>(this Assert assert,
                                                  FakeFunction<T, TReturn> function)
   {
      if (function
         .Invocations()
         .Count
       != 0)
      {
         throw Failed.Assert($"The {Name<T, TReturn>()} was invoked, when we expected it not to be.",
                             function.Invocations()
                                     .Count);
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string Name<T, TReturn>()
      => $"FakeFunction <{typeof(T).Namespace},{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */
}