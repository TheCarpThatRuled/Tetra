using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ChainableTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Chainable)]
public class Next
{
   /* ------------------------------------------------------------ */
   // public T Next()
   /* ------------------------------------------------------------ */

   //GIVEN
   //the_client_has_created_a_Chainable_of_int_with_next
   //WHEN
   //the_client_calls_Next
   //THEN
   //next_was_invoked_once_AND_the_return_value_of_next_is_returned

   [TestMethod]
   public void GIVEN_the_client_has_created_a_Chainable_of_int_with_next_WHEN_the_client_calls_Next_THEN_next_was_invoked_once_AND_the_return_value_of_next_is_returned()
   {
      static Property Property
      (
         int value
      )
      {
         //Arrange
         var next = FakeFunction<int>.Create(value);

         var chainable = TestableChainable<int>.Create(next.Func);

         //Act
         var actual = chainable.Next();

         //Assert
         return WasInvokedOnce(nameof(next),
                               next)
           .And(AreEqual(AssertMessages.ReturnValue,
                         value,
                         actual));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //the_client_has_created_a_Chainable_of_TestClass_with_next
   //WHEN
   //the_client_calls_Next
   //THEN
   //next_was_invoked_once_AND_the_return_value_of_next_is_returned

   [TestMethod]
   public void GIVEN_the_client_has_created_a_Chainable_of_TestClass_with_next_WHEN_the_client_calls_Next_THEN_next_was_invoked_once_AND_the_return_value_of_next_is_returned()
   {
      //Arrange
      var value = TestClass.Create(1,
                                   2);
      var next = FakeFunction<TestClass>.Create(value);

      var chainable = TestableChainable<TestClass>.Create(next.Func);

      //Act
      var actual = chainable.Next();

      //Assert
      Assert.That
            .WasInvokedOnce(nameof(next),
                            next)
            .AreReferenceEqual(AssertMessages.ReturnValue,
                               value,
                               actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //the_client_has_created_a_Chainable_of_TestStruct_with_next
   //WHEN
   //the_client_calls_Next
   //THEN
   //next_was_invoked_once_AND_the_return_value_of_next_is_returned

   [TestMethod]
   public void GIVEN_the_client_has_created_a_Chainable_of_TestStruct_with_next_WHEN_the_client_calls_Next_THEN_next_was_invoked_once_AND_the_return_value_of_next_is_returned()
   {
      //Arrange
      var value = TestStruct.Create(1,
                                    2);
      var next = FakeFunction<TestStruct>.Create(value);

      var chainable = TestableChainable<TestStruct>.Create(next.Func);

      //Act
      var actual = chainable.Next();

      //Assert
      Assert.That
            .WasInvokedOnce(nameof(next),
                            next)
            .AreEqual(AssertMessages.ReturnValue,
                      value,
                      actual);
   }

   /* ------------------------------------------------------------ */
}