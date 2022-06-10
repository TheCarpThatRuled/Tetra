namespace Tetra;

public class Volume : IComparable<Volume>,
                      IEquatable<Volume>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Volume Create(char potentialVolume)
      => new();

   /* ------------------------------------------------------------ */

   public static Result<Volume> Parse(char potentialVolume)
      => new Volume();

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => base.Equals(obj);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => base.GetHashCode();

   /* ------------------------------------------------------------ */

   public override string ToString()
      => base.ToString();

   /* ------------------------------------------------------------ */
   // IComparable<Volume> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(Volume? other)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // IEquatable<Volume> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(Volume? other)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public string Value()
      => string.Empty;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Volume() { }

   /* ------------------------------------------------------------ */
}