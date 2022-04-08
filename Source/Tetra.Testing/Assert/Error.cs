using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsANone(this Assert assert,
                                Error error)
   {
      if (error.Reduce(Function.False,
                       Function.True))
      {
         throw Failed.Assert(TheErrorIsSome());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsANone(this Assert assert,
                                Error error,
                                string name)
   {
      if (error.Reduce(Function.False,
                       Function.True))
      {
         throw Failed.Assert(TheErrorIsSome(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                Error error)
   {
      if (error.Reduce(Function.True,
                       Function.False))
      {
         throw Failed.Assert(TheErrorIsNone());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                Error error,
                                string name)
   {
      if (error.Reduce(Function.True,
                       Function.False))
      {
         throw Failed.Assert(TheErrorIsNone(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                Message expected,
                                Error error)
   {
      if (error.Reduce(Function.True,
                       actual =>
                       {
                          assert.AreEqual(expected,
                                          actual,
                                          TheErrorDoesNotContainTheExpectedValue());

                          return false;
                       }))
      {
         throw Failed.Assert(TheErrorIsNone());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                Message expected,
                                Error error,
                                string name)
   {
      if (error.Reduce(Function.True,
                       actual =>
                       {
                          assert.AreEqual(expected,
                                          actual,
                                          TheErrorDoesNotContainTheExpectedValue(name));

                          return false;
                       }))
      {
         throw Failed.Assert(TheErrorIsNone(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}