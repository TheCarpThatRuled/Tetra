namespace Tetra;

partial class Error
{
   internal sealed class SomeError : IError
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public SomeError(Message content)
         => Content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SomeError some  => Equals(Content,
                                         some.Content),
               Message content => Equals(Content,
                                         content),
               _               => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => Content
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Some ({Content})";

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
         => Error.Some(whenSome(Content));

      /* ------------------------------------------------------------ */

      public IError Map(Func<Message, IError> whenSome)
         => whenSome(Content);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult<T>(T _)
         => Result<T>
           .Failure(Content);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult<T>(Func<T> _)
         => Result<T>
           .Failure(Content);

      /* ------------------------------------------------------------ */

      public Message Reduce(Message _)
         => Content;

      /* ------------------------------------------------------------ */

      public Message Reduce(Func<Message> _)
         => Content;

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(TNew _,
                               Func<Message, TNew> whenSome)
         => whenSome(Content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TNew> _,
                               Func<Message, TNew> whenSome)
         => whenSome(Content);

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly Message Content;

      /* ------------------------------------------------------------ */
   }
}