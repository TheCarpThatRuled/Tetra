namespace Tetra;

/// <summary>
/// A container for functions related to <c>Result&lt;T&gt;</c>
/// </summary>
public static class Result
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a success.
   /// </summary>
   /// <typeparam name="T">The type of the contained object</typeparam>
   /// <param name="content">The value the <c>Result</c> shall contain.</param>
   /// <returns>A success <c>Result</c> that contains <c>content</c>.</returns>
   public static IResult<T> Success<T>(T content)
      => Result<T>.Success(content);

   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Result</c> via a mapping function
   /// </summary>
   /// <param name="whenFailure">A mapping function that shall be applied to the content of the <c>Result</c>, if it is a failure.</param>
   /// <returns>
   /// The content of this <c>Result</c> if it is a success;
   /// otherwise the content of this <c>Result</c> mapped through <c>whenFailure</c>.
   /// </returns>
   public static T Reduce<T>(this IResult<T>       result,
                             Func<Failure, T> whenFailure)
      => result.Reduce(whenFailure,
                       content => content.Content());

   /* ------------------------------------------------------------ */
}