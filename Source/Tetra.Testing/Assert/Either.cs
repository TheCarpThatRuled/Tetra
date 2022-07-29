using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsALeft<TLeft, TRight>(this Assert           assert,
                                               string                description,
                                               Either<TLeft, TRight> either)
   {
      if (either.IsARight())
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsALeft<TLeft, TRight>(this Assert           assert,
                                               string                description,
                                               TLeft                 expected,
                                               Either<TLeft, TRight> either)
   {
      if (either.Reduce(actual =>
                        {
                           assert.AreEqual(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                           expected,
                                           actual);

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsALeftAnd<TLeft, TRight>(this Assert             assert,
                                                  string                  description,
                                                  Func<Left<TLeft>, bool> property,
                                                  Either<TLeft, TRight>   either)
   {
      if (either.Reduce(actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                                  actual);
                           }

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARight<TLeft, TRight>(this Assert           assert,
                                                string                description,
                                                Either<TLeft, TRight> either)
   {
      if (either.IsALeft())
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARight<TLeft, TRight>(this Assert           assert,
                                                string                description,
                                                TRight                expected,
                                                Either<TLeft, TRight> either)
   {
      if (either.Reduce(Function.True,
                        actual =>
                        {
                           assert.AreEqual(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                           expected,
                                           actual);

                           return false;
                        }))
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARightAnd<TLeft, TRight>(this Assert               assert,
                                                   string                    description,
                                                   Func<Right<TRight>, bool> property,
                                                   Either<TLeft, TRight>     either)
   {
      if (either.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(description),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}