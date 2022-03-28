using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_IsANone
{
   /* ------------------------------------------------------------ */
   // bool IsANone()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //IsANone
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestStruct_WHEN_IsANone_THEN_false_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.IsANone();

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}