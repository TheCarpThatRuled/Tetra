using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
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
      static Property Property
      (
         TestRelativeDirectoryPath testPath
      )
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Parse(testPath.PathWithTrailingDirectorySeparator());

         //Assert
         return IsALeftAnd(AssertMessages.ReturnValue,
                           (
                              description,
                              actualPath
                           ) => AreEqual(description,
                                         testPath,
                                         actualPath),
                           actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath>(Property)
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
      static Property Property
      (
         TestRelativeDirectoryPath testPath
      )
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Parse(testPath.PathWithoutTrailingDirectorySeparator());

         //Assert
         return IsALeftAnd(AssertMessages.ReturnValue,
                           (
                              description,
                              actualPath
                           ) => AreEqual(description,
                                         testPath,
                                         actualPath),
                           actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath>(Property)
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
            .IsARight(AssertMessages.ReturnValue,
                      Message.Create(IsNotValidBecauseARelativePathMayNotBeEmpty(string.Empty,
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
      static Property Property
      (
         string path
      )
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Parse(path);

         //Assert
         return IsARight(AssertMessages.ReturnValue,
                         Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(path,
                                                                                                 HumanReadableName.RelativeDirectoryPath)),
                         actual);
      }

      Arb.Register<Libraries.PathWithoutARootButWithAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}