using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsANone<T>(string    description,
                                     IOption<T> option)
      => AsProperty(option.IsANone)
        .Label(TheOptionIsASome<T>(description));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(string    description,
                                     IOption<T> option)
      => AsProperty(option.IsASome)
        .Label(TheOptionIsANone<T>(description));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(string    description,
                                     T         expected,
                                     IOption<T> option)
      => option
        .Reduce(() => False(TheOptionIsANone<T>(description)),
                some => AreEqual(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd<T>(string                    description,
                                        Func<string, T, Property> property,
                                        IOption<T>                 option)
      => option
        .Reduce(() => False(TheOptionIsANone<T>(description)),
                actual => property(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                   actual));

   /* ------------------------------------------------------------ */
}