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
         throw Failed.Assert(TheFakeActionWasInvokedMoreThanOnce<T>(description)
                           + "\nExpected:"
                           + $"\n{expected}"
                           + "\nActual:"
                           + $"\n{action.Invocations().Count}");
      }

      if (action
         .Invocations()
         .Count
       != 1)
      {
         throw Failed.Assert(TheFakeActionWasNotInvokedWheWeExpectedToBe<T>(description)
                           + "\nExpected:"
                           + $"\n {expected}");
      }

      if (!action
          .Invocations()[0]!
          .Equals(expected))
      {
         throw Failed.Assert(TheFakeActionWasInvokedWithAnUnexpectedArgument<T>(description)
                           + $"\nExpected: {expected}"
                           + $"\nActual: {action.Invocations()[0]}");
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
         throw Failed.Assert(TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T>(description),
                             action.Invocations()
                                   .Count);
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}