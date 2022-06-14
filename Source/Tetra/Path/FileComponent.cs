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
      => base.Equals(obj);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => base.GetHashCode();

   /* ------------------------------------------------------------ */

   public override string ToString()
      => base.ToString();

   /* ------------------------------------------------------------ */
   // IComparable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(FileComponent? other)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // IEquatable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(FileComponent? other)
      => throw new NotImplementedException();

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