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
                                   Option<T>   option)
   {
      if (option.IsASome())
      {
         throw Failed.Assert(TheOptionIsASome<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsANone<T>(this Assert assert,
                                   Option<T>   option,
                                   string      name)
   {
      if (option.IsASome())
      {
         throw Failed.Assert(TheOptionIsASome<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   Option<T>   option)
   {
      if (option.IsANone())
      {
         throw Failed.Assert(TheOptionIsANone<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   Option<T>   option,
                                   string      name)
   {
      if (option.IsANone())
      {
         throw Failed.Assert(TheOptionIsANone<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   T           expected,
                                   Option<T>   option)
   {
      if (option.Reduce(true,
                        actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheOptionIsASomeButDoesNotContainTheExpectedContent<T>());

                           return false;
                        }))
      {
         throw Failed.Assert(TheOptionIsANone<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   T           expected,
                                   Option<T>   option,
                                   string      name)
   {
      if (option.Reduce(true,
                        actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(name));

                           return false;
                        }))
      {
         throw Failed.Assert(TheOptionIsANone<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd<T>(this Assert   assert,
                                      Func<T, bool> property,
                                      Option<T>     option)
   {
      if (option.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheOptionIsANone<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASomeAnd<T>(this Assert   assert,
                                      Func<T, bool> property,
                                      Option<T>     option,
                                      string        name)
   {
      if (option.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(name),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheOptionIsANone<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}