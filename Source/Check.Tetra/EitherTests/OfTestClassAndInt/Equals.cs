using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestClassAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // public bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_int_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_int_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Either<TestClass, int> either,
                               object?                other)
      {
         //Arrange
         //Act
         var actual = either.Equals(other);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.EitherOfTestClassAndInt32>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Either<TestClass, int>, object?>(Property)
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
   //Either_of_TestClass_and_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(Either<TestClass, int> either)
      {
         //Arrange
         var copy = either.Reduce(left => Either<TestClass, int>.Left(left.Content()),
                                  right => Either<TestClass, int>.Right(right.Content()));
         //Act
         //Assert
         return EqualsIsReflexive(either,
                                  copy);
      }

      Arb.Register<Libraries.EitherOfTestClassAndInt32>();

      Prop.ForAll<Either<TestClass, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.EitherOfTestClassAndInt32>();

      Prop.ForAll<Either<TestClass, int>, Either<TestClass, int>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveEithersOfTestClassAndInt32>();

      Prop.ForAll<(Either<TestClass, int>, Either<TestClass, int>, Either<TestClass, int>)>(EqualsIsTransitive<Either<TestClass, int>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public bool Equals(Either<TLeft, TRight>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_int_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_int
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_int_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_int_THEN_false_is_returned()
   {
      static Property Property(Either<TestClass, int> either)
      {
         //Arrange
         //Act
         var actual = either.Equals(default(Either<TestClass, int>));

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.EitherOfTestClassAndInt32>();

      Prop.ForAll<Either<TestClass, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_int
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_int
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_int_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_int_THEN_is_reflexive()
   {
      static Property Property(Either<TestClass, int> either)
      {
         //Arrange
         var copy = either.Reduce(left => Either<TestClass, int>.Left(left.Content()),
                                  right => Either<TestClass, int>.Right(right.Content()));
         //Act
         //Assert
         return IEquatableIsReflexive(either,
                                      copy);
      }

      Arb.Register<Libraries.EitherOfTestClassAndInt32>();

      Prop.ForAll<Either<TestClass, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_int
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_int
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_int_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_int_THEN_is_symmetric()
   {
      Arb.Register<Libraries.EitherOfTestClassAndInt32>();

      Prop.ForAll<Either<TestClass, int>, Either<TestClass, int>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_int
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_int
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_int_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_int_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveEithersOfTestClassAndInt32>();

      Prop.ForAll<(Either<TestClass, int>, Either<TestClass, int>, Either<TestClass, int>)>(IEquatableIsTransitive<Either<TestClass, int>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}