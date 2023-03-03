using System.Windows;

namespace Tetra.Testing;

public sealed class TextBoxAsserts<TAsserts, TAssertsInstance>
   where TAsserts : IAsserts
   where TAssertsInstance : IAssertsInstance
{
   /* ------------------------------------------------------------ */
   // Constructors
   /* ------------------------------------------------------------ */

   public TextBoxAsserts(string                                                                                                                       descriptionHeader,
                         Func<Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser>, Action<TextBoxAssertsInstance<TAssertsInstance>>, TAsserts> returnToParent)
   {
      _descriptionHeader = descriptionHeader;
      _returnToParent    = returnToParent;
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TAsserts Is_displayed(Expected_text_box expected)
   {
      _characteriser = _characteriser.Then(
         characteriser => characteriser.AddClauseToBriefCharacterisation($"{_descriptionHeader}{nameof(Is_displayed)}: {expected.BriefCharacterisation()}"));

      return IsEnabled_is(expected.IsEnabled())
            .Text_is(expected.Text())
            .Visibility_is(expected.Visibility())
            .ReturnToParent();
   }

   /* ------------------------------------------------------------ */

   public TextBoxAsserts<TAsserts, TAssertsInstance> IsEnabled_is(bool expected)
   {
      _characteriser = _characteriser.Then(characteriser => characteriser.AddClauseToFullCharacterisation($"{_descriptionHeader}{nameof(IsEnabled_is)}: {expected}"));
      _then          = _then.Then(asserts => asserts.IsEnabled_is(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public TextBoxAsserts<TAsserts, TAssertsInstance> Text_is(object expected)
   {
      _characteriser = _characteriser.Then(characteriser => characteriser.AddClauseToFullCharacterisation($"{_descriptionHeader}{nameof(Text_is)}: {expected}"));
      _then          = _then.Then(asserts => asserts.Text_is(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public TextBoxAsserts<TAsserts, TAssertsInstance> Visibility_is(Visibility expected)
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

   private readonly string                                                                                                                       _descriptionHeader;
   private readonly Func<Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser>, Action<TextBoxAssertsInstance<TAssertsInstance>>, TAsserts> _returnToParent;

   //Mutable
   private Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> _characteriser = Function.PassThrough;
   private Action<TextBoxAssertsInstance<TAssertsInstance>>           _then          = Function.NoOp;

   /* ------------------------------------------------------------ */
}