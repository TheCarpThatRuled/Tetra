using static Tetra.TetraMessages;

namespace Tetra;

public class DirectoryComponent : IComparable<DirectoryComponent>,
                                  IEquatable<DirectoryComponent>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DirectoryComponent Create(string potentialComponent)
   {
      if (potentialComponent.IsNotAValidPathComponent())
      {
         throw new ArgumentException(IsNotAValidDirectoryComponent(potentialComponent),
                                     nameof(potentialComponent));

      }

      return new(potentialComponent);
   }

   /* ------------------------------------------------------------ */

   public static Result<DirectoryComponent> Parse(string potentialComponent)
      => potentialComponent.IsNotAValidPathComponent()
            ? Result<DirectoryComponent>.Failure(Message.Create(IsNotAValidDirectoryComponent(potentialComponent)))
            : new DirectoryComponent(potentialComponent);

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
   // IComparable<DirectoryComponent> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(DirectoryComponent? other)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // IEquatable<DirectoryComponent> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(DirectoryComponent? other)
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

   private DirectoryComponent(string value)
      => _value = value;

   /* ------------------------------------------------------------ */
}