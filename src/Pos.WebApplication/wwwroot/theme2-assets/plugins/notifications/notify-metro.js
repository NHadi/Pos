$.notify.addStyle("metro", {
    html:
        "<div>" +
            "<div class='image' data-notify-html='image'/>" +
            "<div class='text-wrapper'>" +
                "<div class='title' data-notify-html='title'/>" +
                "<div class='text' data-notify-html='text'/>" +
            "</div>" +
        "</div>",
    classes: {
        default: {
            "color": "#fafafa !important",
            "background-color": "#62a3ff",
            "border": "1px solid #62a3ff"
        },
        error: {
            "color": "#fafafa !important",
            "background-color": "#ff3547",
            "border": "1px solid #ff3547"
        },
        custom: {
            "color": "#fafafa !important",
            "background-color": "#62a3ff",
            "border": "1px solid #62a3ff"
        },
        success: {
            "color": "#fafafa !important",
            "background-color": "#2bbbad",
            "border": "1px solid #2bbbad"
        },
        info: {
            "color": "#fafafa !important",
            "background-color": "#33b5e5",
            "border": "1px solid #33b5e5"
        },
        warning: {
            "color": "#fafafa !important",
            "background-color": "#ff8800",
            "border": "1px solid #ff8800"
        },
        black: {
            "color": "#fafafa !important",
            "background-color": "#4c5667",
            "border": "1px solid #212121"
        },
        white: {
            "background-color": "#e6eaed",
            "border": "1px solid #ddd"
        }
    }
});