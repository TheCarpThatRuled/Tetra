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
                                               Either<TLeft, TRight> either)
   {
      if (either.IsARight())
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsALeft<TLeft, TRight>(this Assert           assert,
                                               Either<TLeft, TRight> either,
                                               string                name)
   {
      if (either.IsARight())
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsALeft<TLeft, TRight>(this Assert           assert,
                                               TLeft                 expected,
                                               Either<TLeft, TRight> either)
   {
      if (either.Reduce(actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>());

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsALeft<TLeft, TRight>(this Assert           assert,
                                               TLeft                 expected,
                                               Either<TLeft, TRight> either,
                                               string                name)
   {
      if (either.Reduce(actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(name));

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsALeftAnd<TLeft, TRight>(this Assert             assert,
                                                  Func<Left<TLeft>, bool> property,
                                                  Either<TLeft, TRight>   either)
   {
      if (either.Reduce(actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(),
                                                  actual);
                           }

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsALeftAnd<TLeft, TRight>(this Assert             assert,
                                                  Func<Left<TLeft>, bool> property,
                                                  Either<TLeft, TRight>   either,
                                                  string                  name)
   {
      if (either.Reduce(actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheEitherIsALeftButDoesNotContainTheExpectedContent<TLeft, TRight>(name),
                                                  actual);
                           }

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheEitherIsARight<TLeft, TRight>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARight<TLeft, TRight>(this Assert           assert,
                                                Either<TLeft, TRight> either)
   {
      if (either.IsALeft())
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARight<TLeft, TRight>(this Assert           assert,
                                                Either<TLeft, TRight> either,
                                                string                name)
   {
      if (either.IsALeft())
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARight<TLeft, TRight>(this Assert           assert,
                                                TRight                expected,
                                                Either<TLeft, TRight> either)
   {
      if (either.Reduce(Function.True,
                        actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>());

                           return false;
                        }))
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARight<TLeft, TRight>(this Assert           assert,
                                                TRight                expected,
                                                Either<TLeft, TRight> either,
                                                string                name)
   {
      if (either.Reduce(Function.True,
                        actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(name));

                           return false;
                        }))
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARightAnd<TLeft, TRight>(this Assert               assert,
                                                   Func<Right<TRight>, bool> property,
                                                   Either<TLeft, TRight>     either)
   {
      if (either.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsARightAnd<TLeft, TRight>(this Assert               assert,
                                                   Func<Right<TRight>, bool> property,
                                                   Either<TLeft, TRight>     either,
                                                   string                    name)
   {
      if (either.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheEitherIsARightButDoesNotContainTheExpectedContent<TLeft, TRight>(name),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheEitherIsALeft<TLeft, TRight>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}