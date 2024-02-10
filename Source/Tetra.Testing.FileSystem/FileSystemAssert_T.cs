using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class FileSystemAsserts<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string     _characterisation;
   private readonly FileSystem _fileSystem;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystemAsserts
   (
      string     characterisation,
      FileSystem fileSystem,
      Func<T>    next
   ) : base(next)
   {
      _characterisation = characterisation;
      _fileSystem       = fileSystem;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileSystemAsserts<T> Create
   (
      string     characterisation,
      FileSystem fileSystem,
      Func<T>    next
   )
      => new(characterisation,
             fileSystem,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FileSystemAsserts<T> ADirectoryDoesNotExists
   (
      AbsoluteDirectoryPath expected
   )
   {
      Assert
        .That
        .IsFalse($"{_characterisation}: The directory {expected} should exist",
                 _fileSystem.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemAsserts<T> ADirectoryExists
   (
      AbsoluteDirectoryPath expected
   )
   {
      Assert
        .That
        .IsTrue($"{_characterisation}: The directory {expected} should exist",
                _fileSystem.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ * /

   public FileSystemAsserts<T> ADirectoryHasTheSubDirectories
   (
      AbsoluteDirectoryPath expected,
      Sequence<AbsoluteDirectoryPath> expectedSubDirectories
   )
   {
      Assert
        .That
        .IsALeftAnd($"{_characterisation}: The directory {expected} should successfully retrieve sub-directories",
                    (
                       _,
                       actual
                    ) => Assert
                        .That
                        .AreSetEqual(
                            $"{_characterisation}: The directory {expected} should have sub-directories set equal to {{ {expectedSubDirectories.Aggregate("", (total, next) => $"{total}{next}, ")}}}",
                            expectedSubDirectories,
                            actual),
                    _fileSystem.SubDirectoriesOf(expected));

      return this;
   }

   /* ------------------------------------------------------------ * /

   public FileSystemAsserts<T> ADirectoryHasTheSubFiles
   (
      AbsoluteDirectoryPath expected,
      Sequence<AbsoluteFilePath> expectedSubFiles
   )
   {
      Assert
        .That
        .IsALeftAnd($"{_characterisation}: The directory {expected} should successfully retrieve sub-files",
                    (
                       _,
                       actual
                    ) => Assert
                        .That
                        .AreSetEqual(
                            $"{_characterisation}: The directory {expected} should have sub-files set equal to {{ {expectedSubFiles.Aggregate("", (total, next) => $"{total}{next}, ")}}}",
                            expectedSubFiles,
                            actual),
                    _fileSystem.SubFilesOf(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemAsserts<T> AFileExists
   (
      AbsoluteFilePath expected
   )
   {
      Assert
        .That
        .IsTrue($"{_characterisation}: The file {expected} should exist",
                _fileSystem.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemAsserts<T> AFileDoesNotExists
   (
      AbsoluteFilePath expected
   )
   {
      Assert
        .That
        .IsFalse($"{_characterisation}: The file {expected} should exist",
                 _fileSystem.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemAsserts<T> ExistsAndDoesNotExistsAreInverses
   (
      AbsoluteDirectoryPath path
   )
   {
      Assert
        .That
        .IsTrue($"{_characterisation}: Exists and DoesNotExist are inverse for the directory {path}",
                _fileSystem.Exists(path) != _fileSystem.DoesNotExist(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemAsserts<T> ExistsAndDoesNotExistsAreInverses
   (
      AbsoluteFilePath path
   )
   {
      Assert
        .That
        .IsTrue($"{_characterisation}: Exists and DoesNotExist are inverse for the file {path}",
                _fileSystem.Exists(path) != _fileSystem.DoesNotExist(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemAsserts<T> TheCurrentDirectoryIs
   (
      AbsoluteDirectoryPath expected
   )
   {
      Assert
        .That
        .AreEqual($"{_characterisation}: The directory {expected} should exist",
                  expected,
                  _fileSystem.CurrentDirectory());

      return this;
   }

   /* ------------------------------------------------------------ */
}