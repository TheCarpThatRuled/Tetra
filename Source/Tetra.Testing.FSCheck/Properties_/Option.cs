using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(string     description,
                                     IOption<T> actual)
      => IsASomeAnd(description,
                    (someMessage,
                     some) => True(),
                    actual);

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(string     description,
                                     T          expected,
                                     IOption<T> actual)
      => IsASomeAnd(description,
                    (someMessage,
                     some) => AreEqual(someMessage,
                                       expected,
                                       some),
                    actual);

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd<T>(string                    description,
                                        Func<string, T, Property> property,
                                        IOption<T>                actual)
      => actual
        .IsASome(description,
                 (someMessage,
                  some) => property($"{someMessage}",
                                    some.Content),
                 (noneMessage,
                  none) => False(noneMessage),
                 False);

   /* ------------------------------------------------------------ */

   public static Property IsANone<T>(string     description,
                                     IOption<T> actual)
      => actual
        .IsANone(description,
                 none => True(),
                 (someMessage,
                  some) => False(someMessage),
                 False);

   /* ------------------------------------------------------------ */
}