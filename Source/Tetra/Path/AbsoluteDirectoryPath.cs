namespace Tetra;

public abstract class AbsoluteDirectoryPath : IComparable<AbsoluteDirectoryPath>,
                                              IEquatable<AbsoluteDirectoryPath>
{
   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is AbsoluteDirectoryPath path
      && Equals(path);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => StringComparer
        .OrdinalIgnoreCase
        .GetHashCode(_value);

   /* ------------------------------------------------------------ */

   public override string ToString()
      => $"<{_value}>";

   /* ------------------------------------------------------------ */
   // IComparable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(AbsoluteDirectoryPath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(AbsoluteDirectoryPath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Equals(_value,
                other?._value);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public string Value()
      => _value;

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected internal AbsoluteDirectoryPath(string value)
      => _value = value;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _value;

   /* ------------------------------------------------------------ */
}