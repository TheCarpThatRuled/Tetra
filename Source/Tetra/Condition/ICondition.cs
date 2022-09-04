namespace Tetra;

public interface ICondition : IEquatable<ICondition>,
                              IEquatable<bool>
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public bool Reduce();

   /* ------------------------------------------------------------ */

   public T Reduce<T>(T whenFalse,
                      T whenTrue);

   /* ------------------------------------------------------------ */

   public T Reduce<T>(T       whenFalse,
                      Func<T> whenTrue);

   /* ------------------------------------------------------------ */

   public T Reduce<T>(Func<T> whenFalse,
                      T       whenTrue);

   /* ------------------------------------------------------------ */

   public T Reduce<T>(Func<T> whenFalse,
                      Func<T> whenTrue);

   /* ------------------------------------------------------------ */
}