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
                                string      description,
                                Error       error)
   {
      if (error.IsASome())
      {
         throw Failed.Assert(TheErrorIsASome(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                string      description,
                                Error       error)
   {
      if (error.IsANone())
      {
         throw Failed.Assert(TheErrorIsANone(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                string      description,
                                Message     expected,
                                Error       error)
   {
      if (error.Reduce(Function.True,
                       actual =>
                       {
                          assert.AreEqual(TheErrorIsASomeButDoesNotContainTheExpectedContent(description),
                                          expected,
                                          actual);

                          return false;
                       }))
      {
         throw Failed.Assert(TheErrorIsANone(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd(this Assert         assert,
                                   string              description,
                                   Func<Message, bool> property,
                                   Error               error)
   {
      if (error.Reduce(Function.True,
                       actual =>
                       {
                          if (!property(actual))
                          {
                             throw Failed.Assert(TheErrorIsASomeButDoesNotContainTheExpectedContent(description),
                                                 actual);
                          }

                          return false;
                       }))
      {
         throw Failed.Assert(TheErrorIsANone(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}