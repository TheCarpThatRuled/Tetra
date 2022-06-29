using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_created_the_FileSystem;

[TestClass]
public class WHEN_the_client_checks_if_a_directory_exists
{
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void AND_the_directory_is_the_current_directory_THEN_true_is_returned()
   {
      static Property Property(VolumeRootedDirectoryPath currentDirectory)
      {
         //Arrange
         var fileSystem = FileSystem.Create(currentDirectory);

         //Act
         var actual = fileSystem.Exists(currentDirectory);

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.VolumeRootedDirectoryPath>();

      Prop.ForAll<VolumeRootedDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   [TestMethod]
   public void AND_the_directory_is_not_the_current_directory_THEN_false_is_returned()
   {
      static Property Property((VolumeRootedDirectoryPath currentDirectory, VolumeRootedDirectoryPath otherDirectory) args)
      {
         //Arrange
         var fileSystem = FileSystem.Create(args.currentDirectory);

         //Act
         var actual = fileSystem.Exists(args.otherDirectory);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.TwoUniqueVolumeRootedDirectoryPaths>();

      Prop.ForAll<(VolumeRootedDirectoryPath, VolumeRootedDirectoryPath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}