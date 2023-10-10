using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class ParseComponents
{
   /* ------------------------------------------------------------ */
   // IEither<(VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file), Message> ParseComponents(string potentialPath,
   //                                                                                                               string pathType)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_without_a_trailing_directory_separator
   //WHEN
   //ParseComponents
   //THEN
   //a_success_containing_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_ParseComponents_THEN_a_success_containing_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property
      (
         TestAbsoluteFilePath testPath
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

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_ParseComponents_THEN_a_failure_is_returned()
   {
      static Property Property
      (
         TestAbsoluteFilePath testPath
      )
      {
         //Arrange
         //Act
         var actual = TestPath.TestParseComponents(testPath.PathWithTrailingDirectorySeparator(),
                                                   nameof(TestPath));

         //Assert
         return IsARight(AssertMessages.ReturnValue,
                         Message.Create(IsNotValidBecauseAnAbsoluteFilePathMayNotEndWithADirectorySeparator(testPath.PathWithTrailingDirectorySeparator(),
                                                                                                            nameof(TestPath))),
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
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
                      Message.Create(IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(string.Empty,
                                                                                  nameof(TestPath))),
                      actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_volume
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_volume_WHEN_ParseComponents_THEN_a_failure_is_returned()
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
                         Message.Create(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                 nameof(TestPath))),
                         actual);
      }

      Arb.Register<Libraries.ValidPathWithoutARoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_with_an_invalid_volume_root
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_path_with_an_invalid_volume_root_WHEN_ParseComponents_THEN_a_failure_is_returned()
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
                         Message.Create(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                 nameof(TestPath))),
                         actual);
      }

      Arb.Register<Libraries.PathWithAnInvalidVolumeRoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_with_a_volume_root_and_an_invalid_component
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_path_with_a_volume_root_and_an_invalid_component_WHEN_ParseComponents_THEN_a_failure_is_returned()
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
                         Message.Create(IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(path,
                                                                                                  nameof(TestPath))),
                         actual);
      }

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   private sealed class TestPath : AbsoluteFilePath
   {
      /* ------------------------------------------------------------ */
      // Constructor
      /* ------------------------------------------------------------ */

      private TestPath()
         : base(null!,
                null!,
                null!) { }
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static IEither<(VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file), Message> TestParseComponents
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