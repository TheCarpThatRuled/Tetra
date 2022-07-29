using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ConditionTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Condition)]
// ReSharper disable once InconsistentNaming
public class False_Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //False_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //true_is_returned

   [TestMethod]
   public void
      GIVEN_False_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_true_is_returned()
   {
      static Property Property(object? obj)
      {
         //Act
         var actual = Condition
                     .False()
                     .Equals(obj);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<object?>(Property)
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
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x),
                  Generators.Option(Generators.Bool())
                            .Select(x => (object?)x),
                  Generators.Result(Generators.Bool())
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_False_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      //Arrange
      var original = Condition.False();
      var copy     = Condition.False();

      //Act
      //Assert
      Assert.That
            .EqualsIsReflexive(original,
                               copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False_AND_obj_is_false
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_False_AND_obj_is_false_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_true_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.Equals((object?) false);

      //Assert
      Assert.That
            .IsTrue("Return value",
                    actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False_AND_obj_is_True
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_False_AND_obj_is_True_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.Equals((object?)Condition.True());

      //Assert
      Assert.That
            .IsFalse("Return value",
                     actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False_AND_obj_is_true
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_False_AND_obj_is_true_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.Equals(true);

      //Assert
      Assert.That
            .IsFalse("Return value",
                     actual);
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Condition? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //False_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Condition
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_False_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Condition_THEN_false_is_returned()
   {
      //Act
      var actual = Condition
                  .False()
                  .Equals(default(Condition));

      //Assert
      Assert.That
            .IsFalse("Return value",
                     actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_False_WHEN_Equals_AND_other_is_a_nullable_Condition_THEN_is_reflexive()
   {
      //Arrange
      var original = Condition.False();
      var copy     = Condition.False();

      //Act
      //Assert
      Assert.That
            .IEquatableIsReflexive(original,
                                   copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False_AND_obj_is_True
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_False_AND_obj_is_True_WHEN_Equals_AND_other_is_a_nullable_Condition_THEN_false_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.Equals(Condition.True());

      //Assert
      Assert.That
            .IsFalse("Return value",
                     actual);
   }

   /* ------------------------------------------------------------ */
   // bool Equals(bool? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //False_AND_obj_is_false
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_False_AND_obj_is_false_WHEN_Equals_AND_other_is_a_nullable_bool_THEN_true_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.Equals(false);

      //Assert
      Assert.That
            .IsTrue("Return value",
                    actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //False_AND_obj_is_True
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_False_AND_obj_is_True_WHEN_Equals_AND_other_is_a_nullable_bool_THEN_false_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.Equals(Condition.True());

      //Assert
      Assert.That
            .IsFalse("Return value",
                     actual);
   }

   /* ------------------------------------------------------------ */
}