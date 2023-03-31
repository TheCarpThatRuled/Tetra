using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Map
{
   /* ------------------------------------------------------------ */
   // IResult<TNew> Map<TNew>(Func<T, TNew> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_int
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestClass_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_int_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, int>.Create(value);

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */


   //GIVEN
   //Success_of_TestClass
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_string
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestClass_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_string_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, string>.Create(value);

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestClass_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_TestClass_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, TestClass>.Create(value);

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestClass_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_TestStruct_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, TestStruct>.Create(value);

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // IResult<TNew> Map<TNew>(Func<T, Result<TNew>> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      //Arrange
      var whenFailure = FakeFunction<TestClass, IResult<int>>.Create(Result<int>.Success());

      var result = Result<TestClass>.Success();

      //Act
      var actual = result.Map(whenFailure.Func);

      //Assert
      Assert.That
            .IsASuccess(AssertMessages.ReturnValue,
                     actual)
            .WasNotInvoked(nameof(whenFailure),
                           whenFailure);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      //Arrange
      var whenFailure = FakeFunction<TestClass, IResult<string>>.Create(Result<string>.Success());

      var result = Result<TestClass>.Success();

      //Act
      var actual = result.Map(whenFailure.Func);

      //Assert
      Assert.That
            .IsASuccess(AssertMessages.ReturnValue,
                     actual)
            .WasNotInvoked(nameof(whenFailure),
                           whenFailure);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      //Arrange
      var whenFailure = FakeFunction<TestClass, IResult<TestClass>>.Create(Result<TestClass>.Success());

      var result = Result<TestClass>.Success();

      //Act
      var actual = result.Map(whenFailure.Func);

      //Assert
      Assert.That
            .IsASuccess(AssertMessages.ReturnValue,
                     actual)
            .WasNotInvoked(nameof(whenFailure),
                           whenFailure);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      //Arrange
      var whenFailure = FakeFunction<TestClass, IResult<TestStruct>>.Create(Result<TestStruct>.Success());

      var result = Result<TestClass>.Success();

      //Act
      var actual = result.Map(whenFailure.Func);

      //Assert
      Assert.That
            .IsASuccess(AssertMessages.ReturnValue,
                     actual)
            .WasNotInvoked(nameof(whenFailure),
                           whenFailure);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<int>>.Create(Tetra.Result.Failure(value));

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<string>>.Create(Tetra.Result.Failure(value));

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<TestClass>>.Create(Tetra.Result.Failure(value));

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestClass_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<TestStruct>>.Create(Tetra.Result.Failure(value));

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}