using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Parent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteFilePath
   //WHEN
   //Parent
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_parent_directory_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteFilePath_WHEN_Parent_THEN_an_AbsoluteDirectoryPath_containing_the_parent_directory_is_returned()
   {
      static Property Property(VolumeComponent      volume,
                               DirectoryComponent[] directories,
                               FileComponent        file)
      {
         //Arrange
         var expected = TestAbsoluteDirectoryPath.Create(volume,
                                                         directories);

         var path = AbsoluteFilePath.Create(volume,
                                            directories,
                                            file);

         //Act
         var actual = path.Parent();

         //Assert
         return AreEqual("Parent",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}