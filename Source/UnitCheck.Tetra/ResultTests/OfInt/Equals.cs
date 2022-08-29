using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfInt;

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
   //Result_of_int_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Result_of_int_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(IResult<int> result,
                               object? obj)
      {
         //Act
         var actual = result.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.ResultOfInt32>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<IResult<int>, object?>(Property)
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
                            .Select(x => (object?)x),
                  Generators.UInt32()
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x),
                  Generators.Result(Generators.TestClass())
                            .Select(x => (object?)x),
                  Generators.Result(Generators.TestStruct())
                            .Select(x => (object?)x),
                  Generators.Result(Generators.Option(Generators.Int32()))
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_AND_this_is_a_Failure
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_int_AND_this_is_a_Failure_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(Message content)
      {
         //Arrange
         var original = Result<int>.Failure(content);
         var copy     = Result<int>.Failure(content);

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
   //Result_of_int_AND_this_is_a_Success
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_int_AND_this_is_a_Success_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(int content)
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

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfInt32>();

      Prop.ForAll<IResult<int>, IResult<int>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfInt32>();

      Prop.ForAll<(IResult<int>, IResult<int>, IResult<int>)>(EqualsIsTransitive<IResult<int>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_AND_obj_is_an_int
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_int_AND_obj_is_an_int_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_ResultOfInt_AND_ObjIsAnInt>();

      Prop.ForAll<(IResult<int>, int, int)>(EqualsIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_ResultOfInt_AND_ObjIsAnInt
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(IResult<int>, int, int)> Type()
         => Generators
           .TransitiveResultAndT(Generators.Int32(),
                                 Generators.TwoUniqueInt32s())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}