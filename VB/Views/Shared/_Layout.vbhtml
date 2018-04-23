<!DOCTYPE html>
<html>
<head>
    <title>Custom Keyboard Navigation</title>

    @Html.DevExpress().GetScripts(New Script With {.ExtensionSuite = ExtensionSuite.Editors},
        New Script With {.ExtensionSuite = ExtensionSuite.GridView},
        New Script With {.ExtensionSuite = ExtensionSuite.Editors})

    @Html.DevExpress().GetStyleSheets(New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors})
</head>

<body>
    @RenderBody()
</body>
</html>
