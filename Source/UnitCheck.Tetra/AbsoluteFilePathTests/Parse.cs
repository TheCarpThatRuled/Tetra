using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class Parse
{
   /* ------------------------------------------------------------ */
   // AbsoluteFilePath Parse(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_without_a_trailing_directory_separator
   //WHEN
   //Parse
   //THEN
   //a_success_containing_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = AbsoluteFilePath.Parse(path);

         //Assert
         return IsASuccessAnd(actualPath => path
                                         == actualPath.Content()
                                                      .Value(),
                              actual);
      }

      Arb.Register<Libraries.ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = AbsoluteFilePath.Parse(path);

         //Assert
         return IsAFailure(Message.Create(IsNotValidBecauseAnAbsoluteFilePathMayNotEndWithADirectorySeparator(path,
                                                                                                             HumanReadableName.AbsoluteFilePath)),
                           actual);
      }

      Arb.Register<Libraries.ValidPathWithAVolumeRootAndATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

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
      var actual = AbsoluteFilePath.Parse(string.Empty);

      //Assert
      Assert.That
            .IsAFailure(Message.Create(IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(string.Empty,
                                                                                       HumanReadableName.AbsoluteFilePath)),
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
         var actual = AbsoluteFilePath.Parse(path);

         //Assert
         return IsAFailure(Message.Create(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                      HumanReadableName.AbsoluteFilePath)),
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
         var actual = AbsoluteFilePath.Parse(path);

         //Assert
         return IsAFailure(Message.Create(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(path,
                                                                                                      HumanReadableName.AbsoluteFilePath)),
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
         var actual = AbsoluteFilePath.Parse(path);

         //Assert
         return IsAFailure(Message.Create(IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(path,
                                                                                                       HumanReadableName.AbsoluteFilePath)),
                           actual);
      }

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}