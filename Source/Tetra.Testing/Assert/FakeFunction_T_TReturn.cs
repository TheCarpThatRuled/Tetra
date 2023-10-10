using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce<T, TReturn>
   (
      this Assert              assert,
      string                   description,
      T                        expected,
      FakeFunction<T, TReturn> function
   )
   {
      if (function
         .Invocations()
         .Count
       == 0)
      {
         throw Failed.Assert(TheFakeFunctionWasInvokedMoreThanOnce<T, TReturn>(description)
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
         throw Failed.Assert(TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T, TReturn>(description)
                           + "\nExpected:"
                           + $"\n {expected}");
      }

      if (!function
          .Invocations()[0]!
          .Equals(expected))
      {
         throw Failed.Assert(TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T, TReturn>(description)
                           + $"\nExpected: {expected}"
                           + $"\nActual: {function.Invocations()[0]}");
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked<T, TReturn>
   (
      this Assert              assert,
      string                   description,
      FakeFunction<T, TReturn> function
   )
   {
      if (function
         .Invocations()
         .Count
       != 0)
      {
         throw Failed.Assert(TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T, TReturn>(description),
                             function.Invocations()
                                     .Count);
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}