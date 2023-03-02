using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
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
      static Property Property(IResult<TestClass> result,
                               object? obj)
      {
         //Act
         var actual = result.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.ResultOfTestClass>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<IResult<TestClass>, object?>(Property)
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

      Prop.ForAll<IResult<TestClass>, IResult<TestClass>>(EqualsIsSymmetric)
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

      Prop.ForAll<(IResult<TestClass>, IResult<TestClass>, IResult<TestClass>)>(EqualsIsTransitive<IResult<TestClass>>)
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

      Prop.ForAll<(IResult<TestClass>, TestClass, TestClass)>(EqualsIsTransitive)
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

      public static Arbitrary<(IResult<TestClass>, TestClass, TestClass)> Type()
         => Generators
           .TransitiveResultAndT(Generators.TestClass(),
                                 Generators.TwoUniqueTestClasses())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}