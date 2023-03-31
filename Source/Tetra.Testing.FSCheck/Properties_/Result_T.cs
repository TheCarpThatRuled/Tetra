using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(string    description,
                                        IResult<T> actual)
      => IsAFailureAnd(description,
                       (failureMessage,
                        failure) => True(),
                       actual);

   /* ------------------------------------------------------------ */

   public static Property IsAFailure<T>(string    description,
                                        T         expected,
                                        IResult<T> actual)
      => IsAFailureAnd(description,
                       (failureMessage,
                        failure) => AreEqual(failureMessage,
                                             expected,
                                             failure),
                       actual);

   /* ------------------------------------------------------------ */

   public static Property IsAFailureAnd<T>(string                    description,
                                           Func<string, T, Property> property,
                                           IResult<T>                 actual)
      => actual
        .IsAFailure(description,
                    (failureMessage,
                     failure) => property($"{failureMessage}",
                                          failure.Content),
                    (successMessage,
                     success) => False(successMessage),
                    False);

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<T>(string    description,
                                        IResult<T> actual)
      => actual
        .IsASuccess(description,
                    success => True(),
                    (failureMessage,
                     failure) => False(failureMessage),
                    False);

   /* ------------------------------------------------------------ */
}