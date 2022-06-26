using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // Option<VolumeRootedDirectoryPath> Parent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeRootedDirectoryPath_containing_just_a_volume
   //WHEN
   //Parent
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeRootedDirectoryPath_containing_just_a_volume_WHEN_Parent_THEN_a_none_is_returned()
   {
      static Property Property(Volume volume)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedDirectoryPath.Create(volume,
                                                                          Array.Empty<DirectoryComponent>());

         //Act
         var actual = volumeRootedDirectoryPath.Parent();

         //Assert
         return IsANone(actual);
      }

      Arb.Register<Libraries.Volume>();

      Prop.ForAll<Volume>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeRootedDirectoryPath_containing_a_volume_and_at_least_one_directory
   //WHEN
   //Parent
   //THEN
   //a_some_containing_a_VolumeRootedDirectoryPath_containing_the_parent_directory_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeRootedDirectoryPath_containing_a_volume_and_at_least_one_directory_WHEN_Parent_THEN_a_some_containing_a_VolumeRootedDirectoryPath_containing_the_parent_directory_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedDirectoryPath.Create(volume,
                                                                          directories);
         var expected = directories
                       .SkipLast(1)
                       .Select(x => x.Value())
                       .Prepend(volume.Value())
                       .Aggregate(string.Empty,
                                  (total,
                                   next) => $"{total}{next}{Path.DirectorySeparatorChar}");

         //Act
         var actual = volumeRootedDirectoryPath.Parent();

         //Assert
         return IsASomeAnd(actualParent => expected == actualParent.Value(),
                           actual);
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.NonEmptyArrayOfDirectoryComponents>();

      Prop.ForAll<Volume, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}