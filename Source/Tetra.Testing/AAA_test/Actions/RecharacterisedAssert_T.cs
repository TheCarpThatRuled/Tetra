namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class RecharacterisedAssert<TInitialAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedAssert<TInitialAsserts, TNextAsserts> Create(string                                 characterisation,
                                                                                IAssert<TInitialAsserts, TNextAsserts> assert)
         => new(assert,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAssert<TAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(ThenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(ThenCharacteriser characteriser)
         => _assert
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TNextAsserts Assert(TInitialAsserts environment)
         => _assert
           .Assert(environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAssert<TInitialAsserts, TNextAsserts> _assert;
      private readonly string                                 _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedAssert(IAssert<TInitialAsserts, TNextAsserts> assert,
                                    string                                 characterisation)
      {
         _assert           = assert;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
   }
}