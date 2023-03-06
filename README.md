# BlazorPortals

## WORK IN PROGRESS

Blazor component library for rendering components outside of their normal hierarchy. Known in React as 'Portals', sometimes also called 'Outlets'.
BlazorPortals can be placed anywhere in the DOM, including outside of the root app component, such as the end of the body or the head. This library works in a similar way to the [built-in components for rendering head content](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/control-head-content?view=aspnetcore-7.0).

## General Usage
<details>
  <summary>Click to expand</summary>

Register the services using the extension:
```csharp
builder.Services.AddPortals();
```
Place a `PortalOutlet` wherever you want to be able to render components, for example in the page header:

```razor
@* MainLayout.razor *@
@inherits LayoutComponentBase

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <PortalOutlet Name="header"/>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>
```

Use a `Portal` component to render into the `PortalOutlet`:

```razor
@* Index.razor *@
@page "/"

<PageTitle>Index</PageTitle>

<Portal Name="header">
    <div>This will be in the header</div>
</Portal>

<h1>Hello, world!</h1>

Welcome to your new app.
```
</details>
    
## Rendering outside of the app root
<details>
  <summary>Click to expand</summary>

Portals can be used to render components outside of the root app component hierarchy, such as the end of the body. [This is done in the same way as registering a `HeadOutlet`.](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/control-head-content?view=aspnetcore-7.0#headoutlet-component)

In order to render outside of the root app component, you need a parameterless component.
The project contains a `BodyPortal` component, which is simply the following:
```razor
<PortalOutlet Name="body" />
```

### Blazor WASM
Add your portal component to the RootComponents collection of the WebAssemblyHostBuilder in Program.cs, specifying a selector for its location in the DOM.
```csharp
builder.RootComponents.Add<BodyOutlet>("body::after");
```
From the headoutlet documentation:
> When the ::after pseudo-selector is specified, the contents of the root component are appended to the existing head contents instead of replacing the content. This allows the app to retain static head content in wwwroot/index.html without having to repeat the content in the app's Razor components.

### Blazor Server
Add your portal component to the \_Host.cshtml
```razor
...
<component type="typeof(BodyOutlet)" render-mode="ServerPrerendered" />
</body>
</html>
```
</details>

## Why
Portals are useful for building other components, such as modals, dialogs, and popovers. 
For example; a popover often cannot be rendered as part of the usual hierarchy as issues occur with css overflow of the parent element. 
It can instead be placed at the end of the body and positioned over the element with CSS.

Portals are also useful for general app concerns.
For example, in your app, you may have a header where you want to render shortcut buttons for common actions.
A portal can be placed in the header, and pages and components can render content in the portal. e.g. A documents list page may add a button for creating a new document. 
The responsibility of rendering shortcut buttons moves from the header to the page.



