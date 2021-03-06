using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
public class Parse
{
   /* ------------------------------------------------------------ */
   // public static RelativeDirectoryPath Parse(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_but_with_a_trailing_directory_separator
   //WHEN
   //Parse
   //THEN
   //a_success_containing_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_path_without_a_root_but_with_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Parse(path);

         //Assert
         return IsASuccessAnd(actualPath => path
                                         == actualPath.Content()
                                                      .Value(),
                              actual);
      }

      Arb.Register<Libraries.ValidPathWithoutARootButWithATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_or_a_trailing_directory_separator
   //WHEN
   //Parse
   //THEN
   //a_success_containing_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_path_without_a_root_or_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Parse(path);

         //Assert
         return IsASuccessAnd(actualPath => $"{path}{Path.DirectorySeparatorChar}"
                                         == actualPath.Content()
                                                      .Value(),
                              actual);
      }

      Arb.Register<Libraries.ValidPathWithoutARootOrATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

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
      var actual = RelativeDirectoryPath.Parse(string.Empty);

      //Assert
      Assert.That
            .IsAFailure(Message.Create(IsNotValidBecauseARelativePathMayNotBeEmpty(string.Empty,
                                                                                   HumanReadableName.RelativeDirectoryPath)),
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
         //Act
         var actual = RelativeDirectoryPath.Parse(path);

         //Assert
         return IsAFailure(Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(path,
                                                                                                   HumanReadableName.RelativeDirectoryPath)),
                           actual);
      }

      Arb.Register<Libraries.PathWithoutARootButWithAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}