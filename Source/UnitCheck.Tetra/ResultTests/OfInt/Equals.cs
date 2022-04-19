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
      static Property Property(Result<int> result,
                               object? obj)
      {
         //Act
         var actual = result.Equals(obj);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.ResultOfInt32>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<Result<int>, object?>(Property)
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

      Prop.ForAll<Result<int>, Result<int>>(EqualsIsSymmetric)
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

      Prop.ForAll<(Result<int>, Result<int>, Result<int>)>(EqualsIsTransitive<Result<int>>)
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

      Prop.ForAll<(Result<int>, int, int)>(EqualsIsTransitive)
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

      public static Arbitrary<(Result<int>, int, int)> Type()
         => Generators
           .TransitiveResultAndT(Generators.Int32(),
                                 Generators.TwoUniqueInt32s())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // bool Equals(Result<T>? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_int
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Result_of_int_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Result_of_int_THEN_false_is_returned()
   {
      static Property Property(Result<int> content)
      {
         //act
         var actual = content.Equals(null);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.ResultOfInt32>();

      Prop.ForAll<Result<int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_AND_this_is_a_Failure
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_int
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Result_of_int_AND_this_is_a_Failure_WHEN_Equals_AND_other_is_a_nullable_Result_of_int_THEN_is_reflexive()
   {
      static Property Property(Message content)
      {
         //Arrange
         var original = Result<int>.Failure(content);
         var copy     = Result<int>.Failure(content);

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
   //Result_of_int_AND_this_is_a_Success
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_int
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Result_of_int_AND_this_is_a_Success_WHEN_Equals_AND_other_is_a_nullable_Result_of_int_THEN_is_reflexive()
   {
      static Property Property(int content)
      {
         //Arrange
         var original = Result.Success(content);
         var copy     = Result.Success(content);

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_int
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_int_WHEN_Equals_AND_other_is_a_nullable_Result_of_int_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfInt32>();

      Prop.ForAll<Result<int>, Result<int>>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int
   //WHEN
   //Equals_AND_other_is_a_nullable_Result_of_int
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_int_WHEN_Equals_AND_other_is_a_nullable_Result_of_int_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfInt32>();

      Prop.ForAll<(Result<int>, Result<int>, Result<int>)>(IEquatableIsTransitive<Result<int>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(T? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_AND_this_is_a_Success
   //WHEN
   //Equals_AND_other_is_an_int
   //THEN
   //is_pseudo_reflexive

   [TestMethod]
   public void GIVEN_Result_of_int_AND_this_is_a_Success_WHEN_Equals_AND_other_is_an_int_THEN_is_pseudo_reflexive()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Equals(content);

         //Assert
         return IsTrue(actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int_AND_obj_is_an_int
   //WHEN
   //Equals_AND_other_is_an_int
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_int_WHEN_Equals_AND_other_is_an_int_THEN_is_transitive()
   {
      Arb.Register<Library_ResultOfInt_AND_ObjIsAnInt>();

      Prop.ForAll<(Result<int>, int, int)>(IEquatableIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}