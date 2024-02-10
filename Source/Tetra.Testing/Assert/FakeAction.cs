using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvoked
   (
      this Assert assert,
      string      description,
      FakeAction  function,
      int         numberOfInvocations
   )
   {
      if (function.Invocations() != numberOfInvocations)
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasInvokedAnUnexpectedNumberOfTimes(description),
                            Failed.Expected(numberOfInvocations),
                            Failed.Actual(function.Invocations()))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce
   (
      this Assert assert,
      string      description,
      FakeAction  function
   )
      => assert
        .WasInvoked(description,
                    function,
                    1);

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked
   (
      this Assert assert,
      string      description,
      FakeAction  function
   )
   {
      if (function
            .Invocations()
       != 0)
      {
         throw Failed
              .InTheAsserts(TheFakeActionWasInvokedWhenWeExpectedItNotToBe(description))
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}