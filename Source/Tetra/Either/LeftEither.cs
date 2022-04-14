namespace Tetra;

public abstract partial class Either<TLeft, TRight>
{
   private sealed class LeftEither : Either<TLeft, TRight>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => base.Equals(obj);

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => base.GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => base.ToString();

      /* ------------------------------------------------------------ */
      //  Either<TLeft, TRight> Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool IsALeft()
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override bool IsARight()
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override Either<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<Left<TLeft>, TNewLeft> whenLeft,
                                                                           Func<Right<TRight>, TNewRight> whenRight)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override Either<TNewLeft, TRight> MapLeft<TNewLeft>(Func<Left<TLeft>, TNewLeft> whenLeft)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<Right<TRight>, TNewRight> whenRight)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override T Reduce<T>(Func<Left<TLeft>, T> whenLeft,
                                  Func<Right<TRight>, T> whenRight)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override TLeft ReduceToLeft(TLeft whenRight)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override TLeft ReduceToLeft(Func<Left<TLeft>, TLeft> whenLeft,
                                         TLeft whenRight)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override TRight ReduceToRight(TRight whenLeft)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public override TRight ReduceToRight(TRight whenLeft,
                                           Func<Right<TRight>, TRight> whenRight)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */
      // IEquatable<Either<TLeft, TRight>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Either<TLeft, TRight>? other)
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
   }
}