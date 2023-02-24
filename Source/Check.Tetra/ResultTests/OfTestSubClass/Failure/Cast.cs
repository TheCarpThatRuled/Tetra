﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestSubClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_Cast
{
   /* ------------------------------------------------------------ */
   // public static Result<TNew> Cast<TNew>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_int
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_int_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(content);

         //Act
         var actual = result.Cast<int>();

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestClass_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(content);

         //Act
         var actual = result.Cast<TestClass>();

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestStruct
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestStruct_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(content);

         //Act
         var actual = result.Cast<TestStruct>();

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestSubClass_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(content);

         //Act
         var actual = result.Cast<TestSubClass>();

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static Result<TNew> Cast<TNew>(Message whenCastFails)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_DateTime_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_DateTime_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<DateTime>(args.whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual);
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_int_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_int_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<int>(args.whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual);
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestClass_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<TestClass>(args.whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual);
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestStruct_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestStruct_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<TestStruct>(args.whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual);
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestSubClass_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestSubClass_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<TestSubClass>(args.whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual);
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static Result<TNew> Cast<TNew>(Func<T, Message> whenCastFails)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_int_AND_whenCastFails_is_a_Func_of_TestSubClass_to_Message
   //THEN
   //whenCastFails_was_not_invoked_AND_a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_int_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_TestSubClass_to_Message_THEN_whenCastFails_was_not_invoked_AND_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var whenCastFails = FakeFunction<TestSubClass, Message>.Create(args.whenCastFails);

         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<int>(whenCastFails.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual)
           .And(WasNotInvoked(nameof(whenCastFails),
                              whenCastFails));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_TestSubClass_to_Message
   //THEN
   //whenCastFails_was_not_invoked_AND_a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_TestSubClass_to_Message_THEN_whenCastFails_was_not_invoked_AND_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var whenCastFails = FakeFunction<TestSubClass, Message>.Create(args.whenCastFails);

         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<TestClass>(whenCastFails.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual)
           .And(WasNotInvoked(nameof(whenCastFails),
                              whenCastFails));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestStruct_AND_whenCastFails_is_a_Func_of_TestSubClass_to_Message
   //THEN
   //whenCastFails_was_not_invoked_AND_a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestStruct_AND_whenCastFails_is_a_Func_of_TestSubClass_to_Message_THEN_whenCastFails_was_not_invoked_AND_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var whenCastFails = FakeFunction<TestSubClass, Message>.Create(args.whenCastFails);

         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<TestStruct>(whenCastFails.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual)
           .And(WasNotInvoked(nameof(whenCastFails),
                              whenCastFails));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestSubClass
   //WHEN
   //Cast_to_TestSubClass_AND_whenCastFails_is_a_Func_of_TestSubClass_to_Message
   //THEN
   //whenCastFails_was_not_invoked_AND_a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestSubClass_WHEN_Cast_to_TestSubClass_AND_whenCastFails_is_a_Func_of_TestSubClass_to_Message_THEN_whenCastFails_was_not_invoked_AND_a_failure_containing_the_content_is_returned()
   {
      static Property Property((Message content, Message whenCastFails) args)
      {
         //Arrange
         var whenCastFails = FakeFunction<TestSubClass, Message>.Create(args.whenCastFails);

         var result = Result<TestSubClass>.Failure(args.content);

         //Act
         var actual = result.Cast<TestSubClass>(whenCastFails.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.content,
                           actual)
           .And(WasNotInvoked(nameof(whenCastFails),
                              whenCastFails));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}