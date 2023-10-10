using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T>
   (
      string        description,
      T             expected,
      FakeAction<T> action
   )
      => WasInvokedOnce(description,
                        actual => Equals(expected,
                                         actual),
                        expected?.ToString() ?? string.Empty,
                        action);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce
   (
      string              description,
      Message             expected,
      FakeAction<Message> action
   )
      => WasInvokedOnce(description,
                        actual => Equals(expected,
                                         actual),
                        expected.ToString(),
                        action);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce
   (
      string             description,
      AbsoluteFilePath   expectedPath,
      Message            expectedMessage,
      FakeAction<Locked> action
   )
      => WasInvokedOnce(description,
                        actual => Equals(expectedPath,
                                         actual.Path())
                               && Equals(expectedMessage,
                                         actual.Message()),
                        $"(Path: {expectedPath}, Message: {expectedMessage})",
                        action);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce
   (
      string              description,
      AbsoluteFilePath    expectedPath,
      Message             expectedMessage,
      FakeAction<Missing> action
   )
      => WasInvokedOnce(description,
                        actual => Equals(expectedPath,
                                         actual.Path())
                               && Equals(expectedMessage,
                                         actual.Message()),
                        $"(Path: {expectedPath}, Message: {expectedMessage})",
                        action);

   /* ------------------------------------------------------------ */

   public static Property WasInvokedOnce<T>
   (
      string        description,
      Func<T, bool> property,
      string        expectedString,
      FakeAction<T> action
   )
      => action.Invocations()
               .Count
      == 0
            ? False(TheFakeActionWasNotInvokedWheWeExpectedToBe<T>(description)
                  + "\nExpected:"
                  + $"\n {expectedString}")
            : action.Invocations()
                    .Count
           != 1
               ? False(TheFakeActionWasInvokedMoreThanOnce<T>(description)
                     + "\nExpected:"
                     + $"\n{expectedString}"
                     + "\nActual:"
                     + $"\n{action.Invocations().Count}")
               : AsProperty(() => property(action.Invocations()[0]!))
                 .Label(TheFakeActionWasInvokedWithAnUnexpectedArgument<T>(description)
                      + $"\nExpected: {expectedString}"
                      + $"\nActual: {action.Invocations()[0]}");

   /* ------------------------------------------------------------ */

   public static Property WasNotInvoked<T>
   (
      string        description,
      FakeAction<T> action
   )
      => AsProperty(() => action
                         .Invocations()
                         .Count
                       == 0)
        .Label(TheFakeActionWasInvokedWhenWeExpectedItNotToBe<T>(description));

   /* ------------------------------------------------------------ */
}