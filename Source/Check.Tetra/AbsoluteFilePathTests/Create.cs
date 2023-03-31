using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class Create
{
   /* ------------------------------------------------------------ */
   // static AbsoluteFilePath Create(string potentialPath);
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_with_a_volume_root_but_without_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_with_a_volume_root_but_without_a_trailing_directory_separator_WHEN_Create_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteFilePath testPath)
      {
         //Arrange
         //Act
         var actual = AbsoluteFilePath.Create(testPath.PathWithoutTrailingDirectorySeparator());

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         testPath,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_with_volume_root_and_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //an_ArgumentException_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_path_with_volume_root_and_a_trailing_directory_separator_WHEN_Create_THEN_an_ArgumentException_is_thrown()
   {
      static Property Property(TestAbsoluteFilePath path)
         => AnArgumentExceptionWasThrown(() => AbsoluteFilePath.Create(path.PathWithTrailingDirectorySeparator()),
                                         IsNotValidBecauseAnAbsoluteFilePathMayNotEndWithADirectorySeparator(path.PathWithTrailingDirectorySeparator(),
                                                                                                             HumanReadableName.AbsoluteFilePath),
                                         "potentialPath");

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
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
         AbsoluteFilePath.Create(string.Empty);
      }
      catch (Exception e)
      {
         exception = Option.Some(e);
      }

      //Assert
      Assert.That
            .AnArgumentExceptionWasThrown(ArgumentExceptionMessage(IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(string.Empty,
                                                                                                                HumanReadableName.AbsoluteFilePath),
                                                                   "potentialPath"),
                                          exception);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_volume_root
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_volume_root_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
         => AnArgumentExceptionWasThrown(() => AbsoluteFilePath.Create(path),
                                         IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                  HumanReadableName.AbsoluteFilePath),
                                         "potentialPath");

      Arb.Register<Libraries.ValidPathWithoutARoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_with_an_invalid_volume_root
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_path_with_an_invalid_volume_root_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
         => AnArgumentExceptionWasThrown(() => AbsoluteFilePath.Create(path),
                                         IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                  HumanReadableName.AbsoluteFilePath),
                                         "potentialPath");

      Arb.Register<Libraries.PathWithAnInvalidVolumeRoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_with_a_volume_root_and_an_invalid_component
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_path_with_a_volume_root_and_an_invalid_component_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
         => AnArgumentExceptionWasThrown(() => AbsoluteFilePath.Create(path),
                                         IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(path,
                                                                                                   HumanReadableName.AbsoluteFilePath),
                                         "potentialPath");

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // static AbsoluteFilePath Create(VolumeComponent               volume,
   //                                ISequence<DirectoryComponent> directories,
   //                                FileComponent                 file);
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_and_a_sequence_of_DirectoryComponents_and_a_FileComponent
   //WHEN
   //Create
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_and_a_FileComponent_WHEN_Create_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteFilePath testPath)
      {
         //Arrange
         //Act
         var actual = AbsoluteFilePath.Create(testPath.Volume(),
                                              testPath.Directories(),
                                              testPath.File());

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         testPath,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}