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
                                Error       error)
   {
      if (error.IsASome())
      {
         throw Failed.Assert(TheErrorIsASome());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsANone(this Assert assert,
                                Error       error,
                                string      name)
   {
      if (error.IsASome())
      {
         throw Failed.Assert(TheErrorIsASome(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                Error       error)
   {
      if (error.IsANone())
      {
         throw Failed.Assert(TheErrorIsANone());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                Error       error,
                                string      name)
   {
      if (error.IsANone())
      {
         throw Failed.Assert(TheErrorIsANone(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                Message     expected,
                                Error       error)
   {
      if (error.Reduce(Function.True,
                       actual =>
                       {
                          assert.AreEqual(expected,
                                          actual,
                                          TheErrorIsASomeButDoesNotContainTheExpectedContent());

                          return false;
                       }))
      {
         throw Failed.Assert(TheErrorIsANone());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                Message     expected,
                                Error       error,
                                string      name)
   {
      if (error.Reduce(Function.True,
                       actual =>
                       {
                          assert.AreEqual(expected,
                                          actual,
                                          TheErrorIsASomeButDoesNotContainTheExpectedContent(name));

                          return false;
                       }))
      {
         throw Failed.Assert(TheErrorIsANone(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd(this Assert         assert,
                                   Func<Message, bool> property,
                                   Error               error)
   {
      if (error.Reduce(Function.True,
                       actual =>
                       {
                          if (!property(actual))
                          {
                             throw Failed.Assert(TheErrorIsASomeButDoesNotContainTheExpectedContent(),
                                                 actual);
                          }

                          return false;
                       }))
      {
         throw Failed.Assert(TheErrorIsANone());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd(this Assert         assert,
                                   Func<Message, bool> property,
                                   Error               error,
                                   string              name)
   {
      if (error.Reduce(Function.True,
                       actual =>
                       {
                          if (!property(actual))
                          {
                             throw Failed.Assert(TheErrorIsASomeButDoesNotContainTheExpectedContent(name),
                                                 actual);
                          }

                          return false;
                       }))
      {
         throw Failed.Assert(TheErrorIsANone(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}