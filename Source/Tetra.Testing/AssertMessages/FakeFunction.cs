﻿namespace Tetra.Testing;

partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedAnUnexpectedNumberOfTimes<TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<TReturn>()} {WasInvokedAnUnexpectedNumberOfTimes}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedMoreThanOnce<T, TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<T, TReturn>()} {WasInvokedMoreThanOnce}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedMoreThanOnce<T0, T1, TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<T0, T1, TReturn>()} {WasInvokedMoreThanOnce}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<TReturn>()} {WasInvokedWhenWeExpectedItNotToHaveBeen}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T, TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<T, TReturn>()} {WasInvokedWhenWeExpectedItNotToHaveBeen}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWhenWeExpectedItNotToBe<T0, T1, TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<T0, T1, TReturn>()} {WasInvokedWhenWeExpectedItNotToHaveBeen}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T, TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<T, TReturn>()} {WasInvokedWithAnUnexpectedArgument}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasInvokedWithAnUnexpectedArgument<T0, T1, TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<T0, T1, TReturn>()} {WasInvokedWithAnUnexpectedArgument}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T, TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<T, TReturn>()} {WasNotInvokedWhenWeExpectedItToHaveBeen}.";

   /* ------------------------------------------------------------ */

   public static string TheFakeFunctionWasNotInvokedWheWeExpectedToBe<T0, T1, TReturn>
   (
      string description
   )
      => $"{description}: {TheFakeFunction<T0, T1, TReturn>()} {WasNotInvokedWhenWeExpectedItToHaveBeen}.";

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string TheFakeFunction<TReturn>()
      => $"{The} FakeFunction <{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */

   private static string TheFakeFunction<T, TReturn>()
      => $"{The} FakeFunction <{typeof(T).Name},{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */

   private static string TheFakeFunction<T0, T1, TReturn>()
      => $"{The} FakeFunction <{typeof(T0).Name},{typeof(T1).Name},{typeof(TReturn).Name}>";

   /* ------------------------------------------------------------ */
}