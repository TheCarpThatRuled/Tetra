namespace Tetra;

/// <summary>
///    A container for functions related to <c>IEither&lt;TLeft, TRight&gt;</c>
/// </summary>
/// <typeparam name="TLeft">The type contained by a left</typeparam>
/// <typeparam name="TRight">The type contained by a right</typeparam>
public static partial class Either<TLeft, TRight>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Creates a left.
   /// </summary>
   /// <param name="content">The value the left shall contain.</param>
   /// <returns>An instance of a left containing <c>content</c>.</returns>
   public static IEither<TLeft, TRight> Left
   (
      TLeft content
   )
      => new LeftEither(content);

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Creates a right.
   /// </summary>
   /// <param name="content">The value the right shall contain.</param>
   /// <returns>An instance of the right containing <c>content</c>.</returns>
   public static IEither<TLeft, TRight> Right
   (
      TRight content
   )
      => new RightEither(content);

   /* ------------------------------------------------------------ */
}