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
         throw Failed
              .InTheAsserts(TheFakeFunctionWasInvokedMoreThanOnce<T0, T1, TReturn>(description),
                            Failed.Expected([
                               $"Arg 0:{expectedArg0}",
                               $"Arg 1:{expectedArg1}",
                            ]),
                            Failed.Actual($"{function.Invocations().Count} invocations"))
              .ToAssertFailedException();
      }

      if (function
         .Invocations()
         .Count
       != 1)
      {
         throw Failed
              .InTheAsserts(TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T0, T1, TReturn>(description),
                            Failed.Expected([
                               $"Arg 0:{expectedArg0}",
                               $"Arg 1:{expectedArg1}",
                            ]))
              .ToAssertFailedException();
      }

      var (actualArg0, actualArg1) = function.Invocations()[0];
      if (!Equals(expectedArg0,
                  actualArg0)
       || !Equals(expectedArg1,
                  actualArg1))
      {
         throw Failed
              .InTheAsserts(TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T0, T1, TReturn>(description),
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
         throw Failed
              .InTheAsserts(TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T0, T1, TReturn>(description),
                            Failed.Actual(function
                                         .Invocations()
                                         .Count))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}