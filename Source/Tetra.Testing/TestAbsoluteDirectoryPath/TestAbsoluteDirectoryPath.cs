namespace Tetra.Testing;

public sealed class TestAbsoluteDirectoryPath
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ISequence<DirectoryComponent> _directories;
   private readonly string                        _pathWithoutTrailingDirectorySeparator;
   private readonly string                        _pathWithTrailingDirectorySeparator;
   private readonly VolumeComponent               _volume;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TestAbsoluteDirectoryPath
   (
      ISequence<DirectoryComponent> directories,
      VolumeComponent               volume
   )
   {
      _directories = directories;
      _volume      = volume;

      var path = directories
                .Select(directory => directory.Value())
                .Prepend(volume.Value())
                .ToArray();

      _pathWithoutTrailingDirectorySeparator = path.ToDelimitedString(Path.DirectorySeparatorChar);
      _pathWithTrailingDirectorySeparator    = path.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Create
   (
      VolumeComponent             volume,
      params DirectoryComponent[] directories
   )
      => new(directories.Materialise(),
             volume);

   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Create
   (
      VolumeComponent               volume,
      ISequence<DirectoryComponent> directories
   )
      => new(directories,
             volume);

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

   public VolumeComponent Volume()
      => _volume;

   /* ------------------------------------------------------------ */
}