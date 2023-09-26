namespace Tetra;

partial class Option<T>
{
   internal sealed class SomeOption : IOption<T>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public SomeOption(T content)
         => Content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SomeOption some => Equals(Content,
                                         some.Content),
               T content => Equals(Content,
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
         => $"Some ({Content})";

      /* ------------------------------------------------------------ */
      // IOption<T> Methods
      /* ------------------------------------------------------------ */

      public IOption<T> Do(Action<T> whenSome,
                           Action    whenNone)
      {
         whenSome(Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IOption<T> Do<TExternalState>(TExternalState            externalState,
                                           Action<TExternalState, T> whenSome,
                                           Action<TExternalState>    whenNone)
      {
         whenSome(externalState,
                  Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IEither<T, TRight> ExpandSomeToLeft<TRight>(Func<TRight> whenNone)
         => Either<T, TRight>.Left(Content);

      /* ------------------------------------------------------------ */

      public IEither<T, TRight> ExpandSomeToLeft<TExternalState, TRight>(TExternalState               externalState,
                                                                         Func<TExternalState, TRight> whenNone)
         => Either<T, TRight>.Left(Content);

      /* ------------------------------------------------------------ */

      public IEither<TLeft, T> ExpandSomeToRight<TLeft>(Func<TLeft> whenNone)
         => Either<TLeft, T>.Right(Content);

      /* ------------------------------------------------------------ */

      public IEither<TLeft, T> ExpandSomeToRight<TExternalState, TLeft>(TExternalState              externalState,
                                                                        Func<TExternalState, TLeft> whenNone)
         => Either<TLeft, T>.Right(Content);

      /* ------------------------------------------------------------ */

      public bool IsANone()
         => false;

      /* ------------------------------------------------------------ */

      public bool IsASome()
         => true;

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, TNew> whenSome)
         => new Option<TNew>.SomeOption(whenSome(Content));

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TExternalState, TNew>(TExternalState                externalState,
                                                     Func<TExternalState, T, TNew> whenSome)
         => new Option<TNew>.SomeOption(whenSome(externalState,
                                                 Content));

      /* ------------------------------------------------------------ */

      public TNew Unify<TNew>(Func<T, TNew> whenSome,
                              Func<TNew>    whenNone)
         => whenSome(Content);

      /* ------------------------------------------------------------ */

      public TNew Unify<TExternalState, TNew>(TExternalState                externalState,
                                              Func<TExternalState, T, TNew> whenSome,
                                              Func<TExternalState, TNew>    whenNone)
         => whenSome(externalState,
                     Content);

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly T Content;

      /* ------------------------------------------------------------ */
   }
}