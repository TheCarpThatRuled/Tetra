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
   public static Result<T> Success<T>(T content)
      => content;

   /* ------------------------------------------------------------ */
}