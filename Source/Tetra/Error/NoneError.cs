﻿namespace Tetra;

partial class Error
{
   private sealed class NoneError : Error
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
         => $"None";

      /* ------------------------------------------------------------ */
      // IEquatable<Error> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Error? other)
         => ReferenceEquals(this,
                            other)
         || other switch
            {
               NoneError => true,
               _          => false,
            };

      /* ------------------------------------------------------------ */
      // IEquatable<Message> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Message? other)
         => false;

      /* ------------------------------------------------------------ */
      // Error Methods
      /* ------------------------------------------------------------ */

      public override bool IsANone()
         => true;

      /* ------------------------------------------------------------ */

      public override bool IsASome()
         => false;

      /* ------------------------------------------------------------ */

      public override Error Map(Func<Message, Message> _)
         => this;

      /* ------------------------------------------------------------ */

      public override Error Map(Func<Message, Error> _)
         => this;

      /* ------------------------------------------------------------ */

      public override Message Reduce(Message whenNone)
         => whenNone;

      /* ------------------------------------------------------------ */

      public override Message Reduce(Func<Message> whenNone)
         => whenNone();

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(TNew whenNone,
                                        Func<Message, TNew> _)
         => whenNone;

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<TNew> whenNone,
                                        Func<Message, TNew> _)
         => whenNone();

      /* ------------------------------------------------------------ */
   }
}