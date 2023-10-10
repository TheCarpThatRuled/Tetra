﻿namespace Check;

public static partial class Steps
{
   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheClient the_Client { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheReturnValue the_return_value { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheWhenLeft the_whenLeft { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheWhenNone the_whenNone { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheWhenRight the_whenRight { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheWhenSome the_whenSome { get; } = new();

   /* ------------------------------------------------------------ */
}