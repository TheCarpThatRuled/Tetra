namespace Tetra;

public sealed class Message : IEquatable<Message>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Message Create(string content)
      => new(content);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is Message other
      && Equals(other);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => _content
        .GetHashCode();

   /* ------------------------------------------------------------ */

   public override string ToString()
      => _content;

   /* ------------------------------------------------------------ */
   // IEquatable<Message> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(Message? other)
      => other is not null
      && _content.Equals(other._content);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public string Content()
      => _content;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _content;

   /* ------------------------------------------------------------ */
   // Private Constructor
   /* ------------------------------------------------------------ */

   public Message(string content)
      => _content = content;

   /* ------------------------------------------------------------ */
}