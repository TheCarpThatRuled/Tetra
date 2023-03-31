namespace Tetra;

partial class Either<TLeft, TRight>
{
   internal sealed class RightEither : IEither<TLeft, TRight>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public RightEither(TRight content)
         => Content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj is RightEither right
         && Equals(Content,
                   right.Content);

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => Content
             ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Right ({Content})";

      /* ------------------------------------------------------------ */
      // IEither<TLeft, TRight> Overridden Methods
      /* ------------------------------------------------------------ */

      public bool IsARight()
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public bool IsALeft()
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public IEither<TLeft, TRight> Do(Action<TLeft>  whenLeft,
                                       Action<TRight> whenRight)
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, TNewLeft>   whenLeft,
                                                                   Func<TRight, TNewRight> whenRight)
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, IEither<TNewLeft, TNewRight>>  whenLeft,
                                                                   Func<TRight, IEither<TNewLeft, TNewRight>> whenRight)
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public IOption<TLeft> MapLeftToOption()
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public IOption<TRight> MapRightToOption()
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */
      public TNew Reduce<TNew>(Func<TLeft, TNew>  whenLeft,
                               Func<TRight, TNew> whenRight)
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly TRight Content;

      /* ------------------------------------------------------------ */
   }
}