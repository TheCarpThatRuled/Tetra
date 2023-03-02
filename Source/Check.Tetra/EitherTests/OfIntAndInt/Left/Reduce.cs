using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Left_Reduce
{
   /* ------------------------------------------------------------ */
   // public TLeft Reduce(Func<Right<TRight>,TLeft> whenRight)
   /* ------------------------------------------------------------ * /

   //GIVEN
   //Left_of_int
   //WHEN
   //Reduce_AND_whenRight_is_a_Func_of_Right_of_int_to_int
   //THEN
   //whenRight_was_not_invoked_AND_the_content_is_returned

   [TestMethod]
   public void GIVEN_Left_of_int_WHEN_Reduce_AND_whenRight_is_a_Func_of_Right_of_int_to_int_THEN_whenRight_was_not_invoked_AND_the_content_is_returned()
   {
      static Property Property((int content, int whenRight) args)
      {
         //Arrange
         var whenRight = FakeFunction<Right<int>, int>.Create(args.whenRight);

         var result = Either<int, int>.Left(args.content);

         //Act
         var actual = result.Reduce(whenRight.Func);

         //Assert
         return AreEqual(args.content,
                         actual)
           .And(WasNotInvoked(whenRight));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public TRight Reduce>(Func<Left<TLeft>,TRight> whenLeft)
   /* ------------------------------------------------------------ * /

   //GIVEN
   //Left_of_int
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_int_to_int
   //THEN
   //whenLeft_was_invoked_once_with_the_content_AND_the_return_value_of_whenLeft_is_returned

   [TestMethod]
   public void GIVEN_Left_of_int_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_int_to_int_THEN_whenLeft_was_invoked_once_with_the_content_AND_the_return_value_of_whenLeft_is_returned()
   {
      static Property Property((int content, int whenLeft) args)
      {
         //Arrange
         var whenLeft = FakeFunction<Left<int>, int>.Create(args.whenLeft);

         var result = Either<int, int>.Left(args.content);

         //Act
         var actual = result.Reduce(whenLeft.Func);

         //Assert
         return AreEqual(args.whenLeft,
                         actual)
               .And(WasInvokedOnce(args.content,
                                   whenLeft));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public T Reduce<T>(Func<Left<TLeft>,T>    whenLeft,
   //                    Func<Right<TRight>, T> whenRight)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_int_to_int_AND_whenRight_is_a_Func_of_Right_of_int_to_int
   //THEN
   //whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_int_to_int_AND_whenRight_is_a_Func_of_Right_of_int_to_int_THEN_whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned()
   {
      static Property Property((int content, int whenLeft, int whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<int>, int>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<int>, int>.Create(args.whenRight);

         var result = Either<int, int>.Left(args.content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLeft,
                         actual)
               .And(WasInvokedOnce(nameof(whenLeft),
                                   args.content,
                                   whenLeft))
               .And(WasNotInvoked(nameof(whenRight),
                                  whenRight));
      }

      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<(int, int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_int_to_TestClass_AND_whenRight_is_a_Func_of_Right_of_int_to_TestClass
   //THEN
   //whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_int_to_TestClass_AND_whenRight_is_a_Func_of_Right_of_int_to_TestClass_THEN_whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned()
   {
      static Property Property(int                                       content,
                               (TestClass whenLeft, TestClass whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<int>, TestClass>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<int>, TestClass>.Create(args.whenRight);

         var result = Either<int, int>.Left(content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLeft,
                         actual)
               .And(WasInvokedOnce(nameof(whenLeft),
                                   content,
                                   whenLeft))
               .And(WasNotInvoked(nameof(whenRight),
                                  whenRight));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<int, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_int_to_TestStruct_AND_whenRight_is_a_Func_of_Right_of_int_to_TestStruct
   //THEN
   //whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_int_to_TestStruct_AND_whenRight_is_a_Func_of_Right_of_int_to_TestStruct_THEN_whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned()
   {
      static Property Property(int                                         content,
                               (TestStruct whenLeft, TestStruct whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<int>, TestStruct>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<int>, TestStruct>.Create(args.whenRight);

         var result = Either<int, int>.Left(content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLeft,
                         actual)
               .And(WasInvokedOnce(nameof(whenLeft),
                                   content,
                                   whenLeft))
               .And(WasNotInvoked(nameof(whenRight),
                                  whenRight));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<int, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}