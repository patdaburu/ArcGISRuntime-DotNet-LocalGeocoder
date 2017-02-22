# Where's the Label?

This is a sample application that performs a reverse geocode against a LocatorTask defined in a Mobile Map Package.  At present, we are finding that the Label field of the GeocodeResult object is always empty.

To see what we're seeing, run the application and load a Mobile Map Package using the File->Load menu option.  When the map is loaded, clicking anywhere will attempt a reverse geocode and some of the information contained in the result will be shown on the right.

If you're looking for a place to put a breakpoint so that you can inspect the results directly in a debugger, go to line 66 in the ReverseGeocodeCommand.cs file.


