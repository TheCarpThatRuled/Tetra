// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

public partial class AAA_test : ICharacterised
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string                          _characterisation;
   private readonly Func<Disposables, Func<Action>> _test;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AAA_test
   (
      string                          characterisation,
      Func<Disposables, Func<Action>> test
   )
   {
      _characterisation = characterisation;
      _test             = test;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.DefineGiven GIVEN<TActions, TAsserts>
   (
      AAA_test<TActions, TAsserts>.IInitialAction given
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .DefineGiven
        .Create(given);

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static AAA_test Create
   (
      string                          characterisation,
      Func<Disposables, Func<Action>> test
   )
      => new(characterisation,
             test);

   /* ------------------------------------------------------------ */
   // ICharacterised Methods
   /* ------------------------------------------------------------ */

   public string Characterisation()
      => _characterisation;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Given Create()
      => new(_test);

   /* ------------------------------------------------------------ */
}