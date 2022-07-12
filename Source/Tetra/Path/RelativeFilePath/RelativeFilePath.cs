using static Tetra.TetraMessages;

namespace Tetra;

public class RelativeFilePath : IComparable<RelativeFilePath>,
                                IEquatable<RelativeFilePath>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static RelativeFilePath Create(string potentialPath)
      => new();

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Create(IReadOnlyCollection<DirectoryComponent> directories,
                                         FileComponent                           file)
      => new();

   /* ------------------------------------------------------------ */

   public static Result<RelativeFilePath> Parse(string potentialPath)
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
   // IComparable<RelativeFilePath> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(RelativeFilePath? other)
      => 0;

   /* ------------------------------------------------------------ */
   // IEquatable<RelativeFilePath> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(RelativeFilePath? other)
      => true;

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public FileComponent File()
      => null;

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Parent()
      => null;

   /* ------------------------------------------------------------ */

   public string Value()
      => string.Empty;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(params DirectoryComponent[] directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(IEnumerable<DirectoryComponent> directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(RelativeDirectoryPath path)
      => new();

   /* ------------------------------------------------------------ */

   public AbsoluteFilePath Prepend(VolumeComponent volume)
      => null;

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   public RelativeFilePath() { }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<(IReadOnlyCollection<DirectoryComponent> directories, FileComponent file)> ParseComponents(string potentialPath,
      string                                                                                                                                         pathType)
      => Message.Create(string.Empty);

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "relative file path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly FileComponent                           _file;
   private readonly string                                  _value;

   /* ------------------------------------------------------------ */
}