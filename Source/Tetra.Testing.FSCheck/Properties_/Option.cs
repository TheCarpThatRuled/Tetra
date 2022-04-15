using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsANone<T>(Option<T> option)
      => AsProperty(option.IsANone)
        .Label(TheOptionIsASome<T>());

   /* ------------------------------------------------------------ */

   public static Property IsANone<T>(Option<T> option,
                                     string    name)
      => AsProperty(option.IsANone)
        .Label(TheOptionIsASome<T>(name));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(Option<T> option)
      => AsProperty(option.IsASome)
        .Label(TheOptionIsANone<T>());

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(Option<T> option,
                                     string    name)
      => AsProperty(option.IsASome)
        .Label(TheOptionIsANone<T>(name));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(T         expected,
                                     Option<T> option)
      => option
        .Reduce(() => False(TheOptionIsANone<T>()),
                some => AreEqual(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(T         expected,
                                     Option<T> option,
                                     string    name)
      => option
        .Reduce(() => False(TheOptionIsANone<T>(name)),
                some => AreEqual(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(name),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd<T>(Func<T, bool> property,
                                        Option<T>     option)
      => option
        .Reduce(() => False(TheOptionIsANone<T>()),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(),
                                        actual)));

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd<T>(Func<T, bool> property,
                                        Option<T>     option,
                                        string        name)
      => option
        .Reduce(() => False(TheOptionIsANone<T>(name)),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(name),
                                        actual)));

   /* ------------------------------------------------------------ */
}