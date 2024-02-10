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
         throw Failed
              .InTheAsserts(TheFakeFunctionWasInvokedMoreThanOnce<T, TReturn>(description),
                            Failed.Expected(expected),
                            Failed.Actual(function
                                         .Invocations()
                                         .Count))
              .ToAssertFailedException();
         ;
      }

      if (function
         .Invocations()
         .Count
       != 1)
      {
         throw Failed
              .InTheAsserts(TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T, TReturn>(description),
                            Failed.Expected(expected))
              .ToAssertFailedException();
      }

      if (!function
          .Invocations()[0]!
          .Equals(expected))
      {
         throw Failed
              .InTheAsserts(TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T, TReturn>(description),
                            Failed.Expected(expected),
                            Failed.Actual(function.Invocations()[0]))
              .ToAssertFailedException();
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
         throw Failed
              .InTheAsserts(TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T, TReturn>(description),
                            Failed.Actual(function
                                         .Invocations()
                                         .Count))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}