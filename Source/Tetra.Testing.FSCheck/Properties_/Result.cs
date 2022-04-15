using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(Result<T> result)
      => AsProperty(result.IsAFailure)
        .Label(TheResultIsASuccess<T>());

   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(Result<T> result,
                                        string    name)
      => AsProperty(result.IsAFailure)
        .Label(TheResultIsASuccess<T>(name));

   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(Message   expected,
                                        Result<T> result)
      => result
        .Reduce(actual => AreEqual(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(),
                                   expected,
                                   actual.Content()),
                _ => False(TheResultIsASuccess<T>()));

   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(Message   expected,
                                        Result<T> result,
                                        string    name)
      => result
        .Reduce(actual => AreEqual(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(name),
                                   expected,
                                   actual.Content()),
                _ => False(TheResultIsASuccess<T>(name)));

   /* ------------------------------------------------------------ */

   public static Property IsAIsAFailureAnd<T>(Func<Failure, bool> property,
                                              Result<T>           result)
      => result
        .Reduce(actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(),
                                        actual)),
                _ => False(TheResultIsASuccess<T>()));

   /* ------------------------------------------------------------ */

   public static Property IsAIsAFailureAnd<T>(Func<Failure, bool> property,
                                              Result<T>           result,
                                              string              name)
      => result
        .Reduce(actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(name),
                                        actual)),
                _ => False(TheResultIsASuccess<T>(name)));

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(Result<T> result)
      => AsProperty(result.IsASuccess)
        .Label(TheResultIsAFailure<T>());

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(Result<T> result,
                                        string    name)
      => AsProperty(result.IsASuccess)
        .Label(TheResultIsAFailure<T>(name));

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(T         expected,
                                        Result<T> result)
      => result
        .Reduce(_ => False(TheResultIsAFailure<T>()),
                actual => AreEqual(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(),
                                   expected,
                                   actual.Content()));

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(T         expected,
                                        Result<T> result,
                                        string    name)
      => result
        .Reduce(_ => False(TheResultIsAFailure<T>(name)),
                actual => AreEqual(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(name),
                                   expected,
                                   actual.Content()));

   /* ------------------------------------------------------------ */

   public static Property IsASuccessAnd<T>(Func<Success<T>, bool> property,
                                           Result<T>              result)
      => result
        .Reduce(_ => False(TheResultIsAFailure<T>()),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(),
                                        actual)));

   /* ------------------------------------------------------------ */

   public static Property IsASuccessAnd<T>(Func<Success<T>, bool> property,
                                           Result<T>              result,
                                           string                 name)
      => result
        .Reduce(_ => False(TheResultIsAFailure<T>(name)),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(name),
                                        actual)));

   /* ------------------------------------------------------------ */
}