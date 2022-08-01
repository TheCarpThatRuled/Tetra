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
public class Parse
{
   /* ------------------------------------------------------------ */
   // RelativeFilePath Parse(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_or_a_trailing_directory_separator
   //WHEN
   //Parse
   //THEN
   //a_success_containing_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_path_without_a_root_or_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestRelativeFilePath testPath)
      {
         //Arrange
         //Act
         var actual = RelativeFilePath.Parse(testPath.PathWithoutTrailingDirectorySeparator());

         //Assert
         return IsASuccessAnd(AssertMessages.ReturnValue,
                              (description,
                               actualPath) => AreEqual(description,
                                                       testPath,
                                                       actualPath.Content()),
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
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_path_without_a_root_but_with_a_trailing_directory_separator_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(TestRelativeFilePath testPath)
      {
         //Arrange
         //Act
         var actual = RelativeFilePath.Parse(testPath.PathWithTrailingDirectorySeparator());

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseARelativeFilePathMayNotEndWithADirectorySeparator(testPath.PathWithTrailingDirectorySeparator(),
                                                                                                             HumanReadableName.RelativeFilePath)),
                           actual);
      }

      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //the_empty_string
   //WHEN
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_the_empty_string_WHEN_Parse_THEN_a_failure_is_returned()
   {
      //Arrange
      //Act
      var actual = RelativeFilePath.Parse(string.Empty);

      //Assert
      Assert.That
            .IsAFailure(AssertMessages.ReturnValue,
                        Message.Create(IsNotValidBecauseARelativePathMayNotBeEmpty(string.Empty,
                                                                                   HumanReadableName.RelativeFilePath)),
                        actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_without_a_root_but_with_an_invalid_component
   //WHEN
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_path_without_a_root_but_with_an_invalid_component_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var actual = RelativeFilePath.Parse(path);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(path,
                                                                                                   HumanReadableName.RelativeFilePath)),
                           actual);
      }

      Arb.Register<Libraries.PathWithoutARootButWithAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}