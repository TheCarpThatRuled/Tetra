using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestStructAndTestStruct;

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
   //Either_of_TestStruct_and_TestStruct_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Either_of_TestStruct_and_TestStruct_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Either<TestStruct, TestStruct> either,
                               object?                        other)
      {
         //Arrange
         //Act
         var actual = either.Equals(other);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.EitherOfTestStructAndTestStruct>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Either<TestStruct, TestStruct>, object?>(Property)
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
                  Generators.Result(Generators.Option(Generators.TestStruct()))
                            .Select(x => (object?) x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct_and_TestStruct_AND_Right_of_TestStruct_and_TestStruct_AND_Left_and_Right_contain_the_same_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_TestStruct_and_TestStruct_AND_Right_of_TestStruct_and_TestStruct_AND_Left_and_Right_contain_the_same_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var left  = Either<TestStruct, TestStruct>.Left(content);
         var right = Either<TestStruct, TestStruct>.Right(content);

         //Act
         var leftEqualsRight = left.Equals((object) right);
         var rightEqualsLeft = right.Equals((object) left);

         //Assert
         return IsFalse(nameof(leftEqualsRight),
                        leftEqualsRight)
           .And(IsFalse(nameof(rightEqualsLeft),
                        (rightEqualsLeft)));
      }

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Either_of_TestStruct_and_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(Either<TestStruct, TestStruct> either)
      {
         //Arrange
         var copy = either.Reduce(left => Either<TestStruct, TestStruct>.Left(left.Content()),
                                  right => Either<TestStruct, TestStruct>.Right(right.Content()));
         //Act
         //Assert
         return EqualsIsReflexive(either,
                                  copy);
      }

      Arb.Register<Libraries.EitherOfTestStructAndTestStruct>();

      Prop.ForAll<Either<TestStruct, TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Either_of_TestStruct_and_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.EitherOfTestStructAndTestStruct>();

      Prop.ForAll<Either<TestStruct, TestStruct>, Either<TestStruct, TestStruct>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Either_of_TestStruct_and_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveEithersOfTestStructAndTestStruct>();

      Prop.ForAll<(Either<TestStruct, TestStruct>, Either<TestStruct, TestStruct>, Either<TestStruct, TestStruct>)>(EqualsIsTransitive<Either<TestStruct, TestStruct>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public bool Equals(Either<TLeft, TRight>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestStruct_and_TestStruct_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Either_of_TestStruct_and_TestStruct_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct_THEN_false_is_returned()
   {
      static Property Property(Either<TestStruct, TestStruct> either)
      {
         //Arrange
         //Act
         var actual = either.Equals(default(Either<TestStruct, TestStruct>));

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.EitherOfTestStructAndTestStruct>();

      Prop.ForAll<Either<TestStruct, TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct_and_TestStruct_AND_Right_of_TestStruct_and_TestStruct_AND_Left_and_Right_contain_the_same_TestStruct
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_TestStruct_and_TestStruct_AND_Right_of_TestStruct_and_TestStruct_AND_Left_and_Right_contain_the_same_TestStruct_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct_THEN_false_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var left  = Either<TestStruct, TestStruct>.Left(content);
         var right = Either<TestStruct, TestStruct>.Right(content);

         //Act
         var leftEqualsRight = left.Equals(right);
         var rightEqualsLeft = right.Equals(left);

         //Assert
         return IsFalse(nameof(leftEqualsRight),
                        leftEqualsRight)
           .And(IsFalse(nameof(rightEqualsLeft),
                        (rightEqualsLeft)));
      }

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Either_of_TestStruct_and_TestStruct_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct_THEN_is_reflexive()
   {
      static Property Property(Either<TestStruct, TestStruct> either)
      {
         //Arrange
         var copy = either.Reduce(left => Either<TestStruct, TestStruct>.Left(left.Content()),
                                  right => Either<TestStruct, TestStruct>.Right(right.Content()));
         //Act
         //Assert
         return IEquatableIsReflexive(either,
                                      copy);
      }

      Arb.Register<Libraries.EitherOfTestStructAndTestStruct>();

      Prop.ForAll<Either<TestStruct, TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Either_of_TestStruct_and_TestStruct_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct_THEN_is_symmetric()
   {
      Arb.Register<Libraries.EitherOfTestStructAndTestStruct>();

      Prop.ForAll<Either<TestStruct, TestStruct>, Either<TestStruct, TestStruct>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Either_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Either_of_TestStruct_and_TestStruct_WHEN_Equals_AND_other_is_a_nullable_Either_of_TestStruct_and_TestStruct_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveEithersOfTestStructAndTestStruct>();

      Prop.ForAll<(Either<TestStruct, TestStruct>, Either<TestStruct, TestStruct>, Either<TestStruct, TestStruct>)>(IEquatableIsTransitive<Either<TestStruct, TestStruct>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}