using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvoked<TReturn>
   (
      this Assert           assert,
      string                description,
      FakeFunction<TReturn> function,
      int                   numberOfInvocations
   )
   {
      if (function.Invocations() != numberOfInvocations)
      {
         throw Failed
              .InTheAsserts(TheFakeFunctionWasInvokedAnUnexpectedNumberOfTimes<TReturn>(description),
                            Failed.Expected(numberOfInvocations),
                            Failed.Actual(function.Invocations()))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce<TReturn>
   (
      this Assert           assert,
      string                description,
      FakeFunction<TReturn> function
   )
      => assert
        .WasInvoked(description,
                    function,
                    1);

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked<TReturn>
   (
      this Assert           assert,
      string                description,
      FakeFunction<TReturn> function
   )
   {
      if (function
            .Invocations()
       != 0)
      {
         throw Failed
              .InTheAsserts(TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<TReturn>(description))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}