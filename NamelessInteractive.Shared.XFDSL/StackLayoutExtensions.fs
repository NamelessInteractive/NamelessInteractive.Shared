[<AutoOpen>]
module NamelessInteractive.Shared.StackLayoutExtensions

open Xamarin.Forms

type Xamarin.Forms.StackLayout with
    static member Create() = StackLayout()
    static member CreatePadded(padding) = StackLayout(Padding=Thickness(padding))
    static member CreatePadded(padding: int) = StackLayout(Padding=Thickness(float padding))
    static member CreatePaddedCentered(padding) = StackLayout(Padding=Thickness(padding),VerticalOptions = LayoutOptions.Center)
    static member CreatePaddedCentered(padding: int) = StackLayout(Padding=Thickness(float padding),VerticalOptions = LayoutOptions.Center)
    member this.Add(view:View) = this.Children.Add(view)