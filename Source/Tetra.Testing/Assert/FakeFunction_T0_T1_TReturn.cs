using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce<T0, T1, TReturn>
   (
      this Assert                   assert,
      string                        description,
      T0                            expectedArg0,
      T1                            expectedArg1,
      FakeFunction<T0, T1, TReturn> function
   )
   {
      if (function
         .Invocations()
         .Count
       == 0)
      {
         throw Failed.Assert(TheFakeFunctionWasInvokedMoreThanOnce<T0, T1, TReturn>(description)
                           + "\nExpected:"
                           + $"\nArg 0:{expectedArg0}"
                           + $"\nArg 1:{expectedArg1}"
                           + "\nActual:"
                           + $"\n{function.Invocations().Count} invocations");
      }

      if (function
         .Invocations()
         .Count
       != 1)
      {
         throw Failed.Assert(TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T0, T1, TReturn>(description)
                           + "\nExpected:"
                           + $"\nArg 0:{expectedArg0}"
                           + $"\nArg 1:{expectedArg1}");
      }

      var (actualArg0, actualArg1) = function.Invocations()[0];
      if (!Equals(expectedArg0,
                  actualArg0)
       || !Equals(expectedArg1,
                  actualArg1))
      {
         throw Failed.Assert(TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T0, T1, TReturn>(description)
                           + "\nExpected:"
                           + $"\nArg 0:{expectedArg0}"
                           + $"\nArg 1:{expectedArg1}"
                           + "\nActual:"
                           + $"\nArg 0:{actualArg0}"
                           + $"\nArg 1:{actualArg1}");
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked<T0, T1, TReturn>
   (
      this Assert                   assert,
      string                        description,
      FakeFunction<T0, T1, TReturn> function
   )
   {
      if (function
         .Invocations()
         .Count
       != 0)
      {
         throw Failed.Assert(TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T0, T1, TReturn>(description),
                             function.Invocations()
                                     .Count);
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}