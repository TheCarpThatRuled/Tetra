namespace Tetra;

partial class Error
{
   private sealed class SomeError : IError
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public SomeError(Message content)
         => _content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SomeError some  => Equals(_content,
                                         some._content),
               Message content => Equals(_content,
                                         content),
               _               => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _content
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Some ({_content})";

      /* ------------------------------------------------------------ */
      // IError Methods
      /* ------------------------------------------------------------ */

      public bool IsANone()
         => false;

      /* ------------------------------------------------------------ */

      public bool IsASome()
         => true;

      /* ------------------------------------------------------------ */

      public IError Map(Func<Message, Message> whenSome)
         => Error.Some(whenSome(_content));

      /* ------------------------------------------------------------ */

      public IError Map(Func<Message, IError> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult<T>(T _)
         => Result<T>
           .Failure(_content);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult<T>(Func<T> _)
         => Result<T>
           .Failure(_content);

      /* ------------------------------------------------------------ */

      public Message Reduce(Message _)
         => _content;

      /* ------------------------------------------------------------ */

      public Message Reduce(Func<Message> _)
         => _content;

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(TNew _,
                               Func<Message, TNew> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TNew> _,
                               Func<Message, TNew> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Message _content;

      /* ------------------------------------------------------------ */
   }
}