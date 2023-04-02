using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_Reduce
{
   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<TSuccess, TNew> whenSuccess,
   //                   Func<TFailure, TNew> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_int
   //THEN
   //whenSuccess_was_invoked_once_with_the_content_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_int_THEN_whenSuccess_was_invoked_once_with_the_content_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property((int content, int whenSuccess, int whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<int, int>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, int>.Create(args.whenFailure);

         var result = Result<int, int>.Failure(args.content);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFailure,
                         actual)
               .And(WasNotInvoked(nameof(whenSuccess),
                                  whenSuccess))
               .And(WasInvokedOnce(nameof(whenFailure),
                                   args.content,
                                   whenFailure));
      }

      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<(int, int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_TestClass
   //THEN
   //whenSuccess_was_invoked_once_with_the_content_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_TestClass_THEN_whenSuccess_was_invoked_once_with_the_content_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(int                                            content,
                               (TestClass whenSuccess, TestClass whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<int, TestClass>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, TestClass>.Create(args.whenFailure);

         var result = Result<int, int>.Failure(content);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFailure,
                         actual)
               .And(WasNotInvoked(nameof(whenSuccess),
                                  whenSuccess))
               .And(WasInvokedOnce(nameof(whenFailure),
                                   content,
                                   whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<int, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_once_with_the_content_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct_AND_whenFailure_is_a_Func_of_Failure_of_TestStruct_to_TestStruct_THEN_whenSuccess_was_invoked_once_with_the_content_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(int                                              content,
                               (TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<int, TestStruct>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, TestStruct>.Create(args.whenFailure);

         var result = Result<int, int>.Failure(content);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFailure,
                         actual)
               .And(WasNotInvoked(nameof(whenSuccess),
                                  whenSuccess))
               .And(WasInvokedOnce(nameof(whenFailure),
                                   content,
                                   whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<int, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}