(function (global, undefined) {
    var demo = {};
    var heightSlider = null;
    var widthSlider = null;
    var transpSlider = null;
    var urlTextBox = null;
    var openBtn = null;

    function tabStrip_load(sender, args) {
        tabStrip = sender;
    }

    function transparentSlider_load(sender, args) {
        transpSlider = sender;
    }

    function widthSlider_load(sender, args) {
        widthSlider = sender;
    }
    function heightSlider_load(sender, args) {
        heightSlider = sender;
    }

    function urlTextBox_load(sender, args) {
        urlTextBox = "";//sender;
    }

    function openBtn_load(sender, args) {
        openBtn = sender;
    }

    function KeyDownHandler(event, args) {
        var keyCode = args.get_keyCode();

        // process only the Enter key
        if (keyCode == 13) {
            openNewWindow();
        }
    }

    //
    function OnClientTabSelected(sender, args) {
        //get the current windows collection
        var selIndex = tabStrip.get_selectedIndex();
        OpenWindowByIndex(selIndex);
    }

    function OpenWindowByIndex(index) {
        var windows = demo.manager.get_windows();
        for (var i = 0; i < windows.length; i++) {
            var win = windows[i];
            if (i == index) {
                //Only show window if it is not currently visible to prevent recursion of RadWindow OnClientShow calling RadTabStrip OnClientTabSelected 
                if (!win.isVisible()) {
                    win.show();
                    win.center();
                }
            }
            else {
                win.hide();
            }
        }
    }

    function SetWindowBehavior(oWnd) {
        configureUI(oWnd);
    }

    function configureUI(oWnd) {
        var bounds = oWnd.getWindowBounds();
        var winHeight = bounds.height;
        var winWidth = bounds.width;

        //Configure height 
        winHeight = winHeight < 100 ? 100 : winHeight;
        winHeight = winHeight > 400 ? 400 : winHeight;
        heightSlider.set_value(winHeight);

        //Configure width 
        winWidth = winWidth < 100 ? 100 : winWidth;
        winWidth = winWidth > 700 ? 700 : winWidth;
        widthSlider.set_value(winWidth);

        //Set the transparency slider to the current transparency level for the active RadWindow
        var initialTransp = oWnd.get_opacity();
        transpSlider.set_value(initialTransp);

        //Make sure the window's corresponding tab is selected
        var windows = demo.manager.get_windows();
        for (var i = 0; i < windows.length; i++) {
            if (windows[i] == oWnd) {
                var tab = tabStrip.get_allTabs()[i];
                //Avoid recursion if tab already selected
                if (tab && !tab.get_selected()) {
                    tab.select();
                }
            }
        }
    }

    function OnClientClose(oWnd) {
        //Get the title of the active RadWindow
        var title = oWnd.get_title();
        var tab = tabStrip.findTabByText(title);
        if (tab) {
            tabStrip.trackChanges();
            tabStrip.get_tabs().remove(tab);
            tabStrip.commitChanges();
        }

        var selIndex = tabStrip.get_selectedIndex();
        if (selIndex > -1)
            OpenWindowByIndex(selIndex)
    }

    function OnClientValueChangedHeight(sender, args) {
        //get a reference to the window and set its height
        var oWnd = demo.manager.getActiveWindow();
        if (!oWnd) return;
        var newHeight = sender.get_value();
        oWnd.set_height(newHeight);
        //Update the label, showing the current value of the slider.
        updateLabel(sender, demo.lblHeight);
    }

    function OnClientValueChangedWidth(sender, args) {
        //get a reference to the window and set its width
        var oWnd = demo.manager.getActiveWindow();
        if (!oWnd) return;
        oWnd.set_width(sender.get_value());
        updateLabel(sender, demo.lblWidth);
    }

    function OnClientValueChangedTransparency(sender, args) {
        //get a reference to the window and set its opacity
        var oWnd = demo.manager.getActiveWindow();
        if (!oWnd) return;
        oWnd.set_opacity(sender.get_value());
        updateLabel(sender, demo.opacityLbl);
    }


    function OnClientPageLoad(oWnd) {

        var originalUrl = oWnd.get_navigateUrl();
        var websiteName = getWebsiteName(originalUrl);
        oWnd.set_title(websiteName);
        tabStrip.trackChanges();
        var tab = tabStrip.get_selectedTab();
        //check if tab exists - if it doesn't this is a newly created window and
        //its text will be set in the openNewWindow() function
        if (tab) {
            tab.set_text(websiteName);
        }
        var iconUrl = originalUrl + "/favicon.ico";
        if (originalUrl.indexOf("converter.telerik.com") > 0) iconUrl = "codeConverterFavicon.ico";
        if (originalUrl.indexOf("www.wikipedia.org") > 0) iconUrl = "wikiFavicon.ico";
        //Change RadWindow icon to the favicon.ico icon of the opened site
        oWnd.set_iconUrl(iconUrl);
    }


    function updateLabel(slider, label) {
        if (label)
            label.innerHTML = slider.get_value();
    }

    function openNewWindow() {
        var windowURL = urlTextBox.get_textBoxValue();
        var oWnd = radopen("https://" + windowURL, null);
        oWnd.center();
        var websiteName = getWebsiteName(oWnd.get_navigateUrl());
        //Add new tab to the tabstrip
        tabStrip.trackChanges();
        var tab = new Telerik.Web.UI.RadTab();
        tab.set_text(websiteName);
        tabStrip.get_tabs().add(tab);
        var iconUrl = oWnd.get_navigateUrl() + "/favicon.ico";
        if (iconUrl.indexOf("converter.telerik.com") > 0) iconUrl = "codeConverterFavicon.ico";
        if (originalUrl.indexOf("www.notasonline.es") > 0) iconUrl = "logo.ico";
        tab.set_imageUrl(iconUrl);
        tabStrip.commitChanges();

        //Select this tab
        tab.select();
    }

    //function getWebsiteName(websiteName) {
    //    url = websiteName.replace("https://", "");
    //    url = url.replace("www.", "");
    //    url = url.substr(0, url.indexOf("."));
    //    url = url.charAt(0).toUpperCase() + url.substr(1);
    //    return url;
    //}

    global.tabStrip_load = tabStrip_load;

    global.openNewWindow = openNewWindow;
    global.OnClientPageLoad = OnClientPageLoad;
    global.OnClientValueChangedTransparency = OnClientValueChangedTransparency;
    global.OnClientValueChangedWidth = OnClientValueChangedWidth;
    global.OnClientValueChangedHeight = OnClientValueChangedHeight;
    global.OnClientClose = OnClientClose;
    global.SetWindowBehavior = SetWindowBehavior;
    global.OnClientTabSelected = OnClientTabSelected;


    global.$windowOverviewDemo = demo;
    global.transparentSlider_load = transparentSlider_load;
    global.widthSlider_load = widthSlider_load;
    global.heightSlider_load = heightSlider_load;
    global.KeyDownHandler = KeyDownHandler;
    global.urlTextBox_load = urlTextBox_load;
    global.openBtn_load = openBtn_load;
})(window);