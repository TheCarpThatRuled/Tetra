using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce<T0, T1>(this Assert        assert,
                                               string             description,
                                               T0                 expectedArg0,
                                               T1                 expectedArg1,
                                               FakeAction<T0, T1> action)
   {
      if (action
         .Invocations()
         .Count
       == 0)
      {
         throw Failed.Assert(TheFakeActionWasInvokedMoreThanOnce<T0, T1>(description)
                           + "\nExpected:"
                           + $"\nArg 0:{expectedArg0}"
                           + $"\nArg 1:{expectedArg1}"
                           + "\nActual:"
                           + $"\n{action.Invocations().Count} invocations");
      }

      if (action
         .Invocations()
         .Count
       != 1)
      {
         throw Failed.Assert(TheFakeActionWasNotInvokedWheWeExpectedToBe<T0, T1>(description)
                           + "\nExpected:"
                           + $"\nArg 0:{expectedArg0}"
                           + $"\nArg 1:{expectedArg1}");
      }

      var (actualArg0, actualArg1) = action.Invocations()[0];
      if (!Equals(expectedArg0,
                  actualArg0)
       || !Equals(expectedArg1,
                  actualArg1))
      {
         throw Failed.Assert(TheFakeActionWasInvokedWithAnUnexpectedArgument<T0, T1>(description)
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

   public static Assert WasNotInvoked<T0, T1>(this Assert        assert,
                                              string             description,
                                              FakeAction<T0, T1> action)
   {
      if (action
         .Invocations()
         .Count
       != 0)
      {
         throw Failed.Assert(TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T0, T1>(description),
                             action.Invocations()
                                   .Count);
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}