using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>
   (
      this Assert assert,
      string      description,
      IOption<T>  actual
   )
      => actual
        .IsASome(description,
                 (
                    someMessage,
                    some
                 ) => assert,
                 (
                    noneMessage,
                    none
                 ) => throw Failed
                           .InTheAsserts(noneMessage)
                           .ToAssertFailedException(),
                 unrecognisedMessage => throw Failed
                                             .InTheAsserts(unrecognisedMessage)
                                             .ToAssertFailedException());

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>
   (
      this Assert assert,
      string      description,
      T           expected,
      IOption<T>  actual
   )
      => actual
        .IsASome(description,
                 (
                    someMessage,
                    some
                 ) => assert.AreEqual(someMessage,
                                      expected,
                                      some.Content),
                 (
                    noneMessage,
                    none
                 ) => throw Failed
                           .InTheAsserts(noneMessage)
                           .ToAssertFailedException(),
                 unrecognisedMessage => throw Failed
                                             .InTheAsserts(unrecognisedMessage)
                                             .ToAssertFailedException());

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd<T>
   (
      this Assert   assert,
      string        description,
      Func<T, bool> property,
      IOption<T>    actual
   )
      => actual
        .IsASome(description,
                 (
                    someMessage,
                    some
                 ) => !property(some.Content)
                         ? throw Failed
                                .InTheAsserts(someMessage,
                                              Failed.Actual(some.ToTestOutput()))
                                .ToAssertFailedException()
                         : assert,
                 (
                    noneMessage,
                    none
                 ) => throw Failed
                           .InTheAsserts(noneMessage)
                           .ToAssertFailedException(),
                 unrecognisedMessage => throw Failed
                                             .InTheAsserts(unrecognisedMessage)
                                             .ToAssertFailedException());

   /* ------------------------------------------------------------ */

   public static Assert IsANone<T>
   (
      this Assert assert,
      string      description,
      IOption<T>  actual
   )
      => actual
        .IsANone(description,
                 none => assert,
                 (
                    someMessage,
                    some
                 ) => throw Failed
                           .InTheAsserts(someMessage,
                                         Failed.Actual(some.ToTestOutput()))
                           .ToAssertFailedException(),
                 unrecognisedMessage => throw Failed
                                             .InTheAsserts(unrecognisedMessage)
                                             .ToAssertFailedException());

   /* ------------------------------------------------------------ */
   // Internal Methods
   /* ------------------------------------------------------------ */

   internal static TReturn IsASome<T, TReturn>
   (
      this IOption<T>                             actual,
      string                                      description,
      Func<string, Option<T>.SomeOption, TReturn> whenSome,
      Func<string, Option<T>.NoneOption, TReturn> whenNone,
      Func<string, TReturn>                       whenUnrecognised
   )
      => actual
        .Switch(whenSome.Apply(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description)),
                whenNone.Apply(TheOptionIsANoneWhenWeExpectedItToBeASome<T>(description)),
                whenUnrecognised.Apply(TheOptionIsUnrecognisedWhenWeExpectedItToBeASome<T>(description)));

   /* ------------------------------------------------------------ */

   internal static TReturn IsANone<T, TReturn>
   (
      this IOption<T>                             actual,
      string                                      description,
      Func<Option<T>.NoneOption, TReturn>         whenNone,
      Func<string, Option<T>.SomeOption, TReturn> whenSome,
      Func<string, TReturn>                       whenUnrecognised
   )
      => actual
        .Switch(whenSome.Apply(TheOptionIsASomeWhenWeExpectedItToBeANone<T>(description)),
                whenNone,
                whenUnrecognised.Apply(TheOptionIsUnrecognisedWhenWeExpectedItToBeANone<T>(description)));

   /* ------------------------------------------------------------ */

   internal static TReturn Switch<T, TReturn>
   (
      this IOption<T>                     actual,
      Func<Option<T>.SomeOption, TReturn> whenSome,
      Func<Option<T>.NoneOption, TReturn> whenNone,
      Func<TReturn>                       whenUnrecognised
   )
      => actual switch
         {
            Option<T>.NoneOption none => whenNone(none),
            Option<T>.SomeOption some => whenSome(some),

            _ => whenUnrecognised(),
         };

   /* ------------------------------------------------------------ */
}