using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
// ReSharper disable once InconsistentNaming
public class GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath
   //WHEN
   //GetHashCode
   //THEN
   //the_ordinal_ignore_case_hash_code_of_the_value_is_returned

   [TestMethod]
   public void GIVEN_VolumeRootedDirectoryPath_WHEN_GetHashCode_THEN_the_ordinal_ignore_case_hash_code_of_the_value_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedDirectoryPath.Create(path);

         //Act
         var actual = volumeRootedDirectoryPath.GetHashCode();

         //Assert
         return AreEqual(StringComparer.OrdinalIgnoreCase
                                       .GetHashCode(path),
                         actual);
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootAndTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}