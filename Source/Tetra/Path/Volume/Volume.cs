using static Tetra.TetraMessages;

namespace Tetra;

public class Volume : IComparable<Volume>,
                      IEquatable<Volume>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Volume Create(char potentialVolume)
      => Validate(potentialVolume,
                  "volume label")
        .Reduce<Volume>(() => new(potentialVolume),
                               message => throw new ArgumentException(message.Content(),
                                                                      nameof(potentialVolume)));

   /* ------------------------------------------------------------ */

   public static Result<Volume> Parse(char potentialVolume)
      => Validate(potentialVolume,
                  "volume label")
        .MapToResult(new Volume(potentialVolume));

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
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

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
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Error Validate(char   potentialVolume,
                                   string volumeType)
      => potentialVolume.IsNotAnAsciiLetter()
            ? Error.Some(Message.Create(IsNotAValidVolumeLabel(potentialVolume,
                                                               volumeType)))
            : Error.None();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _value;

   /* ------------------------------------------------------------ */
}