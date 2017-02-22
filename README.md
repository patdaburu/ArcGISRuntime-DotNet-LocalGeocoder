# Where's the Label?

This is a sample application that performs a reverse geocode against a LocatorTask defined in a Mobile Map Package.  At present, we are finding that the Label field of the GeocodeResult object is always empty.

To see what we're seeing, run the application and load a Mobile Map Package using the File->Load menu option.  When the map is loaded, clicking anywhere will attempt a reverse geocode and some of the information contained in the result will be shown on the right.

If you're looking for a place to put a breakpoint so that you can inspect the results directly in a debugger, go to line 85 in the [ReverseGeocodeCommand.cs](Commands/ReverseGeocodeCommand.cs) file.

If you want to inspect how the map is loaded, go to line 60 in the [LoadMapCommand.cs](Commands/LoadMapCommand.cs).

## Update
We have applied a workaround that doesn't resolve the original problem (the Label property remains blank), but allows us to get an address from the Attributes.  See [ReverseGeocodeCommand.cs](Commands/ReverseGeocodeCommand.cs), starting around line 77.


