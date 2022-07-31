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
        .Label(TheEitherIsARight<TLeft, TRight>(description));

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

   public static Property IsAIsALeftAnd<TLeft, TRight>(string                  description,
                                                       Func<Left<TLeft>, Property> property,
                                                       Either<TLeft, TRight>   either)
      => either
        .Reduce(property,
                _ => False(TheEitherIsARight<TLeft, TRight>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>(string                description,
                                                  Either<TLeft, TRight> either)
      => AsProperty(either.IsARight)
        .Label(TheEitherIsALeft<TLeft, TRight>(description));

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

   public static Property IsARightAnd<TLeft, TRight>(Func<Right<TRight>, Property> property,
                                                     Either<TLeft, TRight>     either,
                                                     string                    name)
      => either
        .Reduce(_ => False(TheEitherIsALeft<TLeft, TRight>(name)),
                property);

   /* ------------------------------------------------------------ */
}