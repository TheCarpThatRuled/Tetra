using System.Diagnostics;
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
        .Label(TheErrorIsSome());

   /* ------------------------------------------------------------ */

   public static Property IsANone(Error error,
                                  string name)
      => AsProperty(() => error.Reduce(Function.True,
                                       Function.False))
        .Label(TheErrorIsSome(name));

   /* ------------------------------------------------------------ */

   public static Property IsASome(Error error)
      => AsProperty(() => error.Reduce(Function.False,
                                       Function.True))
        .Label(TheErrorIsNone());

   /* ------------------------------------------------------------ */

   public static Property IsASome(Error error,
                                  string name)
      => AsProperty(() => error.Reduce(Function.False,
                                       Function.True))
        .Label(TheErrorIsNone(name));

   /* ------------------------------------------------------------ */

   public static Property IsASome(Message expected,
                                  Error error)
      => error
        .Reduce(() => False(TheErrorIsNone()),
                some => AreEqual(TheErrorDoesNotContainTheExpectedValue(),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASome(Message expected,
                                  Error error,
                                  string name)
      => error
        .Reduce(() => False(TheErrorIsNone(name)),
                some => AreEqual(TheErrorDoesNotContainTheExpectedValue(name),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */
}