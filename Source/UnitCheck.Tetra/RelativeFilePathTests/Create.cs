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
      static Property Property(TestRelativeFilePath testPath)
      {
         //Arrange
         //Act
         var actual = RelativeFilePath.Create(testPath.PathWithoutTrailingDirectorySeparator());

         //Assert
         return AreEqual("Create",
                         testPath,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath>(Property)
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
      static Property Property(TestRelativeFilePath testPath)
         => AnArgumentExceptionWasThrown(() => RelativeFilePath.Create(testPath.PathWithTrailingDirectorySeparator()),
                                         IsNotValidBecauseARelativeFilePathMayNotEndWithADirectorySeparator(testPath.PathWithTrailingDirectorySeparator(),
                                                                                                            HumanReadableName.RelativeFilePath),
                                         "potentialPath");

      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath>(Property)
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
            .AnArgumentExceptionWasThrown(ArgumentExceptionMessage(IsNotValidBecauseARelativePathMayNotBeEmpty(string.Empty,
                                                                                                               HumanReadableName.RelativeFilePath),
                                                                   "potentialPath"),
                                          exception);
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
         => AnArgumentExceptionWasThrown(() => RelativeFilePath.Create(path),
                                         IsNotValidBecauseARelativePathMayNotContainTheCharacters(path,
                                                                                                  HumanReadableName.RelativeFilePath),
                                         "potentialPath");

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
      static Property Property(TestRelativeFilePath testPath)
      {
         //Arrange
         //Act
         var actual = RelativeFilePath.Create(testPath.Directories(),
                                              testPath.File());

         //Assert
         return AreEqual("Create",
                         testPath,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}