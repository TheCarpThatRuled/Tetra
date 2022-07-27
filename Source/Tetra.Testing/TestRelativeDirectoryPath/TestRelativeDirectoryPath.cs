namespace Tetra.Testing;

public sealed class TestRelativeDirectoryPath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Create(params DirectoryComponent[] directories)
      => new(directories);

   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Create(IReadOnlyCollection<DirectoryComponent> directories)
      => new(directories);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override string ToString()
      => _pathWithTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public IReadOnlyCollection<DirectoryComponent> Directories()
      => _directories;

   /* ------------------------------------------------------------ */

   public string PathWithoutTrailingDirectorySeparator()
      => _pathWithoutTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */

   public string PathWithTrailingDirectorySeparator()
      => _pathWithTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly string                                  _pathWithoutTrailingDirectorySeparator;
   private readonly string                                  _pathWithTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TestRelativeDirectoryPath(IReadOnlyCollection<DirectoryComponent> directories)
   {
      _directories = directories;

      var path = directories
                .Select(directory => directory.Value())
                .ToArray();

      _pathWithoutTrailingDirectorySeparator = path.ToDelimitedString(Path.DirectorySeparatorChar);
      _pathWithTrailingDirectorySeparator    = path.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);
   }

   /* ------------------------------------------------------------ */
}