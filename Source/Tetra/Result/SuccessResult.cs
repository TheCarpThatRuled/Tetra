namespace Tetra;

partial class Result<T>
{
   private sealed class SuccessResult : Result<T>
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
      // Result<T> Methods
      /* ------------------------------------------------------------ */

      public override Result<TNew> Cast<TNew>(Message whenCastFails)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Result<TNew> Cast<TNew>(Func<Message> whenCastFails)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override bool IsAFailure()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override bool IsASuccess()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Result<TNew> Map<TNew>(Func<Success<T>, TNew> whenSuccess)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override T Reduce(T whenFailure)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override T Reduce(Func<Failure, T> whenFailure)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<Failure, TNew> whenFailure,
                                        Func<Success<T>, TNew> whenSuccess)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */
      // IEquatable<Result<T>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Result<T>? other)
         => false;

      /* ------------------------------------------------------------ */
      // IEquatable<T> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(T? other)
         => false;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
   }
}