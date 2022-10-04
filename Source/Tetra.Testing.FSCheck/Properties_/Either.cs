using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsALeft<TLeft, TRight>(string                description,
                                                 Either<TLeft, TRight> either)
      => AsProperty(either.IsALeft)
        .Label(TheEitherIsARightWhenWeExpectItToBeALeft<TLeft, TRight>(description));

   /* ------------------------------------------------------------ */

   public static Property IsALeft<TLeft, TRight>(string                description,
                                                 TLeft                 expected,
                                                 Either<TLeft, TRight> either)
      => either
        .Reduce(actual => AreEqual(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                   expected,
                                   actual.Content()),
                _ => False(TheEitherIsARightWhenWeExpectItToBeALeft<TLeft, TRight>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsAIsALeftAnd<TLeft, TRight>(string                              description,
                                                       Func<string, Left<TLeft>, Property> property,
                                                       Either<TLeft, TRight>               either)
      => either
        .Reduce(left => property(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                 left),
                _ => False(TheEitherIsARightWhenWeExpectItToBeALeft<TLeft, TRight>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>(string                description,
                                                  Either<TLeft, TRight> either)
      => AsProperty(either.IsARight)
        .Label(TheEitherIsALeftWheWeExpectItToBeARight<TLeft, TRight>(description));

   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>(string                description,
                                                  TRight                expected,
                                                  Either<TLeft, TRight> either)
      => either
        .Reduce(_ => False(TheEitherIsALeftWheWeExpectItToBeARight<TLeft, TRight>(description)),
                actual => AreEqual(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                   expected,
                                   actual.Content()));

   /* ------------------------------------------------------------ */

   public static Property IsARightAnd<TLeft, TRight>(string                                description,
                                                     Func<string, Right<TRight>, Property> property,
                                                     Either<TLeft, TRight>                 either)
      => either
        .Reduce(_ => False(TheEitherIsALeftWheWeExpectItToBeARight<TLeft, TRight>(description)),
                right => property(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                  right));

   /* ------------------------------------------------------------ */
}