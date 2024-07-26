# lavaKirbyHatManagerV2
A fully rebuilt version of the original [lavaKirbyHatManager](https://github.com/QuickLava/lavaKirbyHatManager) program, which offers compatibility with the new and improved EX Kirby Hat system featured in Project+ Ex v1.5 and beyond, as well as a brand new editor UI!

***Important Note:*** *While Kirby Hat compatibility has improved in the new system relative to the old one, Hat compatibility is still* ***very*** *spotty, and many source characters still don't work. This will change as fixes are developed for other Hats, but for the moment things are (and will remain) somewhat limited. For preliminary compatibility information, see [this chart](https://docs.google.com/spreadsheets/d/1rlw8wemQ849w-6AgGISXATPv6-pfVnTTQcQqd6N-crI/edit?usp=sharing).*

## A Note on Hat Names
It should be noted that the names the program assigns to Kirby Hats are *purely aesthetic*, and do not influence hat function whatsoever. They exist purely as a quality of life feature to simplify use of the program, and are not stored within the module file at all, and so names specified manually while the program is running will not persist between runs of the program.

By default, the program will label hats according to the Project+ Ex roster and thus aren't guaranteed to be accurate, though following the instructions below for Automatic Hat Name Recognition can assist in ensuring accuracy to any given build. 

## Instructions for Automatic File Recognition
### Automatic Module Recognition
If the program recognizes a valid "ft_kirby.rel" file in the same folder as it, it will automatically load that module on program start-up.

Alternatively, if you place the zipped program folder in its entirety into your build folder (ie. such that the entire folder is where your "pf", "rp", and "Source" folders are), the program will automatically search the build's "pf/module/" folder for a valid "ft_kirby.rel" file compatible with the new EX Kirby Hat system, and attempt to load it on start-up.

### Automatic Hat Name Recognition
After a module is loaded, whether automatically or manually, the program will check if the loaded module was located in a build's "pf/module/" folder.
If it was, the program will additionally check the build's "pf/BrawlEx/FighterConfig/" folder for any FighterConfig files, and use the names and Fighter IDs described by the contained files to label the hats loaded from the module!

## Exporting and Importing Hats
### Exporting and Importing to XML Files
Hats in a loaded module file may be exported/imported to/from XML files through the "File" toolstrip once a module is loaded. Note that Hats exported in this way contain all associated information contained within the loaded REL file (in addition to any associated Hat Names), and thus can be used to safely move Hats between modules!

### Importing from lKHM TXT Files
Hats specified in the TXT file format used in pre-rewrite versions of lKHM can also be applied to a loaded module file through the "File" toolstrip. Note however that these old files worked by just copying the hat configuration from the specified source Fighter ID over to the specified destination ID, and so don't explicitly contain the specific details of any given hat configuration. For this reason, rather than continuing to use this old format, it's best to instead use the provided Export functionality after importing to move to the newer XML format!
 
