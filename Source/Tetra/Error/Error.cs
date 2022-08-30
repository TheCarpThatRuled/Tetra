namespace Tetra;

/// <summary>
/// An implementation of the "option" (Aka "maybe") monad specialised to represent the
/// result of a fallible sinking operation.
/// An <c>Error</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Some, representing that an error has occurred and containing a message related to the error;</description>
/// </item>
/// <item>
/// <description>None, representing the no error has occurred;</description>
/// </item>
/// </list>
/// </summary>
public static partial class Error
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a none.
   /// </summary>
   /// <returns>A none <c>Error</c>.</returns>
   public static IError None()
      => new NoneError();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a some.
   /// </summary>
   /// <param name="content">The message the <c>Error</c> shall contain.</param>
   /// <returns>A some <c>Error</c> that contains <c>content</c>.</returns>
   public static IError Some(Message content)
      => new SomeError(content);

   /* ------------------------------------------------------------ */
}