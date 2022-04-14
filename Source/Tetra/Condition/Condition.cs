namespace Tetra;

public abstract partial class Condition : IEquatable<Condition>,
                                          IEquatable<bool>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Condition False()
      => _false;

   /* ------------------------------------------------------------ */

   public static Condition True()
      => _true;

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Condition(bool condition)
      => condition
            ? new TrueCondition()
            : new FalseCondition();

   /* ------------------------------------------------------------ */
   // IEquatable<Condition> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(Condition? other);

   /* ------------------------------------------------------------ */
   // IEquatable<bool>Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(bool other);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public abstract bool Reduce();

   /* ------------------------------------------------------------ */

   public abstract T Reduce<T>(T whenFalse,
                               T whenTrue);

   /* ------------------------------------------------------------ */

   public abstract T Reduce<T>(T whenFalse,
                               Func<T> whenTrue);

   /* ------------------------------------------------------------ */

   public abstract T Reduce<T>(Func<T> whenFalse,
                               T whenTrue);

   /* ------------------------------------------------------------ */

   public abstract T Reduce<T>(Func<T> whenFalse,
                               Func<T> whenTrue);

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   private static readonly Condition _false = new FalseCondition();
   // ReSharper disable once InconsistentNaming
   private static readonly Condition _true = new TrueCondition();

   /* ------------------------------------------------------------ */
}