using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedFilePath)]
public class Create
{
   /* ------------------------------------------------------------ */
   // VolumeRootedFilePath Create(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_without_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_Create_THEN_a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = VolumeRootedFilePath.Create(path);

         //Assert
         return AreEqual(path,
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //an_ArgumentException_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_Create_THEN_an_ArgumentException_is_thrown()
   {
      static Property Property(string path)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            VolumeRootedFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                            ArgumentExceptionMessage(IsNotAValidVolumeRootedPathBecauseMayNotEndWithADirectorySeparator(path,
                                                                                                                                        HumanReadableName.VolumeRootedFilePath),
                                                                     "potentialPath"));
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootAndTrailingDirectorySeparator>();

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
         VolumeRootedFilePath.Create(string.Empty);
      }
      catch (Exception e)
      {
         exception = e;
      }

      //Assert
      Assert.That
            .AnArgumentExceptionWasThrown(exception,
                                          ArgumentExceptionMessage(IsNotAValidVolumeRootedPathBecauseMayNotBeEmpty(string.Empty,
                                                                                                                   HumanReadableName.VolumeRootedFilePath),
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
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            VolumeRootedFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotAValidVolumeRootedPathBecauseMustStartWithAVolumeLabel(path,
                                                                                                                                  HumanReadableName.VolumeRootedFilePath),
                                                                      "potentialPath"));
      }

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
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            VolumeRootedFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotAValidVolumeRootedPathBecauseMustStartWithAVolumeLabel(path,
                                                                                                                                  HumanReadableName.VolumeRootedFilePath),
                                                                      "potentialPath"));
      }

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
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            VolumeRootedFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotAValidVolumeRootedPathBecauseMayNotContainTheCharacters(path,
                                                                         HumanReadableName.VolumeRootedFilePath),
                                                                      "potentialPath"));
      }

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // VolumeRootedFilePath Create(Volume volume,
   //                             IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_and_a_sequence_of_DirectoryComponents
   //WHEN
   //Create
   //THEN
   //a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_WHEN_Create_THEN_a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume                   volume,
                               List<DirectoryComponent> directories,
                               FileComponent            file)
      {
         //Arrange
         var expected = directories
                       .Select(x => x.Value())
                       .Prepend(volume.Value())
                       .Append(file.Value())
                       .ToArray()
                       .ToDelimitedString(Path.DirectorySeparatorChar);

         //Act
         var actual = VolumeRootedFilePath.Create(volume,
                                                  directories,
                                                  file);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<Volume, List<DirectoryComponent>, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}