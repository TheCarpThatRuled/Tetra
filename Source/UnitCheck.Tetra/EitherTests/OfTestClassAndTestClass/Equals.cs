using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestClassAndTestClass;

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
   //Either_of_TestClass_and_TestClass_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_TestClass_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Either<TestClass, TestClass> either,
                               object?                      other)
      {
         //Arrange
         //Act
         var actual = either.Equals(other);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.EitherOfTestClassAndTestClass>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Either<TestClass, TestClass>, object?>(Property)
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
                  Generators.Result(Generators.Option(Generators.TestClass()))
                            .Select(x => (object?) x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestClass_and_TestClass_AND_Right_of_TestClass_and_TestClass_AND_Left_and_Right_contain_the_same_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_TestClass_and_TestClass_AND_Right_of_TestClass_and_TestClass_AND_Left_and_Right_contain_the_same_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var left  = Either<TestClass, TestClass>.Left(content);
         var right = Either<TestClass, TestClass>.Right(content);

         //Act
         var leftEqualsRight = left.Equals((object) right);
         var rightEqualsLeft = right.Equals((object) left);

         //Assert
         return IsFalse(leftEqualsRight)
           .And(IsFalse((rightEqualsLeft)));
      }

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(Either<TestClass, TestClass> either)
      {
         //Arrange
         var copy = either.Reduce(left => Either<TestClass, TestClass>.Left(left.Content()),
                                  right => Either<TestClass, TestClass>.Right(right.Content()));
         //Act
         //Assert
         return EqualsIsReflexive(either,
                                  copy);
      }

      Arb.Register<Libraries.EitherOfTestClassAndTestClass>();

      Prop.ForAll<Either<TestClass, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.EitherOfTestClassAndTestClass>();

      Prop.ForAll<Either<TestClass, TestClass>, Either<TestClass, TestClass>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveEithersOfTestClassAndTestClass>();

      Prop.ForAll<(Either<TestClass, TestClass>, Either<TestClass, TestClass>, Either<TestClass, TestClass>)>(EqualsIsTransitive<Either<TestClass, TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Either<TLeft, TRight>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_TestClass_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_TestClass_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass_THEN_false_is_returned()
   {
      static Property Property(Either<TestClass, TestClass> either)
      {
         //Arrange
         //Act
         var actual = either.Equals(default(Either<TestClass, TestClass>));

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.EitherOfTestClassAndTestClass>();

      Prop.ForAll<Either<TestClass, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestClass_and_TestClass_AND_Right_of_TestClass_and_TestClass_AND_Left_and_Right_contain_the_same_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_TestClass_and_TestClass_AND_Right_of_TestClass_and_TestClass_AND_Left_and_Right_contain_the_same_TestClass_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass_THEN_false_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var left  = Either<TestClass, TestClass>.Left(content);
         var right = Either<TestClass, TestClass>.Right(content);

         //Act
         var leftEqualsRight = left.Equals(right);
         var rightEqualsLeft = right.Equals(left);

         //Assert
         return IsFalse(leftEqualsRight)
           .And(IsFalse((rightEqualsLeft)));
      }

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_TestClass_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass_THEN_is_reflexive()
   {
      static Property Property(Either<TestClass, TestClass> either)
      {
         //Arrange
         var copy = either.Reduce(left => Either<TestClass, TestClass>.Left(left.Content()),
                                  right => Either<TestClass, TestClass>.Right(right.Content()));
         //Act
         //Assert
         return IEquatableIsReflexive(either,
                                      copy);
      }

      Arb.Register<Libraries.EitherOfTestClassAndTestClass>();

      Prop.ForAll<Either<TestClass, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_TestClass_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass_THEN_is_symmetric()
   {
      Arb.Register<Libraries.EitherOfTestClassAndTestClass>();

      Prop.ForAll<Either<TestClass, TestClass>, Either<TestClass, TestClass>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestClass_and_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Either_of_TestClass_and_TestClass_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestClass_and_TestClass_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveEithersOfTestClassAndTestClass>();

      Prop.ForAll<(Either<TestClass, TestClass>, Either<TestClass, TestClass>, Either<TestClass, TestClass>)>(IEquatableIsTransitive<Either<TestClass, TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}