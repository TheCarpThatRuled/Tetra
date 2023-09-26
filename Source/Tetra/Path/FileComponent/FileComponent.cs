using static Tetra.TetraMessages;

namespace Tetra;

public class FileComponent : IComparable<FileComponent>,
                             IEquatable<FileComponent>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileComponent Create(string potentialComponent)
      => Validate(potentialComponent,
                  ComponentType)
        .Unify<FileComponent>(message => throw new ArgumentException(message.Content(),
                                                                      nameof(potentialComponent)),
                               () => new(potentialComponent));

   /* ------------------------------------------------------------ */

   public static IEither<FileComponent, Message> Parse(string potentialComponent)
      => Validate(potentialComponent,
                  ComponentType)
        .ExpandSomeToRight(() => new FileComponent(potentialComponent));

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
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected FileComponent(string value)
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

   private const string ComponentType = "file component";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _value;

   /* ------------------------------------------------------------ */
}