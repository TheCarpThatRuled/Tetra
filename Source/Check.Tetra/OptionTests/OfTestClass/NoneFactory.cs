namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class NoneFactory
{
   /* ------------------------------------------------------------ */
   // public static Option<T> None()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass
   //WHEN
   //None
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Option_of_TestClass_WHEN_None_THEN_a_none_is_returned()
   {
      //Act
      var actual = Option<TestClass>.None();

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual);
   }
   /* ------------------------------------------------------------ */
}