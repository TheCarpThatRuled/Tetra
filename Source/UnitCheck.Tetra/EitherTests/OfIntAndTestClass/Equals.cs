using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfIntAndTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_int_and_TestClass_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Either_of_int_and_TestClass_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Either<int, TestClass> either,
                               object?                other)
      {
         //Arrange
         //Act
         var actual = either.Equals(other);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.EitherOfInt32AndTestClass>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Either<int, TestClass>, object?>(Property)
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
                            .Select(x => (object?) x),
                  Generators.UInt32()
                            .Select(x => (object?) x),
                  Generators.String()
                            .Select(x => (object?) x),
                  Generators.Result(Generators.TestClass())
                            .Select(x => (object?) x),
                  Generators.Result(Generators.TestStruct())
                            .Select(x => (object?) x),
                  Generators.Result(Generators.Option(Generators.Int32()))
                            .Select(x => (object?) x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_int_and_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Either_of_int_and_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(Either<int, TestClass> either)
      {
         //Arrange
         var copy = either.Reduce(left => Either<int, TestClass>.Left(left.Content()),
                                  right => Either<int, TestClass>.Right(right.Content()));
         //Act
         //Assert
         return EqualsIsReflexive(either,
                                  copy);
      }

      Arb.Register<Libraries.EitherOfInt32AndTestClass>();

      Prop.ForAll<Either<int, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_int_and_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Either_of_int_and_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.EitherOfInt32AndTestClass>();

      Prop.ForAll<Either<int, TestClass>, Either<int, TestClass>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_int_and_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Either_of_int_and_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveEithersOfInt32AndTestClass>();

      Prop.ForAll<(Either<int, TestClass>, Either<int, TestClass>, Either<int, TestClass>)>(EqualsIsTransitive<Either<int, TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Either<TLeft, TRight>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_int_and_TestClass_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_int_and_TestClass
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Either_of_int_and_TestClass_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Either_of_int_and_TestClass_THEN_false_is_returned()
   {
      static Property Property(Either<int, TestClass> either)
      {
         //Arrange
         //Act
         var actual = either.Equals(default(Either<int, TestClass>));

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.EitherOfInt32AndTestClass>();

      Prop.ForAll<Either<int, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_int_and_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_int_and_TestClass
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Either_of_int_and_TestClass_WHEN_Equals_AND_other_is_a_nullable_Either_of_int_and_TestClass_THEN_is_reflexive()
   {
      static Property Property(Either<int, TestClass> either)
      {
         //Arrange
         var copy = either.Reduce(left => Either<int, TestClass>.Left(left.Content()),
                                  right => Either<int, TestClass>.Right(right.Content()));
         //Act
         //Assert
         return IEquatableIsReflexive(either,
                                      copy);
      }

      Arb.Register<Libraries.EitherOfInt32AndTestClass>();

      Prop.ForAll<Either<int, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_int_and_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_int_and_TestClass
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Either_of_int_and_TestClass_WHEN_Equals_AND_other_is_a_nullable_Either_of_int_and_TestClass_THEN_is_symmetric()
   {
      Arb.Register<Libraries.EitherOfInt32AndTestClass>();

      Prop.ForAll<Either<int, TestClass>, Either<int, TestClass>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_int_and_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_int_and_TestClass
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Either_of_int_and_TestClass_WHEN_Equals_AND_other_is_a_nullable_Either_of_int_and_TestClass_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveEithersOfInt32AndTestClass>();

      Prop.ForAll<(Either<int, TestClass>, Either<int, TestClass>, Either<int, TestClass>)>(IEquatableIsTransitive<Either<int, TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}