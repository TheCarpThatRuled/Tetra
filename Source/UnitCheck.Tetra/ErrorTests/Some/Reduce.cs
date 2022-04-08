using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class Some_Reduce
{
   /* ------------------------------------------------------------ */
   // Message Reduce(Message whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_Message
   //THEN
   //the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_Message_THEN_the_content_is_returned()
   {
      static Property Property((Message value, Message whenNone) args)
      {
         //Arrange
         var error = Error.Some(args.value);

         //Act
         var actual = error.Reduce(args.whenNone);

         //Assert
         return AreEqual(args.value,
                         actual);
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Message Reduce(Func<Message> whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_Message
   //THEN
   //whenNone_was_not_invoked_AND_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_Func_of_Message_THEN_whenNone_was_not_invoked_AND_the_content_is_returned()
   {
      static Property Property((Message value, Message whenNone) args)
      {
         //Arrange
         var whenNone = FakeFunction<Message>.Create(args.whenNone);

         var error = Error.Some(args.value);

         //Act
         var actual = error.Reduce(whenNone.Func);

         //Assert
         return AreEqual(args.value,
                         actual)
           .And(WasNotInvoked(whenNone));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(TNew whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_int_AND_whenSome_is_a_Func_of_Message_to_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_int_AND_whenSome_is_a_Func_of_Message_to_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(Message value, (int whenNone, int whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<Message, int>.Create(args.whenSome);

         var error = Error.Some(value);

         //Act
         var actual = error.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
           .And(WasInvokedOnce(value,
                               whenSome));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<Message, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_Message__AND_whenSome_is_a_Func_of_Message_to_Message
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_Message__AND_whenSome_is_a_Func_of_Message_to_Message_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((Message value, Message whenNone, Message whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<Message, Message>.Create(args.whenSome);

         var error = Error.Some(args.value);

         //Act
         var actual = error.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasInvokedOnce(args.value,
                                   whenSome));
      }

      Arb.Register<Libraries.ThreeUniqueMessages>();

      Prop.ForAll<(Message, Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_Message_to_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_Message_to_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(Message value, (TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<Message, TestClass>.Create(args.whenSome);

         var error = Error.Some(value);

         //Act
         var actual = error.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<Message, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_Message_to_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_Message_to_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(Message value, (TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<Message, TestStruct>.Create(args.whenSome);

         var error = Error.Some(value);

         //Act
         var actual = error.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<Message, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<TNew> whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_Message_to_int
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_Message_to_int_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(Message value, (int whenNone, int whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<int>.Create(args.whenNone);
         var whenSome = FakeFunction<Message, int>.Create(args.whenSome);

         var error = Error.Some(value);

         //Act
         var actual = error.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<Message, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_Message_AND_whenSome_is_a_Func_of_Message_to_Message
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_Func_of_Message_AND_whenSome_is_a_Func_of_Message_to_Message_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((Message value, Message whenNone, Message whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<Message>.Create(args.whenNone);
         var whenSome = FakeFunction<Message, Message>.Create(args.whenSome);

         var error = Error.Some(args.value);

         //Act
         var actual = error.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(args.value,
                                   whenSome));
      }

      Arb.Register<Libraries.ThreeUniqueMessages>();

      Prop.ForAll<(Message, Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_Message_to_TestClass
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_Message_to_TestClass_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(Message value, (TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestClass>.Create(args.whenNone);
         var whenSome = FakeFunction<Message, TestClass>.Create(args.whenSome);

         var error = Error.Some(value);

         //Act
         var actual = error.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<Message, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_Message_to_TestStruct
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_Message_to_TestStruct_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(Message value, (TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestStruct>.Create(args.whenNone);
         var whenSome = FakeFunction<Message, TestStruct>.Create(args.whenSome);

         var error = Error.Some(value);

         //Act
         var actual = error.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<Message, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}