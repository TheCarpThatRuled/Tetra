using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_not_created_the_FileSystem;

[TestClass]
public class WHEN_the_client_creates_the_FileSystem
{
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void THEN_the_current_directory_is_the_value_passed_in_on_creation()
   {
      static Property Property(VolumeRootedDirectoryPath path)
      {
         //Arrange
         //Act
         var fileSystem = FileSystem.Create(path);

         //Assert
         return AreEqual(path,
                         fileSystem.CurrentDirectory());
      }

      Arb.Register<Libraries.VolumeRootedDirectoryPath>();

      Prop.ForAll<VolumeRootedDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}