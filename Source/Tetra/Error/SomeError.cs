namespace Tetra;

partial class Error
{
   private sealed class SomeError : Error
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
      // IEquatable<Error> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Error? other)
         => false;

      /* ------------------------------------------------------------ */
      // IEquatable<Message> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Message? other)
         => false;

      /* ------------------------------------------------------------ */
      // Error Methods
      /* ------------------------------------------------------------ */

      public override bool IsANone()
         => false;

      /* ------------------------------------------------------------ */

      public override bool IsASome()
         => false;

      /* ------------------------------------------------------------ */

      public override Error Map(Func<Message, Message> whenSome)
         => null;

      /* ------------------------------------------------------------ */

      public override Error Map(Func<Message, Error> whenSome)
         => null;

      /* ------------------------------------------------------------ */

      public override Message Reduce(Message _)
         => null;

      /* ------------------------------------------------------------ */

      public override Message Reduce(Func<Message> _)
         => null;

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(TNew _,
                                        Func<Message, TNew> whenSome)
         => default;

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<TNew> _,
                                        Func<Message, TNew> whenSome)
         => default;

      /* ------------------------------------------------------------ */
   }
}