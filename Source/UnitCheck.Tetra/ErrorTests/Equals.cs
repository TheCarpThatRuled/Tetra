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
public class Equals
{
   /* ------------------------------------------------------------ */
   // public bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Error_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Error option,
                               object? obj)
      {
         //Act
         var actual = option.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.Error>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Error, object?>(Property)
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
                  Generators.Int16()
                            .Select(x => (object?)x),
                  Generators.UInt32()
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_obj_is_an_Option_of_Message_containing_the_same_Message
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Error_AND_obj_is_an_Option_of_Message_containing_the_same_Message_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Message value)
      {
         //Arrange
         var error  = Error.Some(value);
         var option = Option.Some(value);

         //Act
         var actual = error.Equals(option);

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
   //Error_AND_this_is_a_none
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Error_AND_this_is_a_none_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      //Arrange
      var original = Error.None();
      var copy     = Error.None();

      //Act
      //Assert
      Assert.That
            .EqualsIsReflexive(original,
                               copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_this_is_a_some
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Error_AND_this_is_a_some_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(Message value)
      {
         //Message 
         var original = Error.Some(value);
         var copy     = Error.Some(value);

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy,
                                  value);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Error_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.Error>();

      Prop.ForAll<Error, Error>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Error_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveErrors>();

      Prop.ForAll<(Error, Error, Error)>(EqualsIsTransitive<Error>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_obj_is_a_Message
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Error_AND_obj_is_a_Message_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_Error_AND_ObjIsAMessage>();

      Prop.ForAll<(Error, Message, Message)>(EqualsIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_Error_AND_ObjIsAMessage
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Error, Message, Message)> Type()
         => Generators
           .TransitiveErrorAndMessages(Generators.Message(),
                                       Generators.TwoUniqueMessages())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // public bool Equals(Error? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Error
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Error_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Error_THEN_false_is_returned()
   {
      static Property Property(Error value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.Error>();

      Prop.ForAll<Error>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_this_is_a_none
   //WHEN
   //Equals_AND_other_is_a_nullable_Error
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Error_AND_this_is_a_none_WHEN_Equals_AND_other_is_a_nullable_Error_THEN_is_reflexive()
   {
      //Arrange
      var original = Error.None();
      var copy     = Error.None();

      //Act
      //Assert
      Assert.That
            .IEquatableIsReflexive(original,
                                   copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_Error
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Error_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_Error_THEN_is_reflexive()
   {
      static Property Property(Message value)
      {
         //Arrange
         var original = Option.Some(value);
         var copy     = Option.Some(value);

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
   //Error
   //WHEN
   //Equals_AND_other_is_a_nullable_Error
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Error_WHEN_Equals_AND_other_is_a_nullable_Error_THEN_is_symmetric()
   {
      Arb.Register<Libraries.Error>();

      Prop.ForAll<Error, Error>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error
   //WHEN
   //Equals_AND_other_is_a_nullable_Error
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Error_WHEN_Equals_AND_other_is_a_nullable_Error_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveErrors>();

      Prop.ForAll<(Error, Error, Error)>(IEquatableIsTransitive<Error>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(T? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_Message
   //THEN
   //is_pseudo_reflexive

   [TestMethod]
   public void GIVEN_Error_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_Message_THEN_is_pseudo_reflexive()
   {
      static Property Property(Message value)
      {
         //Arrange
         var option = Error.Some(value);

         //Act
         var actual = option.Equals(value);

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Error_AND_obj_is_a_Message
   //WHEN
   //Equals_AND_other_is_a_Message
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Error_WHEN_Equals_AND_other_is_a_Message_THEN_is_transitive()
   {
      Arb.Register<Library_Error_AND_ObjIsAMessage>();

      Prop.ForAll<(Error, Message, Message)>(IEquatableIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}