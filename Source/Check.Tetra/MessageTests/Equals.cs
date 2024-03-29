﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.MessageTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Message)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // public bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Message_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Message_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property
      (
         Message message,
         object? obj
      )
      {
         //Act
         var actual = message.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, object?>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Message
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Message_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property
      (
         Message original
      )
      {
         //Arrange
         var copy = Message.Create(original.Content());

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Message
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Message_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, Message>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Message
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Message_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveMessages>();

      Prop.ForAll<(Message, Message, Message)>(EqualsIsTransitive<Message>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public bool Equals(Message? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Message_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Message
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Message_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Message_THEN_false_is_returned()
   {
      static Property Property
      (
         Message value
      )
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Message_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_Message
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Message_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_Message_THEN_is_reflexive()
   {
      static Property Property
      (
         Message original
      )
      {
         //Arrange
         var copy = Message.Create(original.Content());

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Message
   //WHEN
   //Equals_AND_other_is_a_nullable_Message
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Message_WHEN_Equals_AND_other_is_a_nullable_Message_THEN_is_symmetric()
   {
      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, Message>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Message
   //WHEN
   //Equals_AND_other_is_a_nullable_Message
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Message_WHEN_Equals_AND_other_is_a_nullable_Message_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveMessages>();

      Prop.ForAll<(Message, Message, Message)>(IEquatableIsTransitive<Message>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class ObjIsNullOrANonEquatableType
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<object?> Obj()
         => Gen
           .OneOf(Gen.Constant(default(object?)),
                  Generators.Int32()
                            .Select(x => (object?) x),
                  Generators.String()
                            .Select(x => (object?) x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}