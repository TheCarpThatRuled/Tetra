namespace Tetra;

/// <summary>
/// The <c>Failure</c> passkey - used to indicate that we are on the failure branch of a <c>Result</c>
/// </summary>
public sealed class Failure
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Makes a function callable through the failure branch of a <c>Result</c>.
   /// </summary>
   /// <typeparam name="T">The type the <c>Failure</c> shall be transformed into.</typeparam>
   /// <param name="func">The source function</param>
   /// <returns>
   /// A function that will invoke <c>func</c> when invoked with a <c>Failure</c>.
   /// </returns>
   public static Func<Failure, T> Wrap<T>(Func<T> func)
      => _ => func();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Makes a function callable through the failure branch of a <c>Result</c>.
   /// </summary>
   /// <typeparam name="T">The type the contents of the <c>Failure</c> shall be transformed into.</typeparam>
   /// <param name="func">The source function</param>
   /// <returns>
   /// A function that will invoke <c>func</c> when invoked with a <c>Failure</c>.
   /// </returns>
   public static Func<Failure, T> Wrap<T>(Func<Message, T> func)
      => failure => func(failure._content);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// The content of this <c>Failure</c>.
   /// </summary>
   /// <returns>The content of this <c>Failure</c>.</returns>
   public Message Content()
      => _content;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Failure(Message content)
      => _content = content;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Message _content;

   /* ------------------------------------------------------------ */
}