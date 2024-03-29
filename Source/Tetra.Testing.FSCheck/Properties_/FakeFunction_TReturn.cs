﻿namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasInvoked<TReturn>
   (
      string                description,
      FakeFunction<TReturn> function,
      int                   numberOfInvocations
   )
      => AsProperty(() => function.Invocations() == numberOfInvocations)
        .Label(Failed.InTheAsserts(AssertMessages.TheFakeFunctionWasInvokedAnUnexpectedNumberOfTimes<TReturn>(description),
                                   Failed.Expected(numberOfInvocations),
                                   Failed.Actual(function.Invocations())));

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<TReturn>
   (
      string                description,
      FakeFunction<TReturn> function
   )
      => WasInvoked(description,
                    function,
                    1);

   /* ------------------------------------------------------------ */

   public static Property WasNotInvoked<TReturn>
   (
      string                description,
      FakeFunction<TReturn> function
   )
      => AsProperty(() => function.Invocations() == 0)
        .Label(AssertMessages.TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<TReturn>(description));

   /* ------------------------------------------------------------ */
}