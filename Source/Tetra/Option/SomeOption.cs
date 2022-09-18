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
               T content       => Equals(Content,
                                         content),
               _               => false,
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
      // IOption Methods
      /* ------------------------------------------------------------ */

      public IOption<TNew> Cast<TNew>()
         => Content is TNew content
               ? new Option<TNew>.SomeOption(content)
               : new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public bool IsANone()
         => false;

      /* ------------------------------------------------------------ */

      public bool IsASome()
         => true;

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, TNew> whenSome)
         => new Option<TNew>
            .SomeOption(whenSome(Content));

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, IOption<TNew>> whenSome)
         => whenSome(Content);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult(Message _)
         => Result<T>
           .Success(Content);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult(Func<Message> _)
         => Result<T>
           .Success(Content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(TNew          _,
                               Func<T, TNew> whenSome)
         => whenSome(Content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TNew>    _,
                               Func<T, TNew> whenSome)
         => whenSome(Content);

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly T Content;

      /* ------------------------------------------------------------ */
   }
}