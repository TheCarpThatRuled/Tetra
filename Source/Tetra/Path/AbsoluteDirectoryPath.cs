namespace Tetra;

public abstract class AbsoluteDirectoryPath : IComparable<AbsoluteDirectoryPath>,
                                              IEquatable<AbsoluteDirectoryPath>
{
   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => default;
   //=> ReferenceEquals(this,
   //                   obj)
   //|| obj is AbsoluteDirectoryPath path
   //&& Equals(path);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => default;
   //    => StringComparer
   //      .OrdinalIgnoreCase
   //      .GetHashCode(_value);

   /* ------------------------------------------------------------ */

   public override string ToString()
      => string.Empty;
   //=> $"<{_value}>";

   /* ------------------------------------------------------------ */
   // IComparable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(AbsoluteDirectoryPath? other)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // IEquatable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(AbsoluteDirectoryPath? other)
      => throw new NotImplementedException();

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