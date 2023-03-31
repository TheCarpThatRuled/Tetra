namespace Tetra;

/// <summary>
/// A container for functions related to <c>IResult&lt;T&gt;</c>
/// </summary>
public static partial class Result<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a success.
   /// </summary>
   /// <returns>A success <c>IError</c>.</returns>
   public static IResult<T> Success()
      => new SuccessResult();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a failure.
   /// </summary>
   /// <param name="content">The content the <c>IError</c> shall contain.</param>
   /// <returns>A failure <c>IError</c> that contains <c>content</c>.</returns>
   public static IResult<T> Failure(T content)
      => new FailureResult(content);

   /* ------------------------------------------------------------ */
}