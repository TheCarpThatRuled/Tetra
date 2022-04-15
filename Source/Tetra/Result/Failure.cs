namespace Tetra;

public sealed class Failure
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Failure Create(Message content)
      => new(content);

   /* ------------------------------------------------------------ */

   public static Func<Failure, T> Wrap<T>(Func<T> func)
      => _ => func();

   /* ------------------------------------------------------------ */

   public static Func<Failure, T> Wrap<T>(Func<Message, T> func)
      => failure => func(failure._content);

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Failure(Message content)
      => new(content);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

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