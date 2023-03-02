using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert WasInvoked(this Assert assert,
                                   string      description,
                                   FakeAction  function,
                                   int         numberOfInvocations)
   {
      if (function.Invocations() != numberOfInvocations)
      {
         throw Failed.Assert(TheFakeActionWasInvokedAnUnexpectedNumberOfTimes(description),
                             numberOfInvocations,
                             function.Invocations());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert WasInvokedOnce(this Assert assert,
                                       string      description,
                                       FakeAction  function)
      => assert
        .WasInvoked(description,
                    function,
                    1);

   /* ------------------------------------------------------------ */

   public static Assert WasNotInvoked(this Assert assert,
                                      string      description,
                                      FakeAction  function)
   {
      if (function
            .Invocations()
       != 0)
      {
         throw Failed.Assert(TheFakeActionWasInvokedWhenWeExpectedItNotToBe(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}