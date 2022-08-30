namespace Tetra;

partial class Error
{
   private sealed class NoneError : IError
   {
      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               NoneError => true,
               _          => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => "None";

      /* ------------------------------------------------------------ */
      // IError  Methods
      /* ------------------------------------------------------------ */

      public bool IsANone()
         => true;

      /* ------------------------------------------------------------ */

      public bool IsASome()
         => false;

      /* ------------------------------------------------------------ */

      public IError Map(Func<Message, Message> _)
         => this;

      /* ------------------------------------------------------------ */

      public IError Map(Func<Message, IError> _)
         => this;

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult<T>(T whenNone)
         => Result<T>
           .Success(whenNone);

      /* ------------------------------------------------------------ */

      public IResult<T> MapToResult<T>(Func<T> whenNone)
         => Result<T>
           .Success(whenNone());

      /* ------------------------------------------------------------ */

      public Message Reduce(Message whenNone)
         => whenNone;

      /* ------------------------------------------------------------ */

      public Message Reduce(Func<Message> whenNone)
         => whenNone();

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(TNew whenNone,
                               Func<Message, TNew> _)
         => whenNone;

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TNew> whenNone,
                               Func<Message, TNew> _)
         => whenNone();

      /* ------------------------------------------------------------ */
   }
}