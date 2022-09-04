namespace Tetra;

/// <summary>
/// The <c>ISuccess</c> passkey - used to indicate that we are on the success branch of a <c>IResult</c>
/// </summary>
public sealed class Success<T> : ISuccess<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Makes a function callable through the success branch of a <c>IResult</c>.
   /// </summary>
   /// <typeparam name="TNew">The type the <c>ISuccess</c> shall be transformed into.</typeparam>
   /// <param name="func">The source function</param>
   /// <returns>
   /// A function that will invoke <c>func</c> when invoked with a <c>ISuccess</c>.
   /// </returns>
   public static Func<Success<T>, TNew> Wrap<TNew>(Func<TNew> func)
      => _ => func();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Makes a function callable through the success branch of a <c>IResult</c>.
   /// </summary>
   /// <typeparam name="TNew">The type the contents of the <c>ISuccess</c> shall be transformed into.</typeparam>
   /// <param name="func">The source function</param>
   /// <returns>
   /// A function that will invoke <c>func</c> when invoked with a <c>ISuccess</c>.
   /// </returns>
   public static Func<Success<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
      => success => func(success._content);

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */
   /// <summary>
   /// Returns the contents of an <c>ISuccess</c>.
   /// </summary>
   /// <param name="success">The success that shall have it's contents accessed.</param>
   /// <returns>The contents of the success.</returns>
   public static T Content(ISuccess<T> success)
      => success
        .Content();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// The content of this <c>ISuccess</c>.
   /// </summary>
   /// <returns>The content of this <c>ISuccess</c>.</returns>
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