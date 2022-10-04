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
                                IError      actual)
      => actual switch
         {
            Error.SomeError some => throw Failed.Assert(TheErrorIsASomeWhenWeExpectedItToBeANone(description),
                                                        some.ToTestOutput()),
            not Error.NoneError => throw Failed.Assert(TheErrorIsUnrecognisedWhenWeExpectedItToBeANone(description)),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                string      description,
                                IError      actual)
      => actual switch
         {
            Error.NoneError     => throw Failed.Assert(TheErrorIsANoneWhenWeExpectedItToBeASome(description)),
            not Error.SomeError => throw Failed.Assert(TheErrorIsUnrecognisedWhenWeExpectedItToBeASome(description)),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsASome(this Assert assert,
                                string      description,
                                Message     expected,
                                IError      actual)
      => actual switch
         {
            Error.NoneError => throw Failed.Assert(TheErrorIsANoneWhenWeExpectedItToBeASome(description)),
            Error.SomeError some => assert.AreEqual(description,
                                                    expected,
                                                    some.Content),

            _ => throw Failed.Assert(TheErrorIsUnrecognisedWhenWeExpectedItToBeASome(description)),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd(this Assert         assert,
                                   string              description,
                                   Func<Message, bool> property,
                                   IError              actual)
      => actual switch
         {
            Error.NoneError => throw Failed.Assert(TheErrorIsANoneWhenWeExpectedItToBeASome(description)),
            Error.SomeError some => !property(some.Content)
                                       ? throw Failed.Assert(TheErrorIsASomeButDoesNotContainTheExpectedContent(description))
                                       : assert,

            _ => throw Failed.Assert(TheErrorIsUnrecognisedWhenWeExpectedItToBeASome(description)),
         };

   /* ------------------------------------------------------------ */
}