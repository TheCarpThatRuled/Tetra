using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ConditionTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Condition)]
// ReSharper disable once InconsistentNaming
public class False_Reduce
{
   /* ------------------------------------------------------------ */
   // public bool Reduce()
   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_Reduce_THEN_false_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.Reduce();

      //Assert
      Assert.That
            .IsFalse(AssertMessages.ReturnValue,
                     actual);
   }

   /* ------------------------------------------------------------ */
   // public T Reduce<T>(T whenFalse,
   //                    T whenTrue)
   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_an_int_AND_whenTrue_is_an_int
   //THEN
   //whenFalse_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_Reduce_AND_whenFalse_is_an_int_AND_whenTrue_is_an_int_THEN_whenFalse_is_returned()
   {
      static Property Property
      (
         (int whenFalse, int whenTrue) args
      )
      {
         //Arrange
         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(args.whenFalse,
                                       args.whenTrue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual);
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_a_TestClass_AND_whenTrue_is_a_TestClass
   //THEN
   //whenFalse_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_Reduce_AND_whenFalse_is_a_TestClass_AND_whenTrue_is_a_TestClass_THEN_whenFalse_is_returned()
   {
      static Property Property
      (
         (TestClass whenFalse, TestClass whenTrue) args
      )
      {
         //Arrange
         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(args.whenFalse,
                                       args.whenTrue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual);
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_a_TestStruct_AND_whenTrue_is_a_TestStruct
   //THEN
   //whenFalse_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_Reduce_AND_whenFalse_is_a_TestStruct_AND_whenTrue_is_a_TestStruct_THEN_whenFalse_is_returned()
   {
      static Property Property
      (
         (TestStruct whenFalse, TestStruct whenTrue) args
      )
      {
         //Arrange
         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(args.whenFalse,
                                       args.whenTrue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual);
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public T Reduce<T>(T       whenFalse,
   //                    Func<T> whenTrue)
   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_an_int_AND_whenTrue_is_a_Func_of_int
   //THEN
   //whenTrue_is_not_invoked_AND_whenFalse_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_Reduce_AND_whenFalse_is_an_int_AND_whenTrue_is_a_Func_of_int_THEN_whenTrue_is_not_invoked_AND_whenFalse_is_returned()
   {
      static Property Property
      (
         (int whenFalse, int whenTrue) args
      )
      {
         //Arrange
         var whenTrue = FakeFunction<int>.Create(args.whenTrue);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(args.whenFalse,
                                       whenTrue.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
           .And(WasNotInvoked(nameof(whenTrue),
                              whenTrue));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_an_TestClass_AND_whenTrue_is_a_Func_of_TestClass
   //THEN
   //whenTrue_is_not_invoked_AND_whenFalse_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_Reduce_AND_whenFalse_is_an_TestClass_AND_whenTrue_is_a_Func_of_TestClass_THEN_whenTrue_is_not_invoked_AND_whenFalse_is_returned()
   {
      static Property Property
      (
         (TestClass whenFalse, TestClass whenTrue) args
      )
      {
         //Arrange
         var whenTrue = FakeFunction<TestClass>.Create(args.whenTrue);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(args.whenFalse,
                                       whenTrue.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
           .And(WasNotInvoked(nameof(whenTrue),
                              whenTrue));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_an_TestStruct_AND_whenTrue_is_a_Func_of_TestStruct
   //THEN
   //whenTrue_is_not_invoked_AND_whenFalse_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_Reduce_AND_whenFalse_is_an_TestStruct_AND_whenTrue_is_a_Func_of_TestStruct_THEN_whenTrue_is_not_invoked_AND_whenFalse_is_returned()
   {
      static Property Property
      (
         (TestStruct whenFalse, TestStruct whenTrue) args
      )
      {
         //Arrange
         var whenTrue = FakeFunction<TestStruct>.Create(args.whenTrue);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(args.whenFalse,
                                       whenTrue.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
           .And(WasNotInvoked(nameof(whenTrue),
                              whenTrue));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public T Reduce<T>(Func<T> whenFalse,
   //                    T       whenTrue)
   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_a_Func_of_int_AND_whenTrue_is_an_int
   //THEN
   //whenFalse_is_invoked_AND_the_return_value_of_whenFalse_is_returned

   [TestMethod]
   public void
      GIVEN_False_WHEN_Reduce_AND_whenFalse_is_a_Func_of_int_AND_whenTrue_is_an_int_THEN_whenFalse_is_invoked_AND_whenTrue_is_not_invoked_AND_the_return_value_of_whenFalse_is_returned()
   {
      static Property Property
      (
         (int whenFalse, int whenTrue) args
      )
      {
         //Arrange
         var whenFalse = FakeFunction<int>.Create(args.whenFalse);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(whenFalse.Func,
                                       args.whenTrue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
           .And(WasInvokedOnce(nameof(whenFalse),
                               whenFalse));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_a_Func_of_TestClass_AND_whenTrue_is_a_TestClass
   //THEN
   //whenFalse_is_invoked_AND_the_return_value_of_whenFalse_is_returned

   [TestMethod]
   public void
      GIVEN_False_WHEN_Reduce_AND_whenFalse_is_a_Func_of_TestClass_AND_whenTrue_is_a_TestClass_THEN_whenFalse_is_invoked_AND_the_return_value_of_whenFalse_is_returned()
   {
      static Property Property
      (
         (TestClass whenFalse, TestClass whenTrue) args
      )
      {
         //Arrange
         var whenFalse = FakeFunction<TestClass>.Create(args.whenFalse);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(whenFalse.Func,
                                       args.whenTrue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
           .And(WasInvokedOnce(nameof(whenFalse),
                               whenFalse));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_a_Func_of_TestStruct_AND_whenTrue_is_a_TestStruct
   //THEN
   //whenFalse_is_invoked_AND_the_return_value_of_whenFalse_is_returned

   [TestMethod]
   public void
      GIVEN_False_WHEN_Reduce_AND_whenFalse_is_a_Func_of_TestStruct_AND_whenTrue_is_a_TestStruct_THEN_whenFalse_is_invoked_AND_the_return_value_of_whenFalse_is_returned()
   {
      static Property Property
      (
         (TestStruct whenFalse, TestStruct whenTrue) args
      )
      {
         //Arrange
         var whenFalse = FakeFunction<TestStruct>.Create(args.whenFalse);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(whenFalse.Func,
                                       args.whenTrue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
           .And(WasInvokedOnce(nameof(whenFalse),
                               whenFalse));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public T Reduce<T>(Func<T> whenFalse,
   //                    Func<T> whenTrue)
   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_a_Func_of_int_AND_whenTrue_is_a_Func_of_int
   //THEN
   //whenFalse_is_invoked_AND_whenTrue_is_not_invoked_AND_the_return_value_of_whenFalse_is_returned

   [TestMethod]
   public void
      GIVEN_False_WHEN_Reduce_AND_whenFalse_is_a_Func_of_int_AND_whenTrue_is_a_Func_of_int_THEN_whenFalse_is_invoked_AND_whenTrue_is_not_invoked_AND_the_return_value_of_whenFalse_is_returned()
   {
      static Property Property
      (
         (int whenFalse, int whenTrue) args
      )
      {
         //Arrange
         var whenFalse = FakeFunction<int>.Create(args.whenFalse);
         var whenTrue  = FakeFunction<int>.Create(args.whenTrue);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(whenFalse.Func,
                                       whenTrue.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
               .And(WasInvokedOnce(nameof(whenFalse),
                                   whenFalse))
               .And(WasNotInvoked(nameof(whenTrue),
                                  whenTrue));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_a_Func_of_TestClass_AND_whenTrue_is_a_Func_of_TestClass
   //THEN
   //whenFalse_is_invoked_AND_whenTrue_is_not_invoked_AND_the_return_value_of_whenFalse_is_returned

   [TestMethod]
   public void
      GIVEN_False_WHEN_Reduce_AND_whenFalse_is_a_Func_of_TestClass_AND_whenTrue_is_a_Func_of_TestClass_THEN_whenFalse_is_invoked_AND_whenTrue_is_not_invoked_AND_the_return_value_of_whenFalse_is_returned()
   {
      static Property Property
      (
         (TestClass whenFalse, TestClass whenTrue) args
      )
      {
         //Arrange
         var whenFalse = FakeFunction<TestClass>.Create(args.whenFalse);
         var whenTrue  = FakeFunction<TestClass>.Create(args.whenTrue);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(whenFalse.Func,
                                       whenTrue.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
               .And(WasInvokedOnce(nameof(whenFalse),
                                   whenFalse))
               .And(WasNotInvoked(nameof(whenTrue),
                                  whenTrue));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Reduce_AND_whenFalse_is_a_Func_of_TestStruct_AND_whenTrue_is_a_Func_of_TestStruct
   //THEN
   //whenFalse_is_invoked_AND_whenTrue_is_not_invoked_AND_the_return_value_of_whenFalse_is_returned

   [TestMethod]
   public void
      GIVEN_False_WHEN_Reduce_AND_whenFalse_is_a_Func_of_TestStruct_AND_whenTrue_is_a_Func_of_TestStruct_THEN_whenFalse_is_invoked_AND_whenTrue_is_not_invoked_AND_the_return_value_of_whenFalse_is_returned()
   {
      static Property Property
      (
         (TestStruct whenFalse, TestStruct whenTrue) args
      )
      {
         //Arrange
         var whenFalse = FakeFunction<TestStruct>.Create(args.whenFalse);
         var whenTrue  = FakeFunction<TestStruct>.Create(args.whenTrue);

         var condition = Condition.False();

         //Act
         var actual = condition.Reduce(whenFalse.Func,
                                       whenTrue.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFalse,
                         actual)
               .And(WasInvokedOnce(nameof(whenFalse),
                                   whenFalse))
               .And(WasNotInvoked(nameof(whenTrue),
                                  whenTrue));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}