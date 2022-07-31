﻿using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(string    description,
                                        Result<T> result)
      => AsProperty(result.IsAFailure)
        .Label(TheResultIsASuccess<T>(description));

   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(string    description,
                                        Message   expected,
                                        Result<T> result)
      => result
        .Reduce(actual => AreEqual(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(description),
                                   expected,
                                   actual.Content()),
                _ => False(TheResultIsASuccess<T>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsAIsAFailureAnd<T>(string              description,
                                              Func<Failure, bool> property,
                                              Result<T>           result)
      => result
        .Reduce(actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(description),
                                        actual)),
                _ => False(TheResultIsASuccess<T>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(string    description,
                                        Result<T> result)
      => AsProperty(result.IsASuccess)
        .Label(TheResultIsAFailure<T>(description));

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(string    description,
                                        T         expected,
                                        Result<T> result)
      => result
        .Reduce(failure => False(TheResultIsAFailure<T>(description,
                                                        failure.Content())),
                actual => AreEqual(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(description),
                                   expected,
                                   actual.Content()));

   /* ------------------------------------------------------------ */

   public static Property IsASuccessAnd<T>(string                 description,
                                           Func<Success<T>, bool> property,
                                           Result<T>              result)
      => result
        .Reduce(failure => False(TheResultIsAFailure<T>(description,
                                                        failure.Content())),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(description),
                                        actual)));

   /* ------------------------------------------------------------ */

   public static Property IsASuccessAnd<T>(string                     description,
                                           Func<Success<T>, Property> property,
                                           Result<T>                  result)
      => result
        .Reduce(failure => False(TheResultIsAFailure<T>(description,
                                                        failure.Content())),
                actual => property(actual)
                  .Label(Failed.Message(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(description),
                                        actual)));

   /* ------------------------------------------------------------ */
}