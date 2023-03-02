using System.Windows;

namespace Tetra.Testing;

public sealed class LabelAsserts<TAsserts, TAssertsInstance>
   where TAsserts : IAsserts
   where TAssertsInstance : IAssertsInstance
{
   /* ------------------------------------------------------------ */
   // Constructors
   /* ------------------------------------------------------------ */

   public LabelAsserts(string                                                                                                                     descriptionHeader,
                       Func<Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser>, Action<LabelAssertsInstance<TAssertsInstance>>, TAsserts> returnToParent)
   {
      _descriptionHeader = descriptionHeader;
      _returnToParent    = returnToParent;
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TAsserts Is_displayed(Expected_label expected)
   {
      _characteriser = _characteriser.Then(characteriser => characteriser.AddClauseToBriefCharacterisation($"{_descriptionHeader}{nameof(Is_displayed)}: {expected.BriefCharacterisation()}"));

      return Content_is(expected.Content())
            .Visibility_is(expected.Visibility())
            .ReturnToParent();
   }

   /* ------------------------------------------------------------ */

   public LabelAsserts<TAsserts, TAssertsInstance> Content_is(object expected)
   {
      _characteriser = _characteriser.Then(characteriser => characteriser.AddClauseToFullCharacterisation($"{_descriptionHeader}{nameof(Content_is)}: {expected}"));
      _then          = _then.Then(asserts => asserts.Content_is(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public LabelAsserts<TAsserts, TAssertsInstance> Visibility_is(Visibility expected)
   {
      _characteriser = _characteriser.Then(characteriser => characteriser.AddClauseToFullCharacterisation($"{_descriptionHeader}{nameof(Visibility_is)}: {expected}"));
      _then          = _then.Then(asserts => asserts.Visibility_is(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */

   public TAsserts ReturnToParent()
      => _returnToParent(_characteriser,
                         _then);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string                                                                                                                     _descriptionHeader;
   private readonly Func<Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser>, Action<LabelAssertsInstance<TAssertsInstance>>, TAsserts> _returnToParent;

   //Mutable
   private Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> _characteriser = Function.PassThrough;
   private Action<LabelAssertsInstance<TAssertsInstance>>             _then          = Function.NoOp;

   /* ------------------------------------------------------------ */
}