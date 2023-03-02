using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.DirectoryComponent)]
// ReSharper disable once InconsistentNaming
public class GetHashCode
{
   /* ------------------------------------------------------------ */
   // public int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent
   //WHEN
   //GetHashCode
   //THEN
   //the_ordinal_ignore_case_hash_code_of_the_value_is_returned

   [TestMethod]
   public void GIVEN_DirectoryComponent_WHEN_GetHashCode_THEN_the_ordinal_ignore_case_hash_code_of_the_value_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         var directoryComponent = DirectoryComponent.Create(value);

         //Act
         var actual = directoryComponent.GetHashCode();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .GetHashCode(value),
                         actual);
      }

      Arb.Register<Libraries.ValidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}