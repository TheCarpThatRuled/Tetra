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
   // public bool Equals(object? obj)
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
      static Property Property(IOption<TestStruct> option,
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

      Prop.ForAll<IOption<TestStruct>, object?>(Property)
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

      Prop.ForAll<IOption<TestStruct>, IOption<TestStruct>>(EqualsIsSymmetric)
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

      Prop.ForAll<(IOption<TestStruct>, IOption<TestStruct>, IOption<TestStruct>)>(EqualsIsTransitive<IOption<TestStruct>>)
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

      Prop.ForAll<(IOption<TestStruct>, TestStruct, TestStruct)>(EqualsIsTransitive)
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

      public static Arbitrary<(IOption<TestStruct>, TestStruct, TestStruct)> Type()
         => Generators
           .TransitiveOptionAndT(Generators.TestStruct(),
                                 Generators.TwoUniqueTestStructs())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}