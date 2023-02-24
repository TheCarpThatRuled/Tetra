using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_a_directory_exists;

[TestClass]
public class WHEN_the_client_creates_a_different_directory
{
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void THEN_a_none_is_returned_AND_the_directory_and_all_its_parents_exist()
   {
      static Property Property((AbsoluteDirectoryPath currentDirectory, AbsoluteDirectoryPath secondDirectory, AbsoluteDirectoryPath thirdDirectory) args)
      {
         //Arrange
         var fileSystem = FileSystem.From(args.currentDirectory);
         fileSystem.Create(args.secondDirectory);

         //Act
         var actual = fileSystem.Create(args.thirdDirectory);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(IsTrue("Directories created",
                       args.secondDirectory
                           .Ancestry()
                           .Concat(args
                                  .thirdDirectory
                                  .Ancestry())
                           .All(fileSystem.Exists)));
      }

      Arb.Register<Libraries.ThreeUniqueAbsoluteDirectoryPaths>();

      Prop.ForAll<(AbsoluteDirectoryPath, AbsoluteDirectoryPath, AbsoluteDirectoryPath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}