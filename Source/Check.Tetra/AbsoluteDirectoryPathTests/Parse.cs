using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class Parse
{
   /* ------------------------------------------------------------ */
   // public static AbsoluteDirectoryPath Parse(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //Parse
   //THEN
   //a_success_containing_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Parse(testPath.PathWithTrailingDirectorySeparator());

         //Assert
         return IsASuccessAnd(AssertMessages.ReturnValue,
                              (description,
                               actualPath) => AreEqual(description,
                                                       testPath,
                                                       actualPath),
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
   //Parse
   //THEN
   //a_success_containing_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Parse(testPath.PathWithoutTrailingDirectorySeparator());

         //Assert
         return IsASuccessAnd(AssertMessages.ReturnValue,
                              (description,
                               actualPath) => AreEqual(description,
                                                       testPath,
                                                       actualPath),
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
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_the_empty_string_WHEN_Parse_THEN_a_failure_is_returned()
   {
      //Arrange
      //Act
      var actual = AbsoluteDirectoryPath.Parse(string.Empty);

      //Assert
      Assert.That
            .IsAFailure(AssertMessages.ReturnValue,
                        Message.Create(IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(string.Empty,
                                                                                    HumanReadableName.AbsoluteDirectoryPath)),
                        actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_volume
   //WHEN
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_volume_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Parse(path);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                   HumanReadableName.AbsoluteDirectoryPath)),
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
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_path_with_an_invalid_volume_root_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Parse(path);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                   HumanReadableName.AbsoluteDirectoryPath)),
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
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_path_with_a_volume_root_and_an_invalid_component_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = AbsoluteDirectoryPath.Parse(path);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(path,
                                                                                                    HumanReadableName.AbsoluteDirectoryPath)),
                           actual);
      }

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}