namespace Tetra;

partial class Option<T>
{
   private sealed class SomeOption : IOption<T>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public SomeOption(T content)
         => _content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SomeOption some => Equals(_content,
                                         some._content),
               T content       => Equals(_content,
                                         content),
               _               => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _content
             ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Some ({_content})";

      /* ------------------------------------------------------------ */
      // IOption Methods
      /* ------------------------------------------------------------ */

      public IOption<TNew> Cast<TNew>()
         => _content is TNew content
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
            .SomeOption(whenSome(_content));

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, IOption<TNew>> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult(Message _)
         => Result<T>
           .Success(_content);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult(Func<Message> _)
         => Result<T>
           .Success(_content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(TNew          _,
                               Func<T, TNew> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TNew>    _,
                               Func<T, TNew> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly T _content;

      /* ------------------------------------------------------------ */
   }
}