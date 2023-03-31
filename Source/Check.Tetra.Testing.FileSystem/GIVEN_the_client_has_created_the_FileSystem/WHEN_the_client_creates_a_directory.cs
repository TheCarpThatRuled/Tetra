using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_created_the_FileSystem;

[TestClass]
public class WHEN_the_client_creates_a_directory
{
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void THEN_a_none_is_returned_AND_the_directory_and_all_its_parents_exist()
   {
      static Property Property((AbsoluteDirectoryPath currentDirectory, AbsoluteDirectoryPath otherDirectory) args)
      {
         //Arrange
         var fileSystem = FileSystem.From(args.currentDirectory);

         //Act
         var actual = fileSystem.Create(args.otherDirectory);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           actual)
           .And(IsTrue("Directories created",
                       args.otherDirectory
                           .Ancestry()
                           .All(fileSystem.Exists)));
      }

      Arb.Register<Libraries.TwoUniqueAbsoluteDirectoryPaths>();

      Prop.ForAll<(AbsoluteDirectoryPath, AbsoluteDirectoryPath )>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}