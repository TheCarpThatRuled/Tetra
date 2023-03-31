namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_Do
{
   /* ------------------------------------------------------------ */
   // TNewIOption<T> Do(Action<T, TNew> whenSome,
   //                   Action<TNew>    whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestClass
   //WHEN
   //Do_AND_whenNone_is_a_Action_AND_whenSome_is_a_Action_of_TestClass
   //THEN
   //whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Do_AND_whenNone_is_a_Action_AND_whenSome_is_a_Action_of_TestClass_THEN_whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_this_is_returned()
   {
      //Arrange
      var whenNone = FakeAction.Create();
      var whenSome = FakeAction<TestClass>.Create();

      var option = Option<TestClass>.None();

      //Act
      var actual = option.Do(whenSome.Action,
                             whenNone.Action);

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      option,
                      actual)
            .WasInvokedOnce(nameof(whenNone),
                            whenNone)
            .WasNotInvoked(nameof(whenSome),
                           whenSome);
   }

   /* ------------------------------------------------------------ */
}