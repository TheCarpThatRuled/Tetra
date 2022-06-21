using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedFilePath)]
// ReSharper disable once InconsistentNaming
public class GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath
   //WHEN
   //GetHashCode
   //THEN
   //the_ordinal_ignore_case_hash_code_of_the_value_is_returned

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_WHEN_GetHashCode_THEN_the_ordinal_ignore_case_hash_code_of_the_value_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var volumeRootedFilePath = VolumeRootedFilePath.Create(path);

         //Act
         var actual = volumeRootedFilePath.GetHashCode();

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