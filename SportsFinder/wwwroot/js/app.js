// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Mobile Button. No Jquery required!
document.addEventListener("DOMContentLoaded", function (event) {
    initializeDropdowns();
    initializeNotification();
    initializeSidebarOverlay();
    detectColorScheme();
});

document.addEventListener("turbolinks:load", function () {
    initializeDropdowns();
    initializeNotification();

    const mqDark = window.matchMedia(DARK);
    if (mqDark)
        changeWebsiteTheme('dark');

});



function initializeSidebarOverlay() {
    var overlayClicked = document.getElementById('sidebar-overlay');

    if (overlayClicked) {
        overlayClicked.addEventListener('click', function (e) {
            e.preventDefault();
            closeSidebar();
        });
    }
}

function initializeDropdowns() {
    var attributeName = "data-dropdown-click-event-listener";

    var dropdowns = document.querySelectorAll('.dropdown'), i;

    for (i = 0; i < dropdowns.length; ++i) {
        if (dropdowns[i].hasAttribute(attributeName) === false) {
            dropdowns[i].addEventListener('click', function (event) {
                event.stopPropagation();
                this.classList.toggle('is-active');
            });
            dropdowns[i].setAttribute(attributeName, "true");
        }
    }
}

function initializeNotification() {
    var attributeName = "data-notification-delete-event-listener";
    var notifications = document.querySelectorAll('.notification .delete');
    for (i = 0; i < notifications.length; ++i) {
        if (notifications[i].hasAttribute(attributeName) === false) {
            notifications[i].addEventListener('click', function (event) {
                event.stopPropagation();
                this.parentNode.parentNode.removeChild(this.parentNode);
            });
            notifications[i].setAttribute(attributeName, "true");
        }
    }
}

function openSidebar() {
    document.getElementById("app").classList.add("sidebar-open");
}

function closeSidebar() {
    document.getElementById("app").classList.remove("sidebar-open");
}


var DARK = '(prefers-color-scheme: dark)';
var LIGHT = '(prefers-color-scheme: light)';

function changeWebsiteTheme(scheme) {
    //var cssLink = document.getElementsByClassName("main-css-link-class")[0];
    //var cssFile = cssLink.getAttribute("href");


    //if (scheme === 'dark') {
    //    cssLink.setAttribute("href", cssFile.replace("app.","app-dark."));
    //}
    //else {
    //    cssLink.setAttribute("href", cssFile.replace("app-dark.","app."));
    //}    
    // 'dark' or 'light' string is in scheme here
    // so the website theme can be updated
}

function detectColorScheme() {
    //if(!window.matchMedia) {
    //    return;
    //}
    //function listener({matches, media}) {
    //    if(!matches) { // Not matching anymore = not interesting
    //        return;
    //    }
    //    if(media === DARK) {
    //        changeWebsiteTheme('dark');
    //    } else if (media === LIGHT) {
    //        changeWebsiteTheme('light');
    //    }
    //}
    //const mqDark = window.matchMedia(DARK);
    //mqDark.addListener(listener);
    //const mqLight = window.matchMedia(LIGHT);
    //mqLight.addListener(listener);
}



//Form Helpers:
function jsonToFormData(obj, rootName, ignoreList) {
    var formData = new FormData();

    function appendFormData(data, root) {
        if (!ignore(root)) {
            root = root || '';
            if (data instanceof File) {
                formData.append(root, data);
            } else if (Array.isArray(data)) {
                for (var i = 0; i < data.length; i++) {
                    appendFormData(data[i], root + '[' + i + ']');
                }
            } else if (typeof data === 'object' && data) {
                for (var key in data) {
                    if (data.hasOwnProperty(key)) {
                        if (root === '') {
                            appendFormData(data[key], key);
                        } else {
                            appendFormData(data[key], root + '.' + key);
                        }
                    }
                }
            } else {
                if (data !== null && typeof data !== 'undefined') {
                    formData.append(root, data);
                }
            }
        }
    }

    function ignore(root) {
        return Array.isArray(ignoreList)
            && ignoreList.some(function (x) { return x === root; });
    }

    appendFormData(obj, rootName);

    return formData;
}