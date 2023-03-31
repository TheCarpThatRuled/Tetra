using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_and_TestStruct_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_and_TestStruct_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(IResult<TestStruct, TestStruct> result,
                               object?                         other)
      {
         //Arrange
         //Act
         var actual = result.Equals(other);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.ResultOfTestStructAndTestStruct>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<IResult<TestStruct, TestStruct>, object?>(Property)
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

      // ReSharper disable once UnusedMember.Local
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
   //Success_of_TestStruct_and_TestStruct_AND_Failure_of_TestStruct_and_TestStruct_AND_Success_and_Failure_contain_the_same_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_and_TestStruct_AND_Failure_of_TestStruct_and_TestStruct_AND_Success_and_Failure_contain_the_same_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var success = Result<TestStruct, TestStruct>.Success(content);
         var failure = Result<TestStruct, TestStruct>.Failure(content);

         //Act
         var successEqualsFailure = success.Equals(failure);
         var failureEqualsSuccess = failure.Equals(success);

         //Assert
         return IsFalse(nameof(successEqualsFailure),
                        successEqualsFailure)
           .And(IsFalse(nameof(failureEqualsSuccess),
                        (failureEqualsSuccess)));
      }

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_and_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(IResult<TestStruct, TestStruct> result)
      {
         //Arrange
         var copy = result.Reduce(Result<TestStruct, TestStruct>.Success,
                                  Result<TestStruct, TestStruct>.Failure);
         //Act
         //Assert
         return EqualsIsReflexive(result,
                                  copy);
      }

      Arb.Register<Libraries.ResultOfTestStructAndTestStruct>();

      Prop.ForAll<IResult<TestStruct, TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_and_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfTestStructAndTestStruct>();

      Prop.ForAll<IResult<TestStruct, TestStruct>, IResult<TestStruct, TestStruct>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_and_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_and_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfTestStructAndTestStruct>();

      Prop.ForAll<(IResult<TestStruct, TestStruct>, IResult<TestStruct, TestStruct>, IResult<TestStruct, TestStruct>)>(EqualsIsTransitive<IResult<TestStruct, TestStruct>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}