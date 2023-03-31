using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class Create
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Create(string potentialPath);
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_Create_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Create(testPath.PathWithTrailingDirectorySeparator());

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         testPath,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_without_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_Create_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Create(testPath.PathWithoutTrailingDirectorySeparator());

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         testPath,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath>(Property)
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
         AbsoluteDirectoryPath.Create(string.Empty);
      }
      catch (Exception e)
      {
         exception = Option.Some(e);
      }

      //Assert
      Assert.That
            .AnArgumentExceptionWasThrown(ArgumentExceptionMessage(IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(string.Empty,
                                                                                                                HumanReadableName.AbsoluteDirectoryPath),
                                                                   "potentialPath"),
                                          exception);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_volume
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_volume_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(string path)
         => AnArgumentExceptionWasThrown(() => AbsoluteDirectoryPath.Create(path),
                                         IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                  HumanReadableName.AbsoluteDirectoryPath),
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
         => AnArgumentExceptionWasThrown(() => AbsoluteDirectoryPath.Create(path),
                                         IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                  HumanReadableName.AbsoluteDirectoryPath),
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
         => AnArgumentExceptionWasThrown(() => AbsoluteDirectoryPath.Create(path),
                                         IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(path,
                                                                                                   HumanReadableName.AbsoluteDirectoryPath),
                                         "potentialPath");

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Create(VolumeComponent volume,
   //                              params DirectoryComponent[] directories);
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_and_an_Array_of_DirectoryComponents
   //WHEN
   //Create
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_an_Array_of_DirectoryComponents_WHEN_Create_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Create(testPath.Volume(),
                                                   testPath.Directories()
                                                           .ToArray());

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         testPath,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Create(VolumeComponent volume,
   //                              ISequence<DirectoryComponent> directories);
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_and_a_sequence_of_DirectoryComponents
   //WHEN
   //Create
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_WHEN_Create_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Create(testPath.Volume(),
                                                   testPath.Directories());

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         testPath,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}