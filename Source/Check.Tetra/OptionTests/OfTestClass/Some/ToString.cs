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
public class Some_ToString
{
   /* ------------------------------------------------------------ */
   // public string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //ToString
   //THEN
   //Some_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestClass_WHEN_ToString_THEN_Some_brackets_the_content_to_string_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Some ({value})",
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}