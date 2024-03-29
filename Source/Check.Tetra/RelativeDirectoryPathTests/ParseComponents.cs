﻿using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
public class ParseComponents
{
   /* ------------------------------------------------------------ */
   // protected static IEither<ISequence<DirectoryComponent>> ParseComponents(string potentialPath,
   //                                                                        string pathType)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_root_but_with_a_trailing_directory_separator
   //WHEN
   //ParseComponents
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
         var actual = TestPath.TestParseComponents(testPath.PathWithTrailingDirectorySeparator(),
                                                   nameof(TestPath));

         //Assert
         return IsALeftAnd(AssertMessages.ReturnValue,
                           (
                              description,
                              actualComponents
                           ) => AreEqual(description,
                                         testPath,
                                         actualComponents),
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
   //ParseComponents
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
         var actual = TestPath.TestParseComponents(testPath.PathWithoutTrailingDirectorySeparator(),
                                                   nameof(TestPath));

         //Assert
         return IsALeftAnd(AssertMessages.ReturnValue,
                           (
                              description,
                              actualComponents
                           ) => AreEqual(description,
                                         testPath,
                                         actualComponents),
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
            .IsARight(AssertMessages.ReturnValue,
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
   public void GIVEN_a_path_without_a_root_but_with_an_invalid_component_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property
      (
         string path
      )
      {
         //Arrange
         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   nameof(TestPath));

         //Assert
         return IsARight(AssertMessages.ReturnValue,
                         Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(path,
                                                                                                 nameof(TestPath))),
                         actual);
      }

      Arb.Register<Libraries.PathWithoutARootButWithAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   private sealed class TestPath : RelativeDirectoryPath
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public TestPath() : base(null!) { }
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static IEither<ISequence<DirectoryComponent>, Message> TestParseComponents
      (
         string potentialPath,
         string pathType
      )
         => ParseComponents(potentialPath,
                            pathType);

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}