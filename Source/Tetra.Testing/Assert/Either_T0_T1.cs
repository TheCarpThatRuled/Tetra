using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsALeft<TLeft, TRight>
   (
      this Assert            assert,
      string                 description,
      IEither<TLeft, TRight> actual
   )
      => actual
        .IsALeft(description,
                 (
                    _,
                    _
                 ) => assert,
                 (
                    rightMessage,
                    right
                 ) => throw Failed
                           .InTheAsserts(rightMessage,
                                         Failed.Actual(right.ToTestOutput()))
                           .ToAssertFailedException(),
                 unrecognisedMessage => throw Failed
                                             .InTheAsserts(unrecognisedMessage)
                                             .ToAssertFailedException());

   /* ------------------------------------------------------------ */

   public static Assert IsALeft<TLeft, TRight>
   (
      this Assert            assert,
      string                 description,
      TLeft                  expected,
      IEither<TLeft, TRight> actual
   )
      => actual
        .IsALeft(description,
                 (
                    leftMessage,
                    left
                 ) => assert.AreEqual(leftMessage,
                                      expected,
                                      left.Content),
                 (
                    rightMessage,
                    right
                 ) => throw Failed
                           .InTheAsserts(rightMessage,
                                         Failed.Actual(right.ToTestOutput()))
                           .ToAssertFailedException(),
                 unrecognisedMessage => throw Failed
                                             .InTheAsserts(unrecognisedMessage)
                                             .ToAssertFailedException());

   /* ------------------------------------------------------------ */

   public static Assert IsALeftAnd<TLeft, TRight>
   (
      this Assert            assert,
      string                 description,
      Func<TLeft, bool>      property,
      IEither<TLeft, TRight> actual
   )
      => actual
        .IsALeft(description,
                 (
                    leftMessage,
                    left
                 ) => !property(left.Content)
                         ? throw Failed
                                .InTheAsserts(leftMessage,
                                              Failed.Actual(left.ToTestOutput()))
                                .ToAssertFailedException()
                         : assert,
                 (
                    rightMessage,
                    right
                 ) => throw Failed
                           .InTheAsserts(rightMessage,
                                         Failed.Actual(right.ToTestOutput()))
                           .ToAssertFailedException(),
                 unrecognisedMessage => throw Failed
                                             .InTheAsserts(unrecognisedMessage)
                                             .ToAssertFailedException());

   /* ------------------------------------------------------------ */

   public static Assert IsARight<TLeft, TRight>
   (
      this Assert            assert,
      string                 description,
      IEither<TLeft, TRight> actual
   )
      => actual
        .IsARight(description,
                  (
                     _,
                     _
                  ) => assert,
                  (
                     leftMessage,
                     left
                  ) => throw Failed
                            .InTheAsserts(leftMessage,
                                          Failed.Actual(left.ToTestOutput()))
                            .ToAssertFailedException(),
                  unrecognisedMessage => throw Failed
                                              .InTheAsserts(unrecognisedMessage)
                                              .ToAssertFailedException());

   /* ------------------------------------------------------------ */

   public static Assert IsARight<TLeft, TRight>
   (
      this Assert            assert,
      string                 description,
      TRight                 expected,
      IEither<TLeft, TRight> actual
   )
      => actual
        .IsARight(description,
                  (
                     rightMessage,
                     right
                  ) => assert.AreEqual(rightMessage,
                                       expected,
                                       right.Content),
                  (
                     leftMessage,
                     left
                  ) => throw Failed
                            .InTheAsserts(leftMessage,
                                          Failed.Actual(left.ToTestOutput()))
                            .ToAssertFailedException(),
                  unrecognisedMessage => throw Failed
                                              .InTheAsserts(unrecognisedMessage)
                                              .ToAssertFailedException());

   /* ------------------------------------------------------------ */

   public static Assert IsARightAnd<TLeft, TRight>
   (
      this Assert            assert,
      string                 description,
      Func<TRight, bool>     property,
      IEither<TLeft, TRight> actual
   )
      => actual
        .IsARight(description,
                  (
                     rightMessage,
                     right
                  ) => !property(right.Content)
                          ? throw Failed
                                 .InTheAsserts(rightMessage,
                                               Failed.Actual(right.ToTestOutput()))
                                 .ToAssertFailedException()
                          : assert,
                  (
                     leftMessage,
                     left
                  ) => throw Failed
                            .InTheAsserts(leftMessage,
                                          Failed.Actual(left.ToTestOutput()))
                            .ToAssertFailedException(),
                  unrecognisedMessage => throw Failed
                                              .InTheAsserts(unrecognisedMessage)
                                              .ToAssertFailedException());

   /* ------------------------------------------------------------ */
   // Internal Methods
   /* ------------------------------------------------------------ */

   internal static TReturn IsALeft<TLeft, TRight, TReturn>
   (
      this IEither<TLeft, TRight>                              actual,
      string                                                   description,
      Func<string, Either<TLeft, TRight>.LeftEither, TReturn>  whenLeft,
      Func<string, Either<TLeft, TRight>.RightEither, TReturn> whenRight,
      Func<string, TReturn>                                    whenUnrecognised
   )
      => actual
        .Switch(whenRight.Apply(TheEitherIsARightWhenWeExpectedItToBeALeft<TLeft, TRight>(description)),
                whenLeft.Apply(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(description)),
                whenUnrecognised.Apply(TheEitherIsUnrecognisedWhenWeExpectedItToBeALeft<TLeft, TRight>(description)));

   /* ------------------------------------------------------------ */

   internal static TReturn IsARight<TLeft, TRight, TReturn>
   (
      this IEither<TLeft, TRight>                              actual,
      string                                                   description,
      Func<string, Either<TLeft, TRight>.RightEither, TReturn> whenRight,
      Func<string, Either<TLeft, TRight>.LeftEither, TReturn>  whenLeft,
      Func<string, TReturn>                                    whenUnrecognised
   )
      => actual
        .Switch(whenRight.Apply(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(description)),
                whenLeft.Apply(TheEitherIsALeftWhenWeExpectedItToBeARight<TLeft, TRight>(description)),
                whenUnrecognised.Apply(TheEitherIsUnrecognisedWhenWeExpectedItToBeARight<TLeft, TRight>(description)));

   /* ------------------------------------------------------------ */

   internal static TReturn Switch<TLeft, TRight, TReturn>
   (
      this IEither<TLeft, TRight>                      actual,
      Func<Either<TLeft, TRight>.RightEither, TReturn> whenRight,
      Func<Either<TLeft, TRight>.LeftEither, TReturn>  whenLeft,
      Func<TReturn>                                    whenUnrecognised
   )
      => actual switch
         {
            Either<TLeft, TRight>.LeftEither left   => whenLeft(left),
            Either<TLeft, TRight>.RightEither right => whenRight(right),

            _ => whenUnrecognised(),
         };

   /* ------------------------------------------------------------ */
}