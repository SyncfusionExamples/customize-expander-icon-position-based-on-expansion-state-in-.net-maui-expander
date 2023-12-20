# customize-expander-icon-position-based-on-expansion-state-in-.net-maui-expander
This example demonstrates about how to show the expander icon in header in collapsed state and show the expander icon in content part in expanded state in .NET MAUI Expander (SfExpander).
How to display the expander icon in the header at collapsed state and content at expand state in Maui Expander (SfExpander)?
You can customize the expander icon to be in header or content based on expand/collapse using the custom expander icon and converters in Maui SfExpander.

XAML

Define converters for Expander.Header and Expander.Content to change the expander icon visibility based on the IsExpanded property.
```
<ContentPage xmlns= "http://schemas.microsoft.com/dotnet/2021/maui”
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ExpanderXamarin"
             xmlns: syncfusion="clr-namespace:Syncfusion.Maui.Expander;assembly=Syncfusion.Maui.Expander"
             x:Class="ExpanderMaui.MainPage" Padding="{OnPlatform iOS='0,40,0,0'}">
    <ContentPage.Resources>
        <ResourceDictionary>
            <OnPlatform x:TypeArguments="x:String" x:Key="ExpanderIcon">
                <On Platform="Android" Value="ExpanderIcons.ttf#ExpanderIcons" />
                <On Platform="" Value="/Assets/ExpanderIcons.ttf#ExpanderIcons" />
                <On Platform="iOS" Value="ExpanderIcons" />
            </OnPlatform>
        </ResourceDictionary>
        <local:ExpanderIconConverter x:Key="ExpanderIconConverter"/>
        <local:ExpanderVisibilityConverter x:Key="ExpanderVisibilityConverter"/>
    </ContentPage.Resources>
    <ContentPage.Content>
        <ScrollView BackgroundColor="#EDF2F5" Margin="{OnPlatform iOS='0,40,0,0'}">
            <StackLayout>
                <syncfusion:SfExpander x:Name="expander1" HeaderIconPosition="None">
                    <syncfusion:SfExpander.Header>
                        <Grid HeightRequest="50">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="50"/>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <Label HorizontalOptions="Center" VerticalOptions="Center"
                                FontFamily="{StaticResource ExpanderIcon}"
                                IsVisible="{Binding Path=IsExpanded, Source={x:Reference expander1}, Converter={StaticResource ExpanderVisibilityConverter}, ConverterParameter=Header}" 
                                Text="{Binding Path=IsExpanded,Source={x:Reference expander1}, Converter={StaticResource ExpanderIconConverter}, ConverterParameter={x:Static Device.RuntimePlatform}}"/>
                            <Label Text="Veg Pizza" Grid.Column="1" TextColor="#495F6E"  VerticalTextAlignment="Center" />
                        </Grid>
                    </syncfusion:SfExpander.Header>
                    <syncfusion:SfExpander.Content>
                        <Grid BackgroundColor="#FFFFFF">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="50"/>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <Label HorizontalOptions="Center" VerticalOptions="Center"
                                   FontFamily="{StaticResource ExpanderIcon}" 
                                   IsVisible="{Binding Path=IsExpanded,Source={x:Reference expander1}, Converter={StaticResource ExpanderVisibilityConverter}, ConverterParameter=Content}" 
                                   Text="{Binding Path=IsExpanded,Source={x:Reference expander1}, Converter={StaticResource ExpanderIconConverter}, ConverterParameter={x:Static Device.RuntimePlatform}}"/>
                            <Label BackgroundColor="#FFFFFF" HeightRequest="50" Grid.Column="1" Text="Veg pizza is prepared with the items that meet vegetarian standards by not including any meat or animal tissue products." TextColor="#303030" VerticalTextAlignment="Center"/>
                        </Grid>
                    </syncfusion:SfExpander.Content>
                </syncfusion:SfExpander>
            </StackLayout>
        </ScrollView>
    </ContentPage.Content>
</ContentPage>
```

C#

Returns true or false, based on the expanded state for both Header and Content.

```
public class ExpanderVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((string)parameter == "Header")
            return (bool)value ? false : true;
        else
            return (bool)value ? true : false;
    }
 
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```