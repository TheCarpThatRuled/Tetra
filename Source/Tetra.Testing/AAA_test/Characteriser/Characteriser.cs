using System.Text;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class Characteriser
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly ISequence<string> _givenBriefCharacterisation;
      private readonly ISequence<string> _givenFullCharacterisation;
      private readonly ISequence<string> _thenBriefCharacterisation;
      private readonly ISequence<string> _thenFullCharacterisation;
      private readonly ISequence<string> _whenBriefCharacterisation;
      private readonly ISequence<string> _whenFullCharacterisation;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Characteriser
      (
         ISequence<string> givenBriefCharacterisation,
         ISequence<string> whenBriefCharacterisation,
         ISequence<string> thenBriefCharacterisation,
         ISequence<string> givenFullCharacterisation,
         ISequence<string> whenFullCharacterisation,
         ISequence<string> thenFullCharacterisation
      )
      {
         _givenBriefCharacterisation = givenBriefCharacterisation;
         _givenFullCharacterisation  = givenFullCharacterisation;
         _whenBriefCharacterisation  = whenBriefCharacterisation;
         _whenFullCharacterisation   = whenFullCharacterisation;
         _thenBriefCharacterisation  = thenBriefCharacterisation;
         _thenFullCharacterisation   = thenFullCharacterisation;
      }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public string GenerateBriefCharacterisation()
      {
         var builder = new StringBuilder();

         builder.Append("GIVEN ");

         foreach (var (clause, index) in _givenBriefCharacterisation.WithIndices())
         {
            builder.Append(clause);

            if (index != _givenBriefCharacterisation.Length() - 1)
            {
               builder.Append(" AND ");
            }
         }

         builder.Append(" WHEN ");

         foreach (var (clause, index) in _whenBriefCharacterisation.WithIndices())
         {
            builder.Append(clause);

            if (index != _whenBriefCharacterisation.Length() - 1)
            {
               builder.Append(" AND ");
            }
         }

         builder.Append(" THEN ");

         foreach (var (clause, index) in _thenBriefCharacterisation.WithIndices())
         {
            builder.Append(clause);

            if (index != _thenBriefCharacterisation.Length() - 1)
            {
               builder.Append(" AND ");
            }
         }

         return builder.ToString();
      }

      /* ------------------------------------------------------------ */

      public string GenerateFullCharacterisation()
      {
         var builder = new StringBuilder();

         builder.AppendLine(">>> GIVEN <<<");

         foreach (var (clause, index) in _givenFullCharacterisation.WithIndices())
         {
            builder.AppendLine($">>> {clause}");

            if (index != _givenFullCharacterisation.Length() - 1)
            {
               builder.AppendLine(">>> AND");
            }
         }

         builder.AppendLine(">>> WHEN <<<");

         foreach (var (clause, index) in _whenFullCharacterisation.WithIndices())
         {
            builder.AppendLine($">>> {clause}");

            if (index != _whenFullCharacterisation.Length() - 1)
            {
               builder.AppendLine(">>> AND");
            }
         }

         builder.AppendLine(">>> THEN <<<");

         foreach (var (clause, index) in _thenFullCharacterisation.WithIndices())
         {
            if (index != _thenFullCharacterisation.Length() - 1)
            {
               builder.AppendLine($">>> {clause}");
               builder.AppendLine(">>> AND");
            }
            else
            {
               builder.Append($">>> {clause}");
            }
         }


         return builder.ToString();
      }

      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public ISequence<string> GivenCharacterisation()
         => _givenBriefCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> WhenCharacterisation()
         => _whenBriefCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> ThenCharacterisation()
         => _thenBriefCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> GivenFullCharacterisation()
         => _givenFullCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> WhenFullCharacterisation()
         => _whenFullCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> ThenFullCharacterisation()
         => _thenFullCharacterisation;

      /* ------------------------------------------------------------ */
   }
}