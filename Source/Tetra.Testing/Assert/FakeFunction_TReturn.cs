using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvoked<TReturn>(this Assert assert,
                                            FakeFunction<TReturn> function,
                                            int numberOfInvocations)
   {
      if (function.Invocations() != numberOfInvocations)
      {
         throw Failed.Assert($"The FakeFunction<{typeof(TReturn).Name}> was invoked an unexpected number of times",
                             numberOfInvocations,
                             function.Invocations());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce<TReturn>(this Assert assert,
                                                FakeFunction<TReturn> function)
      => assert
        .WasInvoked(function,
                    1);

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked<TReturn>(this Assert assert,
                                               FakeFunction<TReturn> function)
      => assert
        .WasInvoked(function,
                    0);

   /* ------------------------------------------------------------ */
}