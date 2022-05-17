namespace Tetra;

public abstract partial class Either<TLeft, TRight>
{
   private sealed class RightEither : Either<TLeft, TRight>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public RightEither(Right<TRight> right)
         => _right = right;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj is RightEither right
         && Equals(_right.Content(),
                   right._right.Content());

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _right
           .Content()
          ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Right ({_right.Content()})";

      /* ------------------------------------------------------------ */
      //  Either<TLeft, TRight> Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool IsALeft()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override bool IsARight()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Either<TNewLeft, TRight> Map<TNewLeft>(Func<Left<TLeft>, TNewLeft> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Either<TLeft, TNewRight> Map<TNewRight>(Func<Right<TRight>, TNewRight> whenRight)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Either<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<Left<TLeft>, TNewLeft> _,
                                                                           Func<Right<TRight>, TNewRight> whenRight)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override TLeft Reduce(Func<Right<TRight>, TLeft> whenRight)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override TRight Reduce(Func<Left<TLeft>, TRight> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override T Reduce<T>(Func<Left<TLeft>, T> _,
                                  Func<Right<TRight>, T> whenRight)
         => whenRight(_right);

      /* ------------------------------------------------------------ */
      // IEquatable<Either<TLeft, TRight>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Either<TLeft, TRight>? other)
         => ReferenceEquals(this,
                            other)
         || other is RightEither right
         && Equals(_right.Content(),
                   right._right.Content());

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Right<TRight> _right;

      /* ------------------------------------------------------------ */
   }
}