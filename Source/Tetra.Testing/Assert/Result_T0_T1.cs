using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<TSuccess, TFailure>(this Assert                 assert,
                                                       string                      description,
                                                       IResult<TSuccess, TFailure> actual)
      => actual
        .IsAFailure(description,
                    (failureMessage,
                     failure) => assert,
                    (successMessage,
                     success) => throw Failed.Assert(successMessage),
                    unrecognisedMessage => throw Failed.Assert(unrecognisedMessage));

   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<TSuccess, TFailure>(this Assert                 assert,
                                                       string                      description,
                                                       TFailure                    expected,
                                                       IResult<TSuccess, TFailure> actual)
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

   public static Assert IsAFailureAnd<TSuccess, TFailure>(this Assert                 assert,
                                                          string                      description,
                                                          Func<TFailure, bool>        property,
                                                          IResult<TSuccess, TFailure> actual)
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

   public static Assert IsASuccess<TSuccess, TFailure>(this Assert                 assert,
                                                       string                      description,
                                                       IResult<TSuccess, TFailure> actual)
      => actual
        .IsASuccess(description,
                    (successMessage,
                     success) => assert,
                    (failureMessage,
                     failure) => throw Failed.Assert(failureMessage,
                                                     failure.ToTestOutput()),
                    unrecognisedMessage => throw Failed.Assert(unrecognisedMessage));

   /* ------------------------------------------------------------ */

   public static Assert IsASuccess<TSuccess, TFailure>(this Assert                 assert,
                                                       string                      description,
                                                       TSuccess                    expected,
                                                       IResult<TSuccess, TFailure> actual)
      => actual
        .IsASuccess(description,
                    (successMessage,
                     success) => assert.AreEqual(successMessage,
                                                 expected,
                                                 success.Content),
                    (failureMessage,
                     failure) => throw Failed.Assert(failureMessage,
                                                     failure.ToTestOutput()),
                    unrecognisedMessage => throw Failed.Assert(unrecognisedMessage));

   /* ------------------------------------------------------------ */

   public static Assert IsASuccessAnd<TSuccess, TFailure>(this Assert                 assert,
                                                          string                      description,
                                                          Func<TSuccess, bool>        property,
                                                          IResult<TSuccess, TFailure> actual)
      => actual
        .IsASuccess(description,
                    (successMessage,
                     success) => !property(success.Content)
                                    ? throw Failed.Assert(successMessage,
                                                          success.ToTestOutput())
                                    : assert,
                    (failureMessage,
                     failure) => throw Failed.Assert(failureMessage,
                                                     failure.ToTestOutput()),
                    unrecognisedMessage => throw Failed.Assert(unrecognisedMessage));

   /* ------------------------------------------------------------ */
   // Internal Methods
   /* ------------------------------------------------------------ */

   internal static TReturn IsAFailure<TSuccess, TFailure, TReturn>(this IResult<TSuccess, TFailure>                                actual,
                                                                   string                                                          description,
                                                                   Func<string, Result<TSuccess, TFailure>.FailureResult, TReturn> whenFailure,
                                                                   Func<string, Result<TSuccess, TFailure>.SuccessResult, TReturn> whenSuccess,
                                                                   Func<string, TReturn>                                           whenUnrecognised)
      => actual
        .Switch(whenFailure.Apply(TheResultIsAFailureButDoesNotContainTheExpectedContent<TSuccess, TFailure>(description)),
                whenSuccess.Apply(TheResultIsASuccessWhenWeExpectedItToBeAFailure<TSuccess, TFailure>(description)),
                whenUnrecognised.Apply(TheResultIsUnrecognisedWhenWeExpectedItToBeAFailure<TSuccess, TFailure>(description)));

   /* ------------------------------------------------------------ */

   internal static TReturn IsASuccess<TSuccess, TFailure, TReturn>(this IResult<TSuccess, TFailure>                                actual,
                                                                   string                                                          description,
                                                                   Func<string, Result<TSuccess, TFailure>.SuccessResult, TReturn> whenSuccess,
                                                                   Func<string, Result<TSuccess, TFailure>.FailureResult, TReturn> whenFailure,
                                                                   Func<string, TReturn>                                           whenUnrecognised)
      => actual
        .Switch(whenFailure.Apply(TheResultIsAFailureWhenWeExpectedItToBeASuccess<TSuccess, TFailure>(description)),
                whenSuccess.Apply(TheResultIsASuccessButDoesNotContainTheExpectedContent<TSuccess, TFailure>(description)),
                whenUnrecognised.Apply(TheResultIsUnrecognisedWhenWeExpectedItToBeASuccess<TSuccess, TFailure>(description)));

   /* ------------------------------------------------------------ */

   internal static TReturn Switch<TSuccess, TFailure, TReturn>(this IResult<TSuccess, TFailure>                        actual,
                                                               Func<Result<TSuccess, TFailure>.FailureResult, TReturn> whenFailure,
                                                               Func<Result<TSuccess, TFailure>.SuccessResult, TReturn> whenSuccess,
                                                               Func<TReturn>                                           whenUnrecognised)
      => actual switch
         {
            Result<TSuccess, TFailure>.SuccessResult success => whenSuccess(success),
            Result<TSuccess, TFailure>.FailureResult failure => whenFailure(failure),

            _ => whenUnrecognised(),
         };

   /* ------------------------------------------------------------ */
}