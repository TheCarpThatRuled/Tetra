using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // Option<RelativeDirectoryPath> Parent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_containing_just_one_directory
   //WHEN
   //Parent
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeDirectoryPath_containing_just_one_directory_WHEN_Parent_THEN_a_none_is_returned()
   {
      static Property Property(DirectoryComponent directory)
      {
         //Arrange
         var path = RelativeDirectoryPath.Create(directory);

         //Act
         var actual = path.Parent();

         //Assert
         return IsANone(actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_containing_more_than_one_directory
   //WHEN
   //Parent
   //THEN
   //a_some_containing_a_RelativeDirectoryPath_containing_the_parent_directory_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_containing_a_volume_and_at_least_one_directory_WHEN_Parent_THEN_a_some_containing_a_RelativeDirectoryPath_containing_the_parent_directory_is_returned()
   {
      static Property Property(DirectoryComponent[] directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(directories.SkipLast(1));

         var path = RelativeDirectoryPath.Create(directories);

         //Act
         var actual = path.Parent();

         //Assert
         return IsASomeAnd(actualParent => expected == actualParent.Value(),
                           actual);
      }

      Arb.Register<Libraries.ArrayOfAtLeastTwoDirectoryComponents>();

      Prop.ForAll<DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}