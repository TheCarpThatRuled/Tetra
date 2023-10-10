using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
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
      static Property Property
      (
         TestRelativeDirectoryPath testPath
      )
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Create(testPath.PathWithTrailingDirectorySeparator());

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         testPath,
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
   //Create
   //THEN
   //a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_root_or_a_trailing_directory_separator_WHEN_Create_THEN_a_RelativeDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property
      (
         TestRelativeDirectoryPath testPath
      )
      {
         //Arrange
         //Act
         var actual = RelativeDirectoryPath.Create(testPath.PathWithoutTrailingDirectorySeparator());

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         testPath,
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
         exception = Option.Some(e);
      }

      //Assert
      Assert.That
            .AnArgumentExceptionWasThrown(ArgumentExceptionMessage(IsNotValidBecauseARelativePathMayNotBeEmpty(string.Empty,
                                                                                                               HumanReadableName.RelativeDirectoryPath),
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
      static Property Property
      (
         string path
      )
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
      static Property Property
      (
         DirectoryComponent[] directories
      )
      {
         //Arrange
         var expected = TestRelativeDirectoryPath.Create(directories);

         //Act
         var actual = RelativeDirectoryPath.Create(directories);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static RelativeDirectoryPath Create(ISequence<DirectoryComponent> directories)
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
      static Property Property
      (
         ISequence<DirectoryComponent> directories
      )
      {
         //Arrange
         var expected = TestRelativeDirectoryPath.Create(directories);

         //Act
         var actual = RelativeDirectoryPath.Create(directories);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.SequenceOfDirectoryComponents>();

      Prop.ForAll<ISequence<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}