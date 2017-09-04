using ColorNavigationBarIcon.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(ColorIconContentPageRenderer))]
namespace ColorNavigationBarIcon.iOS.Renderers
{
    public class ColorIconContentPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (this.NavigationController == null) return;

            var items = this.NavigationController.TopViewController.NavigationItem;

            foreach (var item in items.RightBarButtonItems)
            {
                if (item.Image == null) continue;

                item.Image = item.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
        }
    }
}