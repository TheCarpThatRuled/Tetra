using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<T>(this Assert assert,
                                      string      description,
                                      IResult<T>   result)
   {
      if (result.IsASuccess())
      {
         throw Failed.Assert(TheResultIsASuccess<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<T>(this Assert assert,
                                      string      description,
                                      Message     expected,
                                      IResult<T>   result)
   {
      if (result.Reduce(actual =>
                        {
                           assert.AreEqual(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(description),
                                           expected,
                                           actual.Content());

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheResultIsASuccess<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsAFailureAnd<T>(this Assert         assert,
                                         string              description,
                                         Func<Failure, bool> property,
                                         IResult<T>           result)
   {
      if (result.Reduce(actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(description),
                                                  actual);
                           }

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheResultIsASuccess<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccess<T>(this Assert assert,
                                      string      description,
                                      IResult<T>   result)
   {
      if (result.IsAFailure())
      {
         throw Failed.Assert(TheResultIsAFailure<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccess<T>(this Assert assert,
                                      string      description,
                                      T           expected,
                                      IResult<T>   result)
   {
      if (result.Reduce(Function.True,
                        actual =>
                        {
                           assert.AreEqual(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(description),
                                           expected,
                                           actual.Content());

                           return false;
                        }))
      {
         throw Failed.Assert(TheResultIsAFailure<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccessAnd<T>(this Assert             assert,
                                         string                  description,
                                         Func<ISuccess<T>, bool> property,
                                         IResult<T>              result)
   {
      if (result.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(description),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheResultIsAFailure<T>(description));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}