using FsCheck;
using static Tetra.Testing.Properties;

namespace Tetra.Testing;

public sealed class FileSystemPropertyAsserts<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string           _characterisation;
   private readonly FileSystem       _fileSystem;
   private readonly Action<Property> _pushProperty;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystemPropertyAsserts
   (
      string           characterisation,
      FileSystem       fileSystem,
      Func<T>          next,
      Action<Property> pushProperty
   ) : base(next)
   {
      _characterisation = characterisation;
      _fileSystem       = fileSystem;
      _pushProperty     = pushProperty;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileSystemPropertyAsserts<T> Create
   (
      Action<Property> pushProperty,
      string           characterisation,
      FileSystem       fileSystem,
      Func<T>          next
   )
      => new(characterisation,
             fileSystem,
             next,
             pushProperty);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> ADirectoryDoesNotExists
   (
      AbsoluteDirectoryPath expected
   )
   {
      _pushProperty(IsFalse($"{_characterisation}: The directory {expected} should exist",
                            _fileSystem.Exists(expected)));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> ADirectoryExists
   (
      AbsoluteDirectoryPath expected
   )
   {
      _pushProperty(IsTrue($"{_characterisation}: The directory {expected} should exist",
                           _fileSystem.Exists(expected)));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> ADirectoryHasTheSubDirectories
   (
      AbsoluteDirectoryPath           expected,
      Sequence<AbsoluteDirectoryPath> expectedSubDirectories
   )
   {
      _pushProperty(IsALeftAnd($"{_characterisation}: The directory {expected} should successfully retrieve sub-directories",
                               (
                                  _,
                                  actual
                               ) => AreSetEqual(
                                  $"{_characterisation}: The directory {expected} should have sub-directories set equal to {{ {expectedSubDirectories.Aggregate("", (total, next) => $"{total}{next}, ")}}}",
                                  expectedSubDirectories,
                                  actual),
                               _fileSystem.SubDirectoriesOf(expected)));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> ADirectoryHasTheSubFiles
   (
      AbsoluteDirectoryPath      expected,
      Sequence<AbsoluteFilePath> expectedSubFiles
   )
   {
      _pushProperty(IsALeftAnd($"{_characterisation}: The directory {expected} should successfully retrieve sub-files",
                               (
                                  _,
                                  actual
                               ) => AreSetEqual(
                                  $"{_characterisation}: The directory {expected} should have sub-files set equal to {{ {expectedSubFiles.Aggregate("", (total, next) => $"{total}{next}, ")}}}",
                                  expectedSubFiles,
                                  actual),
                               _fileSystem.SubFilesOf(expected)));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> AFileExists
   (
      AbsoluteFilePath expected
   )
   {
      _pushProperty(IsTrue($"{_characterisation}: The file {expected} should exist",
                           _fileSystem.Exists(expected)));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> AFileDoesNotExists
   (
      AbsoluteFilePath expected
   )
   {
      _pushProperty(IsFalse($"{_characterisation}: The file {expected} should exist",
                            _fileSystem.Exists(expected)));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> ExistsAndDoesNotExistsAreInverses
   (
      AbsoluteDirectoryPath path
   )
   {
      _pushProperty(IsTrue($"{_characterisation}: Exists and DoesNotExist are inverse for the directory {path}",
                           _fileSystem.Exists(path) != _fileSystem.DoesNotExist(path)));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> ExistsAndDoesNotExistsAreInverses
   (
      AbsoluteFilePath path
   )
   {
      _pushProperty(IsTrue($"{_characterisation}: Exists and DoesNotExist are inverse for the file {path}",
                           _fileSystem.Exists(path) != _fileSystem.DoesNotExist(path)));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemPropertyAsserts<T> TheCurrentDirectoryIs
   (
      AbsoluteDirectoryPath expected
   )
   {
      _pushProperty(AreEqual($"{_characterisation}: The directory {expected} should exist",
                             expected,
                             _fileSystem.CurrentDirectory()));

      return this;
   }

   /* ------------------------------------------------------------ */
}