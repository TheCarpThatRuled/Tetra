﻿using System.Windows;

namespace Tetra.Testing;

public sealed class FakeTextBox
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeTextBox Create(TextBoxContext context)
      => new(context);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public bool IsEnabled()
      => _isEnabled
        .Get();

   /* ------------------------------------------------------------ */

   public string Text()
      => _text
        .Get();

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility
        .Get();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void SetText(string text)
      => _text
        .Set(text);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeOneWayBinding<bool>       _isEnabled;
   private readonly FakeTwoWayBinding<string>     _text;
   private readonly FakeOneWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeTextBox(TextBoxContext context)
   {
      _isEnabled = FakeOneWayBinding<bool>.Create(context,
                                                  nameof(TextBoxContext.IsEnabled),
                                                  () => context.IsEnabled);
      _text = FakeTwoWayBinding<string>.Create(context,
                                               nameof(TextBoxContext.Text),
                                               () => context.Text,
                                               value => context.Text = value);
      _visibility = FakeOneWayBinding<Visibility>.Create(context,
                                                         nameof(TextBoxContext.Visibility),
                                                         () => context.Visibility);
   }

   /* ------------------------------------------------------------ */
}