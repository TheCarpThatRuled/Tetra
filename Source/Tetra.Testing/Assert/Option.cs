using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsANone<T>(this Assert assert,
                                   string      description,
                                   IOption<T>  actual)
      => actual switch
         {
            Option<T>.SomeOption some => throw Failed.Assert(TheOptionIsASomeWhenWeExpectedItToBeANone<T>(description),
                                                             some.ToTestOutput()),
            not Option<T>.NoneOption => throw Failed.Assert(TheOptionIsUnrecognisedWhenWeExpectedItToBeANone<T>(description)),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   string      description,
                                   IOption<T>  actual)
      => actual switch
         {
            Option<T>.NoneOption     => throw Failed.Assert(TheOptionIsANoneWhenWeExpectedItToBeASome<T>(description)),
            not Option<T>.SomeOption => throw Failed.Assert(TheOptionIsIUnrecognisedWhenWeExpectedItToBeASome<T>(description)),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   string      description,
                                   T           expected,
                                   IOption<T>  actual)
      => actual switch
         {
            Option<T>.NoneOption => throw Failed.Assert(TheOptionIsANoneWhenWeExpectedItToBeASome<T>(description)),
            Option<T>.SomeOption some => assert.AreEqual(description,
                                                         expected,
                                                         some.Content),

            _ => throw Failed.Assert(TheOptionIsIUnrecognisedWhenWeExpectedItToBeASome<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd<T>(this Assert   assert,
                                      string        description,
                                      Func<T, bool> property,
                                      IOption<T>    actual)
      => actual switch
         {
            Option<T>.NoneOption => throw Failed.Assert(TheOptionIsANoneWhenWeExpectedItToBeASome<T>(description)),
            Option<T>.SomeOption some => !property(some.Content)
                                            ? throw Failed.Assert(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description))
                                            : assert,

            _ => throw Failed.Assert(TheOptionIsIUnrecognisedWhenWeExpectedItToBeASome<T>(description)),
         };

   /* ------------------------------------------------------------ */
}