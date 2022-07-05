using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_configured_setting_the_current_directory_to_fail;

[TestClass]
public class WHEN_the_client_sets_the_current_directory
{
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void THEN_the_current_directory_is_the_directory_passed_in_on_construction_AND_a_failure_containing_the_message_set_up_is_returned()
   {
      static Property Property((AbsoluteDirectoryPath initialPath, AbsoluteDirectoryPath updatedPath) args, Message message)
      {
         //Arrange
         var fileSystem = FileSystem.From(args.initialPath);
         fileSystem.SettingTheCurrentDirectoryShallFail(message);

         //Act
         var actual = fileSystem.SetCurrentDirectory(args.updatedPath);

         //Assert
         return AreEqual(args.initialPath,
                         fileSystem.CurrentDirectory())
           .And(() => IsASome(message,
                              actual));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueAbsoluteDirectoryPaths>();

      Prop.ForAll<(AbsoluteDirectoryPath, AbsoluteDirectoryPath), Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}