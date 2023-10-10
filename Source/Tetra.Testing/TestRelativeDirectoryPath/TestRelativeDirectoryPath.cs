namespace Tetra.Testing;

public sealed class TestRelativeDirectoryPath
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ISequence<DirectoryComponent> _directories;
   private readonly string                        _pathWithoutTrailingDirectorySeparator;
   private readonly string                        _pathWithTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TestRelativeDirectoryPath
   (
      ISequence<DirectoryComponent> directories
   )
   {
      _directories = directories;

      var path = directories
                .Select(directory => directory.Value())
                .ToArray();

      _pathWithoutTrailingDirectorySeparator = path.ToDelimitedString(Path.DirectorySeparatorChar);
      _pathWithTrailingDirectorySeparator    = path.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Create
   (
      params DirectoryComponent[] directories
   )
      => new(directories.Materialise());

   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Create
   (
      ISequence<DirectoryComponent> directories
   )
      => new(directories);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override string ToString()
      => _pathWithTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public ISequence<DirectoryComponent> Directories()
      => _directories;

   /* ------------------------------------------------------------ */

   public string PathWithoutTrailingDirectorySeparator()
      => _pathWithoutTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */

   public string PathWithTrailingDirectorySeparator()
      => _pathWithTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */
}