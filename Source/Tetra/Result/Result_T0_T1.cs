namespace Tetra;

/// <summary>
/// An implementation of the "either" monad specialised to represent the result of a fallible function.
/// A <c>IResult</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Success, representing the no error has occurred and containing the return value of the function;</description>
/// </item>
/// <item>
/// <description>Failure, representing that an error has occurred and containing a error type related to the error;</description>
/// </item>
/// </list>
/// </summary>
/// <typeparam name="TSuccess">The type of the contained object</typeparam>
/// <typeparam name="TFailure">The type of the failure</typeparam>
public static partial class Result<TSuccess, TFailure>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a failure.
   /// </summary>
   /// <param name="content">The value the <c>IResult</c> shall contain.</param>
   /// <returns>A failure <c>IResult</c> that contains <c>content</c>.</returns>
   public static IResult<TSuccess, TFailure> Failure(TFailure content)
      => new FailureResult(content);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a success.
   /// </summary>
   /// <param name="content">The value the <c>IResult</c> shall contain.</param>
   /// <returns>A success <c>IResult</c> that contains <c>content</c>.</returns>
   public static IResult<TSuccess, TFailure> Success(TSuccess content)
      => new SuccessResult(content);

   /* ------------------------------------------------------------ */
}