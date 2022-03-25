namespace Tetra;

/// <summary>
/// A container for functions related to <c>Option&gt;T&lt;</c>
/// </summary>
public static class Option
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a some.
   /// </summary>
   /// <typeparam name="T">The type of the contained object</typeparam>
   /// <param name="content">The value the <c>Option</c> shall contain.</param>
   /// <returns>A some <c>Option</c> that contains <c>content</c>.</returns>
   public static Option<T> Some<T>(T content)
      => content;

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
}