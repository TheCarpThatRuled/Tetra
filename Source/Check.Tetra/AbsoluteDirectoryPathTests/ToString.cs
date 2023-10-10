using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
// ReSharper disable once InconsistentNaming
public class ToString
{
   /* ------------------------------------------------------------ */
   // string ToString();
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath
   //WHEN
   //ToString
   //THEN
   //the_value_bounded_by_angle_brackets_is_returned

   [TestMethod]
   public void GIVEN_AbsoluteDirectoryPath_WHEN_ToString_THEN_the_value_bounded_by_angle_brackets_is_returned()
   {
      static Property Property
      (
         string sourcePath
      )
      {
         //Arrange
         var path = AbsoluteDirectoryPath.Create(sourcePath);

         //Act
         var actual = path.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"<{sourcePath}>",
                         actual);
      }

      Arb.Register<Libraries.ValidPathWithAVolumeRootAndATrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}