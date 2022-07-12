using static Tetra.TetraMessages;

namespace Tetra;

public class DirectoryComponent : IComparable<DirectoryComponent>,
                                  IEquatable<DirectoryComponent>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DirectoryComponent Create(string potentialComponent)
      => Validate(potentialComponent,
                  ComponentType)
        .Reduce<DirectoryComponent>(() => new(potentialComponent),
                                    message => throw new ArgumentException(message.Content(),
                                                                           nameof(potentialComponent)));

   /* ------------------------------------------------------------ */

   public static Result<DirectoryComponent> Parse(string potentialComponent)
      => Validate(potentialComponent,
                  ComponentType)
        .MapToResult(new DirectoryComponent(potentialComponent));

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is DirectoryComponent directoryComponent
      && Equals(directoryComponent);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => StringComparer
        .OrdinalIgnoreCase
        .GetHashCode(_value);

   /* ------------------------------------------------------------ */

   public override string ToString()
      => $"<{_value}>";

   /* ------------------------------------------------------------ */
   // IComparable<DirectoryComponent> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(DirectoryComponent? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<DirectoryComponent> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(DirectoryComponent? other)
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

   protected DirectoryComponent(string value)
      => _value = value;

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Error Validate(string potentialComponent,
                                   string componentType)
      => potentialComponent.IsNotAValidPathComponent()
            ? Error.Some(Message.Create(IsNotAValidComponent(potentialComponent,
                                                             componentType)))
            : Error.None();

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string ComponentType = "directory component";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _value;

   /* ------------------------------------------------------------ */
}