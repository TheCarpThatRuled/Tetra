using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Reduce
{
   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<TSuccess, TNew> whenSuccess,
   //                   Func<TFailure, TNew> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_int
   //THEN
   //whenSuccess_was_invoked_once_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_int_THEN_whenSuccess_was_invoked_once_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestStruct                    content,
                               (int whenSuccess, int whenFailure) args)
      {
         //Arrange
         var whenSuccess  = FakeFunction<TestStruct, int>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<TestStruct, int>.Create(args.whenFailure);

         var result = Result<TestStruct, TestStruct>.Success(content);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   content,
                                   whenSuccess))
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<TestStruct, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_TestClass
   //THEN
   //whenSuccess_was_invoked_once_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_TestClass_THEN_whenSuccess_was_invoked_once_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestStruct                                content,
                               (TestClass whenSuccess, TestClass whenFailure) args)
      {
         //Arrange
         var whenSuccess  = FakeFunction<TestStruct, TestClass>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<TestStruct, TestClass>.Create(args.whenFailure);

         var result = Result<TestStruct, TestStruct>.Success(content);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   content,
                                   whenSuccess))
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<TestStruct, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_once_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_TestStruct_THEN_whenSuccess_was_invoked_once_with_the_content_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct content, TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccess  = FakeFunction<TestStruct, TestStruct>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<TestStruct, TestStruct>.Create(args.whenFailure);

         var result = Result<TestStruct, TestStruct>.Success(args.content);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   args.content,
                                   whenSuccess))
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}