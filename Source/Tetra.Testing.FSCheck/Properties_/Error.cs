﻿using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsANone(string description,
                                  IError error)
      => AsProperty(() => error.Reduce(Function.True,
                                       Function.False))
        .Label(TheErrorIsASome(description));

   /* ------------------------------------------------------------ */

   public static Property IsASome(string description,
                                  IError error)
      => AsProperty(() => error.Reduce(Function.False,
                                       Function.True))
        .Label(TheErrorIsANone(description));

   /* ------------------------------------------------------------ */

   public static Property IsASome(string  description,
                                  Message expected,
                                  IError  error)
      => error
        .Reduce(() => False(TheErrorIsANone(description)),
                some => AreEqual(TheErrorIsASomeButDoesNotContainTheExpectedContent(description),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd(string                          description,
                                     Func<string, Message, Property> property,
                                     IError                          error)
      => error
        .Reduce(() => False(TheErrorIsANone(description)),
                actual => property(TheErrorIsASomeButDoesNotContainTheExpectedContent(description),
                                   actual));

   /* ------------------------------------------------------------ */
}