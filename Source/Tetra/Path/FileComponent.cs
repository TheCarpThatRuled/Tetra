namespace Tetra;

public class FileComponent : IComparable<FileComponent>,
                             IEquatable<FileComponent>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileComponent Create(string potentialComponent)
      => new();

   /* ------------------------------------------------------------ */

   public static Result<FileComponent> Parse(string potentialComponent)
      => new FileComponent();

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
      => string.Empty;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileComponent() { }

   /* ------------------------------------------------------------ */
}