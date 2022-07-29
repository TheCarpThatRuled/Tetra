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
                                   Option<T>   option)
   {
      if (option.IsASome())
      {
         throw Failed.Assert(TheOptionIsASome<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   string      description,
                                   Option<T>   option)
   {
      if (option.IsANone())
      {
         throw Failed.Assert(TheOptionIsANone<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   string      description,
                                   T           expected,
                                   Option<T>   option)
   {
      if (option.Reduce(true,
                        actual =>
                        {
                           assert.AreEqual(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                           expected,
                                           actual);

                           return false;
                        }))
      {
         throw Failed.Assert(TheOptionIsANone<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd<T>(this Assert   assert,
                                      string        description,
                                      Func<T, bool> property,
                                      Option<T>     option)
   {
      if (option.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheOptionIsANone<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}