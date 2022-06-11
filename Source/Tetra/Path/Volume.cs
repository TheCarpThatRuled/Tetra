namespace Tetra;

public class Volume : IComparable<Volume>,
                      IEquatable<Volume>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Volume Create(char potentialVolume)
   {
      if (potentialVolume.IsNotAnAsciiLetter())
      {
         throw new ArgumentException($"'{potentialVolume}' is not a valid volume label; a volume label must be an ASCII letter",
                                     nameof(potentialVolume));
      }

      return new(potentialVolume);
   }

   /* ------------------------------------------------------------ */

   public static Result<Volume> Parse(char potentialVolume)
      => potentialVolume.IsAnAsciiLetter()
            ? new Volume(potentialVolume)
            : Result<Volume>.Failure(Message.Create($"'{potentialVolume}' is not a valid volume label; a volume label must be an ASCII letter"));

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */


   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is Volume volume
      && Equals(volume);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => StringComparer
        .OrdinalIgnoreCase
        .GetHashCode(_value);

   /* ------------------------------------------------------------ */

   public override string ToString()
      => $"<{_value}>";

   /* ------------------------------------------------------------ */
   // IComparable<Volume> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(Volume? other)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // IEquatable<Volume> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(Volume? other)
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

   protected Volume(char volumeLabel)
      => _value = $"{volumeLabel}:";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _value;

   /* ------------------------------------------------------------ */
}