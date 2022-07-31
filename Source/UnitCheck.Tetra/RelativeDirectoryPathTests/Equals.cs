using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_RelativeDirectoryPath_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(RelativeDirectoryPath path,
                               object?               obj)
      {
         //Act
         var actual = path.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.RelativeDirectoryPath>();

      Prop.ForAll<RelativeDirectoryPath, object?>(Property)
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
   //RelativeDirectoryPath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_RelativeDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property((RelativeDirectoryPath original, RelativeDirectoryPath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return EqualsIsReflexive(args.original,
                                  args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalRelativeDirectoryPaths>();

      Prop.ForAll<(RelativeDirectoryPath, RelativeDirectoryPath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_RelativeDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.RelativeDirectoryPath>();

      Prop.ForAll<RelativeDirectoryPath, RelativeDirectoryPath>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_RelativeDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveRelativeDirectoryPaths>();

      Prop.ForAll<(RelativeDirectoryPath, RelativeDirectoryPath, RelativeDirectoryPath)>(EqualsIsTransitive<RelativeDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(RelativeDirectoryPath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_RelativeDirectoryPath
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_RelativeDirectoryPath_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_RelativeDirectoryPath_THEN_false_is_returned()
   {
      static Property Property(RelativeDirectoryPath value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.RelativeDirectoryPath>();

      Prop.ForAll<RelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_RelativeDirectoryPath
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_RelativeDirectoryPath_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_RelativeDirectoryPath_THEN_is_reflexive()
   {
      static Property Property((RelativeDirectoryPath original, RelativeDirectoryPath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return IEquatableIsReflexive(args.original,
                                      args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalRelativeDirectoryPaths>();

      Prop.ForAll<(RelativeDirectoryPath, RelativeDirectoryPath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath
   //WHEN
   //Equals_AND_other_is_a_nullable_RelativeDirectoryPath
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_RelativeDirectoryPath_WHEN_Equals_AND_other_is_a_nullable_RelativeDirectoryPath_THEN_is_symmetric()
   {
      Arb.Register<Libraries.RelativeDirectoryPath>();

      Prop.ForAll<RelativeDirectoryPath, RelativeDirectoryPath>(IEquatableIsSymmetric<RelativeDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath
   //WHEN
   //Equals_AND_other_is_a_nullable_RelativeDirectoryPath
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_RelativeDirectoryPath_WHEN_Equals_AND_other_is_a_nullable_RelativeDirectoryPath_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveRelativeDirectoryPaths>();

      Prop.ForAll<(RelativeDirectoryPath, RelativeDirectoryPath, RelativeDirectoryPath)>(IEquatableIsTransitive<RelativeDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}