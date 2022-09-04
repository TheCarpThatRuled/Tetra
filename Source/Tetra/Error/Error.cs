namespace Tetra;

/// <summary>
/// A container for functions related to <c>IError&lt;T&gt;</c>
/// </summary>
public static partial class Error
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a none.
   /// </summary>
   /// <returns>A none <c>IError</c>.</returns>
   public static IError None()
      => new NoneError();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a some.
   /// </summary>
   /// <param name="content">The message the <c>IError</c> shall contain.</param>
   /// <returns>A some <c>IError</c> that contains <c>content</c>.</returns>
   public static IError Some(Message content)
      => new SomeError(content);

   /* ------------------------------------------------------------ */
}