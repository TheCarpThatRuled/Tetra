using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_GetHashCode
{
   /* ------------------------------------------------------------ */
   // public int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_the_content_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_GetHashCode_THEN_the_hash_code_of_the_content_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.GetHashCode();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         value.GetHashCode(),
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}