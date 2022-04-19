using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestClass;

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
   //Result_of_TestClass_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Result_of_TestClass_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(Result<TestClass> result,
                               object? obj)
      {
         //Act
         var actual = result.Equals(obj);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.ResultOfTestClass>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Result<TestClass>, object?>(Property)
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
                  Generators.Result(Generators.TestStruct())
                            .Select(x => (object?)x),
                  Generators.Result(Generators.Option(Generators.TestClass()))
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_this_is_a_Failure
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_AND_this_is_a_Failure_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(Message content)
      {
         //Arrange
         var original = Result<TestClass>.Failure(content);
         var copy     = Result<TestClass>.Failure(content);

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
   //Result_of_TestClass_AND_this_is_a_Success
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_AND_this_is_a_Success_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(TestClass content)
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

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfTestClass>();

      Prop.ForAll<Result<TestClass>, Result<TestClass>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfTestClass>();

      Prop.ForAll<(Result<TestClass>, Result<TestClass>, Result<TestClass>)>(EqualsIsTransitive<Result<TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_obj_is_an_TestClass
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_AND_obj_is_an_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_ResultOfTestClass_AND_ObjIsAnTestClass>();

      Prop.ForAll<(Result<TestClass>, TestClass, TestClass)>(EqualsIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_ResultOfTestClass_AND_ObjIsAnTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Result<TestClass>, TestClass, TestClass)> Type()
         => Generators
           .TransitiveResultAndT(Generators.TestClass(),
                                 Generators.TwoUniqueTestClasses())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Result<T>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestClass
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Result_of_TestClass_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestClass_THEN_false_is_returned()
   {
      static Property Property(Result<TestClass> content)
      {
         //act
         var actual = content.Equals(null);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.ResultOfTestClass>();

      Prop.ForAll<Result<TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_this_is_a_Failure
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestClass
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Result_of_TestClass_AND_this_is_a_Failure_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestClass_THEN_is_reflexive()
   {
      static Property Property(Message content)
      {
         //Arrange
         var original = Result<TestClass>.Failure(content);
         var copy     = Result<TestClass>.Failure(content);

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
   //Result_of_TestClass_AND_this_is_a_Success
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestClass
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Result_of_TestClass_AND_this_is_a_Success_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestClass_THEN_is_reflexive()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var original = Result.Success(content);
         var copy     = Result.Success(content);

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestClass
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestClass_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfTestClass>();

      Prop.ForAll<Result<TestClass>, Result<TestClass>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_TestClass
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Equals_AND_other_is_a_nullable_Result_of_TestClass_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfTestClass>();

      Prop.ForAll<(Result<TestClass>, Result<TestClass>, Result<TestClass>)>(IEquatableIsTransitive<Result<TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(T? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_this_is_a_Success
   //WHEN
   //Equals_AND_other_is_an_TestClass
   //THEN
   //is_pseudo_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_AND_this_is_a_Success_WHEN_Equals_AND_other_is_an_TestClass_THEN_is_pseudo_reflexive()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Equals(content);

         //Assert
         return IsTrue(actual);
      }

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_obj_is_an_TestClass
   //WHEN
   //Equals_AND_other_is_an_TestClass
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Equals_AND_other_is_an_TestClass_THEN_is_transitive()
   {
      Arb.Register<Library_ResultOfTestClass_AND_ObjIsAnTestClass>();

      Prop.ForAll<(Result<TestClass>, TestClass, TestClass)>(IEquatableIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}