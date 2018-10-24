using Android.Text;
using Android.Widget;
using BattleconCompanion.Droid;
using BattleconCompanion.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HtmlFormatLabel), typeof(HtmlFormatLabelRenderer))]
namespace BattleconCompanion.Droid
{
    public class HtmlFormatLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HtmlFormatLabel)Element;
            if (view == null) return;

            Control.SetText(Html.FromHtml(view.Text.ToString(), FromHtmlOptions.ModeLegacy), TextView.BufferType.Spannable);
        }
    }
}