using static Tetra.TetraMessages;

namespace Tetra;

public class FileComponent : IComparable<FileComponent>,
                             IEquatable<FileComponent>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileComponent Create(string potentialComponent)
   {
      if (potentialComponent.IsNotAValidPathComponent())
      {
         throw new ArgumentException(IsNotAValidFileComponent(potentialComponent),
                                     nameof(potentialComponent));

      }

      return new(potentialComponent);
   }

   /* ------------------------------------------------------------ */

   public static Result<FileComponent> Parse(string potentialComponent)
      => potentialComponent.IsNotAValidPathComponent()
            ? Result<FileComponent>.Failure(Message.Create(IsNotAValidFileComponent(potentialComponent)))
            : new FileComponent(potentialComponent);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is FileComponent fileComponent
      && Equals(fileComponent);

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

   public int CompareTo(FileComponent? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(FileComponent? other)
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
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileComponent(string value)
      => _value = value;

   /* ------------------------------------------------------------ */
}