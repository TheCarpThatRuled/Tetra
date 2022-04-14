namespace Tetra;

partial class Error
{
   private sealed class SomeError : Error
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
               SomeError some  => Equals(some._content),
               Message content => Equals(content),
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
      // Error Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool IsANone()
         => false;

      /* ------------------------------------------------------------ */

      public override bool IsASome()
         => true;

      /* ------------------------------------------------------------ */

      public override Error Map(Func<Message, Message> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */

      public override Error Map(Func<Message, Error> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */

      public override Message Reduce(Message _)
         => _content;

      /* ------------------------------------------------------------ */

      public override Message Reduce(Func<Message> _)
         => _content;

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(TNew _,
                                        Func<Message, TNew> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<TNew> _,
                                        Func<Message, TNew> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */
      // IEquatable<Error> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Error? other)
         => ReferenceEquals(this,
                            other)
         || other switch
            {
               SomeError some => Equals(some._content),
               _              => false,
            };

      /* ------------------------------------------------------------ */
      // IEquatable<Message> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Message? other)
         => Equals(_content,
                   other);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Message _content;

      /* ------------------------------------------------------------ */
   }
}