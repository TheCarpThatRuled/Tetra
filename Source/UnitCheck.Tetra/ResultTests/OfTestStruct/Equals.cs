using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Result_of_TestStruct_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Result<TestStruct> result,
                               object? obj)
      {
         //Act
         var actual = result.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.ResultOfTestStruct>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Result<TestStruct>, object?>(Property)
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
                  Generators.String()
                            .Select(x => (object?)x),
                  Generators.Result(Generators.Int32())
                            .Select(x => (object?)x),
                  Generators.Result(Generators.TestClass())
                            .Select(x => (object?)x),
                  Generators.Result(Generators.Option(Generators.TestStruct()))
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_this_is_a_Failure
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_AND_this_is_a_Failure_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(Message content)
      {
         //Arrange
         var original = Result<TestStruct>.Failure(content);
         var copy     = Result<TestStruct>.Failure(content);

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_this_is_a_Success
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_AND_this_is_a_Success_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var original = Result.Success(content);
         var copy     = Result.Success(content);

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy,
                                  content);
      }

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfTestStruct>();

      Prop.ForAll<Result<TestStruct>, Result<TestStruct>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfTestStruct>();

      Prop.ForAll<(Result<TestStruct>, Result<TestStruct>, Result<TestStruct>)>(EqualsIsTransitive<Result<TestStruct>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_obj_is_an_TestStruct
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_AND_obj_is_an_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_ResultOfTestStruct_AND_ObjIsAnTestStruct>();

      Prop.ForAll<(Result<TestStruct>, TestStruct, TestStruct)>(EqualsIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_ResultOfTestStruct_AND_ObjIsAnTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Result<TestStruct>, TestStruct, TestStruct)> Type()
         => Generators
           .TransitiveResultAndT(Generators.TestStruct(),
                                 Generators.TwoUniqueTestStructs())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Result<T>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestStruct
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Result_of_TestStruct_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestStruct_THEN_false_is_returned()
   {
      static Property Property(Result<TestStruct> content)
      {
         //act
         var actual = content.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.ResultOfTestStruct>();

      Prop.ForAll<Result<TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_this_is_a_Failure
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestStruct
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Result_of_TestStruct_AND_this_is_a_Failure_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestStruct_THEN_is_reflexive()
   {
      static Property Property(Message content)
      {
         //Arrange
         var original = Result<TestStruct>.Failure(content);
         var copy     = Result<TestStruct>.Failure(content);

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
   //Result_of_TestStruct_AND_this_is_a_Success
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestStruct
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Result_of_TestStruct_AND_this_is_a_Success_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestStruct_THEN_is_reflexive()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var original = Result.Success(content);
         var copy     = Result.Success(content);

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestStruct
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestStruct_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfTestStruct>();

      Prop.ForAll<Result<TestStruct>, Result<TestStruct>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestStruct
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestStruct_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfTestStruct>();

      Prop.ForAll<(Result<TestStruct>, Result<TestStruct>, Result<TestStruct>)>(IEquatableIsTransitive<Result<TestStruct>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(T? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_this_is_a_Success
   //WHEN
   //Equals_AND_other_is_an_TestStruct
   //THEN
   //is_pseudo_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_AND_this_is_a_Success_WHEN_Equals_AND_other_is_an_TestStruct_THEN_is_pseudo_reflexive()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Equals(content);

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_obj_is_an_TestStruct
   //WHEN
   //Equals_AND_other_is_an_TestStruct
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Equals_AND_other_is_an_TestStruct_THEN_is_transitive()
   {
      Arb.Register<Library_ResultOfTestStruct_AND_ObjIsAnTestStruct>();

      Prop.ForAll<(Result<TestStruct>, TestStruct, TestStruct)>(IEquatableIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}