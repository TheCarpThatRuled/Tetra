namespace Tetra.Testing;

public sealed class TestAbsoluteFilePath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestAbsoluteFilePath Create(VolumeComponent                         volume,
                                             IReadOnlyCollection<DirectoryComponent> directories,
                                             FileComponent                           file)
      => new(directories,
             file,
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

   public FileComponent File()
      => _file;

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
   private readonly FileComponent                           _file;
   private readonly string                                  _pathWithoutTrailingDirectorySeparator;
   private readonly string                                  _pathWithTrailingDirectorySeparator;
   private readonly VolumeComponent                         _volume;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TestAbsoluteFilePath(IReadOnlyCollection<DirectoryComponent> directories,
                                FileComponent                           file,
                                VolumeComponent                         volume)
   {
      _directories = directories;
      _file        = file;
      _volume      = volume;

      var path = directories
                .Select(directory => directory.Value())
                .Prepend(volume.Value())
                .Append(file.Value())
                .ToArray();

      _pathWithoutTrailingDirectorySeparator = path.ToDelimitedString(Path.DirectorySeparatorChar);
      _pathWithTrailingDirectorySeparator    = path.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);
   }

   /* ------------------------------------------------------------ */
}