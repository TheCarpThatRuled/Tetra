using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class Create
{
   /* ------------------------------------------------------------ */
   // AbsoluteFilePath Create(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_with_a_volume_root_but_without_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_with_a_volume_root_but_without_a_trailing_directory_separator_WHEN_Create_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = AbsoluteFilePath.Create(path);

         //Assert
         return AreEqual(path,
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_with_volume_root_and_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //an_ArgumentException_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_path_with_volume_root_and_a_trailing_directory_separator_WHEN_Create_THEN_an_ArgumentException_is_thrown()
   {
      static Property Property(string path)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            AbsoluteFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotValidBecauseAnAbsoluteFilePathMayNotEndWithADirectorySeparator(path,
                                                                         HumanReadableName.AbsoluteFilePath),
                                                                      "potentialPath"));
      }

      Arb.Register<Libraries.ValidPathWithAVolumeRootAndATrailingDirectorySeparator>();

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
         AbsoluteFilePath.Create(string.Empty);
      }
      catch (Exception e)
      {
         exception = e;
      }

      //Assert
      Assert.That
            .AnArgumentExceptionWasThrown(exception,
                                          ArgumentExceptionMessage(IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(string.Empty,
                                                                                                                   HumanReadableName.AbsoluteFilePath),
                                                                   "potentialPath"));
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_volume_root
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_volume_root_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            AbsoluteFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                         HumanReadableName.AbsoluteFilePath),
                                                                      "potentialPath"));
      }

      Arb.Register<Libraries.ValidPathWithoutARoot>();

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
            AbsoluteFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                         HumanReadableName.AbsoluteFilePath),
                                                                      "potentialPath"));
      }

      Arb.Register<Libraries.PathWithAnInvalidVolumeRoot>();

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
            AbsoluteFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(path,
                                                                         HumanReadableName.AbsoluteFilePath),
                                                                      "potentialPath"));
      }

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteFilePath Create(VolumeComponent volume,
   //                         IReadOnlyCollection<DirectoryComponent> directories,
   //                         FileComponent file)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_and_a_sequence_of_DirectoryComponents_and_a_FileComponent
   //WHEN
   //Create
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_and_a_FileComponent_WHEN_Create_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent          volume,
                               List<DirectoryComponent> directories,
                               FileComponent            file)
      {
         //Arrange
         var expected = ExpectedPath.Combine(volume,
                                             directories,
                                             file);

         //Act
         var actual = AbsoluteFilePath.Create(volume,
                                              directories,
                                              file);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<VolumeComponent, List<DirectoryComponent>, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}