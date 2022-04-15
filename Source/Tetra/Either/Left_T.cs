namespace Tetra;

public sealed class Left<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Left<T> Create(T content)
      => new(content);

   /* ------------------------------------------------------------ */

   public static Func<Left<T>, TNew> Wrap<TNew>(Func<TNew> func)
      => _ => func();

   /* ------------------------------------------------------------ */

   public static Func<Left<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
      => Left => func(Left._content);

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Left<T>(T content)
      => new(content);

   /* ------------------------------------------------------------ */

   public static implicit operator Left<T>(Right<T> Left)
      => new(Left.Content());

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public T Content()
      => _content;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Left(T content)
      => _content = content;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T _content;

   /* ------------------------------------------------------------ */
}