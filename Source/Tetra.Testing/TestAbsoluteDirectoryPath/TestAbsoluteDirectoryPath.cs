namespace Tetra.Testing;

public sealed class TestAbsoluteDirectoryPath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Create(VolumeComponent             volume,
                                                  params DirectoryComponent[] directories)
      => new(directories,
             volume);

   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Create(VolumeComponent                         volume,
                                                  IReadOnlyCollection<DirectoryComponent> directories)
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

   public IReadOnlyCollection<DirectoryComponent> Directories()
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
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly string                                  _pathWithoutTrailingDirectorySeparator;
   private readonly string                                  _pathWithTrailingDirectorySeparator;
   private readonly VolumeComponent                         _volume;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TestAbsoluteDirectoryPath(IReadOnlyCollection<DirectoryComponent> directories,
                                     VolumeComponent                         volume)
   {
      _volume      = volume;
      _directories = directories;

      var path = directories
                .Select(directory => directory.Value())
                .Prepend(volume.Value())
                .ToArray();

      _pathWithoutTrailingDirectorySeparator = path.ToDelimitedString(Path.DirectorySeparatorChar);
      _pathWithTrailingDirectorySeparator    = path.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);
   }

   /* ------------------------------------------------------------ */
}