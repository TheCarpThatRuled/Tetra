namespace Tetra;

public abstract partial class Either<TLeft, TRight> : IEquatable<Either<TLeft, TRight>>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Either<TLeft, TRight> Left(TLeft content)
      => new LeftEither();

   /* ------------------------------------------------------------ */

   public static Either<TLeft, TRight> Right(TRight content)
      => new RightEither();

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Either<TLeft, TRight>(Left<TLeft> left)
      => new LeftEither();

   /* ------------------------------------------------------------ */

   public static implicit operator Either<TLeft, TRight>(Right<TRight> right)
      => new RightEither();

   /* ------------------------------------------------------------ */
   // IEquatable<Either<TLeft, TRight>> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(Either<TLeft, TRight>? other);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public abstract bool IsALeft();

   /* ------------------------------------------------------------ */

   public abstract bool IsARight();

   /* ------------------------------------------------------------ */

   public abstract Either<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<Left<TLeft>, TNewLeft> whenLeft,
                                                                        Func<Right<TRight>, TNewRight> whenRight);

   /* ------------------------------------------------------------ */

   public abstract Either<TNewLeft, TRight> MapLeft<TNewLeft>(Func<Left<TLeft>, TNewLeft> whenLeft);

   /* ------------------------------------------------------------ */

   public abstract Either<TLeft, TNewRight> MapRight<TNewRight>(Func<Right<TRight>, TNewRight> whenRight);

   /* ------------------------------------------------------------ */

   public abstract T Reduce<T>(Func<Left<TLeft>,T> whenLeft,
                               Func<Right<TRight>, T> whenRight);

   /* ------------------------------------------------------------ */

   public abstract TLeft ReduceToLeft(TLeft whenRight);

   /* ------------------------------------------------------------ */

   public abstract TLeft ReduceToLeft(Func<Left<TLeft>, TLeft> whenLeft,
                                      TLeft whenRight);

   /* ------------------------------------------------------------ */

   public abstract TRight ReduceToRight(TRight whenLeft);

   /* ------------------------------------------------------------ */

   public abstract TRight ReduceToRight(TRight whenLeft,
                                        Func<Right<TRight>, TRight> whenRight);

   /* ------------------------------------------------------------ */
}