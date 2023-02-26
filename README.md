# BlazorPortals

Blazor component library for rendering components outside of their normal hierarchy. Known in React as 'Portals', sometimes also called 'Outlets'.
BlazorPortals can be placed anywhere in the DOM, including outside of the root app component, such as the end of the body.

## General Usage

Register the services using the extension:
```csharp
builder.Services.AddPortals();
```

Place a portal wherever you want to be able to render components, for example the end of your Layout component.
```razor
<Portal Name="layout" />
```

Use a `PortalContent` component to render into the portal:
```razor
<PortalContent PortalName="layout">
    <div>This will be rendered in the portal</div>
</PortalContent>
```

## Rendering outside of the app root
### Blazor WASM
todo
### Blazor Server
todo


## Why
Portals are useful for building other components, such as modals, dialogs, and popovers. 
For example; a popover often cannot be rendered as part of the usual hierarchy as issues occur with parent element overflow. 
It can instead be placed at the end of the body and positioned over the element with CSS.

Portals are also useful for general app concerns.
For example, in your app, you may have a header where you want to render shortcut buttons for common actions.
A portal can be placed in the header, and pages and components can render content in the portal. e.g. A documents list page may add a button for creating a new document. 
The responsibility of rendering shortcut buttons moves from the header to the page.



