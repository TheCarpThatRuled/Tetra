namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class WhenCharacteriser
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public WhenCharacteriser AddClauseToBriefCharacterisation(string clause)
      {
         _briefCharacterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */

      public WhenCharacteriser AddClauseToCharacterisation(string clause)
         => AddClauseToBriefCharacterisation(clause)
           .AddClauseToFullCharacterisation(clause);

      /* ------------------------------------------------------------ */

      public WhenCharacteriser AddClauseToFullCharacterisation(string clause)
      {
         _fullCharacterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal WhenCharacteriser(ISequence<string> givenBriefCharacterisation,
                                 ISequence<string> givenFullCharacterisation)
      {
         _givenBriefCharacterisation = givenBriefCharacterisation;
         _givenFullCharacterisation  = givenFullCharacterisation;
      }

      /* ------------------------------------------------------------ */
      // Internal Methods
      /* ------------------------------------------------------------ */

      // ReSharper disable once MemberHidesStaticFromOuterClass
      internal ThenCharacteriser Then()
         => new(_givenBriefCharacterisation,
                _briefCharacterisation.Materialise(),
                _givenFullCharacterisation,
                _fullCharacterisation.Materialise());

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<string> _briefCharacterisation = new();
      private readonly List<string> _fullCharacterisation  = new();

      private readonly ISequence<string> _givenBriefCharacterisation;
      private readonly ISequence<string> _givenFullCharacterisation;

      /* ------------------------------------------------------------ */
   }
}