using AndroidX.AppCompat.Widget;
using Google.Android.Material.TextField;
using Microsoft.Maui.Handlers;
using LP = Android.Widget.LinearLayout.LayoutParams;

namespace MauiIssueEntry.Controls;

public class CEntry : Entry
{
    public CEntry()
    {
    }

    protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
    {
        var size = base.MeasureOverride(widthConstraint, heightConstraint); //Required to tolerate layout's constraints
        MinimumWidthRequest = widthConstraint;
        return size;
    }
}

public class CEntryHandler : ViewHandler<CEntry, TextInputLayout>, IEntryHandler
{
    public static PropertyMapper<CEntry, CEntryHandler> PropertyMapper = new PropertyMapper<CEntry, CEntryHandler>(EntryHandler.Mapper)
    {
        [nameof(IEntry.Placeholder)] = MapPlaceholder, //Placeholder needs to be moved to TextInputLayout
    };

    public CEntryHandler() : base(PropertyMapper, null)
    {
        //PropertyMapper.ReplaceMapping<CEntry, CEntryHandler>(nameof(IView.Width), MapWidth);
    }

    protected override TextInputLayout CreatePlatformView()
    {
        TextInputLayout layout = new(Context)
        {
            LayoutParameters = new LP(LP.MatchParent, LP.WrapContent),
        };
        AppCompatEditText editText = new(layout.Context) //important to set context from TextInputLayout
        {
            LayoutParameters = new LP(LP.MatchParent, LP.WrapContent)
        };
        editText.SetSingleLine(true);

        layout.AddView(editText, new LP(LP.MatchParent, LP.WrapContent));

        return layout;
    }

    public static void MapPlaceholder(CEntryHandler handler, CEntry entry)
    {
        handler.PlatformView.Hint = entry.Placeholder;
    }

    public new IEntry VirtualView => base.VirtualView;
    AppCompatEditText IEntryHandler.PlatformView => this.PlatformView.EditText as AppCompatEditText;
}