namespace Tetra;

/// <summary>
/// A container for functions related to <c>Option&lt;T&gt;</c>
/// </summary>
public static class Option
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a none.
   /// </summary>
   /// <returns>
   /// The instance of the <c>None</c> passkey.
   /// It will be implicitly converted into a none <c>Option</c> of the appropriate type.
   /// </returns>
   public static None None()
      => Tetra
        .None
        .Instance;

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