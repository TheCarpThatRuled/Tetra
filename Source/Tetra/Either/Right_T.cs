namespace Tetra;

public sealed class Right<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Right<T> Create(T content)
      => new(content);

   /* ------------------------------------------------------------ */

   public static Func<Right<T>, TNew> Wrap<TNew>(Func<TNew> func)
      => _ => func();

   /* ------------------------------------------------------------ */

   public static Func<Right<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
      => right => func(right._content);

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Right<T>(T content)
      => new(content);

   /* ------------------------------------------------------------ */

   public static implicit operator Right<T>(Left<T> left)
      => new(left.Content());

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public T Content()
      => _content;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Right(T content)
      => _content = content;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T _content;

   /* ------------------------------------------------------------ */
}