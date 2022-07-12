using static Tetra.TetraMessages;

namespace Tetra;

public class RelativeDirectoryPath : IComparable<RelativeDirectoryPath>,
                                     IEquatable<RelativeDirectoryPath>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Create(string potentialPath)
      => new();

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Create(IReadOnlyCollection<DirectoryComponent> directories)
      => new();

   /* ------------------------------------------------------------ */

   public static Result<RelativeDirectoryPath> Parse(string potentialPath)
      => Message.Create(string.Empty);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => true;

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => 0;

   /* ------------------------------------------------------------ */

   public override string ToString()
      => string.Empty;

   /* ------------------------------------------------------------ */
   // IComparable<RelativeDirectoryPath> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(RelativeDirectoryPath? other)
      => 0;

   /* ------------------------------------------------------------ */
   // IEquatable<RelativeDirectoryPath> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(RelativeDirectoryPath? other)
      => true;

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public string Value()
      => string.Empty;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Append(params DirectoryComponent[] directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Append(IEnumerable<DirectoryComponent> directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Append(RelativeDirectoryPath path)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Append(FileComponent file)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Append(RelativeFilePath path)
      => new();

   /* ------------------------------------------------------------ */

   public Option<RelativeDirectoryPath> Parent()
      => Option<RelativeDirectoryPath>.None();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(params DirectoryComponent[] directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(IEnumerable<DirectoryComponent> directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(RelativeDirectoryPath path)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(FileComponent file)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(RelativeFilePath path)
      => new();

   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Prepend(VolumeComponent volume)
      => null;

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath() { }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<IReadOnlyCollection<DirectoryComponent>> ParseComponents(string potentialPath,
                                                                                    string pathType)
      => Message.Create(string.Empty);

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "relative directory path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly string                                  _value;

   /* ------------------------------------------------------------ */
}