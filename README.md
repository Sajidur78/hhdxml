# hhdxml
hhdxml is a tool for converting Sonic Lost World (PC) hhd files to xml and back.

```
Arguments:
    --help (Show this help message)
    --hhd input_file (Input hhd file to use)
    --xml input_xml (Input xml file to use, if converting back to hhd)
    --output_file output_file (Path to output file)

Examples:
    hhdxml.exe --hhd w1a01.hhd --output_file w1a01.xml
    hhdxml.exe --xml w1a01.xml --output_file w1a01.hhd
    hhdxml.exe w1a01.hhd
```