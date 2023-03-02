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
public class Some_IsASome
{
   /* ------------------------------------------------------------ */
   // public bool IsASome()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //IsASome
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestClass_WHEN_IsASome_THEN_true_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.IsASome();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}