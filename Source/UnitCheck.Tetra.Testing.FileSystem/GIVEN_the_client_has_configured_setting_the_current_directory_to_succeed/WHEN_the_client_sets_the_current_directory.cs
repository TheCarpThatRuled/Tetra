using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_configured_setting_the_current_directory_to_succeed;

[TestClass]
public class WHEN_the_client_sets_the_current_directory
{
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void THEN_the_current_directory_is_the_value_passed_to_SetCurrentDirectory_AND_a_none_is_returned()
   {
      static Property Property((VolumeRootedDirectoryPath initialPath, VolumeRootedDirectoryPath updatedPath) args, Message message)
      {
         //Arrange
         var fileSystem = FileSystem.Create(args.initialPath);
         fileSystem.SettingTheCurrentDirectoryShallSucceed();

         //Act
         var actual = fileSystem.SetCurrentDirectory(args.updatedPath);

         //Assert
         return AreEqual(args.updatedPath,
                         fileSystem.CurrentDirectory())
           .And(() => IsANone(actual));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueVolumeRootedDirectoryPaths>();

      Prop.ForAll<(VolumeRootedDirectoryPath, VolumeRootedDirectoryPath), Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}