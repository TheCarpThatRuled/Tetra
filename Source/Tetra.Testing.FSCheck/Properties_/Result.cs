using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(string     description,
                                        IResult<T> result)
      => AsProperty(result.IsAFailure)
        .Label(TheResultIsASuccess<T>(description));

   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(string     description,
                                        Message    expected,
                                        IResult<T> result)
      => result
        .Reduce(actual => AreEqual(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(description),
                                   expected,
                                   actual.Content()),
                _ => False(TheResultIsASuccess<T>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsAIsAFailureAnd<T>(string                          description,
                                              Func<string, Failure, Property> property,
                                              IResult<T>                      result)
      => result
        .Reduce(actual => property(TheResultIsAFailureButDoesNotContainTheExpectedContent<T>(description),
                                   actual),
                _ => False(TheResultIsASuccess<T>(description)));

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(string     description,
                                        IResult<T> result)
      => AsProperty(result.IsASuccess)
        .Label(TheResultIsAFailure<T>(description));

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(string     description,
                                        T          expected,
                                        IResult<T> result)
      => result
        .Reduce(failure => False(TheResultIsAFailure<T>(description,
                                                        failure.Content())),
                actual => AreEqual(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(description),
                                   expected,
                                   actual.Content()));

   /* ------------------------------------------------------------ */

   public static Property IsASuccessAnd<T>(string                                      description,
                                           Func<string, ISuccess<T>, Property> property,
                                           IResult<T>                                  result)
      => result
        .Reduce(failure => False(TheResultIsAFailure<T>(description,
                                                        failure.Content())),
                actual => property(TheResultIsASuccessButDoesNotContainTheExpectedContent<T>(description),
                                   actual));

   /* ------------------------------------------------------------ */
}