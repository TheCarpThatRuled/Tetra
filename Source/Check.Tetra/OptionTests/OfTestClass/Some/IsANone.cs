using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_IsANone
{
   /* ------------------------------------------------------------ */
   // public bool IsANone()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //IsANone
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestClass_WHEN_IsANone_THEN_false_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.IsANone();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}