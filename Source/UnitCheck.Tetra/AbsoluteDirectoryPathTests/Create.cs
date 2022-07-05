﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class Create
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Create(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_Create_THEN_a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Create(path);

         //Assert
         return AreEqual(path,
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootAndTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_without_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_Create_THEN_a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Create(path);

         //Assert
         return AreEqual($"{path}{Path.DirectorySeparatorChar}",
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //the_empty_string
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_the_empty_string_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      //Arrange
      var exception = Option<Exception>.None();

      //Act
      try
      {
         AbsoluteDirectoryPath.Create(string.Empty);
      }
      catch (Exception e)
      {
         exception = e;
      }

      //Assert
      Assert.That
            .AnArgumentExceptionWasThrown(exception,
                                          ArgumentExceptionMessage(IsNotAValidVolumeRootedPathBecauseMayNotBeEmpty(string.Empty,
                                                                                                                   HumanReadableName.AbsoluteDirectoryPath),
                                                                   "potentialPath"));
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_volume
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_volume_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
         => AnArgumentExceptionWasThrown(() => AbsoluteDirectoryPath.Create(path),
                                         IsNotAValidVolumeRootedPathBecauseMustStartWithAVolumeLabel(path,
                                                                                                     HumanReadableName.AbsoluteDirectoryPath),
                                         "potentialPath");

      Arb.Register<Libraries.ValidPathWithoutRoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }
/* ------------------------------------------------------------ */

   //GIVEN
   //a_path_with_an_invalid_volume_root
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_path_with_an_invalid_volume_root_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
         => AnArgumentExceptionWasThrown(() => AbsoluteDirectoryPath.Create(path),
                                         IsNotAValidVolumeRootedPathBecauseMustStartWithAVolumeLabel(path,
                                                                                                     HumanReadableName.AbsoluteDirectoryPath),
                                         "potentialPath");

      Arb.Register<Libraries.PathWithInvalidVolumeRoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_with_a_volume_root_and_an_invalid_component
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_path_with_a_volume_root_and_an_invalid_component_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
         => AnArgumentExceptionWasThrown(() => AbsoluteDirectoryPath.Create(path),
                                         IsNotAValidVolumeRootedPathBecauseMayNotContainTheCharacters(path,
                                                                                                      HumanReadableName.AbsoluteDirectoryPath),
                                         "potentialPath");

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Create(Volume volume,
   //                              IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_and_a_sequence_of_DirectoryComponents
   //WHEN
   //Create
   //THEN
   //a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_WHEN_Create_THEN_a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume                   volume,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var expected = directories
                       .Select(x => x.Value())
                       .Prepend(volume.Value())
                       .ToArray()
                       .ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);

         //Act
         var actual = AbsoluteDirectoryPath.Create(volume,
                                                   directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<Volume, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}