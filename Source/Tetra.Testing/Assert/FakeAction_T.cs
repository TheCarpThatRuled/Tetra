using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce<T>
   (
      this Assert   assert,
      string        description,
      T             expected,
      FakeAction<T> action
   )
   {
      if (action
         .Invocations()
         .Count
       == 0)
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasInvokedMoreThanOnce<T>(description),
                            Failed.Expected(expected),
                            Failed.Actual(action
                                         .Invocations()
                                         .Count))
              .ToAssertFailedException();
      }

      if (action
         .Invocations()
         .Count
       != 1)
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasNotInvokedWheWeExpectedToBe<T>(description),
                            Failed.Expected(expected))
              .ToAssertFailedException();
      }

      if (!action
          .Invocations()[0]!
          .Equals(expected))
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasInvokedWithAnUnexpectedArgument<T>(description),
                            Failed.Expected(expected),
                            Failed.Actual(action.Invocations()[0]))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked<T>
   (
      this Assert   assert,
      string        description,
      FakeAction<T> action
   )
   {
      if (action
         .Invocations()
         .Count
       != 0)
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T>(description),
                            Failed.Actual(action
                                         .Invocations()
                                         .Count))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}