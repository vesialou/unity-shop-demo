
# Unity Modular Shop Demo

## Architecture

### Domain Isolation
- 6 isolated domains: Core, Health, Gold, Location, VIP, Shop
- Each domain has its own asmdef
- No cross-domain dependencies (only Core dependency)
- Communication via EventBus

### Key Patterns
- Dependency Injection (VContainer)
- Event-Driven Architecture
- Action System for extensible bundle configuration
- Generic PlayerData storage

## Setup

### Prerequisites
- Unity 2021.3+
- VContainer
- UniTask
- TextMeshPro

### Installation
1. Clone repository
2. Open in Unity
3. Open `AppRootScene`
4. Press Play

## Adding New Bundles

1. Create ScriptableObject: `Create > Shop > Bundle`
2. Configure costs and rewards using action assets
3. Place in `Resources/Bundles/`

## Adding New Actions

1. Create action class inheriting `BaseActionScriptableObject`
2. Implement `CanApply()` and `Apply()`
3. Place in corresponding domain folder
4. Create asset: `Create > Actions > [Domain] > [Action]`

## Adding New Domain

1. Create domain folder with asmdef (reference Core only)
2. Create Data, Services, Actions, Views subfolders
3. Create domain installer inheriting `MonoBehaviourInstaller`
4. Add installer to `ProjectLifetimeScope`

## AppRootScene (root scene)
```plaintext
AppRootScene
└── ProjectContext
├── HealthInstallerGO (Health domain installer)
├── ShopCoreInstallerGO (Shop domain installer)
├── GoldInstallerGO (Gold domain installer)
├── LocationInstallerGO (Location domain installer)
└── VIPInstallerGO (VIP domain installer)
```

## BundlesListScene (bundles list)
```plaintext
BundlesListScene
├── Main Camera
├── EventSystem
├── GameUIContext
│   ├── HealthInstallerGO (Health UI installer)
│   ├── ShopListInstallerGO (Shop list installer)
│   ├── GoldUIInstallerGO (Gold UI installer)
│   ├── LocationInstallerGO (Location UI installer)
│   └── VIPInstallerGO (VIP UI installer)
└── Canvas
├── PlayerInfoPanel
│   ├── GoldView
│   │   └── Gold Text (TMP)
│   │       └── CheatButton
│   ├── HealthView
│   │   └── HealthText (TMP)
│   │       └── CheatButton
│   ├── LocationView
│   │   └── Location Text (TMP)
│   │       └── CheatButton
│   └── VIPTimeView
│       └── VIPTime Text (TMP)
│           └── CheatButton
├── ShopPanel
│   └── Scroll View
│       ├── Viewport
│       │   └── Content (bundle cards container)
│       ├── Scrollbar Horizontal
│       │   └── Sliding Area
│       │       └── Handle
│       └── Scrollbar Vertical
│           └── Sliding Area
│               └── Handle
└── BlockUI (purchase blocking panel)
└── Text (TMP) "Loading..."
```

## BundleDetailsScene (bundle details)
```plaintext
BundleDetailsScene
├── Main Camera
├── EventSystem
├── GameUIContext
│   └── ShopDetailsGO (Shop details installer)
└── Canvas
├── BackBtn (back button)
│   └── Text (TMP) "click to close..."
├── CardPanel (card container)
└── BlockUI (purchase blocking panel)
└── Text (TMP) "Loading..."
```
## Project Structure
```plaintext
Project
├── AppRootScene (always loaded)
│   └── Domain registration (Health, Gold, Location, VIP, Shop)
│
└── Additively loaded scenes:
├── BundlesListScene (bundles list)
│   ├── Player resources UI
│   └── Bundle cards list with horizontal scroll
│
└── BundleDetailsScene (bundle details)
├── Single card fullscreen
└── Back button
```
## Scene Navigation

- **AppRootScene** → loads **BundlesListScene** additively on start
- **BundlesListScene** → **BundleDetailsScene** (on "i" button click)
- **BundleDetailsScene** → **BundlesListScene** (on "back" button click)

**GameFlowController** manages switching between `BundlesListScene` and `BundleDetailsScene`, unloading the previous scene before loading the new one.