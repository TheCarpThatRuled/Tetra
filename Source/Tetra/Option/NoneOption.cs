﻿namespace Tetra;

static partial class Option<T>
{
   internal sealed class NoneOption : IOption<T>
   {
      /* ------------------------------------------------------------ */
      // IOption<T> Methods
      /* ------------------------------------------------------------ */

      public IOption<T> Do
      (
         Action<T> whenSome,
         Action    whenNone
      )
      {
         whenNone();

         return this;
      }

      /* ------------------------------------------------------------ */

      public IOption<T> Do<TExternalState>
      (
         TExternalState            externalState,
         Action<TExternalState, T> whenSome,
         Action<TExternalState>    whenNone
      )
      {
         whenNone(externalState);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IEither<T, TRight> ExpandSomeToLeft<TRight>
      (
         Func<TRight> whenNone
      )
         => Either<T, TRight>.Right(whenNone());

      /* ------------------------------------------------------------ */

      public IEither<T, TRight> ExpandSomeToLeft<TExternalState, TRight>
      (
         TExternalState               externalState,
         Func<TExternalState, TRight> whenNone
      )
         => Either<T, TRight>.Right(whenNone(externalState));

      /* ------------------------------------------------------------ */

      public IEither<TLeft, T> ExpandSomeToRight<TLeft>
      (
         Func<TLeft> whenNone
      )
         => Either<TLeft, T>.Left(whenNone());

      /* ------------------------------------------------------------ */

      public IEither<TLeft, T> ExpandSomeToRight<TExternalState, TLeft>
      (
         TExternalState              externalState,
         Func<TExternalState, TLeft> whenNone
      )
         => Either<TLeft, T>.Left(whenNone(externalState));

      /* ------------------------------------------------------------ */

      public bool IsANone()
         => true;

      /* ------------------------------------------------------------ */

      public bool IsASome()
         => false;

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>
      (
         Func<T, TNew> whenSome
      )
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TExternalState, TNew>
      (
         TExternalState                externalState,
         Func<TExternalState, T, TNew> whenSome
      )
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public TNew Unify<TNew>
      (
         Func<T, TNew> whenSome,
         Func<TNew>    whenNone
      )
         => whenNone();

      /* ------------------------------------------------------------ */

      public TNew Unify<TExternalState, TNew>
      (
         TExternalState                externalState,
         Func<TExternalState, T, TNew> whenSome,
         Func<TExternalState, TNew>    whenNone
      )
         => whenNone(externalState);
      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals
      (
         object? obj
      )
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               NoneOption => true,
               _          => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => typeof(T)
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"None of {typeof(T).Name}";

      /* ------------------------------------------------------------ */
   }
}