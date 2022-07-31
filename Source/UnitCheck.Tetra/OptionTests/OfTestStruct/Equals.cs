using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

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
   //Option_of_TestStruct_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Option_of_TestStruct_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Option<TestStruct> option,
                               object? obj)
      {
         //Act
         var actual = option.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.OptionOfTestStruct>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Option<TestStruct>, object?>(Property)
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
                  Generators.TestClass()
                            .Select(x => (object?)x),
                  Generators.UInt32()
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x),
                  Generators.Option(Generators.Int32())
                            .Select(x => (object?)x),
                  Generators.Option(Generators.TestClass())
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct_AND_this_is_a_none
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_AND_this_is_a_none_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      //Arrange
      var original = Option<TestStruct>.None();
      var copy     = Option<TestStruct>.None();

      //Act
      //Assert
      Assert.That
            .EqualsIsReflexive(original,
                               copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct_AND_this_is_a_some
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_AND_this_is_a_some_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(TestStruct value)
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

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.OptionOfTestStruct>();

      Prop.ForAll<Option<TestStruct>, Option<TestStruct>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveOptionsOfTestStruct>();

      Prop.ForAll<(Option<TestStruct>, Option<TestStruct>, Option<TestStruct>)>(EqualsIsTransitive<Option<TestStruct>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct_AND_obj_is_a_TestStruct
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_AND_obj_is_a_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_OptionOfTestStruct_AND_ObjIsAnTestStruct>();

      Prop.ForAll<(Option<TestStruct>, TestStruct, TestStruct)>(EqualsIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_OptionOfTestStruct_AND_ObjIsAnTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Option<TestStruct>, TestStruct, TestStruct)> Type()
         => Generators
           .TransitiveOptionAndT(Generators.TestStruct(),
                                 Generators.TwoUniqueTestStructs())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Option<T>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_TestStruct
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Option_of_TestStruct_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestStruct_THEN_false_is_returned()
   {
      static Property Property(Option<TestStruct> value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.OptionOfTestStruct>();

      Prop.ForAll<Option<TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct_AND_this_is_a_none
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_TestStruct
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Option_of_TestStruct_AND_this_is_a_none_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestStruct_THEN_is_reflexive()
   {
      //Arrange
      var original = Option<TestStruct>.None();
      var copy     = Option<TestStruct>.None();

      //Act
      //Assert
      Assert.That
            .IEquatableIsReflexive(original,
                                   copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_TestStruct
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Option_of_TestStruct_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestStruct_THEN_is_reflexive()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var original = Option.Some(value);
         var copy     = Option.Some(value);

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_TestStruct
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestStruct_THEN_is_symmetric()
   {
      Arb.Register<Libraries.OptionOfTestStruct>();

      Prop.ForAll<Option<TestStruct>, Option<TestStruct>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct
   //WHEN
   //Equals_AND_other_is_a_nullable_Option_of_TestStruct
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_WHEN_Equals_AND_other_is_a_nullable_Option_of_TestStruct_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveOptionsOfTestStruct>();

      Prop.ForAll<(Option<TestStruct>, Option<TestStruct>, Option<TestStruct>)>(IEquatableIsTransitive<Option<TestStruct>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(T? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_TestStruct
   //THEN
   //is_pseudo_reflexive

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_TestStruct_THEN_is_pseudo_reflexive()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Equals(value);

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct_AND_obj_is_an_int
   //WHEN
   //Equals_AND_other_is_a_TestStruct
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_WHEN_Equals_AND_other_is_a_TestStruct_THEN_is_transitive()
   {
      Arb.Register<Library_OptionOfTestStruct_AND_ObjIsAnTestStruct>();

      Prop.ForAll<(Option<TestStruct>, TestStruct, TestStruct)>(IEquatableIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}