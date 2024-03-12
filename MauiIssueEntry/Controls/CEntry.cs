using Android.Widget;
using Google.Android.Material.TextField;
using Microsoft.Maui.Handlers;
using LP = Android.Widget.LinearLayout.LayoutParams;

namespace MauiIssueEntry.Controls;

public class CEntry : View
{
    public CEntry()
    {
    }
}

public class CEntryHandler : ViewHandler<CEntry, Android.Views.View>
{
    public static PropertyMapper<CEntry, CEntryHandler> PropertyMapper = new PropertyMapper<CEntry, CEntryHandler>();
    public CEntryHandler() : base(PropertyMapper, null)
    {
    }

    protected override Android.Views.View CreatePlatformView()
    {
        TextInputLayout layout = new(Context)
        {
            LayoutParameters = new LP(LP.MatchParent, LP.MatchParent),
        };
        TextInputEditText editText = new(Context)
        {
            LayoutParameters = new LP(LP.MatchParent, LP.WrapContent)
        };
        editText.SetSingleLine(true);

        layout.AddView(editText, new LP(LP.MatchParent, LP.WrapContent));
        layout.Hint = "Placeholder test";
        editText.Text = "Text test";

        return layout;
    }
}