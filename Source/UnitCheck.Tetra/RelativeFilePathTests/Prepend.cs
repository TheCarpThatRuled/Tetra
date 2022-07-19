using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeFilePath)]
public class Prepend
{
   /* ------------------------------------------------------------ */
   // public RelativeFilePath Prepend(params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_an_Array_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property((DirectoryComponent[] directories,
                                  FileComponent file) relativeFilePath,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(directories.Concat(relativeFilePath.directories),
                                             relativeFilePath.file);

         var path = RelativeFilePath.Create(relativeFilePath.directories,
                                            relativeFilePath.file);

         //Act
         var actual = path.Prepend(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.RelativeFilePathAsComponents>();

      Prop.ForAll<(DirectoryComponent[], FileComponent), DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeFilePath Prepend(IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_a_sequence_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property((DirectoryComponent[] directories,
                                  FileComponent file) relativeFilePath,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(directories.Concat(relativeFilePath.directories),
                                             relativeFilePath.file);

         var path = RelativeFilePath.Create(relativeFilePath.directories,
                                            relativeFilePath.file);

         //Act
         var actual = path.Prepend(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.RelativeFilePathAsComponents>();

      Prop.ForAll<(DirectoryComponent[], FileComponent), List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeFilePath Prepend(RelativeDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_a_RelativeDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_a_RelativeDirectoryPath_WHEN_Prepend_THEN_a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property((DirectoryComponent[] directories,
                                  FileComponent file) relativeFilePath,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(directories.Concat(relativeFilePath.directories),
                                             relativeFilePath.file);

         var initialPath = RelativeFilePath.Create(relativeFilePath.directories,
                                                   relativeFilePath.file);

         var path = RelativeDirectoryPath.Create(directories);

         //Act
         var actual = initialPath.Prepend(path);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.RelativeFilePathAsComponents>();

      Prop.ForAll<(DirectoryComponent[], FileComponent), List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Prepend(VolumeComponent path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_a_VolumeComponent
   //WHEN
   //Prepend
   //THEN
   //a_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_a_VolumeComponent_WHEN_Prepend_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property((DirectoryComponent[] directories,
                                  FileComponent file) relativeFilePath,
                               VolumeComponent      volume)
      {
         //Arrange
         var expected = ExpectedPath.Combine(volume,
                                             relativeFilePath.directories,
                                             relativeFilePath.file);

         var path = RelativeFilePath.Create(relativeFilePath.directories,
                                            relativeFilePath.file);

         //Act
         var actual = path.Prepend(volume);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.RelativeFilePathAsComponents>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<(DirectoryComponent[], FileComponent), VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Prepend(AbsoluteDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_a_AbsoluteDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //a_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_a_AbsoluteDirectoryPath_WHEN_Prepend_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property((DirectoryComponent[] directories,
                                  FileComponent file) relativeFilePath,
                               (VolumeComponent volume,
                                  DirectoryComponent[] directories) absoluteDirectoryPath)
      {
         //Arrange
         var expected = ExpectedPath.Combine(absoluteDirectoryPath.volume,
                                             absoluteDirectoryPath.directories
                                                                  .Concat(relativeFilePath.directories),
                                             relativeFilePath.file);

         var child = RelativeFilePath.Create(relativeFilePath.directories,
                                             relativeFilePath.file);
         var parent = AbsoluteDirectoryPath.Create(absoluteDirectoryPath.volume,
                                                   absoluteDirectoryPath.directories);

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.RelativeFilePathAsComponents>();
      Arb.Register<Libraries.AbsoluteDirectoryPathAsComponents>();

      Prop.ForAll<(DirectoryComponent[], FileComponent), (VolumeComponent, DirectoryComponent[])>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}