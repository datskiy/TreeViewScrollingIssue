using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace TreeViewScrollingIssue;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public TreeViewTestGroupItem[] GroupsItemSource { get; } =
    [
        new TreeViewTestGroupItem("Group I"),
        new TreeViewTestGroupItem("Group II"),
        new TreeViewTestGroupItem("Group III"),
        new TreeViewTestGroupItem("Group IV"),
        new TreeViewTestGroupItem("Group V"),
        new TreeViewTestGroupItem("Group VI"),
        new TreeViewTestGroupItem("Group VII")
    ];

    public MainWindow()
    {
        InitializeComponent();
    }
}

public sealed class TreeViewTestGroupItem(string title)
{
    public string Title { get; } = title;

    public TreeViewTestMemberItem[] MembersItemSource { get; } =
    [
        new("Member #01"),
        new("Member #02"),
        new("Member #03"),
        new("Member #04"),
        new("Member #05"),
        new("Member #06"),
        new("Member #07"),
        new("Member #08"),
        new("Member #09"),
        new("Member #10"),
        new("Member #11"),
        new("Member #12"),
        new("Member #13"),
        new("Member #14"),
        new("Member #15"),
        new("Member #16"),
        new("Member #17"),
        new("Member #18"),
        new("Member #19"),
        new("Member #20")
    ];
}

public sealed class TreeViewTestMemberItem(string name)
{
    public string Name { get; } = name;
}

public sealed class TreeViewTemplateSelector : DataTemplateSelector
{
    public DataTemplate? GroupTemplate { get; set; }

    public DataTemplate? MemberTemplate { get; set; }

    protected override DataTemplate? SelectTemplateCore(object item)
    {
        return item switch
        {
            TreeViewTestGroupItem => GroupTemplate,
            TreeViewTestMemberItem => MemberTemplate,
            _ => throw new ArgumentOutOfRangeException(nameof(item))
        };
    }
}