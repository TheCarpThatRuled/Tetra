﻿namespace Tetra.Testing;

public sealed class TextBoxActions<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string      _descriptionHeader;
   private readonly FakeTextBox _textBox;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TextBoxActions
   (
      string      descriptionHeader,
      Func<T>     next,
      FakeTextBox textBox
   ) : base(next)
   {
      _textBox           = textBox;
      _descriptionHeader = descriptionHeader;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TextBoxActions<T> Create
   (
      string      descriptionHeader,
      FakeTextBox textBox,
      Func<T>     next
   )
      => new(descriptionHeader,
             next,
             textBox);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TextBoxActions<T> EnterText
   (
      string text
   )
   {
      if (!_textBox.IsEnabled())
      {
         throw Failed
              .InTheAsserts($"enter text into {_descriptionHeader}",
                            "it is not enabled")
              .ToAssertFailedException();
      }

      _textBox.EnterText(text);

      return this;
   }

   /* ------------------------------------------------------------ */
}