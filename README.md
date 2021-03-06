# pHelperPlugin for TurboHUD!

## This is heavy WIP and might still contain bugs!

## Usage

To use this plugin, either clone or download and copy into `TurboHUD/plugins/patrick`.\
Currently no preconfigured definitions exist, but it should not be much of an effort to add your own.\

## Definitions

This helper uses a plugin based definition type system. To add definition types check existing examples in `skills/definitions`. Classes which inherit from `AbstractDefinition.cs` will automatically be added to the UI.

## Hotkeys / AutoActions

Works the same way as definitions. Inherit from `hotkeys/actions/AbstractHotkeyAction.cs` or `autoactions/actions/AbstractAutoAction.cs`.

## Known Bugs / Issues
- Some weird exception randomly thrown in TurboHUD. Can't replicate and can't catch it
- Some ComboBox settings are not set properly when editing a definition 

## Bugs / Feature Requests / Feedback / Donations

To report bugs/weird behavior or just have a feature request, just [create an issue](https://github.com/petikk/pHelperPlugin/issues/new) and I will answer asap.\
If there's any questions you would like to directly discuss with me, you can message me on Discord: `patrick#7777` or [join my discord server](https://discord.gg/8fRxTDM66q)

If you'd like to support my work you can donate here and buy me a coffee, I'd really appreciate that:\
[![](https://i.imgur.com/qHzwSC7.png)](https://www.buymeacoffee.com/phelper)

## Contribute

I am very happy if you'd like to contribute! Just open a PR and I will check it out asap :)
