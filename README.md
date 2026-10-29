# Portfolio

A standalone Blazor WebAssembly portfolio on .NET 10 LTS, using C#, Razor components and plain CSS. The terminal-inspired design uses Fira Code, a full-screen menu and Vim-style navigation commands.

## Development

Install the .NET SDK specified in `global.json` (10.0.403 or a newer patch in the same feature band), or open the repository in its dev container.

From the repository root:

```powershell
dotnet restore
dotnet watch --project Portfolio
```

The launch profile serves the app at `https://localhost:5001` and `http://localhost:5000`. If needed, trust the local HTTPS certificate with `dotnet dev-certs https --trust`.

## Production

```powershell
dotnet publish Portfolio --configuration Release --output build
```

Deploy `build/wwwroot` as static files. Azure Static Web Apps CI installs the pinned SDK and publishes explicitly, rather than relying on the hosting platform's SDK detection. The source `Portfolio/wwwroot/staticwebapp.config.json` is copied into the published output and provides SPA fallback for direct links such as `/Contact` and `/Projects`, without rewriting missing assets to HTML.

Keep the SDK in `global.json` and the dev container, and the Microsoft package versions in `Portfolio/Portfolio.csproj`, aligned with supported stable .NET releases. `System.Net.Http.Json` comes from the framework and does not need a separate package.

## Localization

English, Spanish, French, German, Portuguese and Japanese are available from the language selector. The app uses the first supported browser language by default, falls back to English, and remembers an explicit choice in browser local storage. Changing language reloads the current route so .NET culture and localized resources stay consistent.

UI translations use `IStringLocalizer<SharedResource>` and the `Portfolio/Resources/SharedResource*.resx` files. Keep the resource keys aligned across languages. To add a language, add its resource file and its culture code to `Services/AppCulture.cs`. Full ICU globalization data is included for all supported cultures. Names, links, code-style filenames and routes are intentionally not translated.
