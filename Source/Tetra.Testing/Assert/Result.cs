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
                                      Result<T>   result)
   {
      if (result.IsASuccess())
      {
         throw Failed.Assert(TheResultIsASuccess<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<T>(this Assert assert,
                                      Result<T>   result,
                                      string      name)
   {
      if (result.IsASuccess())
      {
         throw Failed.Assert(TheResultIsASuccess<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<T>(this Assert assert,
                                      Message     expected,
                                      Result<T>   result)
   {
      if (result.Reduce(actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheResultIsAFailureButDoesNotContainTheExpectedContent<T>());

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheResultIsASuccess<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsAFailure<T>(this Assert assert,
                                      Message     expected,
                                      Result<T>   result,
                                      string      name)
   {
      if (result.Reduce(actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(name));

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheResultIsASuccess<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsAFailureAnd<T>(this Assert         assert,
                                         Func<Failure, bool> property,
                                         Result<T>           result)
   {
      if (result.Reduce(actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(),
                                                  actual);
                           }

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheResultIsASuccess<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsAFailureAnd<T>(this Assert         assert,
                                         Func<Failure, bool> property,
                                         Result<T>           result,
                                         string              name)
   {
      if (result.Reduce(actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(name),
                                                  actual);
                           }

                           return false;
                        },
                        Function.True))
      {
         throw Failed.Assert(TheResultIsASuccess<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccess<T>(this Assert assert,
                                      Result<T>   result)
   {
      if (result.IsAFailure())
      {
         throw Failed.Assert(TheResultIsAFailure<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccess<T>(this Assert assert,
                                      Result<T>   result,
                                      string      name)
   {
      if (result.IsAFailure())
      {
         throw Failed.Assert(TheResultIsAFailure<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccess<T>(this Assert assert,
                                      T           expected,
                                      Result<T>   result)
   {
      if (result.Reduce(Function.True,
                        actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheResultIsASuccessButDoesNotContainTheExpectedContent<T>());

                           return false;
                        }))
      {
         throw Failed.Assert(TheResultIsAFailure<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccess<T>(this Assert assert,
                                      T           expected,
                                      Result<T>   result,
                                      string      name)
   {
      if (result.Reduce(Function.True,
                        actual =>
                        {
                           assert.AreEqual(expected,
                                           actual,
                                           TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(name));

                           return false;
                        }))
      {
         throw Failed.Assert(TheResultIsAFailure<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccessAnd<T>(this Assert            assert,
                                         Func<Success<T>, bool> property,
                                         Result<T>              result)
   {
      if (result.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheResultIsAFailure<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsASuccessAnd<T>(this Assert            assert,
                                         Func<Success<T>, bool> property,
                                         Result<T>              result,
                                         string                 name)
   {
      if (result.Reduce(Function.True,
                        actual =>
                        {
                           if (!property(actual))
                           {
                              throw Failed.Assert(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(name),
                                                  actual);
                           }

                           return false;
                        }))
      {
         throw Failed.Assert(TheResultIsAFailure<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}