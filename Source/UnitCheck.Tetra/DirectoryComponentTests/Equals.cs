using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.DirectoryComponent)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // public bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_DirectoryComponent_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(DirectoryComponent directoryComponent,
                               object?            obj)
      {
         //Act
         var actual = directoryComponent.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent, object?>(Property)
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
   //DirectoryComponent
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_DirectoryComponent_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(DirectoryComponent original)
      {
         //Arrange
         var copy = DirectoryComponent.Create(original.Value());

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy);
      }

      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_DirectoryComponent_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent, DirectoryComponent>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_DirectoryComponent_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveDirectoryComponents>();

      Prop.ForAll<(DirectoryComponent, DirectoryComponent, DirectoryComponent)>(EqualsIsTransitive<DirectoryComponent>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public bool Equals(DirectoryComponent? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_DirectoryComponent
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_DirectoryComponent_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_DirectoryComponent_THEN_false_is_returned()
   {
      static Property Property(DirectoryComponent value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_DirectoryComponent
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_DirectoryComponent_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_DirectoryComponent_THEN_is_reflexive()
   {
      static Property Property(DirectoryComponent original)
      {
         //Arrange
         var copy = DirectoryComponent.Create(original.Value());

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent
   //WHEN
   //Equals_AND_other_is_a_nullable_DirectoryComponent
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_DirectoryComponent_WHEN_Equals_AND_other_is_a_nullable_DirectoryComponent_THEN_is_symmetric()
   {
      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent, DirectoryComponent>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent
   //WHEN
   //Equals_AND_other_is_a_nullable_DirectoryComponent
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_DirectoryComponent_WHEN_Equals_AND_other_is_a_nullable_DirectoryComponent_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveDirectoryComponents>();

      Prop.ForAll<(DirectoryComponent, DirectoryComponent, DirectoryComponent)>(IEquatableIsTransitive<DirectoryComponent>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}