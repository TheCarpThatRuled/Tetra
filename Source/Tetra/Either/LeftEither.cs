namespace Tetra;

public abstract partial class Either<TLeft, TRight>
{
   private sealed class LeftEither : Either<TLeft, TRight>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public LeftEither(Left<TLeft> left)
         => _left = left;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => base.Equals(obj);

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _left
           .Content()
          ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Left ({_left.Content()})";

      /* ------------------------------------------------------------ */
      //  Either<TLeft, TRight> Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool IsALeft()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override bool IsARight()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Either<TNewLeft, TRight> Map<TNewLeft>(Func<Left<TLeft>, TNewLeft> whenLeft)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Either<TLeft, TNewRight> Map<TNewRight>(Func<Right<TRight>, TNewRight> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Either<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<Left<TLeft>, TNewLeft> whenLeft,
                                                                           Func<Right<TRight>, TNewRight> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override TLeft Reduce(Func<Right<TRight>, TLeft> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override TRight Reduce(Func<Left<TLeft>, TRight> whenLeft)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override T Reduce<T>(Func<Left<TLeft>, T> whenLeft,
                                  Func<Right<TRight>, T> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */
      // IEquatable<Either<TLeft, TRight>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Either<TLeft, TRight>? other)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Left<TLeft> _left;

      /* ------------------------------------------------------------ */
   }
}