using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Map
{
   /* ------------------------------------------------------------ */
   // IResult<TNewSuccess, TNewFailure> Map<TNewSuccess, TNewFailure>(Func<TSuccess, TNewSuccess> whenSuccess,
   //                                                                 Func<TFailure, TNewFailure> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct_AND_whenSuccess_is_a_Func_of_TestStruct_to_DateTime
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct_AND_whenSuccess_is_a_Func_of_TestStruct_to_DateTime_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenFailure) args,
                               DateTime                                   whenSuccess)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestStruct, TestStruct>.Create(args.whenFailure);
         var whenSuccessFunc = FakeFunction<TestStruct, DateTime>.Create(whenSuccess);

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct), DateTime>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct_AND_whenSuccess_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct_AND_whenSuccess_is_a_Func_of_TestStruct_to_int_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenFailure) args,
                               int                                        whenSuccess)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestStruct, TestStruct>.Create(args.whenFailure);
         var whenSuccessFunc = FakeFunction<TestStruct, int>.Create(whenSuccess);

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct), int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestClass_AND_whenSuccess_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestClass_AND_whenSuccess_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenFailure) args,
                               TestClass                                  whenSuccess)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestStruct, TestStruct>.Create(args.whenFailure);
         var whenSuccessFunc = FakeFunction<TestStruct, TestClass>.Create(whenSuccess);

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<(TestStruct, TestStruct), TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct_AND_whenSuccess_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_TestStruct_AND_whenSuccess_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, TestStruct>.Create(args.whenSuccess);
         var whenFailureFunc = FakeFunction<TestStruct, TestStruct>.Create(args.whenFailure);

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           args.whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(args.whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }
   /* ------------------------------------------------------------ */
   // IResult<TNewSuccess, TNewFailure> Map<TNewSuccess, TNewFailure>(Func<TSuccess, IResult<TNewSuccess, TNewFailure>> whenSuccess,
   //                                                                 Func<TFailure, IResult<TNewSuccess, TNewFailure>> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_DateTime_and_TestStruct_AND_whenFailure_will_return_a_failure_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_DateTime_and_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_DateTime_and_TestStruct_AND_whenFailure_will_return_a_failure_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_DateTime_and_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenFailure) args,
                               DateTime                                   whenSuccess)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<TestStruct, IResult<TestStruct, DateTime>>.Create(Result<TestStruct, DateTime>.Success(args.whenFailure));
         var whenSuccessFunc = FakeFunction<TestStruct, IResult<TestStruct, DateTime>>.Create(Result<TestStruct, DateTime>.Failure(whenSuccess));

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct), DateTime>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_DateTime_and_TestStruct_AND_whenFailure_will_return_a_success_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_DateTime_and_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_DateTime_and_TestStruct_AND_whenFailure_will_return_a_success_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_DateTime_and_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, IResult<TestStruct, DateTime>>.Create(Result<TestStruct, DateTime>.Success(args.whenSuccess));
         var whenFailureFunc = FakeFunction<TestStruct, IResult<TestStruct, DateTime>>.Create(Result<TestStruct, DateTime>.Success(args.whenFailure));

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           args.whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(args.whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_int_and_TestStruct_AND_whenFailure_will_return_a_failure_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_int_and_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_int_and_TestStruct_AND_whenFailure_will_return_a_failure_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_int_and_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenFailure) args,
                               int                                        whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, IResult<TestStruct, int>>.Create(Result<TestStruct, int>.Failure(whenSuccess));
         var whenFailureFunc = FakeFunction<TestStruct, IResult<TestStruct, int>>.Create(Result<TestStruct, int>.Success(args.whenFailure));

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct), int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_int_and_TestStruct_AND_whenFailure_will_return_a_success_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_int_and_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_int_and_TestStruct_AND_whenFailure_will_return_a_success_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_int_and_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, IResult<TestStruct, int>>.Create(Result<TestStruct, int>.Success(args.whenSuccess));
         var whenFailureFunc = FakeFunction<TestStruct, IResult<TestStruct, int>>.Create(Result<TestStruct, int>.Success(args.whenFailure));

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           args.whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(args.whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestClass_and_TestStruct_AND_whenFailure_will_return_a_failure_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_TestClass_and_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestClass_and_TestStruct_AND_whenFailure_will_return_a_failure_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_TestClass_and_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenFailure) args,
                               TestClass                                  whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, IResult<TestStruct, TestClass>>.Create(Result<TestStruct, TestClass>.Failure(whenSuccess));
         var whenFailureFunc = FakeFunction<TestStruct, IResult<TestStruct, TestClass>>.Create(Result<TestStruct, TestClass>.Success(args.whenFailure));

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct), TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestClass_and_TestStruct_AND_whenFailure_will_return_a_success_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_TestClass_and_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestClass_and_TestStruct_AND_whenFailure_will_return_a_success_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_TestClass_and_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, IResult<TestStruct, TestClass>>.Create(Result<TestStruct, TestClass>.Success(args.whenSuccess));
         var whenFailureFunc = FakeFunction<TestStruct, IResult<TestStruct, TestClass>>.Create(Result<TestStruct, TestClass>.Success(args.whenFailure));

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           args.whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(args.whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestStruct_and_TestStruct_AND_whenFailure_will_return_a_failure_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_TestStruct_and_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestStruct_and_TestStruct_AND_whenFailure_will_return_a_failure_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_TestStruct_and_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, IResult<TestStruct, TestStruct>>.Create(Result<TestStruct, TestStruct>.Failure(args.whenSuccess));
         var whenFailureFunc = FakeFunction<TestStruct, IResult<TestStruct, TestStruct>>.Create(Result<TestStruct, TestStruct>.Success(args.whenFailure));

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(args.whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct_and_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestStruct_and_TestStruct_AND_whenFailure_will_return_a_success_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_TestStruct_and_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_TestStruct_to_Result_of_TestStruct_and_TestStruct_AND_whenFailure_will_return_a_success_AND_whenSuccess_is_a_Func_of_TestStruct_to_Result_of_TestStruct_and_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, IResult<TestStruct, TestStruct>>.Create(Result<TestStruct, TestStruct>.Success(args.whenSuccess));
         var whenFailureFunc = FakeFunction<TestStruct, IResult<TestStruct, TestStruct>>.Create(Result<TestStruct, TestStruct>.Success(args.whenFailure));

         var result = Result<TestStruct, TestStruct>.Success(args.value);

         //Act
         var actual = result.Map(whenSuccessFunc.Func,
                                 whenFailureFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           args.whenSuccess,
                           actual)
               .And(WasInvokedOnce(nameof(args.whenSuccess),
                                   args.value,
                                   whenSuccessFunc))
               .And(WasNotInvoked(nameof(args.whenFailure),
                                  whenFailureFunc));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}