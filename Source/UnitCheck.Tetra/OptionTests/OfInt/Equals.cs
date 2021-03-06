using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Option_of_int_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Option<int> option,
                               object? obj)
      {
         //Act
         var actual = option.Equals(obj);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.OptionOfInt32>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Option<int>, object?>(Property)
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
                            .Select(x => (object?)x),
                  Generators.Option(Generators.TestClass())
                            .Select(x => (object?)x),
                  Generators.Option(Generators.TestStruct())
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_this_is_a_none
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Option_of_int_AND_this_is_a_none_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      //Arrange
      var original = Option<int>.None();
      var copy     = Option<int>.None();

      //Act
      //Assert
      Assert.That
            .EqualsIsReflexive(original,
                               copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_this_is_a_some
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Option_of_int_AND_this_is_a_some_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(int value)
      {
         //Arrange
         var original = Option.Some(value);
         var copy     = Option.Some(value);

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy,
                                  value);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Option_of_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.OptionOfInt32>();

      Prop.ForAll<Option<int>, Option<int>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveOptionsOfInt32>();

      Prop.ForAll<(Option<int>, Option<int>, Option<int>)>(EqualsIsTransitive<Option<int>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_obj_is_an_int
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_int_AND_obj_is_an_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_OptionOfInt_AND_ObjIsAnInt>();

      Prop.ForAll<(Option<int>, int, int)>(EqualsIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_OptionOfInt_AND_ObjIsAnInt
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Option<int>, int, int)> Type()
         => Generators
           .TransitiveOptionAndT(Generators.Int32(),
                                 Generators.TwoUniqueInt32s())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Option<T>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_int
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Option_of_int_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Option_of_int_THEN_false_is_returned()
   {
      static Property Property(Option<int> value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.OptionOfInt32>();

      Prop.ForAll<Option<int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_this_is_a_none
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_int
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Option_of_int_AND_this_is_a_none_WHEN_Equals_AND_other_is_a_nullable_Option_of_int_THEN_is_reflexive()
   {
      //Arrange
      var original = Option<int>.None();
      var copy     = Option<int>.None();

      //Act
      //Assert
      Assert.That
            .IEquatableIsReflexive(original,
                                   copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_int
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Option_of_int_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_Option_of_int_THEN_is_reflexive()
   {
      static Property Property(int value)
      {
         //Arrange
         var original = Option.Some(value);
         var copy     = Option.Some(value);

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_int
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Option_of_int_WHEN_Equals_AND_other_is_a_nullable_Option_of_int_THEN_is_symmetric()
   {
      Arb.Register<Libraries.OptionOfInt32>();

      Prop.ForAll<Option<int>, Option<int>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_int
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_int_WHEN_Equals_AND_other_is_a_nullable_Option_of_int_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveOptionsOfInt32>();

      Prop.ForAll<(Option<int>, Option<int>, Option<int>)>(IEquatableIsTransitive<Option<int>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(T? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_an_int
   //THEN
   //is_pseudo_reflexive

   [TestMethod]
   public void GIVEN_Option_of_int_AND_this_is_a_some_WHEN_Equals_AND_other_is_an_int_THEN_is_pseudo_reflexive()
   {
      static Property Property(int value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Equals(value);

         //Assert
         return IsTrue(actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int_AND_obj_is_an_int
   //WHEN
   //Equals_AND_other_is_an_int
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_int_WHEN_Equals_AND_other_is_an_int_THEN_is_transitive()
   {
      Arb.Register<Library_OptionOfInt_AND_ObjIsAnInt>();

      Prop.ForAll<(Option<int>, int, int)>(IEquatableIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}