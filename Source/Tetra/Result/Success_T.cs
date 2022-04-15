namespace Tetra;

public sealed class Success<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Success<T> Create(T content)
      => new(content);

   /* ------------------------------------------------------------ */

   public static Func<Success<T>, TNew> Wrap<TNew>(Func<TNew> func)
      => _ => func();

   /* ------------------------------------------------------------ */

   public static Func<Success<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
      => success => func(success._content);

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Success<T>(T content)
      => new(content);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

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