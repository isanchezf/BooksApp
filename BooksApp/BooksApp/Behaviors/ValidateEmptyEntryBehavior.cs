namespace BooksApp.Behaviors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class ValidateEmptyEntryBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(ValidateEmptyEntryBehavior), false);

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
            bindable.BindingContextChanged -= OnBindingContextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var textValue = e.NewTextValue;
            IsValid = !string.IsNullOrEmpty(textValue) && textValue.Length >= 5;
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        private void OnBindingContextChanged(object sender, EventArgs eventArgs)
        {
            BindingContext = ((BindableObject)sender).BindingContext;
        }
    }
}
