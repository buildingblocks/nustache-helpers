Nustache Custom Helpers
================

A .NET implementation of [Handlebars Helpers](https://github.com/danharper/Handlebars-Helpers) for use with [Nustache](https://github.com/jdiamond/Nustache)

## Building

Clone this repository locally with the following command:

    git clone https://github.com/buildingblocks/nustache-helpers.git

This library requires [Nustache](https://github.com/jdiamond/Nustache) `> 1.13.8.22` which is not yet released on NuGet.

To include the [Nustache](https://github.com/jdiamond/Nustache) code, run this command from your nustache-helpers clone:

    git submodule update --init

Build the solution with VS2012.

## Usage
**NOTE:** this assumes you are using the Nustache MVC View Engine already, please refer to the Nustache README for instructions.

- Add a reference to `Blocks.NustacheHelpers.dll`
- On Application_Start, call `Blocks.NustacheHelpers.EqualityHelpers.Register()` and `Blocks.NustacheHelpers.DisplayHelpers.Register()`.

Your mustache/handlebars templates can now make use of the Handlebars Helpers server-side as well as client-side.

Refer to the unit tests for more details.