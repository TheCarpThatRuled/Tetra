using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

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
   //Result_of_int_and_int_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Result_of_int_and_int_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(IResult<int, int> result,
                               object?           other)
      {
         //Arrange
         //Act
         var actual = result.Equals(other);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.ResultOfInt32AndInt32>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<IResult<int, int>, object?>(Property)
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
   //Success_of_int_and_int_AND_Failure_of_int_and_int_AND_Success_and_Failure_contain_the_same_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_and_int_AND_Failure_of_int_and_int_AND_Success_and_Failure_contain_the_same_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var success = Result<int, int>.Success(content);
         var failure = Result<int, int>.Failure(content);

         //Act
         var successEqualsFailure = success.Equals(failure);
         var failureEqualsSuccess = failure.Equals(success);

         //Assert
         return IsFalse(nameof(successEqualsFailure),
                        successEqualsFailure)
           .And(IsFalse(nameof(failureEqualsSuccess),
                        (failureEqualsSuccess)));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_and_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_int_and_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(IResult<int, int> result)
      {
         //Arrange
         var copy = result.Reduce(Result<int, int>.Success,
                                  Result<int, int>.Failure);
         //Act
         //Assert
         return EqualsIsReflexive(result,
                                  copy);
      }

      Arb.Register<Libraries.ResultOfInt32AndInt32>();

      Prop.ForAll<IResult<int, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_and_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_int_and_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfInt32AndInt32>();

      Prop.ForAll<IResult<int, int>, IResult<int, int>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_and_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_int_and_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfInt32AndInt32>();

      Prop.ForAll<(IResult<int, int>, IResult<int, int>, IResult<int, int>)>(EqualsIsTransitive<IResult<int, int>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}