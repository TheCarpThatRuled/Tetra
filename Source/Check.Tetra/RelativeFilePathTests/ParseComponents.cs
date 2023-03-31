using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.RelativeFilePath)]
public class ParseComponents
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   private sealed class TestPath : RelativeFilePath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static IResult<(ISequence<DirectoryComponent> directories, FileComponent file), Message> TestParseComponents(string potentialPath,
         string                                                                                                                  pathType)
         => ParseComponents(potentialPath,
                            pathType);

      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public TestPath() : base(null!,
                               null!) { }

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // protected static Result(ISequence<DirectoryComponent> directories, FileComponent file) ParseComponents(string potentialPath,
   //                                                                                                        string pathType)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_or_a_trailing_directory_separator
   //WHEN
   //ParseComponents
   //THEN
   //a_success_containing_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_path_without_a_root_or_a_trailing_directory_separator_WHEN_ParseComponents_THEN_a_success_containing_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestRelativeFilePath testPath)
      {
         //Arrange
         //Act
         var actual = TestPath.TestParseComponents(testPath.PathWithoutTrailingDirectorySeparator(),
                                                   nameof(TestPath));

         //Assert
         return IsASuccessAnd(AssertMessages.ReturnValue,
                              (description,
                               actualComponents) => AreEqual(description,
                                                             testPath,
                                                             actualComponents),
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
   //ParseComponents
   //THEN
   //a_failure_isReturned

   [TestMethod]
   public void
      GIVEN_a_valid_path_without_a_root_but_with_a_trailing_directory_separator_WHEN_ParseComponents_THEN_a_success_containing_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   nameof(TestPath));

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseARelativeFilePathMayNotEndWithADirectorySeparator(path,
                                                                                                             nameof(TestPath))),
                           actual);
      }

      Arb.Register<Libraries.ValidPathWithoutARootButWithATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //the_empty_string
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_the_empty_string_WHEN_ParseComponents_THEN_a_failure_is_returned()
   {
      //Arrange
      //Act
      var actual = TestPath.TestParseComponents(string.Empty,
                                                nameof(TestPath));

      //Assert
      Assert.That
            .IsAFailure(AssertMessages.ReturnValue,
                        Message.Create(IsNotValidBecauseARelativePathMayNotBeEmpty(string.Empty,
                                                                                   nameof(TestPath))),
                        actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_without_a_root_but_with_an_invalid_component
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_path_without_a_root_but_with_an_invalid_component_WHEN_ParseComponents_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   nameof(TestPath));

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(path,
                                                                                                   nameof(TestPath))),
                           actual);
      }

      Arb.Register<Libraries.PathWithoutARootButWithAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}