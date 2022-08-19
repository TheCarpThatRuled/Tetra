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
               SomeOption some => Equals(some._content),
               T content       => Equals(content),
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
      // IEquatable<Option<T>> Methods
      /* ------------------------------------------------------------ */

      public bool Equals(IOption<T>? other)
         => ReferenceEquals(this,
                            other)
         || other is SomeOption some
         && Equals(some._content);

      /* ------------------------------------------------------------ */
      // IEquatable<T> Methods
      /* ------------------------------------------------------------ */

      public bool Equals(T? other)
         => Equals(_content,
                   other);

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
         => new Option<TNew>.SomeOption(whenSome(_content));

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, IOption<TNew>> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */

      public Result<T> MapToResult(Message _)
         => _content;

      /* ------------------------------------------------------------ */

      public Result<T> MapToResult(Func<Message> _)
         => _content;

      /* ------------------------------------------------------------ */

      public T Reduce(T _)
         => _content;

      /* ------------------------------------------------------------ */

      public T Reduce(Func<T> _)
         => _content;

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