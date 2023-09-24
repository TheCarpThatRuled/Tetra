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
        .Reduce<DirectoryComponent>(message => throw new ArgumentException(message.Content(),
                                                                           nameof(potentialComponent)),
                                    () => new(potentialComponent));

   /* ------------------------------------------------------------ */

   public static IEither<DirectoryComponent, Message> Parse(string potentialComponent)
      => Validate(potentialComponent,
                  ComponentType)
        .ExpandSomeToRight(() => new DirectoryComponent(potentialComponent));

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

   protected static IOption<Message> Validate(string potentialComponent,
                                              string componentType)
      => potentialComponent.IsNotAValidPathComponent()
            ? Option.Some(Message.Create(IsNotValidBecauseAComponentMayNotContainTheCharacters(potentialComponent,
                                                                                               componentType)))
            : Option<Message>.None();

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