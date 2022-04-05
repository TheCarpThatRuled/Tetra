namespace Tetra;

partial class Error
{
   private sealed class NoneError : Error
   {
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

      public override Error Map(Func<Message, Message> _)
         => null;

      /* ------------------------------------------------------------ */

      public override Error Map(Func<Message, Error> _)
         => null;

      /* ------------------------------------------------------------ */

      public override Message Reduce(Message whenNone)
         => null;

      /* ------------------------------------------------------------ */

      public override Message Reduce(Func<Message> whenNone)
         => null;

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(TNew whenNone,
                                        Func<Message, TNew> _)
         => default;

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<TNew> whenNone,
                                        Func<Message, TNew> _)
         => default;

      /* ------------------------------------------------------------ */
   }
}