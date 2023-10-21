using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace RTH.Windows.Views.Helpers
{
    /// <summary>
    /// Apply this behavior to a TextBox to ensure that it only accepts numeric values.
    /// The property <see cref="NumericTextBoxBehavior.AllowDecimal"/> controls whether or not
    /// the input is an integer or not.
    /// <para>
    /// A common requirement is to constrain the number count that appears after the decimal place.
    /// Setting <see cref="NumericTextBoxBehavior.DecimalLimit"/> specifies how many numbers appear here.
    /// If this value is 0, no limit is applied.
    /// </para>
    /// </summary>
    /// <remarks>
    /// In the view, this behavior is attached in the following way:
    /// <code>
    /// <TextBox Text="{Binding Price}">
    ///   <i:Interaction.Behaviors>
    ///     <gl:NumericTextBoxBehavior AllowDecimal="False" />
    ///   </i:Interaction.Behaviors>
    /// </TextBox>
    /// </code>
    /// <para>
    /// Add references to System.Windows.Interactivity to the view to use
    /// this behavior.
    /// </para>
    /// </remarks>
    public partial class NumericTextBoxBehavior : Behavior<TextBox>
    {
        private string _pattern = string.Empty;

        /// <summary>
        /// Initialize a new instance of <see cref="NumericTextBoxBehavior"/>.
        /// </summary>
        public NumericTextBoxBehavior()
        {
           
        }

        public bool AllowDecimal
        {
            get { return (bool)GetValue(AllowDecimalProperty); }
            set { SetValue(AllowDecimalProperty, value); SetText(); }
        }

        // Using a DependencyProperty as the backing store for AllowDecimal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowDecimalProperty =
            DependencyProperty.Register("AllowDecimal", typeof(bool), typeof(NumericTextBoxBehavior), new PropertyMetadata(true));


        public Int32 DecimalLimit
        {
            get { return (Int32)GetValue(DecimalLimitProperty); }
            set { SetValue(DecimalLimitProperty, value); SetText(); }
        }

        // Using a DependencyProperty as the backing store for DecimalLimit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecimalLimitProperty =
            DependencyProperty.Register("DecimalLimit", typeof(Int32), typeof(NumericTextBoxBehavior), new PropertyMetadata(0));




        public bool AllowNegatives
        {
            get { return (bool)GetValue(AllowNegativeProperty); }
            set { SetValue(AllowNegativeProperty, value); SetText(); }
        }

        // Using a DependencyProperty as the backing store for AllowNegative.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowNegativeProperty =
            DependencyProperty.Register("AllowNegative", typeof(bool), typeof(NumericTextBoxBehavior), new PropertyMetadata(true));




        #region Overrides
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewTextInput += new TextCompositionEventHandler(AssociatedObject_PreviewTextInput);
#if !SILVERLIGHT
            DataObject.AddPastingHandler(AssociatedObject, OnClipboardPaste);
#endif
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= new TextCompositionEventHandler(AssociatedObject_PreviewTextInput);
#if !SILVERLIGHT
            DataObject.RemovePastingHandler(AssociatedObject, OnClipboardPaste);
#endif
        }
        #endregion

        #region Private methods
        private void SetText()
        {
            _pattern = string.Empty;
            GetRegularExpressionText();
        }

#if !SILVERLIGHT
        /// <summary>
        /// Handle paste operations into the textbox to ensure that the behavior
        /// is consistent with directly typing into the TextBox.
        /// </summary>
        /// <param name="sender">The TextBox sender.</param>
        /// <param name="dopea">Paste event arguments.</param>
        /// <remarks>This operation is only available in WPF.</remarks>
        private void OnClipboardPaste(object sender, DataObjectPastingEventArgs dopea)
        {
            string text = dopea.SourceDataObject.GetData(dopea.FormatToApply).ToString();

            if (!string.IsNullOrWhiteSpace(text) && !Validate(text))
                dopea.CancelCommand();
        }
#endif

        /// <summary>
        /// Preview the text input.
        /// </summary>
        /// <param name="sender">The TextBox sender.</param>
        /// <param name="e">The composition event arguments.</param>
        void AssociatedObject_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Validate(e.Text);
        }

        /// <summary>
        /// Validate the contents of the textbox with the new content to see if it is
        /// valid.
        /// </summary>
        /// <param name="value">The text to validate.</param>
        /// <returns>True if this is valid, false otherwise.</returns>
        protected bool Validate(string value)
        {
            TextBox textBox = AssociatedObject;

            string pre = string.Empty;
            string post = string.Empty;

            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                int selStart = textBox.SelectionStart;
                if (selStart > textBox.Text.Length)
                    selStart--;
                pre = textBox.Text.Substring(0, selStart);
                post = textBox.Text.Substring(selStart + textBox.SelectionLength, textBox.Text.Length - (selStart + textBox.SelectionLength));
            }
            else
            {
                pre = textBox.Text.Substring(0, textBox.CaretIndex);
                post = textBox.Text.Substring(textBox.CaretIndex, textBox.Text.Length - textBox.CaretIndex);
            }
            string test = string.Concat(pre, value, post);

            string pattern = GetRegularExpressionText();

            return new Regex(pattern).IsMatch(test);
        }

        private string GetRegularExpressionText()
        {
            if (!string.IsNullOrWhiteSpace(_pattern))
            {
                return _pattern;
            }
            _pattern = GetPatternText();
            return _pattern;
        }

        private string GetPatternText()
        {
            string pattern = string.Empty;
            string signPattern = "[{0}+]";

            // If the developer has chosen to allow negative numbers, the pattern will be [-+].
            // If the developer chooses not to allow negatives, the pattern is [+].
            if (AllowNegatives)
            {
                signPattern = string.Format(signPattern, "-");
            }
            else
            {
                signPattern = string.Format(signPattern, string.Empty);
            }

            // If the developer doesn't allow decimals, return the pattern.
            if (!AllowDecimal)
            {
                return string.Format(@"^({0}?)(\d*)$", signPattern);
            }

            // If the developer has chosen to apply a decimal limit, the pattern matches
            // on a


            if (DecimalLimit > 0)
            {
                pattern = string.Format(@"^({2}?)(\d*)([{0}]?)(\d{{0,{1}}})$",
                  NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator,
                  DecimalLimit,
                  signPattern);
            }
            else
            {
                pattern = string.Format(@"^({1}?)(\d*)([{0}]?)(\d*)$", NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator, signPattern);
            }

            return pattern;
        }
        #endregion
    }

}