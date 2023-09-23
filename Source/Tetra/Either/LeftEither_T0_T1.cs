namespace Tetra;

partial class Either<TLeft, TRight>
{
   internal sealed class LeftEither : IEither<TLeft, TRight>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public LeftEither(TLeft content)
         => Content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj is LeftEither left
         && Equals(Content,
                   left.Content);

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => Content
          ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Left ({Content})";

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

      public IEither<TLeft, TRight> Do<TExternalState>(TExternalState                 externalState,
                                                       Action<TExternalState, TLeft>  whenLeft,
                                                       Action<TExternalState, TRight> whenRight)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, TNewLeft>   whenLeft,
                                                                   Func<TRight, TNewRight> whenRight)
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TExternalState, TNewLeft, TNewRight>(TExternalState                          externalState,
                                                                                   Func<TExternalState, TLeft, TNewLeft>   whenLeft,
                                                                                   Func<TExternalState, TRight, TNewRight> whenRight)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, IEither<TNewLeft, TNewRight>>  whenLeft,
                                                                   Func<TRight, IEither<TNewLeft, TNewRight>> whenRight)
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TExternalState, TNewLeft, TNewRight>(TExternalState                                             externalState,
                                                                                   Func<TExternalState, TLeft, IEither<TNewLeft, TNewRight>>  whenLeft,
                                                                                   Func<TExternalState, TRight, IEither<TNewLeft, TNewRight>> whenRight)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public TNew Reduce<TExternalState, TNew>(TExternalState                     externalState,
                                               Func<TExternalState, TLeft, TNew>  whenLeft,
                                               Func<TExternalState, TRight, TNew> whenRight)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public IOption<TLeft> ReduceLeftToOption()
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public IOption<TRight> ReduceRightToOption()
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TLeft, TNew>  whenLeft,
                               Func<TRight, TNew> whenRight)
         => throw Exceptions.NotImplemented();

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly TLeft Content;

      /* ------------------------------------------------------------ */
   }
}