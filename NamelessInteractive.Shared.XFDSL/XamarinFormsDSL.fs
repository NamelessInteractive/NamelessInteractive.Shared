[<AutoOpen>]
module NamelessInteractive.Shared.XamarinFormsDSL

open Xamarin.Forms
open NamelessInteractive.Shared.Controls

let WithTextEntryBinding (bindingPath: string ) (stack: StackLayout) =
    let entry = stack.Children.[1] :?> Entry
    entry.SetBinding(Entry.TextProperty, bindingPath)
    stack

let WithSwitchBinding (bindingPath: string) (stack: StackLayout) =
    let entry = stack.Children.[1] :?> Switch
    entry.SetBinding(Switch.IsToggledProperty, bindingPath)
    stack

let AndAddToStack (stack: StackLayout) (view) =
    stack.Add view

let CreateLabelledDropDown (labelText) (elements) =
    let stack = StackLayout.Create()
    let label = Label(Text=labelText)
    let entry = BindablePicker()
    entry.ItemsSource <- elements
    stack.Add(label)
    stack.Add(entry)
    stack

let CreateLabelledEntry (labelText) =
    let stack = StackLayout.Create()
    let label = Label(Text=labelText)
    let entry = Entry(Placeholder=labelText)
    stack.Add(label)
    stack.Add(entry)
    stack

let CreateLabelledSwitch (labelText) =
    let stack = StackLayout(Orientation=StackOrientation.Horizontal)
    let label = Label(Text=labelText)
    label.VerticalOptions <- LayoutOptions.CenterAndExpand
    let entry = Switch()
    stack.Children.Add(label)
    stack.Children.Add(entry)
    stack

let CreateLabelledLabel (labelText) (labelValue) =
    let stack = StackLayout.Create()
    let label1 = Label(Text=labelText)
    label1.Font <- Font.SystemFontOfSize(NamedSize.Large)
    let label2 = Label(Text=labelValue)
    stack.Add(label1)
    stack.Add(label2)
    stack