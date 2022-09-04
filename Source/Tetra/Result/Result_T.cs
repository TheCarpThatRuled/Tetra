namespace Tetra;

/// <summary>
/// An implementation of the "either" monad specialised to represent the result of a fallible function.
/// A <c>IResult</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Success, representing the no error has occurred and containing the return value of the function;</description>
/// </item>
/// <item>
/// <description>Failure, representing that an error has occurred and containing a message related to the error;</description>
/// </item>
/// </list>
/// </summary>
/// <typeparam name="T">The type of the contained object</typeparam>
public static partial class Result<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a failure.
   /// </summary>
   /// <param name="content">The value the <c>IResult</c> shall contain.</param>
   /// <returns>A failure <c>IResult</c> that contains <c>content</c>.</returns>
   public static IResult<T> Failure(Message content)
      => new FailureResult(new(content));

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a success.
   /// </summary>
   /// <param name="content">The value the <c>IResult</c> shall contain.</param>
   /// <returns>A success <c>IResult</c> that contains <c>content</c>.</returns>
   public static IResult<T> Success(T content)
      => new SuccessResult(new(content));

   /* ------------------------------------------------------------ */
}