using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeComponent)]
public class Append
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Append(this VolumeComponent volume,
   //                                  params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent      volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var expected = directories
                       .Select(x => x.Value())
                       .Prepend(volume.Value())
                       .Aggregate(string.Empty,
                                  (total,
                                   next) => $"{total}{next}{Path.DirectorySeparatorChar}");

         //Act
         var actual = volume.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Append(this VolumeComponent volume,
   //                                  IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent          volume,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var expected = directories
                       .Select(x => x.Value())
                       .Prepend(volume.Value())
                       .Aggregate(string.Empty,
                                  (total,
                                   next) => $"{total}{next}{Path.DirectorySeparatorChar}");

         //Act
         var actual = volume.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteFilePath Append(this VolumeComponent volume,
   //                             FileComponent file)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //a_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_FileComponent_WHEN_Append_THEN_a_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent volume,
                               FileComponent   file)
      {
         //Arrange
         var expected = volume.Value()
                      + Path.DirectorySeparatorChar
                      + file.Value();

         //Act
         var actual = volume.Append(file);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<VolumeComponent, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}