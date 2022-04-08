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
                                   Option<T> option)
   {
      if (option.IsASome())
      {
         throw Failed.Assert(TheOptionIsNone<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsANone<T>(this Assert assert,
                                   Option<T> option,
                                   string name)
   {
      if (option.IsASome())
      {
         throw Failed.Assert(TheOptionIsNone<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   Option<T> option)
   {
      if (option.IsANone())
      {
         throw Failed.Assert(TheOptionIsNone<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   Option<T> option,
                                   string name)
   {
      if (option.IsANone())
      {
         throw Failed.Assert(TheOptionIsNone<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   T expected,
                                   Option<T> option)
   {
      if (option.Reduce(true,
                        actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheOptionDoesNotContainTheExpectedValue<T>());

                           return false;
                        }))
      {
         throw Failed.Assert(TheOptionIsNone<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASome<T>(this Assert assert,
                                   T expected,
                                   Option<T> option,
                                   string name)
   {
      if (option.Reduce(true,
                        actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheOptionDoesNotContainTheExpectedValue<T>(name));

                           return false;
                        }))
      {
         throw Failed.Assert(TheOptionIsNone<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}