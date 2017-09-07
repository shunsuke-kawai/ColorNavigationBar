using Xamarin.Forms;

namespace ColorNavigationBar.Controls
{
    public class CustomContentPage : ContentPage
    {
        #region NavigationBarColor BindableProperty
        public static readonly BindableProperty NavigationBarColorProperty =
            BindableProperty.Create(nameof(NavigationBarColor), typeof(Color), typeof(CustomContentPage), default(Color),
                propertyChanged: (bindable, oldValue, newValue) =>
                    ((CustomContentPage)bindable).NavigationBarColor = (Color)newValue);

        public Color NavigationBarColor
        {
            get { return (Color)GetValue(NavigationBarColorProperty); }
            set { SetValue(NavigationBarColorProperty, value); }
        }
        #endregion


        #region IsUseDefaultBarStyle BindableProperty
        public static readonly BindableProperty IsUseDefaultBarStyleProperty =
            BindableProperty.Create(nameof(IsUseDefaultBarStyle), typeof(bool), typeof(CustomContentPage), default(bool),
                propertyChanged: (bindable, oldValue, newValue) =>
                    ((CustomContentPage)bindable).IsUseDefaultBarStyle = (bool)newValue);

        public bool IsUseDefaultBarStyle
        {
            get { return (bool)GetValue(IsUseDefaultBarStyleProperty); }
            set { SetValue(IsUseDefaultBarStyleProperty, value); }
        }
        #endregion

    }
}
