using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_VolumeRootedDirectoryPath_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(VolumeRootedDirectoryPath VolumeRootedDirectoryPath,
                               object? obj)
      {
         //Act
         var actual = VolumeRootedDirectoryPath.Equals(obj);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.VolumeRootedDirectoryPath>();

      Prop.ForAll<VolumeRootedDirectoryPath, object?>(Property)
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
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_VolumeRootedDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property((VolumeRootedDirectoryPath original, VolumeRootedDirectoryPath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return EqualsIsReflexive(args.original,
                                  args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalVolumeRootedDirectoryPaths>();

      Prop.ForAll<(VolumeRootedDirectoryPath, VolumeRootedDirectoryPath )>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_VolumeRootedDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.VolumeRootedDirectoryPath>();

      Prop.ForAll<VolumeRootedDirectoryPath, VolumeRootedDirectoryPath>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_VolumeRootedDirectoryPath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveVolumeRootedDirectoryPaths>();

      Prop.ForAll<(VolumeRootedDirectoryPath, VolumeRootedDirectoryPath, VolumeRootedDirectoryPath)>(EqualsIsTransitive<VolumeRootedDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(VolumeRootedDirectoryPath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_VolumeRootedDirectoryPath
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_VolumeRootedDirectoryPath_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_VolumeRootedDirectoryPath_THEN_false_is_returned()
   {
      static Property Property(VolumeRootedDirectoryPath value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.VolumeRootedDirectoryPath>();

      Prop.ForAll<VolumeRootedDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_VolumeRootedDirectoryPath
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_VolumeRootedDirectoryPath_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_VolumeRootedDirectoryPath_THEN_is_reflexive()
   {
      static Property Property((VolumeRootedDirectoryPath original, VolumeRootedDirectoryPath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return IEquatableIsReflexive<AbsoluteDirectoryPath>(args.original,
                                                             args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalVolumeRootedDirectoryPaths>();

      Prop.ForAll<(VolumeRootedDirectoryPath, VolumeRootedDirectoryPath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath
   //WHEN
   //Equals_AND_other_is_a_nullable_VolumeRootedDirectoryPath
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_VolumeRootedDirectoryPath_WHEN_Equals_AND_other_is_a_nullable_VolumeRootedDirectoryPath_THEN_is_symmetric()
   {
      Arb.Register<Libraries.VolumeRootedDirectoryPath>();

      Prop.ForAll<VolumeRootedDirectoryPath, VolumeRootedDirectoryPath>(IEquatableIsSymmetric<AbsoluteDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath
   //WHEN
   //Equals_AND_other_is_a_nullable_VolumeRootedDirectoryPath
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_VolumeRootedDirectoryPath_WHEN_Equals_AND_other_is_a_nullable_VolumeRootedDirectoryPath_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveVolumeRootedDirectoryPaths>();

      Prop.ForAll<(VolumeRootedDirectoryPath, VolumeRootedDirectoryPath, VolumeRootedDirectoryPath)>(IEquatableIsTransitive<AbsoluteDirectoryPath, VolumeRootedDirectoryPath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}