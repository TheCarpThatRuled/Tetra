using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStruct;

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
   //Success_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_DateTime
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_DateTime_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(DateTime value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, DateTime>.Create(value);

         var result = Result<TestStruct>.Success();

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Prop.ForAll<DateTime>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_int_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, int>.Create(value);

         var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestClass
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestClass_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, TestClass>.Create(value);

         var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, TestStruct>.Create(value);

         var result = Result<TestStruct>.Success();

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
   // Result<TNew> Map<TNew>(Func<T, Result<TNew>> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      //Arrange
      var whenFailure = FakeFunction<TestStruct, IResult<int>>.Create(Result<int>.Success());

      var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      //Arrange
      var whenFailure = FakeFunction<TestStruct, IResult<string>>.Create(Result<string>.Success());

      var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      //Arrange
      var whenFailure = FakeFunction<TestStruct, IResult<TestStruct>>.Create(Result<TestStruct>.Success());

      var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      //Arrange
      var whenFailure = FakeFunction<TestStruct, IResult<TestStruct>>.Create(Result<TestStruct>.Success());

      var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<int>>.Create(Tetra.Result.Failure(value));

         var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<string>>.Create(Tetra.Result.Failure(value));

         var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<TestClass>>.Create(Tetra.Result.Failure(value));

         var result = Result<TestStruct>.Success();

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
   //Success_of_TestStruct_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_a_success_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct_THEN_whenFailure_was_not_invoked_AND_a_success_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<TestStruct>>.Create(Tetra.Result.Failure(value));

         var result = Result<TestStruct>.Success();

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