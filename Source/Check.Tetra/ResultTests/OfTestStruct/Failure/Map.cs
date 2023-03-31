using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_Map
{
   /* ------------------------------------------------------------ */
   // IResult<TNew> Map<TNew>(Func<T, TNew> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_DateTime
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_DateTime_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(TestStruct value,
                               DateTime   whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestStruct, DateTime>.Create(whenFailure);

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailureFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        whenFailure,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailureFunc));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, DateTime>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_int_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(TestStruct value,
                               int        whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestStruct, int>.Create(whenFailure);

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailureFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        whenFailure,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailureFunc));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestClass
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestClass_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(TestStruct value,
                               TestClass  whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestStruct, TestClass>.Create(whenFailure);

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailureFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        whenFailure,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailureFunc));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenFailure) args)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, TestStruct>.Create(args.whenFailure);

         var result = Tetra.Result.Failure(args.value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        args.whenFailure,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               args.value,
                               whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public Result<TNew> Map<TNew>(Func<T, Result<TNew>> whenFailure)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_DateTime
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_DateTime_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<DateTime>>.Create(Result<DateTime>.Success());

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailure));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_int
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_int_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<int>>.Create(Result<int>.Success());

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailure));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestClass
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestClass_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<TestClass>>.Create(Result<TestClass>.Success());

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailure));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestStruct_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<TestStruct>>.Create(Result<TestStruct>.Success());

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailure));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_DateTime
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_DateTime_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestStruct value,
                               DateTime   newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<DateTime>>.Create(Tetra.Result.Failure(newValue));

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailure));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct, DateTime>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_int
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_int_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestStruct value,
                               int        newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<int>>.Create(Tetra.Result.Failure(newValue));

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailure));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestClass
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestClass_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestStruct value,
                               TestClass  newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<TestClass>>.Create(Tetra.Result.Failure(newValue));

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               value,
                               whenFailure));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestStruct_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property((TestStruct value, TestStruct newValue) args)
      {
         //Arrange
         var whenFailure = FakeFunction<TestStruct, IResult<TestStruct>>.Create(Tetra.Result.Failure(args.newValue));

         var result = Tetra.Result.Failure(args.value);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        args.newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               args.value,
                               whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}