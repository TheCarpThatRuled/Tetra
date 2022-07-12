using static Tetra.TetraMessages;

namespace Tetra;

public class VolumeComponent : IComparable<VolumeComponent>,
                               IEquatable<VolumeComponent>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static VolumeComponent Create(char potentialVolume)
      => Validate(potentialVolume,
                  VolumeType)
        .Reduce<VolumeComponent>(() => new(potentialVolume),
                                 message => throw new ArgumentException(message.Content(),
                                                                        nameof(potentialVolume)));

   /* ------------------------------------------------------------ */

   public static Result<VolumeComponent> Parse(char potentialVolume)
      => Validate(potentialVolume,
                  VolumeType)
        .MapToResult(new VolumeComponent(potentialVolume));

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is VolumeComponent volume
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
   // IComparable<VolumeComponent> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(VolumeComponent? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<VolumeComponent> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(VolumeComponent? other)
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

   protected VolumeComponent(char volumeLabel)
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
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string VolumeType = "volume label";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _value;

   /* ------------------------------------------------------------ */
}