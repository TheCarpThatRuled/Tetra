namespace Tetra;

public abstract partial class Error : IEquatable<Error>,
                                      IEquatable<Message>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Error None()
      => new NoneError();

   /* ------------------------------------------------------------ */

   public static Error Some(Message message)
      => new SomeError();

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Error(Message message)
      => new SomeError();

   /* ------------------------------------------------------------ */
   // IEquatable<Error> Methods
   /* ------------------------------------------------------------ */
   public abstract bool Equals(Error? other);

   /* ------------------------------------------------------------ */
   // IEquatable<Message> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(Message? other);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public abstract bool IsANone();

   /* ------------------------------------------------------------ */

   public abstract bool IsASome();

   /* ------------------------------------------------------------ */

   public abstract Error Map(Func<Message, Message> whenSome);

   /* ------------------------------------------------------------ */

   public abstract Error Map(Func<Message, Error> whenSome);

   /* ------------------------------------------------------------ */

   public abstract Message Reduce(Message whenNone);

   /* ------------------------------------------------------------ */

   public abstract Message Reduce(Func<Message> whenNone);

   /* ------------------------------------------------------------ */

   public abstract TNew Reduce<TNew>(TNew whenNone,
                                     Func<Message, TNew> whenSome);

   /* ------------------------------------------------------------ */

   public abstract TNew Reduce<TNew>(Func<TNew> whenNone,
                                     Func<Message, TNew> whenSome);

   /* ------------------------------------------------------------ */
}