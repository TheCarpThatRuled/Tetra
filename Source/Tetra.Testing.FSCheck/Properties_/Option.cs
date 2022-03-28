﻿using System.Diagnostics;
using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsANone<T>(Option<T> option)
      => AsProperty(() => option.Reduce(() => true,
                                        _ => false))
        .Label(TheOptionIsSome<T>());

   /* ------------------------------------------------------------ */

   public static Property IsANone<T>(Option<T> option,
                                     string name)
      => AsProperty(() => option.Reduce(() => true,
                                        _ => false))
        .Label(TheOptionIsSome<T>(name));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(Option<T> option)
      => AsProperty(() => option.Reduce(() => false,
                                        _ => true))
        .Label(TheOptionIsNone<T>());

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(Option<T> option,
                                     string name)
      => AsProperty(() => option.Reduce(() => false,
                                        _ => true))
        .Label(TheOptionIsNone<T>(name));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(T expected,
                                     Option<T> option)
      => option
        .Reduce(() => False(TheOptionIsNone<T>()),
                some => AreEqual(TheOptionDoesNotContainTheExpectedValue<T>(),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(T expected,
                                     Option<T> option,
                                     string name)
      => option
        .Reduce(() => False(TheOptionIsNone<T>(name)),
                some => AreEqual(TheOptionDoesNotContainTheExpectedValue<T>(name),
                                 expected,
                                 some));

   /* ------------------------------------------------------------ */
}