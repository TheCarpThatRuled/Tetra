using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeFilePath)]
public class Create
{
   /* ------------------------------------------------------------ */
   // RelativeFilePath Create(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_or_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_root_or_a_trailing_directory_separator_WHEN_Create_THEN_a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = RelativeFilePath.Create(path);

         //Assert
         return AreEqual(path,
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithoutARootOrATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_but_with_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //an_ArgumentException_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_root_but_with_a_trailing_directory_separator_WHEN_Create_THEN_an_ArgumentException_is_thrown()
   {
      static Property Property(string path)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            RelativeFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotValidBecauseARelativeFilePathMayNotEndWithADirectorySeparator(path,
                                                                         HumanReadableName.RelativeFilePath),
                                                                      "potentialPath"));
      }

      Arb.Register<Libraries.ValidPathWithoutARootButWithATrailingDirectorySeparator>();

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
         RelativeFilePath.Create(string.Empty);
      }
      catch (Exception e)
      {
         exception = e;
      }

      //Assert
      Assert.That
            .AnArgumentExceptionWasThrown(exception,
                                          ArgumentExceptionMessage(IsNotValidBecauseARelativePathMayNotBeEmpty(string.Empty,
                                                                                                               HumanReadableName.RelativeFilePath),
                                                                   "potentialPath"));
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_without_a_root_but_with_an_invalid_component
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_path_without_a_root_but_with_an_invalid_component_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            RelativeFilePath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             ArgumentExceptionMessage(IsNotValidBecauseARelativePathMayNotContainTheCharacters(path,
                                                                         HumanReadableName.RelativeFilePath),
                                                                      "potentialPath"));
      }

      Arb.Register<Libraries.PathWithoutARootButWithAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // RelativeFilePath Create(IReadOnlyCollection<DirectoryComponent> directories,
   //                         FileComponent file)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_sequence_of_DirectoryComponents_and_a_FileComponent
   //WHEN
   //Create
   //THEN
   //a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_sequence_of_DirectoryComponents_and_a_FileComponent_WHEN_Create_THEN_a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(List<DirectoryComponent> directories,
                               FileComponent            file)
      {
         //Arrange
         var expected = ExpectedPath.Combine(directories,
                                             file);

         //Act
         var actual = RelativeFilePath.Create(directories,
                                              file);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<List<DirectoryComponent>, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}