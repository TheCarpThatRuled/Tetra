﻿namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string ANone = $"{A} none";

   private const string ASome = $"{A} some";
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheOptionIsANoneWhenWeExpectedItToBeASome<T>
   (
      string description
   )
      => $"{description}: {TheIOption<T>()} {Is} {ANone} {WhenWeExpectedItToBe} {ASome}";

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASomeButDoesNotContainTheExpectedContent<T>
   (
      string description
   )
      => $"{description}: {TheIOption<T>()} {Is} {ASome} {ButDoesNotContain} {TheExpectedContent}";

   /* ------------------------------------------------------------ */

   public static string TheOptionIsASomeWhenWeExpectedItToBeANone<T>
   (
      string description
   )
      => $"{description}: {TheIOption<T>()} {Is} {ASome} {WhenWeExpectedItToBe} {ANone}";

   /* ------------------------------------------------------------ */

   public static string TheOptionIsUnrecognisedWhenWeExpectedItToBeANone<T>
   (
      string description
   )
      => $"{description}: {TheIOption<T>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {ANone}";

   /* ------------------------------------------------------------ */

   public static string TheOptionIsUnrecognisedWhenWeExpectedItToBeASome<T>
   (
      string description
   )
      => $"{description}: {TheIOption<T>()} {Is} {Unrecognised} {WhenWeExpectedItToBe} {ASome}";

   /* ------------------------------------------------------------ */
   // Internal Extension
   /* ------------------------------------------------------------ */

   internal static string ToTestOutput<T>
   (
      this Option<T>.SomeOption some
   )
      => $@"Some({some.Content})";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheIOption<T>()
      => $@"{The} IOption<{typeof(T).Name}>";

   /* ------------------------------------------------------------ */
}