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
public class Create
{
   /* ------------------------------------------------------------ */
   // public static RelativeDirectoryPath Create(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_but_with_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_root_but_with_a_trailing_directory_separator_WHEN_Create_THEN_a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Create(path);

         //Assert
         return AreEqual(path,
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithoutARootButWithATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_or_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_root_or_a_trailing_directory_separator_WHEN_Create_THEN_a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Create(path);

         //Assert
         return AreEqual($"{path}{Path.DirectorySeparatorChar}",
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithoutARootOrATrailingDirectorySeparator>();

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
         RelativeDirectoryPath.Create(string.Empty);
      }
      catch (Exception e)
      {
         exception = e;
      }

      //Assert
      Assert.That
            .AnArgumentExceptionWasThrown(exception,
                                          ArgumentExceptionMessage(IsNotValidBecauseARelativePathMayNotBeEmpty(string.Empty,
                                                                                                               HumanReadableName.RelativeDirectoryPath),
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
         => AnArgumentExceptionWasThrown(() => RelativeDirectoryPath.Create(path),
                                         IsNotValidBecauseARelativePathMayNotContainTheCharacters(path,
                                                                                                  HumanReadableName.RelativeDirectoryPath),
                                         "potentialPath");

      Arb.Register<Libraries.PathWithoutARootButWithAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static RelativeDirectoryPath Create(params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_Array_of_DirectoryComponents
   //WHEN
   //Create
   //THEN
   //a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_an_Array_of_DirectoryComponents_WHEN_Create_THEN_a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(DirectoryComponent[] directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(directories);

         //Act
         var actual = RelativeDirectoryPath.Create(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
   // public static RelativeDirectoryPath Create(IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_sequence_of_DirectoryComponents
   //WHEN
   //Create
   //THEN
   //a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_sequence_of_DirectoryComponents_WHEN_Create_THEN_a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(List<DirectoryComponent> directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(directories);

         //Act
         var actual = RelativeDirectoryPath.Create(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}