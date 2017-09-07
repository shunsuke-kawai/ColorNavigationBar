using System;
using System.ComponentModel;
using ColorNavigationBar.Controls;
using ColorNavigationBar.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomContentPage), typeof(ColorIconContentPageRenderer))]
namespace ColorNavigationBar.iOS.Renderers
{
    public class ColorIconContentPageRenderer : PageRenderer
    {
        private Color _barColor;
        private UIStatusBarStyle _barStyle;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            _barStyle = ((CustomContentPage)e.NewElement).IsUseDefaultBarStyle ? UIStatusBarStyle.Default : UIStatusBarStyle.LightContent;
            _barColor = ((CustomContentPage)e.NewElement).NavigationBarColor;
        }


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            UIApplication.SharedApplication.StatusBarStyle = _barStyle;

            if (this.NavigationController == null) return;

            NavigationController.NavigationBar.BarTintColor = _barColor.ToUIColor();

            var items = this.NavigationController.TopViewController.NavigationItem;
            foreach (var item in items.RightBarButtonItems)
            {
                if (item.Image == null) continue;

                item.Image = item.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
        }
    }
}