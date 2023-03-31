using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

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
   //Failure_of_TestClass
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_int
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_int_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(TestClass value,
                               int       whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestClass, int>.Create(whenFailure);

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

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_string
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_string_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(TestClass value,
                               string    whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestClass, string>.Create(whenFailure);

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

      Prop.ForAll<TestClass, string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_TestClass_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property((TestClass value, TestClass whenFailure) args)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, TestClass>.Create(args.whenFailure);

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

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_TestStruct_THEN_whenFailure_was_invoked_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(TestClass  value,
                               TestStruct whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestClass, TestStruct>.Create(whenFailure);

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

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Map<TNew>(Func<T, Result<TNew>> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<int>>.Create(Result<int>.Success());

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

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<string>>.Create(Result<string>.Success());

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

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<TestClass>>.Create(Result<TestClass>.Success());

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

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass_AND_whenFailure_returns_a_success
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_AND_whenFailure_returns_a_success_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<TestStruct>>.Create(Result<TestStruct>.Success());

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

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_int_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestClass value,
                               int       newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<int>>.Create(Tetra.Result.Failure(newValue));

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

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_string_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestClass value,
                               string    newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<string>>.Create(Tetra.Result.Failure(newValue));

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

      Prop.ForAll<TestClass, string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestClass_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property((TestClass value, TestClass newValue) args)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<TestClass>>.Create(Tetra.Result.Failure(args.newValue));

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

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass_AND_whenFailure_returns_a_failure
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_AND_whenFailure_returns_a_failure_WHEN_Map_AND_whenFailure_is_a_Func_of_TestClass_to_Result_of_TestStruct_THEN_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_return()
   {
      static Property Property(TestClass  value,
                               TestStruct newValue)
      {
         //Arrange
         var whenFailure = FakeFunction<TestClass, IResult<TestStruct>>.Create(Tetra.Result.Failure(newValue));

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

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}