namespace Tetra.Testing
{
   partial class AAATest
   {
      public sealed class ThenCharacteriser
      {
         /* ------------------------------------------------------------ */
         // Methods
         /* ------------------------------------------------------------ */

         public ThenCharacteriser AddClauseToBriefCharacterisation(string clause)
         {
            _briefCharacterisation.Add(clause);

            return this;
         }

         /* ------------------------------------------------------------ */

         public ThenCharacteriser AddClauseToCharacterisation(string clause)
            => AddClauseToBriefCharacterisation(clause)
              .AddClauseToFullCharacterisation(clause);

         /* ------------------------------------------------------------ */

         public ThenCharacteriser AddClauseToFullCharacterisation(string clause)
         {
            _fullCharacterisation.Add(clause);

            return this;
         }

         /* ------------------------------------------------------------ */
         // Internal Constructors
         /* ------------------------------------------------------------ */

         internal ThenCharacteriser(ISequence<string> givenBriefCharacterisation,
                                    ISequence<string> whenBriefCharacterisation,
                                    ISequence<string> givenFullCharacterisation,
                                    ISequence<string> whenFullCharacterisation)
         {
            _givenBriefBriefCharacterisation = givenBriefCharacterisation;
            _givenFullCharacterisation       = givenFullCharacterisation;
            _whenBriefBriefCharacterisation  = whenBriefCharacterisation;
            _whenFullCharacterisation        = whenFullCharacterisation;
         }

         /* ------------------------------------------------------------ */
         // Internal Methods
         /* ------------------------------------------------------------ */

         internal Characteriser Finish()
            => new(_givenBriefBriefCharacterisation,
                   _whenBriefBriefCharacterisation,
                   _briefCharacterisation.Materialise(),
                   _givenFullCharacterisation,
                   _whenFullCharacterisation,
                   _fullCharacterisation.Materialise());

         /* ------------------------------------------------------------ */
         // Private Fields
         /* ------------------------------------------------------------ */

         private readonly List<string> _briefCharacterisation = new();
         private readonly List<string> _fullCharacterisation  = new();

         private readonly ISequence<string> _givenBriefBriefCharacterisation;
         private readonly ISequence<string> _givenFullCharacterisation;
         private readonly ISequence<string> _whenBriefBriefCharacterisation;
         private readonly ISequence<string> _whenFullCharacterisation;

         /* ------------------------------------------------------------ */
      }
   }
}