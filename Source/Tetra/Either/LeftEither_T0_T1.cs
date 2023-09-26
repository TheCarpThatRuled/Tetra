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
         || obj switch
            {
               LeftEither some => Equals(Content,
                                         some.Content),
               TLeft content => Equals(Content,
                                       content),
               _ => false,
            };

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
         => false;

      /* ------------------------------------------------------------ */

      public bool IsALeft()
         => true;

      /* ------------------------------------------------------------ */

      public IEither<TLeft, TRight> Do(Action<TLeft>  whenLeft,
                                       Action<TRight> whenRight)
      {
         whenLeft(Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IEither<TLeft, TRight> Do<TExternalState>(TExternalState                 externalState,
                                                       Action<TExternalState, TLeft>  whenLeft,
                                                       Action<TExternalState, TRight> whenRight)
      {
         whenLeft(externalState,
                  Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, TNewLeft>   whenLeft,
                                                                   Func<TRight, TNewRight> whenRight)
         => new Either<TNewLeft, TNewRight>.LeftEither(whenLeft(Content));

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TExternalState, TNewLeft, TNewRight>(TExternalState                          externalState,
                                                                                   Func<TExternalState, TLeft, TNewLeft>   whenLeft,
                                                                                   Func<TExternalState, TRight, TNewRight> whenRight)
         => new Either<TNewLeft, TNewRight>.LeftEither(whenLeft(externalState,
                                                                Content));

      /* ------------------------------------------------------------ */

      public TNew Unify<TNew>(Func<TLeft, TNew>  whenLeft,
                              Func<TRight, TNew> whenRight)
         => whenLeft(Content);

      /* ------------------------------------------------------------ */

      public TNew Unify<TExternalState, TNew>(TExternalState                     externalState,
                                              Func<TExternalState, TLeft, TNew>  whenLeft,
                                              Func<TExternalState, TRight, TNew> whenRight)
         => whenLeft(externalState,
                     Content);

      /* ------------------------------------------------------------ */

      public IOption<TLeft> ReduceLeftToOption()
         => new Option<TLeft>.SomeOption(Content);

      /* ------------------------------------------------------------ */

      public IOption<TRight> ReduceRightToOption()
         => new Option<TRight>.NoneOption();

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly TLeft Content;

      /* ------------------------------------------------------------ */
   }
}