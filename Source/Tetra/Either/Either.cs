namespace Tetra;

/// <summary>
/// A container for functions related to <c>Either&lt;TLeft, TRight&gt;</c>
/// </summary>
public static class Either
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a left.
   /// </summary>
   /// <typeparam name="T">The type of the contained object</typeparam>
   /// <param name="content">The value the <c>Left</c> shall contain.</param>
   /// <returns>An instance of the <c>Left</c> passkey containing <c>content</c>.</returns>
   public static Left<T> Left<T>(T content)
      => new(content);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a right.
   /// </summary>
   /// <typeparam name="T">The type of the contained object</typeparam>
   /// <param name="content">The value the <c>Right</c> shall contain.</param>
   /// <returns>An instance of the <c>Right</c> passkey containing <c>content</c>.</returns>
   public static Right<T> Right<T>(T content)
      => new(content);

   /* ------------------------------------------------------------ */
}