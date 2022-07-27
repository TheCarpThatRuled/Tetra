namespace Tetra.Testing;

public sealed class TestRelativeFilePath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestRelativeFilePath Create(IReadOnlyCollection<DirectoryComponent> directories,
                                             FileComponent                           file)
      => new(directories,
             file);

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

   public FileComponent File()
      => _file;

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
   private readonly FileComponent                           _file;
   private readonly string                                  _pathWithoutTrailingDirectorySeparator;
   private readonly string                                  _pathWithTrailingDirectorySeparator;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TestRelativeFilePath(IReadOnlyCollection<DirectoryComponent> directories,
                                FileComponent                           file)
   {
      _directories = directories;
      _file        = file;

      var path = directories
                .Select(directory => directory.Value())
                .Append(file.Value())
                .ToArray();

      _pathWithoutTrailingDirectorySeparator = path.ToDelimitedString(Path.DirectorySeparatorChar);
      _pathWithTrailingDirectorySeparator    = path.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);
   }

   /* ------------------------------------------------------------ */
}