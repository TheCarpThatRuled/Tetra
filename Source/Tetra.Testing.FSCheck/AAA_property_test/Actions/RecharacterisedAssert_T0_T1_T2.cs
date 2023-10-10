namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class RecharacterisedAssert<TInitialAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAssert<TInitialAsserts, TNextAsserts> _assert;
      private readonly string                                 _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedAssert
      (
         IAssert<TInitialAsserts, TNextAsserts> assert,
         string                                 characterisation
      )
      {
         _assert           = assert;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IAssert<TAsserts, TState> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         ThenCharacteriser characteriser
      )
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         ThenCharacteriser characteriser
      )
         => _assert
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TNextAsserts Assert
      (
         TState          state,
         TInitialAsserts environment
      )
         => _assert
           .Assert(state,
                   environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedAssert<TInitialAsserts, TNextAsserts> Create
      (
         IAssert<TInitialAsserts, TNextAsserts> assert,
         string                                 characterisation
      )
         => new(assert,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}