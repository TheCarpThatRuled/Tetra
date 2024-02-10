using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce<T0, T1>
   (
      this Assert        assert,
      string             description,
      T0                 expectedArg0,
      T1                 expectedArg1,
      FakeAction<T0, T1> action
   )
   {
      if (action
         .Invocations()
         .Count
       == 0)
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasInvokedMoreThanOnce<T0, T1>(description),
                            Failed.Expected([
                               $"Arg 0:{expectedArg0}",
                               $"Arg 1:{expectedArg1}",
                            ]),
                            Failed.Actual($"{action.Invocations().Count} invocations"))
              .ToAssertFailedException();
      }

      if (action
         .Invocations()
         .Count
       != 1)
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasNotInvokedWheWeExpectedToBe<T0, T1>(description),
                            Failed.Expected([
                               $"Arg 0:{expectedArg0}",
                               $"Arg 1:{expectedArg1}",
                            ]))
              .ToAssertFailedException();
      }

      var (actualArg0, actualArg1) = action.Invocations()[0];
      if (!Equals(expectedArg0,
                  actualArg0)
       || !Equals(expectedArg1,
                  actualArg1))
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasInvokedWithAnUnexpectedArgument<T0, T1>(description),
                            Failed.Expected([
                               $"Arg 0:{expectedArg0}",
                               $"Arg 1:{expectedArg1}",
                            ]),
                            Failed.Actual([
                               $"Arg 0:{actualArg0}",
                               $"Arg 1:{actualArg1}",
                            ]))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked<T0, T1>
   (
      this Assert        assert,
      string             description,
      FakeAction<T0, T1> action
   )
   {
      if (action
         .Invocations()
         .Count
       != 0)
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T0, T1>(description),
                            Failed.Actual(action
                                         .Invocations()
                                         .Count))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}