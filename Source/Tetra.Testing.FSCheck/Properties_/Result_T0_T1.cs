using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsAFailure<TSuccess, TFailure>(string                      description,
                                                         IResult<TSuccess, TFailure> actual)
      => IsAFailureAnd(description,
                       (failureMessage,
                        failure) => True(),
                       actual);

   /* ------------------------------------------------------------ */

   public static Property IsAFailure<TSuccess, TFailure>(string                      description,
                                                         TFailure                    expected,
                                                         IResult<TSuccess, TFailure> actual)
      => IsAFailureAnd(description,
                       (failureMessage,
                        failure) => AreEqual(failureMessage,
                                             expected,
                                             failure),
                       actual);

   /* ------------------------------------------------------------ */

   public static Property IsAFailureAnd<TSuccess, TFailure>(string                           description,
                                                            Func<string, TFailure, Property> property,
                                                            IResult<TSuccess, TFailure>      actual)
      => actual
        .IsAFailure(description,
                    (failureMessage,
                     failure) => property($"{failureMessage}",
                                          failure.Content),
                    (successMessage,
                     success) => False(successMessage),
                    False);

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<TSuccess, TFailure>(string                      description,
                                                         IResult<TSuccess, TFailure> actual)
      => actual
        .IsASuccess(description,
                    (successMessage,
                     success) => True(),
                    (failureMessage,
                     failure) => False(failureMessage),
                    False);

   /* ------------------------------------------------------------ */

   public static Property IsASuccess<TSuccess, TFailure>(string                      description,
                                                         TSuccess                    expected,
                                                         IResult<TSuccess, TFailure> actual)
      => IsASuccessAnd(description,
                       (successMessage,
                        success) => AreEqual(successMessage,
                                             expected,
                                             success),
                       actual);

   /* ------------------------------------------------------------ */

   public static Property IsASuccessAnd<TSuccess, TFailure>(string                           description,
                                                            Func<string, TSuccess, Property> property,
                                                            IResult<TSuccess, TFailure>      actual)
      => actual
        .IsASuccess(description,
                    (successMessage,
                     success) => property($"{successMessage}",
                                          success.Content),
                    (failureMessage,
                     failure) => False(failureMessage),
                    False);

   /* ------------------------------------------------------------ */
}