namespace Tetra;

public class DirectoryComponent : IComparable<DirectoryComponent>,
                                  IEquatable<DirectoryComponent>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DirectoryComponent Create(string potentialComponent)
      => new();

   /* ------------------------------------------------------------ */

   public static Result<DirectoryComponent> Parse(string potentialComponent)
      => new DirectoryComponent();

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
      => string.Empty;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private DirectoryComponent() { }

   /* ------------------------------------------------------------ */
}