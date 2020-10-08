jQuery(document).ready(function () {
    jQuery("#timepicker").timepicker({
        defaultTIme: "7:00 AM",
        icons: { up: "mdi mdi-chevron-up", down: "mdi mdi-chevron-down" },
    }),
    jQuery("#timepicker2").timepicker({
        defaultTIme: !1,
        icons: { up: "mdi mdi-chevron-up", down: "mdi mdi-chevron-down" },
    })
});
