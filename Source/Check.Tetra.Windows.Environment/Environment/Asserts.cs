using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check;

public sealed class Asserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Asserts The_file_system_contains_a_directory(string expected)
   {
      Assert.That
            .IsTrue($"The file system should contain <{expected}>",
                    Directory.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public Asserts The_file_system_contains_a_file(string expected)
   {
      Assert.That
            .IsTrue($"The file system should contain <{expected}>",
                    File.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public Asserts The_file_system_does_not_contain_a_directory(string expected)
   {
      Assert.That
            .IsFalse($"The file system should not contain <{expected}>",
                     Directory.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public Asserts The_file_system_does_not_contain_a_file(string expected)
   {
      Assert.That
            .IsFalse($"The file system should not contain <{expected}>",
                     File.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public Asserts The_file_system_has_a_current_directory_of(string expected)
   {
      Assert.That
            .AreEqualOrdinalIgnoreCase($"The file system should have a current directory of <{expected}>",
                                       expected[..^1],
                                       Directory.GetCurrentDirectory());

      return this;
   }

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Asserts Create(IFileSystem fileSystem)
      => new(fileSystem);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IFileSystem _fileSystem;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Asserts(IFileSystem fileSystem)
      => _fileSystem = fileSystem;

   /* ------------------------------------------------------------ */
}