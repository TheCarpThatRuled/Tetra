﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // Option<AbsoluteDirectoryPath> Parent();
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
      static Property Property
      (
         VolumeComponent volume
      )
      {
         //Arrange
         var path = AbsoluteDirectoryPath.Create(volume,
                                                 Array.Empty<DirectoryComponent>());

         //Act
         var actual = path.Parent();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
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
      static Property Property
      (
         VolumeComponent      volume,
         DirectoryComponent[] directories
      )
      {
         //Arrange
         var expected = TestAbsoluteDirectoryPath.Create(volume,
                                                         directories.SkipLast(1)
                                                                    .ToArray());

         var path = AbsoluteDirectoryPath.Create(volume,
                                                 directories);

         //Act
         var actual = path.Parent();

         //Assert
         return IsASomeAnd(AssertMessages.ReturnValue,
                           (
                              description,
                              actualParent
                           ) => AreEqual(description,
                                         expected,
                                         actualParent),
                           actual);
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.NonEmptyArrayOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}