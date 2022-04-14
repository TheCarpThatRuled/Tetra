namespace Tetra;

public abstract partial class Result<T> : IEquatable<Result<T>>,
                                          IEquatable<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Result<T> Failure(Message content)
      => new FailureResult();

   /* ------------------------------------------------------------ */

   public static Result<T> Success(T content)
      => new SuccessResult();

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Result<T> (Message content)
      => new FailureResult();

   /* ------------------------------------------------------------ */

   public static implicit operator Result<T> (T content)
      => new SuccessResult();

   /* ------------------------------------------------------------ */
   // IEquatable<Result<T>> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(Result<T>? other);

   /* ------------------------------------------------------------ */
   // IEquatable<T> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(T? other);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public abstract Result<TNew> Cast<TNew>(Message whenCastFails);

   /* ------------------------------------------------------------ */

   public abstract Result<TNew> Cast<TNew>(Func<Message> whenCastFails);

   /* ------------------------------------------------------------ */

   public abstract bool IsAFailure();

   /* ------------------------------------------------------------ */

   public abstract bool IsASuccess();

   /* ------------------------------------------------------------ */

   public abstract Result<TNew> Map<TNew>(Func<Success<T>, TNew> whenSuccess
      );

   /* ------------------------------------------------------------ */

   public abstract T Reduce(T whenFailure);

   /* ------------------------------------------------------------ */

   public abstract T Reduce(Func<Failure, T> whenFailure);

   /* ------------------------------------------------------------ */

   public abstract TNew Reduce<TNew>(Func<Failure, TNew> whenFailure,
                                     Func<Success<T>, TNew> whenSuccess);

   /* ------------------------------------------------------------ */
}