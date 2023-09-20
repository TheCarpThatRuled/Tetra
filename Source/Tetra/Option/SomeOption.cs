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

      public bool IsANone()
         => false;

      /* ------------------------------------------------------------ */

      public bool IsASome()
         => true;

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

      public IOption<TNew> Map<TNew>(Func<T, TNew> whenSome)
         => new Option<TNew>.SomeOption(whenSome(Content));

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TExternalState, TNew>(TExternalState                externalState,
                                                     Func<TExternalState, T, TNew> whenSome)
         => new Option<TNew>.SomeOption(whenSome(externalState,
                                                 Content));

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, IOption<TNew>> whenSome)
         => whenSome(Content);

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TExternalState, TNew>(TExternalState                         externalState,
                                                     Func<TExternalState, T, IOption<TNew>> whenSome)
         => whenSome(externalState,
                     Content);

      /* ------------------------------------------------------------ */

      public IResult<T, TNew> MapToResult<TNew>(TNew whenNone)
         => new Result<T, TNew>.SuccessResult(Content);

      /* ------------------------------------------------------------ */

      public IResult<T, TNew> MapToResult<TNew>(Func<TNew> whenNone)
         => new Result<T, TNew>.SuccessResult(Content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<T, TNew> whenSome,
                               Func<TNew>    whenNone)
         => whenSome(Content);

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly T Content;

      /* ------------------------------------------------------------ */
   }
}