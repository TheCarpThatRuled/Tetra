namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class CompoundAssert<TInitialAsserts, TMiddleAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
      where TInitialAsserts : IAsserts
      where TMiddleAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAssert<TInitialAsserts, TMiddleAsserts> _first;
      private readonly IAssert<TMiddleAsserts, TNextAsserts>    _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundAssert
      (
         IAssert<TInitialAsserts, TMiddleAsserts> first,
         IAssert<TMiddleAsserts, TNextAsserts>    second
      )
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
      // IAssertAction<TInitialAsserts, TNextAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         ThenCharacteriser characteriser
      )
      {
         _first.AddBriefCharacterisation(characteriser);
         _second.AddBriefCharacterisation(characteriser);
      }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         ThenCharacteriser characteriser
      )
      {
         _first.AddFullCharacterisation(characteriser);
         _second.AddFullCharacterisation(characteriser);
      }

      /* ------------------------------------------------------------ */

      public TNextAsserts Assert
      (
         TInitialAsserts environment
      )
         => _second
           .Assert(_first.Assert(environment));
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundAssert<TInitialAsserts, TMiddleAsserts, TNextAsserts> Create
      (
         IAssert<TInitialAsserts, TMiddleAsserts> first,
         IAssert<TMiddleAsserts, TNextAsserts>    second
      )
         => new(first,
                second);

      /* ------------------------------------------------------------ */
   }
}