namespace Tetra;

/// <summary>
/// The <c>Success</c> passkey - used to indicate that we are on the success branch of a <c>Result</c>
/// </summary>
public sealed class Success<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Makes a function callable through the success branch of a <c>Result</c>.
   /// </summary>
   /// <typeparam name="TNew">The type the <c>Success</c> shall be transformed into.</typeparam>
   /// <param name="func">The source function</param>
   /// <returns>
   /// A function that will invoke <c>func</c> when invoked with a <c>Success</c>.
   /// </returns>
   public static Func<Success<T>, TNew> Wrap<TNew>(Func<TNew> func)
      => _ => func();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Makes a function callable through the success branch of a <c>Result</c>.
   /// </summary>
   /// <typeparam name="TNew">The type the contents of the <c>Success</c> shall be transformed into.</typeparam>
   /// <param name="func">The source function</param>
   /// <returns>
   /// A function that will invoke <c>func</c> when invoked with a <c>Success</c>.
   /// </returns>
   public static Func<Success<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
      => success => func(success._content);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// The content of this <c>Success</c>.
   /// </summary>
   /// <returns>The content of this <c>Success</c>.</returns>
   public T Content()
      => _content;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Success(T content)
      => _content = content;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T _content;

   /* ------------------------------------------------------------ */
}