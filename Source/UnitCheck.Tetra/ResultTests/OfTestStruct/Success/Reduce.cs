using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Reduce
{
   /* ------------------------------------------------------------ */
   // T Reduce(Func<Failure, T> whenFailure)
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestStruct
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_TestStruct_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestStruct_THEN_whenFailure_was_not_invoked_AND_the_content_is_returned()
   {
      static Property Property((TestStruct content, TestStruct whenFailure) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, TestStruct>.Create(args.whenFailure);

         var result = Result.Success(args.content);

         //Act
         var actual = result.Reduce(whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.content,
                         actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Message Reduce(Func<T, Message> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestStruct
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_TestStruct_to_Message
   //THEN
   //whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_TestStruct_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_TestStruct_to_Message_THEN_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestStruct content,
                               Message    whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestStruct, Message>.Create(whenSuccess);

         var result = Result.Success(content);

         //Act
         var actual = result.Reduce(whenSuccessFunc.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         whenSuccess,
                         actual)
           .And(WasInvokedOnce(nameof(whenSuccess),
                               content,
                               whenSuccessFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<Failure, TNew> whenFailure,
   //                   Func<T, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestStruct
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_int_AND_whenSuccess_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_TestStruct_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_int_AND_whenSuccess_is_a_Func_of_TestStruct_to_int_THEN_whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestStruct                         value,
                               (int whenFailure, int whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, int>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<TestStruct, int>.Create(args.whenSuccess);

         var result = Result.Success(value);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure))
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   value,
                                   whenSuccess));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<TestStruct, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestStruct
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestClass_AND_whenSuccess_is_a_Func_of_TestStruct_to_TestClass
   //THEN
   //whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_TestStruct_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestClass_AND_whenSuccess_is_a_Func_of_TestStruct_to_TestClass_THEN_whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestStruct                                     value,
                               (TestClass whenFailure, TestClass whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, TestClass>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<TestStruct, TestClass>.Create(args.whenSuccess);

         var result = Result.Success(value);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure))
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   value,
                                   whenSuccess));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<TestStruct, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestStruct
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestStruct_AND_whenSuccess_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_TestStruct_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestStruct_AND_whenSuccess_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenFailure, TestStruct whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, TestStruct>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<TestStruct, TestStruct>.Create(args.whenSuccess);

         var result = Result.Success(args.value);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure))
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   args.value,
                                   whenSuccess));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}