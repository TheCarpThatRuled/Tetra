using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfInt;

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
   //Failure_of_int
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_int
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_int_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property((int value, int whenFailure) args)
      {
         //Arrange
         var whenFailure = FakeFunction<int, int>.Create(args.whenFailure);

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

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_TestClass
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_TestClass_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(int       value,
                               TestClass whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<int, TestClass>.Create(whenFailure);

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

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_TestStruct_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(int        value,
                               TestStruct whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<int, TestStruct>.Create(whenFailure);

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

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_uint
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_uint_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(int  value,
                               uint whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<int, uint>.Create(whenFailure);

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

      Prop.ForAll<int, uint>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // IResult<TNew> Map<TNew>(Func<T, Result<TNew>> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_int
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_int_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_int_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenFailure = FakeFunction<int, IResult<int>>.Create(Result<int>.Success());

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

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_TestClass
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_int_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_TestClass_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenFailure = FakeFunction<int, IResult<TestClass>>.Create(Result<TestClass>.Success());

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

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_int_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_TestStruct_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenFailure = FakeFunction<int, IResult<TestStruct>>.Create(Result<TestStruct>.Success());

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

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_uint
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_int_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_uint_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenFailure = FakeFunction<int, IResult<uint>>.Create(Result<uint>.Success());

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

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_int
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_int_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_int_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property((int value, int newValue) args)
      {
         //Arrange
         var whenFailure = FakeFunction<int, IResult<int>>.Create(Tetra.Result.Failure(args.newValue));

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

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_TestClass
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_int_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_TestClass_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(int       value,
                               TestClass newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<int, IResult<TestClass>>.Create(Tetra.Result.Failure(newValue));

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

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_int_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_TestStruct_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(int        value,
                               TestStruct newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<int, IResult<TestStruct>>.Create(Tetra.Result.Failure(newValue));

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

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_uint
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_int_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_int_to_Result_of_uint_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(int  value,
                               uint newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<int, IResult<uint>>.Create(Tetra.Result.Failure(newValue));

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

      Prop.ForAll<int, uint>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}