using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // public bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_AbsoluteDirectoryPath_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(AbsoluteDirectoryPath path,
                               object?               obj)
      {
         //Act
         var actual = path.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.AbsoluteDirectoryPath>();

      Prop.ForAll<AbsoluteDirectoryPath, object?>(Property)
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
                  Generators.Int32()
                            .Select(x => (object?) x),
                  Generators.String()
                            .Select(x => (object?) x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_AbsoluteDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property((AbsoluteDirectoryPath original, AbsoluteDirectoryPath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return EqualsIsReflexive(args.original,
                                  args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalAbsoluteDirectoryPaths>();

      Prop.ForAll<(AbsoluteDirectoryPath, AbsoluteDirectoryPath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_AbsoluteDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.AbsoluteDirectoryPath>();

      Prop.ForAll<AbsoluteDirectoryPath, AbsoluteDirectoryPath>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_AbsoluteDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveAbsoluteDirectoryPaths>();

      Prop.ForAll<(AbsoluteDirectoryPath, AbsoluteDirectoryPath, AbsoluteDirectoryPath)>(EqualsIsTransitive<AbsoluteDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public bool Equals(AbsoluteDirectoryPath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_AbsoluteDirectoryPath
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_AbsoluteDirectoryPath_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_AbsoluteDirectoryPath_THEN_false_is_returned()
   {
      static Property Property(AbsoluteDirectoryPath value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.AbsoluteDirectoryPath>();

      Prop.ForAll<AbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_AbsoluteDirectoryPath
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_AbsoluteDirectoryPath_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_AbsoluteDirectoryPath_THEN_is_reflexive()
   {
      static Property Property((AbsoluteDirectoryPath original, AbsoluteDirectoryPath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return IEquatableIsReflexive(args.original,
                                      args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalAbsoluteDirectoryPaths>();

      Prop.ForAll<(AbsoluteDirectoryPath, AbsoluteDirectoryPath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath
   //WHEN
   //Equals_AND_other_is_a_nullable_AbsoluteDirectoryPath
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_AbsoluteDirectoryPath_WHEN_Equals_AND_other_is_a_nullable_AbsoluteDirectoryPath_THEN_is_symmetric()
   {
      Arb.Register<Libraries.AbsoluteDirectoryPath>();

      Prop.ForAll<AbsoluteDirectoryPath, AbsoluteDirectoryPath>(IEquatableIsSymmetric<AbsoluteDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath
   //WHEN
   //Equals_AND_other_is_a_nullable_AbsoluteDirectoryPath
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_AbsoluteDirectoryPath_WHEN_Equals_AND_other_is_a_nullable_AbsoluteDirectoryPath_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveAbsoluteDirectoryPaths>();

      Prop.ForAll<(AbsoluteDirectoryPath, AbsoluteDirectoryPath, AbsoluteDirectoryPath)>(IEquatableIsTransitive<AbsoluteDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}