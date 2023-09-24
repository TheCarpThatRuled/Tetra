﻿namespace Tetra;

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
         || obj switch
            {
               RightEither some => Equals(Content,
                                          some.Content),
               TRight content => Equals(Content,
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
         => $"Right ({Content})";

      /* ------------------------------------------------------------ */
      // IEither<TLeft, TRight> Overridden Methods
      /* ------------------------------------------------------------ */

      public bool IsARight()
         => true;

      /* ------------------------------------------------------------ */

      public bool IsALeft()
         => false;

      /* ------------------------------------------------------------ */

      public IEither<TLeft, TRight> Do(Action<TLeft>  whenLeft,
                                       Action<TRight> whenRight)
      {
         whenRight(Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IEither<TLeft, TRight> Do<TExternalState>(TExternalState                 externalState,
                                                       Action<TExternalState, TLeft>  whenLeft,
                                                       Action<TExternalState, TRight> whenRight)
      {
         whenRight(externalState,
                   Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, TNewLeft>   whenLeft,
                                                                   Func<TRight, TNewRight> whenRight)
         => new Either<TNewLeft,TNewRight>.RightEither(whenRight(Content));

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TExternalState, TNewLeft, TNewRight>(TExternalState                          externalState,
                                                                                   Func<TExternalState, TLeft, TNewLeft>   whenLeft,
                                                                                   Func<TExternalState, TRight, TNewRight> whenRight)
         => new Either<TNewLeft, TNewRight>.RightEither(whenRight(externalState,
                                                                  Content));

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, IEither<TNewLeft, TNewRight>>  whenLeft,
                                                                   Func<TRight, IEither<TNewLeft, TNewRight>> whenRight)
         => whenRight(Content);

      /* ------------------------------------------------------------ */

      public IEither<TNewLeft, TNewRight> Map<TExternalState, TNewLeft, TNewRight>(TExternalState                                             externalState,
                                                                                   Func<TExternalState, TLeft, IEither<TNewLeft, TNewRight>>  whenLeft,
                                                                                   Func<TExternalState, TRight, IEither<TNewLeft, TNewRight>> whenRight)
         => whenRight(externalState,
                      Content);

      /* ------------------------------------------------------------ */
      public TNew Reduce<TNew>(Func<TLeft, TNew>  whenLeft,
                               Func<TRight, TNew> whenRight)
         => whenRight(Content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TExternalState, TNew>(TExternalState                     externalState,
                                               Func<TExternalState, TLeft, TNew>  whenLeft,
                                               Func<TExternalState, TRight, TNew> whenRight)
         => whenRight(externalState,
                      Content);

      /* ------------------------------------------------------------ */

      public IOption<TLeft> ReduceLeftToOption()
         => new Option<TLeft>.NoneOption();

      /* ------------------------------------------------------------ */

      public IOption<TRight> ReduceRightToOption()
         => new Option<TRight>.SomeOption(Content);

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly TRight Content;

      /* ------------------------------------------------------------ */
   }
}