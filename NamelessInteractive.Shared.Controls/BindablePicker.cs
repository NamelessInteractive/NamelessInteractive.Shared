using System;
using Xamarin.Forms;
using System.Collections;

namespace NamelessInteractive.Shared.Controls
{
    /// <summary>
    /// Bindable picker.
    /// </summary>
    public class BindablePicker : Picker
    {
        #region Bindable Properties
        /// <summary>
        /// The items source property.
        /// </summary>
        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindablePicker, IEnumerable>(o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);

        /// <summary>
        /// The selected item property.
        /// </summary>
        public static BindableProperty SelectedItemProperty =
            BindableProperty.Create<BindablePicker, object>(o => o.SelectedItem, default(object), propertyChanged: OnSelectedItemChanged);

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the items source.
        /// </summary>
        /// <value>The items source.</value>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Raises the selected index changed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = Items[SelectedIndex];
            }
        }

        /// <summary>
        /// Raises the items source changed event.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldvalue">Oldvalue.</param>
        /// <param name="newvalue">Newvalue.</param>
        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var picker = bindable as BindablePicker;
            picker.Items.Clear();
            if (newvalue != null)
            {
                //now it works like "subscribe once" but you can improve
                foreach (var item in newvalue)
                {
                    picker.Items.Add(item.ToString());
                }
            }
        }

        /// <summary>
        /// Raises the selected item changed event.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldvalue">Oldvalue.</param>
        /// <param name="newvalue">Newvalue.</param>
        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as BindablePicker;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="NamelessInteractive.Shared.Controls.BindablePicker"/> class.
        /// </summary>
        public BindablePicker ()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }
    }
}

