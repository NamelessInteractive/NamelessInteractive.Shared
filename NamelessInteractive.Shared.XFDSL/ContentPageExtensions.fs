[<AutoOpen>]
module NamelessInteractive.Shared.ContentPageExtensions

open Xamarin.Forms

type Xamarin.Forms.ContentPage with
    static member Create() = ContentPage()
    static member Create title = ContentPage(Title=title)
    static member Create (title, padding) = ContentPage(Title=title, Padding=Thickness(padding))
    static member Create (title,padding:int) = ContentPage(Title=title, Padding=Thickness(float padding))
    static member Create (title,padding, content) = ContentPage(Title=title, Padding=Thickness(padding), Content=content)
    static member Create (title, padding:int, content) = ContentPage(Title=title, Padding=Thickness(float padding), Content=content)