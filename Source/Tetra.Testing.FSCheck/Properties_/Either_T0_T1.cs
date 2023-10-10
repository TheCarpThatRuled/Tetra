using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>
   (
      string                 description,
      IEither<TLeft, TRight> actual
   )
      => IsARightAnd(description,
                     (
                        rightMessage,
                        right
                     ) => True(),
                     actual);

   /* ------------------------------------------------------------ */

   public static Property IsARight<TLeft, TRight>
   (
      string                 description,
      TRight                 expected,
      IEither<TLeft, TRight> actual
   )
      => IsARightAnd(description,
                     (
                        rightMessage,
                        right
                     ) => AreEqual(rightMessage,
                                   expected,
                                   right),
                     actual);

   /* ------------------------------------------------------------ */

   public static Property IsARightAnd<TLeft, TRight>
   (
      string                         description,
      Func<string, TRight, Property> property,
      IEither<TLeft, TRight>         actual
   )
      => actual
        .IsARight(description,
                  (
                     rightMessage,
                     right
                  ) => property($"{rightMessage}",
                                right.Content),
                  (
                     leftMessage,
                     left
                  ) => False(leftMessage),
                  False);

   /* ------------------------------------------------------------ */

   public static Property IsALeft<TLeft, TRight>
   (
      string                 description,
      IEither<TLeft, TRight> actual
   )
      => actual
        .IsALeft(description,
                 (
                    leftMessage,
                    left
                 ) => True(),
                 (
                    rightMessage,
                    right
                 ) => False(rightMessage),
                 False);

   /* ------------------------------------------------------------ */

   public static Property IsALeft<TLeft, TRight>
   (
      string                 description,
      TLeft                  expected,
      IEither<TLeft, TRight> actual
   )
      => IsALeftAnd(description,
                    (
                       leftMessage,
                       left
                    ) => AreEqual(leftMessage,
                                  expected,
                                  left),
                    actual);

   /* ------------------------------------------------------------ */

   public static Property IsALeftAnd<TLeft, TRight>
   (
      string                        description,
      Func<string, TLeft, Property> property,
      IEither<TLeft, TRight>        actual
   )
      => actual
        .IsALeft(description,
                 (
                    leftMessage,
                    left
                 ) => property($"{leftMessage}",
                               left.Content),
                 (
                    rightMessage,
                    right
                 ) => False(rightMessage),
                 False);

   /* ------------------------------------------------------------ */
}