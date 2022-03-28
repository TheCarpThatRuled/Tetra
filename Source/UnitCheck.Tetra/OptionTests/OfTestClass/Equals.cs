using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestClass;

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
   //Option_of_TestClass AND obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals AND obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Option_of_TestClass_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Option<TestClass> option,
                               object? obj)
      {
         //Act
         var actual = option.Equals(obj);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<OptionOfTestClass_AND_ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Option<TestClass>, object?>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class OptionOfTestClass_AND_ObjIsNullOrANonEquatableType
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Option<TestClass>> OptionOfInt()
         => Generators
           .Option(Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */

      public static Arbitrary<object?> Obj()
         => Gen
           .OneOf(Gen.Constant(default(object?)),
                  Generators.TestStruct()
                            .Select(x => (object?)x),
                  Generators.UInt32()
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x),
                  Generators.Option(Generators.Int32())
                            .Select(x => (object?)x),
                  Generators.Option(Generators.TestStruct())
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass AND this_is_a_none
   //WHEN
   //Equals AND obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Option_of_TestClass_AND_this_is_a_none_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      //Arrange
      var original = Option<TestClass>.None();
      var copy     = Option<TestClass>.None();

      //Act
      //Assert
      Assert.That
            .EqualsIsReflexive(original,
                               copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass AND this_is_a_some
   //WHEN
   //Equals AND obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Option_of_TestClass_AND_this_is_a_some_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(TestClass value)
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

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass
   //WHEN
   //Equals AND obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Option_of_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.OptionOfTestClass>();

      Prop.ForAll<Option<TestClass>, Option<TestClass>>(EqualsIsSymmetric<Option<TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveOptionOfTestClass>();

      Prop.ForAll<(Option<TestClass>, Option<TestClass>, Option<TestClass>)>(EqualsIsTransitive<Option<TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass AND obj_is_a_TestStruct
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_TestClass_AND_obj_is_a_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_OptionOfTestClass_AND_ObjIsATestClass>();

      Prop.ForAll<(Option<TestClass>, TestClass, TestClass)>(EqualsIsTransitive<Option<TestClass>, TestClass>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_OptionOfTestClass_AND_ObjIsATestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Option<TestClass>, TestClass, TestClass)> Type()
         => Generators
           .TransitiveOptionAndT(Generators.TestClass(),
                                 Generators.TwoUniqueTestClasses())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Option<T>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass AND other_is_null
   //WHEN
   //Equals AND other_is_a_nullable_Option_of_TestClass
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Option_of_TestClass_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestClass_THEN_false_is_returned()
   {
      static Property Property(Option<TestClass> value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.OptionOfTestClass>();

      Prop.ForAll<Option<TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass AND this_is_a_none
   //WHEN
   //Equals AND other_is_a_nullable_Option_of_TestClass
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Option_of_TestClass_AND_this_is_a_none_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestClass_THEN_is_reflexive()
   {
      //Arrange
      var original = Option<TestClass>.None();
      var copy     = Option<TestClass>.None();

      //Act
      //Assert
      Assert.That
            .IEquatableIsReflexive(original,
                                   copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass AND this_is_a_some
   //WHEN
   //Equals AND other_is_a_nullable_Option_of_TestClass
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Option_of_TestClass_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestClass_THEN_is_reflexive()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var original = Option.Some(value);
         var copy     = Option.Some(value);

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass
   //WHEN
   //Equals AND other_is_a_nullable_Option_of_TestClass
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Option_of_TestClass_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestClass_THEN_is_symmetric()
   {
      Arb.Register<Libraries.OptionOfTestClass>();

      Prop.ForAll<Option<TestClass>, Option<TestClass>>(IEquatableIsSymmetric<Option<TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass
   //WHEN
   //Equals AND other_is_a_nullable_Option_of_TestClass
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_TestClass_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestClass_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveOptionOfTestStruct>();

      Prop.ForAll<(Option<TestClass>, Option<TestClass>, Option<TestClass>)>(IEquatableIsTransitive<Option<TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(T? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass AND this_is_a_some
   //WHEN
   //Equals AND other_is_a_TestStruct
   //THEN
   //is_pseudo_reflexive

   [TestMethod]
   public void GIVEN_Option_of_TestClass_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_TestStruct_THEN_is_pseudo_reflexive()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Equals(value);

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass AND obj_is_an_int
   //WHEN
   //Equals AND other_is_a_TestStruct
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_TestClass_WHEN_Equals_AND_other_is_a_TestStruct_THEN_is_transitive()
   {
      Arb.Register<Library_OptionOfTestClass_AND_ObjIsATestClass>();

      Prop.ForAll<(Option<TestClass>, TestClass, TestClass)>(IEquatableIsTransitive<Option<TestClass>, TestClass>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}