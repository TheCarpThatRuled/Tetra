﻿using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T, TReturn>(string                   description,
                                                     T                        expected,
                                                     FakeFunction<T, TReturn> function)
      => WasInvokedOnce(description,
                        actual => Equals(expected,
                                         actual),
                        expected?.ToString() ?? string.Empty,
                        function);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<TReturn>(string                         description,
                                                  Message                        expected,
                                                  FakeFunction<Failure, TReturn> function)
      => WasInvokedOnce(description,
                        actual => Equals(expected,
                                         actual.Content()),
                        expected.ToString(),
                        function);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T, TReturn>(string                         description,
                                                     T                              expected,
                                                     FakeFunction<Left<T>, TReturn> function)
      => WasInvokedOnce(description,
                        actual => Equals(expected,
                                         actual.Content()),
                        expected?.ToString() ?? string.Empty,
                        function);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T, TReturn>(string                          description,
                                                     T                               expected,
                                                     FakeFunction<Right<T>, TReturn> function)
      => WasInvokedOnce(description,
                        actual => Equals(expected,
                                         actual.Content()),
                        expected?.ToString() ?? string.Empty,
                        function);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T, TReturn>(string                   description,
                                                     Func<T, bool>            property,
                                                     string                   expectedString,
                                                     FakeFunction<T, TReturn> function)
      => function.Invocations()
                 .Count
      == 0
            ? False(TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T, TReturn>(description)
                  + "\nExpected:"
                  + $"\n {expectedString}")
            : function.Invocations()
                      .Count
           != 1
               ? False(TheFakeFunctionWasInvokedMoreThanOnce<T, TReturn>(description)
                     + "\nExpected:"
                     + $"\n{expectedString}"
                     + "\nActual:"
                     + $"\n{function.Invocations().Count}")
               : AsProperty(() => property(function.Invocations()[0]!))
                 .Label(TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T, TReturn>(description)
                      + $"\nExpected: {expectedString}"
                      + $"\nActual: {function.Invocations()[0]}");

   /* ------------------------------------------------------------ */

   public static Property WasNotInvoked<T, TReturn>(string                   description,
                                                    FakeFunction<T, TReturn> function)
      => AsProperty(() => function
                         .Invocations()
                         .Count
                       == 0)
        .Label(TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T, TReturn>(description));

   /* ------------------------------------------------------------ */
}