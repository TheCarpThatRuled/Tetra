using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_created_the_FileSystem;

[TestClass]
public class WHEN_the_client_sets_the_current_directory
{
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void THEN_the_current_directory_is_the_value_passed_to_SetCurrentDirectory_AND_a_none_is_returned()
   {
      static Property Property
      (
         (AbsoluteDirectoryPath initialPath, AbsoluteDirectoryPath updatedPath) args
      )
      {
         //Arrange
         var fileSystem = FileSystem.From(args.initialPath);

         //Act
         var actual = fileSystem.SetCurrentDirectory(args.updatedPath);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(AreEqual("Current directory",
                         args.updatedPath,
                         fileSystem.CurrentDirectory()));
      }

      Arb.Register<Libraries.TwoUniqueAbsoluteDirectoryPaths>();

      Prop.ForAll<(AbsoluteDirectoryPath, AbsoluteDirectoryPath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}