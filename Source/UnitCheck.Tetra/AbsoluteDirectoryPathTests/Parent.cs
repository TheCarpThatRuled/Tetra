using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // Option<AbsoluteDirectoryPath> Parent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_containing_just_a_volume
   //WHEN
   //Parent
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_containing_just_a_volume_WHEN_Parent_THEN_a_none_is_returned()
   {
      static Property Property(VolumeComponent volume)
      {
         //Arrange
         var path = AbsoluteDirectoryPath.Create(volume,
                                                 Array.Empty<DirectoryComponent>());

         //Act
         var actual = path.Parent();

         //Assert
         return IsANone(actual);
      }

      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_containing_a_volume_and_at_least_one_directory
   //WHEN
   //Parent
   //THEN
   //a_some_containing_an_AbsoluteDirectoryPath_containing_the_parent_directory_is_returned

   [TestMethod]
   public void
      GIVEN_an_AbsoluteDirectoryPath_containing_a_volume_and_at_least_one_directory_WHEN_Parent_THEN_a_some_containing_an_AbsoluteDirectoryPath_containing_the_parent_directory_is_returned()
   {
      static Property Property(VolumeComponent      volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(volume,
                                             directories.SkipLast(1));

         var path = AbsoluteDirectoryPath.Create(volume,
                                                 directories);

         //Act
         var actual = path.Parent();

         //Assert
         return IsASomeAnd(actualParent => expected == actualParent.Value(),
                           actual);
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.NonEmptyArrayOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}