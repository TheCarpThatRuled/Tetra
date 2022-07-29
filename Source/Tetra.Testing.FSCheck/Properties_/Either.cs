using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsALeft<TLeft, TRight>(Either<TLeft, TRight> either)
      => AsProperty(either.IsALeft)
        .Label(TheEitherIsARight<TLeft, TRight>());

   /* ------------------------------------------------------------ */

   public static Property IsALeft<TLeft, TRight>(Either<TLeft, TRight> either,
                                                 string                name)
      => AsProperty(either.IsALeft)
        .Label(TheEitherIsARight<TLeft, TRight>(name));

   /* ------------------------------------------------------------ */

   public static Property IsALeft<TLeft, TRight>(TLeft                 expected,
                                                 Either<TLeft, TRight> either)
      => either
        .Reduce(actual => AreEqual(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(),
                                   expected,
                                   actual.Content()),
                _ => False(TheEitherIsARight<TLeft, TRight>()));

   /* ------------------------------------------------------------ */

   public static Property IsALeft<TLeft, TRight>(string                description,
                                                 TLeft                 expected,
                                                 Either<TLeft, TRight> either)
      => either
        .Reduce(actual => AreEqual(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                   expected,
                                   actual.Content()),
                _ => False(TheEitherIsARight<TLeft, TRight>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsAIsALeftAnd<TLeft, TRight>(Func<Left<TLeft>, bool> property,
                                                       Either<TLeft, TRight>   either)
      => either
        .Reduce(actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(),
                                        actual)),
                _ => False(TheEitherIsARight<TLeft, TRight>()));

   /* ------------------------------------------------------------ */

   public static Property IsAIsALeftAnd<TLeft, TRight>(string                  description,
                                                       Func<Left<TLeft>, bool> property,
                                                       Either<TLeft, TRight>   either)
      => either
        .Reduce(actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                        actual)),
                _ => False(TheEitherIsARight<TLeft, TRight>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>(Either<TLeft, TRight> either)
      => AsProperty(either.IsARight)
        .Label(TheEitherIsALeft<TLeft, TRight>());

   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>(string                description,
                                                  Either<TLeft, TRight> either)
      => AsProperty(either.IsARight)
        .Label(TheEitherIsALeft<TLeft, TRight>(description));

   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>(TRight                expected,
                                                  Either<TLeft, TRight> either)
      => either
        .Reduce(_ => False(TheEitherIsALeft<TLeft, TRight>()),
                actual => AreEqual(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(),
                                   expected,
                                   actual.Content()));

   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>(TRight                expected,
                                                  Either<TLeft, TRight> either,
                                                  string                name)
      => either
        .Reduce(_ => False(TheEitherIsALeft<TLeft, TRight>(name)),
                actual => AreEqual(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(name),
                                   expected,
                                   actual.Content()));

   /* ------------------------------------------------------------ */

   public static Property IsARightAnd<TLeft, TRight>(Func<Right<TRight>, bool> property,
                                                     Either<TLeft, TRight>     either)
      => either
        .Reduce(_ => False(TheEitherIsALeft<TLeft, TRight>()),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(),
                                        actual)));

   /* ------------------------------------------------------------ */

   public static Property IsARightAnd<TLeft, TRight>(Func<Right<TRight>, bool> property,
                                                     Either<TLeft, TRight>     either,
                                                     string                    name)
      => either
        .Reduce(_ => False(TheEitherIsALeft<TLeft, TRight>(name)),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(name),
                                        actual)));

   /* ------------------------------------------------------------ */
}