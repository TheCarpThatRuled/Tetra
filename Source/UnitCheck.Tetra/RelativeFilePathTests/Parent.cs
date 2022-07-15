using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeFilePath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // Option<RelativeDirectoryPath> Parent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_containing_no_directories
   //WHEN
   //Parent
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_containing_no_directories_WHEN_Parent_THEN_a_none_is_returned()
   {
      static Property Property(FileComponent file)
      {
         //Arrange
         var path = RelativeFilePath.Create(Array.Empty<DirectoryComponent>(),
                                            file);

         //Act
         var actual = path.Parent();

         //Assert
         return IsANone(actual);
      }

      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_containing_more_than_one_directory
   //WHEN
   //Parent
   //THEN
   //a_RelativeDirectoryPath_containing_the_parent_directory_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_containing_more_than_one_directory_WHEN_Parent_THEN_a_RelativeDirectoryPath_containing_the_parent_directory_is_returned()
   {
      static Property Property(DirectoryComponent[] directories,
                               FileComponent        file)
      {
         //Arrange
         var expected = ExpectedPath.Combine(directories);

         var path = RelativeFilePath.Create(directories,
                                            file);

         //Act
         var actual = path.Parent();

         //Assert
         return IsASomeAnd(actualParent => expected == actualParent.Value(),
                           actual);
      }

      Arb.Register<Libraries.NonEmptyArrayOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}