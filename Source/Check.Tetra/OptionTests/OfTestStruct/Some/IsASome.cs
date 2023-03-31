using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

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
   //Some_of_TestStruct
   //WHEN
   //IsASome
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestStruct_WHEN_IsASome_THEN_true_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.IsASome();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}