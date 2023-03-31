using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<T>(this Assert assert,
                                      string      description,
                                      IResult<T>   actual)
      => actual
        .IsAFailure(description,
                    (failureMessage,
                     failure) => assert,
                    (successMessage,
                     success) => throw Failed.Assert(successMessage),
                    unrecognisedMessage => throw Failed.Assert(unrecognisedMessage));

   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<T>(this Assert assert,
                                      string      description,
                                      T           expected,
                                      IResult<T>   actual)
      => actual
        .IsAFailure(description,
                    (failureMessage,
                     failure) => assert.AreEqual(failureMessage,
                                                 expected,
                                                 failure.Content),
                    (successMessage,
                     success) => throw Failed.Assert(successMessage),
                    unrecognisedMessage => throw Failed.Assert(unrecognisedMessage));

   /* ------------------------------------------------------------ */

   public static Assert IsAFailureAnd<T>(this Assert   assert,
                                         string        description,
                                         Func<T, bool> property,
                                         IResult<T>     actual)
      => actual
        .IsAFailure(description,
                    (failureMessage,
                     failure) => !property(failure.Content)
                                    ? throw Failed.Assert(failureMessage,
                                                          failure.ToTestOutput())
                                    : assert,
                    (successMessage,
                     success) => throw Failed.Assert(successMessage),
                    unrecognisedMessage => throw Failed.Assert(unrecognisedMessage));

   /* ------------------------------------------------------------ */

   public static Assert IsASuccess<T>(this Assert assert,
                                      string      description,
                                      IResult<T>   actual)
      => actual
        .IsASuccess(description,
                    success => assert,
                    (failureMessage,
                     failure) => throw Failed.Assert(failureMessage,
                                                     failure.ToTestOutput()),
                    unrecognisedMessage => throw Failed.Assert(unrecognisedMessage));

   /* ------------------------------------------------------------ */
   // Internal Methods
   /* ------------------------------------------------------------ */

   internal static TReturn IsAFailure<T, TReturn>(this IResult<T>                               actual,
                                                  string                                       description,
                                                  Func<string, Result<T>.FailureResult, TReturn> whenFailure,
                                                  Func<string, Result<T>.SuccessResult, TReturn> whenSuccess,
                                                  Func<string, TReturn>                        whenUnrecognised)
      => actual
        .Switch(whenFailure.Apply(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(description)),
                whenSuccess.Apply(TheResultIsASuccessWhenWeExpectedItToBeAFailure<T>(description)),
                whenUnrecognised.Apply(TheResultIsUnrecognisedWhenWeExpectedItToBeAFailure<T>(description)));

   /* ------------------------------------------------------------ */

   internal static TReturn IsASuccess<T, TReturn>(this IResult<T>                               actual,
                                                  string                                       description,
                                                  Func<Result<T>.SuccessResult, TReturn>         whenSuccess,
                                                  Func<string, Result<T>.FailureResult, TReturn> whenFailure,
                                                  Func<string, TReturn>                        whenUnrecognised)
      => actual
        .Switch(whenFailure.Apply(TheResultIsAFailureWhenWeExpectedItToBeASuccess<T>(description)),
                whenSuccess,
                whenUnrecognised.Apply(TheResultIsUnrecognisedWhenWeExpectedItToBeASuccess<T>(description)));

   /* ------------------------------------------------------------ */

   internal static TReturn Switch<T, TReturn>(this IResult<T>                       actual,
                                              Func<Result<T>.FailureResult, TReturn> whenFailure,
                                              Func<Result<T>.SuccessResult, TReturn> whenSuccess,
                                              Func<TReturn>                        whenUnrecognised)
      => actual switch
         {
            Result<T>.SuccessResult success => whenSuccess(success),
            Result<T>.FailureResult failure => whenFailure(failure),

            _ => whenUnrecognised(),
         };

   /* ------------------------------------------------------------ */
}