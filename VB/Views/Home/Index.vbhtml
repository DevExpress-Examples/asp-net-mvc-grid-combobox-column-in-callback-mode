﻿

<script type="text/javascript">
    function OnSelectedIndexChanged(s, e) {
        grid.AutoFilterByColumn("CountryID", s.GetText());
    }
</script>
<h3>
    GridView - How to use Callback Mode for the ComboBox column
</h3>
@Html.Partial("GridViewPartial")