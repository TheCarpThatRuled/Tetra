using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsANone(Error error)
      => AsProperty(() => error.Reduce(Function.True,
                                       Function.False))
        .Label(TheErrorIsASome());

   /* ------------------------------------------------------------ */

   public static Property IsANone(string description,
                                  Error  error)
      => AsProperty(() => error.Reduce(Function.True,
                                       Function.False))
        .Label(TheErrorIsASome(description));

   /* ------------------------------------------------------------ */

   public static Property IsASome(Error error)
      => AsProperty(() => error.Reduce(Function.False,
                                       Function.True))
        .Label(TheErrorIsANone());

   /* ------------------------------------------------------------ */

   public static Property IsASome(Error  error,
                                  string name)
      => AsProperty(() => error.Reduce(Function.False,
                                       Function.True))
        .Label(TheErrorIsANone(name));

   /* ------------------------------------------------------------ */

   public static Property IsASome(Message expected,
                                  Error   error)
      => error
        .Reduce(() => False(TheErrorIsANone()),
                some => AreEqual(TheErrorIsASomeButDoesNotContainTheExpectedContent(),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASome(Message expected,
                                  Error   error,
                                  string  name)
      => error
        .Reduce(() => False(TheErrorIsANone(name)),
                some => AreEqual(TheErrorIsASomeButDoesNotContainTheExpectedContent(name),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd(Func<Message, bool> property,
                                     Error               error)
      => error
        .Reduce(() => False(TheErrorIsANone()),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheErrorIsASomeButDoesNotContainTheExpectedContent(),
                                        actual)));

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd(Func<Message, bool> property,
                                     Error               error,
                                     string              name)
      => error
        .Reduce(() => False(TheErrorIsANone(name)),
                actual => AsProperty(() => property(actual))
                  .Label(Failed.Message(TheErrorIsASomeButDoesNotContainTheExpectedContent(name),
                                        actual)));

   /* ------------------------------------------------------------ */
}