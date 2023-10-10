namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class ThenCharacteriser
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<string> _briefCharacterisation = new();
      private readonly List<string> _fullCharacterisation  = new();

      private readonly ISequence<string> _givenBriefCharacterisation;
      private readonly ISequence<string> _givenFullCharacterisation;
      private readonly ISequence<string> _whenBriefCharacterisation;
      private readonly ISequence<string> _whenFullCharacterisation;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ThenCharacteriser
      (
         ISequence<string> givenBriefCharacterisation,
         ISequence<string> whenBriefCharacterisation,
         ISequence<string> givenFullCharacterisation,
         ISequence<string> whenFullCharacterisation
      )
      {
         _givenBriefCharacterisation = givenBriefCharacterisation;
         _givenFullCharacterisation  = givenFullCharacterisation;
         _whenBriefCharacterisation  = whenBriefCharacterisation;
         _whenFullCharacterisation   = whenFullCharacterisation;
      }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ThenCharacteriser AddClauseToBriefCharacterisation
      (
         string clause
      )
      {
         _briefCharacterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */

      public ThenCharacteriser AddClauseToCharacterisation
      (
         string clause
      )
         => AddClauseToBriefCharacterisation(clause)
           .AddClauseToFullCharacterisation(clause);

      /* ------------------------------------------------------------ */

      public ThenCharacteriser AddClauseToFullCharacterisation
      (
         string clause
      )
      {
         _fullCharacterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Methods
      /* ------------------------------------------------------------ */

      internal Characteriser Finish()
         => new(_givenBriefCharacterisation,
                _whenBriefCharacterisation,
                _briefCharacterisation.Materialise(),
                _givenFullCharacterisation,
                _whenFullCharacterisation,
                _fullCharacterisation.Materialise());

      /* ------------------------------------------------------------ */
   }
}