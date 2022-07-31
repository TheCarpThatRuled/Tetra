using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsANone<T>(string    description,
                                     Option<T> option)
      => AsProperty(option.IsANone)
        .Label(TheOptionIsASome<T>(description));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(string    description,
                                     Option<T> option)
      => AsProperty(option.IsASome)
        .Label(TheOptionIsANone<T>(description));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(string    description,
                                     T         expected,
                                     Option<T> option)
      => option
        .Reduce(() => False(TheOptionIsANone<T>(description)),
                some => AreEqual(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd<T>(string        description,
                                        Func<T, bool> property,
                                        Option<T>     option)
      => option
        .Reduce(() => False(TheOptionIsANone<T>(description)),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                        actual)));

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd<T>(string            description,
                                        Func<T, Property> property,
                                        Option<T>         option)
      => option
        .Reduce(() => False(TheOptionIsANone<T>(description)),
                actual => property(actual)
                  .Label(Failed.Message(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                        actual)));

   /* ------------------------------------------------------------ */
}