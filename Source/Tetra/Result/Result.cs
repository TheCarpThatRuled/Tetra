namespace Tetra;

/// <summary>
/// A container for functions related to <c>IError&lt;T&gt;</c>
/// </summary>
public static class Result
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a failure.
   /// </summary>
   /// <param name="content">The message the <c>IError</c> shall contain.</param>
   /// <returns>A failure <c>IError</c> that contains <c>content</c>.</returns>
   public static IResult<T> Failure<T>(T content)
      => new Result<T>.FailureResult(content);

   /* ------------------------------------------------------------ */
}