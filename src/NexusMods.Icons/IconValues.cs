using Avalonia;
using Avalonia.Media;
using NexusMods.Icons.SimpleVector;

namespace NexusMods.Icons;

// https://www.figma.com/file/8pjtQeNggvVi7RWoLNGV80/%F0%9F%A7%B0-Nexus-Mods-Design-System?type=design&node-id=130-463

/*
    Important Notes!! - Sewer
    
    What not to do:
    
        - Paste Raw Coordinates from SVG in Figma
            - This will get you wrong icon sizes, as padding will be excluded.
            
    What to do:
    
        - Use Projektanker Icon if possible https://pictogrammers.com/library/mdi/icon/code-tags/
            - Projectanker Icons are the raw SVGs, so it's okay ^-^
        - Create a SimpleVectorIconImage based on the contents of an SVG 
            - This will give you the correct icon size, as padding etc. is preserved.
            - We can't use the raw SVGs as they don't support recolouring.
        - If you explicitly don't want recolouring for brand purposes, import an SVG like
            - AvaloniaSvg("avares://NexusMods.App.UI/Assets/Icons/disk_20px.svg");

    How to Import SVG:
    
        Exporting from Figma may give you an SVG like
        
        ```xml
        <svg width="25" height="25" viewBox="0 0 25 25" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path fill-rule="evenodd" clip-rule="evenodd" d="M12.46 17.9912L18.1722 13.5441L19.445 12.5584L12.46 7.12561L5.47498 12.5584L6.74004 13.5441L12.46 17.9912Z" fill="#F4F4F5"/>
        </svg>
        ```
        
        You have to extract the `d` attribute from the `path` tag, and the `viewBox` attribute from the `svg` tag.
        
        Then create a `SimpleVectorIconImage` with the `d` attribute as the `pathData` and the `viewBox` attribute as the `viewBox`.
        
        ```csharp
        public static readonly IconValue Mods = new SimpleVectorIconImage(
            "M12.46 17.9912L18.1722 13.5441L19.445 12.5584L12.46 7.12561L5.47498 12.5584L6.74004 13.5441L12.46 17.9912Z",
            new Rect(0, 0, 25, 25)
        );
        ```
*/

public static class IconValues
{
#region Action
    // https://pictogrammers.com/library/mdi/icon/code-tags/
    public static readonly IconValue Code = new ProjektankerIcon("mdi-code-tags");

    // https://pictogrammers.com/library/mdi/icon/check-circle/
    public static readonly IconValue CheckCircle = new ProjektankerIcon("mdi-check-circle");

    // https://pictogrammers.com/library/mdi/icon/delete-outline/
    public static readonly IconValue DeleteOutline = new ProjektankerIcon("mdi-delete-outline");

    // https://pictogrammers.com/library/mdi/icon/delete-forever/
    public static readonly IconValue DeleteForever = new ProjektankerIcon("mdi-delete-forever");

    // https://pictogrammers.com/library/mdi/icon/file-document/
    // This is mislabeled on Figma and some places as 'description'
    public static readonly IconValue Description = new ProjektankerIcon("mdi-file-document");

    // https://pictogrammers.com/library/mdi/icon/check/
    public static readonly IconValue Done = new ProjektankerIcon("mdi-check");

    // https://pictogrammers.com/library/mdi/icon/help-circle/
    public static readonly IconValue Help = new ProjektankerIcon("mdi-help-circle");

    // https://pictogrammers.com/library/mdi/icon/help-circle-outline/
    public static readonly IconValue HelpOutline = new ProjektankerIcon("mdi-help-circle-outline");

    // https://pictogrammers.com/library/mdi/icon/history/
    public static readonly IconValue History = new ProjektankerIcon("mdi-history");

    // https://pictogrammers.com/library/mdi/icon/home/
    public static readonly IconValue Home = new ProjektankerIcon("mdi-home");

    // https://pictogrammers.com/library/mdi/icon/playlist-plus/
    public static readonly IconValue PlaylistAdd = new ProjektankerIcon("mdi-playlist-plus");
    
    // https://pictogrammers.com/library/mdi/icon/playlist-remove/
    public static readonly IconValue PlaylistRemove = new ProjektankerIcon("mdi-playlist-remove");

    // https://pictogrammers.com/library/mdi/icon/open-in-new/
    public static readonly IconValue OpenInNew = new ProjektankerIcon("mdi-open-in-new");

    // https://pictogrammers.com/library/mdi/icon/tab/
    public static readonly IconValue Tab = new ProjektankerIcon("mdi-tab");

    // https://pictogrammers.com/library/mdi/icon/magnfiy/
    public static readonly IconValue Search = new ProjektankerIcon("mdi-magnify");

    // https://pictogrammers.com/library/mdi/icon/cog/
    public static readonly IconValue Settings = new ProjektankerIcon("mdi-cog");

    // https://pictogrammers.com/library/mdi/icon/eye/
    public static readonly IconValue Visibility = new ProjektankerIcon("mdi-eye");
    
    // https://pictogrammers.com/library/mdi/icon/view-carousel/
    public static readonly IconValue ViewCarousel = new ProjektankerIcon("mdi-view-carousel");

#endregion

#region Alert

    // https://pictogrammers.com/library/mdi/icon/alert-circle/
    public static readonly IconValue Error = new ProjektankerIcon("mdi-alert-circle");

    // https://pictogrammers.com/library/mdi/icon/alert/
    public static readonly IconValue Warning = new ProjektankerIcon("mdi-alert");

    // https://pictogrammers.com/library/mdi/icon/alert-outline/
    public static readonly IconValue WarningAmber = new ProjektankerIcon("mdi-alert-outline");

    // https://pictogrammers.com/library/mdi/icon/bell/
    public static readonly IconValue NotificationImportant = new ProjektankerIcon("mdi-bell");

#endregion

#region AV

    // https://pictogrammers.com/library/mdi/icon/pause-circle/
    public static readonly IconValue PauseCircleFilled = new ProjektankerIcon("mdi-pause-circle");

    // https://pictogrammers.com/library/mdi/icon/pause-circle-outline/
    public static readonly IconValue PauseCircleOutline = new ProjektankerIcon("mdi-pause-circle-outline");

    // https://pictogrammers.com/library/mdi/icon/play/
    public static readonly IconValue PlayArrow = new ProjektankerIcon("mdi-play");

    // https://pictogrammers.com/library/mdi/icon/play-circle/
    public static readonly IconValue PlayCircleFilled = new ProjektankerIcon("mdi-play-circle");

    // https://pictogrammers.com/library/mdi/icon/play-circle-outline/
    public static readonly IconValue PlayCircleOutline = new ProjektankerIcon("mdi-play-circle-outline");

#endregion

#region Communication

    // https://pictogrammers.com/library/mdi/icon/notification-clear-all/
    public static readonly IconValue ClearAll = new ProjektankerIcon("mdi-notification-clear-all");

    // https://pictogrammers.com/library/mdi/icon/tooltip-question/
    public static readonly IconValue LiveHelp = new ProjektankerIcon("mdi-tooltip-question");

#endregion

#region Content

    // https://pictogrammers.com/library/mdi/icon/plus/
    public static readonly IconValue Add = new ProjektankerIcon("mdi-plus");

    // https://pictogrammers.com/library/mdi/icon/plus-circle/
    public static readonly IconValue AddCircle = new ProjektankerIcon("mdi-plus-circle");

    // https://pictogrammers.com/library/mdi/icon/plus-circle-outline/
    public static readonly IconValue AddCircleOutline = new ProjektankerIcon("mdi-plus-circle-outline");

    // https://pictogrammers.com/library/mdi/icon/content-copy/
    public static readonly IconValue Copy = new ProjektankerIcon("mdi-content-copy");

    // https://pictogrammers.com/library/mdi/icon/content-paste/
    public static readonly IconValue Paste = new ProjektankerIcon("mdi-content-paste");

    // https://pictogrammers.com/library/mdi/icon/redo/
    public static readonly IconValue Redo = new ProjektankerIcon("mdi-redo");

    // https://pictogrammers.com/library/mdi/icon/minus-circle-outline/
    public static readonly IconValue RemoveCircleOutline = new ProjektankerIcon("mdi-minus-circle-outline");

    // https://pictogrammers.com/library/mdi/icon/content-save/
    public static readonly IconValue Save = new ProjektankerIcon("mdi-content-save");

    // https://pictogrammers.com/library/mdi/icon/undo/
    public static readonly IconValue Undo = new ProjektankerIcon("mdi-undo");

#endregion

#region Editor

    // https://pictogrammers.com/library/mdi/icon/poll
    public static readonly IconValue BarChart = new ProjektankerIcon("mdi-poll");

    // https://pictogrammers.com/library/mdi/icon/drag-horizontal-variant/
    public static readonly IconValue DragHandleHorizontal = new ProjektankerIcon("mdi-drag-horizontal-variant");

    // https://pictogrammers.com/library/mdi/icon/drag-vertical-variant/
    public static readonly IconValue DragHandleVertical = new ProjektankerIcon("mdi-drag-vertical-variant");

    // https://pictogrammers.com/library/mdi/icon/file-outline/
    public static readonly IconValue File = new ProjektankerIcon("mdi-file-outline");

#endregion

#region File

    // https://pictogrammers.com/library/mdi/icon/download/
    public static readonly IconValue Download = new ProjektankerIcon("mdi-download");

    // https://pictogrammers.com/library/mdi/icon/check-underline/
    public static readonly IconValue DownloadDone = new ProjektankerIcon("mdi-check-underline");

    // https://pictogrammers.com/library/mdi/icon/folder-outline/
    public static readonly IconValue Folder = new ProjektankerIcon("mdi-folder-outline");

    // https://pictogrammers.com/library/mdi/icon/check-underline/
    public static readonly IconValue FolderOpen = new ProjektankerIcon("mdi-folder-open-outline");

    // https://pictogrammers.com/library/mdi/icon/file-edit/
    public static readonly IconValue FileEdit = new ProjektankerIcon("mdi-file-edit");

    // https://pictogrammers.com/library/mdi/icon/video-outline/
    public static readonly IconValue Video = new ProjektankerIcon("mdi-video-outline");

    // https://pictogrammers.com/library/mdi/icon/music-note/
    public static readonly IconValue MusicNote = new ProjektankerIcon("mdi-music-note");

    // https://pictogrammers.com/library/mdi/icon/file-document-outline/
    public static readonly IconValue FileDocumentOutline = new ProjektankerIcon("mdi-file-document-outline");

#endregion

#region Hardware

    // https://pictogrammers.com/library/mdi/icon/monitor/
    public static readonly IconValue Desktop = new ProjektankerIcon("mdi-monitor");

    // https://pictogrammers.com/library/mdi/icon/gamepad-square/
    public static readonly IconValue Game = new ProjektankerIcon("mdi-gamepad-square");

#endregion

#region Image

    // https://pictogrammers.com/library/mdi/icon/image/
    public static readonly IconValue Image = new ProjektankerIcon("mdi-image");

    // https://pictogrammers.com/library/mdi/icon/tune/
    public static readonly IconValue Tune = new ProjektankerIcon("mdi-tune");
    
    // https://pictogrammers.com/library/mdi/icon/palette/
    public static readonly IconValue ColorLens = new ProjektankerIcon("mdi-palette");
    
    

#endregion

#region Navigation

    // https://pictogrammers.com/library/mdi/icon/arrow-left/
    public static readonly IconValue ArrowBack = new ProjektankerIcon("mdi-arrow-left");

    // https://pictogrammers.com/library/mdi/icon/arrow-right/
    public static readonly IconValue ArrowForward = new ProjektankerIcon("mdi-arrow-right");

    // https://pictogrammers.com/library/mdi/icon/menu-down/
    public static readonly IconValue ArrowDropDown = new ProjektankerIcon("mdi-menu-down");

    // https://pictogrammers.com/library/mdi/icon/menu-up/
    public static readonly IconValue ArrowDropUp = new ProjektankerIcon("mdi-menu-up");

    // https://pictogrammers.com/library/mdi/icon/chevron-left/
    public static readonly IconValue ChevronLeft = new ProjektankerIcon("mdi-chevron-left");

    // https://pictogrammers.com/library/mdi/icon/chevron-right/
    public static readonly IconValue ChevronRight = new ProjektankerIcon("mdi-chevron-right");
    
    // https://pictogrammers.com/library/mdi/icon/chevron-down/
    public static readonly IconValue ChevronDown = new ProjektankerIcon("mdi-chevron-down");
    
    // https://pictogrammers.com/library/mdi/icon/chevron-up/
    public static readonly IconValue ChevronUp = new ProjektankerIcon("mdi-chevron-up");

    // https://pictogrammers.com/library/mdi/icon/close/
    public static readonly IconValue Close = new ProjektankerIcon("mdi-close");
    
    // https://pictogrammers.com/library/mdi/icon/window-minimize/
    public static readonly IconValue WindowMinimize = new ProjektankerIcon("mdi-window-minimize");
    
    // https://pictogrammers.com/library/mdi/icon/window-maximize/
    public static readonly IconValue WindowMaximize = new ProjektankerIcon("mdi-window-maximize");
    
    // https://pictogrammers.com/library/mdi/icon/refresh/
    public static readonly IconValue Refresh = new ProjektankerIcon("mdi-refresh");

#endregion
    
#region Notification
    
    // https://pictogrammers.com/library/mdi/icon/sync/
    public static readonly IconValue Sync = new ProjektankerIcon("mdi-sync");
    
#endregion

#region Social

    // https://pictogrammers.com/library/mdi/icon/school
    public static readonly IconValue School = new ProjektankerIcon("mdi-school");

#endregion

#region Toggle
    
    // https://pictogrammers.com/library/mdi/icon/checkbox-marked/
    public static readonly IconValue CheckBox = new ProjektankerIcon("mdi-checkbox-marked");

    // https://pictogrammers.com/library/mdi/icon/star/
    public static readonly IconValue Star = new ProjektankerIcon("mdi-star");

    // https://pictogrammers.com/library/mdi/icon/toggle-switch-outline/
    public static readonly IconValue ToggleOff = new ProjektankerIcon("mdi-toggle-switch-outline");

    // https://pictogrammers.com/library/mdi/icon/toggle-switch-off-outline/
    public static readonly IconValue ToggleOn = new ProjektankerIcon("mdi-toggle-switch-off-outline");

#endregion

#region Custom Icons

    // https://pictogrammers.com/library/mdi/icon/alert-octagon/
    public static readonly IconValue Alert = new ProjektankerIcon("mdi-alert-octagon");

    // From Design System "Custom Icons" section on Figma
    public static readonly IconValue Mods = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M12.46 17.9912L18.1722 13.5441L19.445 12.5584L12.46 7.12561L5.47498 12.5584L6.74004 13.5441L12.46 17.9912Z",
        new Rect(0, 0, 25, 25)
        ));

    // From Design System "Custom Icons" section on Figma
    public static readonly IconValue Collections = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M12.1979 15.4946L6.68644 11.2096L5.47498 12.1518L12.2053 17.3866L18.9357 12.1518L17.7167 11.2021L12.1979 15.4946ZM12.1979 19.2336L6.68644 14.9486L5.47498 15.8908L12.2053 21.1255L18.9357 15.8908L17.7167 14.9411L12.1979 19.2336ZM12.2053 13.5951L17.7093 9.31006L18.9357 8.36033L12.2053 3.12561L5.47498 8.36033L6.69392 9.31006L12.2053 13.5951Z",
        new Rect(0, 0, 25, 25)
    ));
    
    // From Design System "Custom Icons" section on Figma
    public static readonly IconValue ListFilled = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M9.39429 18.8744H20.3943V16.1994H9.39429V18.8744ZM4.39429 9.54939H7.39429V6.87439H4.39429V9.54939ZM4.39429 14.2244H7.39429V11.5494H4.39429V14.2244ZM4.39429 18.8744H7.39429V16.1994H4.39429V18.8744ZM9.39429 14.2244H20.3943V11.5494H9.39429V14.2244ZM9.39429 9.54939H20.3943V6.87439H9.39429V9.54939ZM4.39429 20.8744C3.84429 20.8744 3.37345 20.6786 2.98179 20.2869C2.59012 19.8952 2.39429 19.4244 2.39429 18.8744V6.87439C2.39429 6.32439 2.59012 5.85356 2.98179 5.46189C3.37345 5.07022 3.84429 4.87439 4.39429 4.87439H20.3943C20.9443 4.87439 21.4151 5.07022 21.8068 5.46189C22.1985 5.85356 22.3943 6.32439 22.3943 6.87439V18.8744C22.3943 19.4244 22.1985 19.8952 21.8068 20.2869C21.4151 20.6786 20.9443 20.8744 20.3943 20.8744H4.39429Z",
        new Rect(0, 0, 25, 25)
    ));
    
    // https://pictogrammers.com/library/mdi/icon/progress-download/
    public static readonly IconValue Downloading = new ProjektankerIcon("mdi-progress-download");

    // From Design System "Custom Icons" section on Figma
    public static readonly IconValue ModLibrary = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M18.3721 4.87439H6.40772C6.40772 4.87439 6.1358 2.87439 8.03922 2.87439H17.2844C18.644 2.87439 18.3721 4.87439 18.3721 4.87439ZM22.3943 20.5411V11.2077C22.3943 9.92439 21.4943 8.87439 20.3943 8.87439H4.39429C3.29429 8.87439 2.39429 9.92439 2.39429 11.2077V20.5411C2.39429 21.8244 3.29429 22.8744 4.39429 22.8744H20.3943C21.4943 22.8744 22.3943 21.8244 22.3943 20.5411ZM4.41219 7.87439H20.3647C20.3647 7.87439 20.7272 5.87439 18.9145 5.87439H6.58753C4.04963 5.87439 4.41219 7.87439 4.41219 7.87439ZM12.3943 11.8744L18.3943 15.8805L12.3943 19.8744L6.39429 15.8805L12.3943 11.8744Z",
        new Rect(0, 0, 25, 25)
    ));

    // From Design System "Custom Icons" section on Figma
    public static readonly IconValue Discord = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M19.4058 5.38929C18.1311 4.80439 16.7641 4.37346 15.3349 4.12665C15.3089 4.12188 15.2829 4.13379 15.2695 4.15759C15.0937 4.47027 14.8989 4.87819 14.7626 5.19881C13.2253 4.96867 11.696 4.96867 10.1902 5.19881C10.0538 4.87106 9.85205 4.47027 9.67546 4.15759C9.66205 4.13458 9.63605 4.12268 9.61002 4.12665C8.18157 4.37267 6.81461 4.8036 5.53909 5.38929C5.52805 5.39405 5.51858 5.40199 5.5123 5.4123C2.91947 9.28593 2.20918 13.0644 2.55763 16.7959C2.5592 16.8142 2.56945 16.8317 2.58364 16.8428C4.29432 18.099 5.9514 18.8617 7.57771 19.3672C7.60374 19.3752 7.63131 19.3657 7.64788 19.3442C8.03258 18.8189 8.37551 18.2649 8.66954 17.6824C8.68689 17.6483 8.67033 17.6078 8.63486 17.5943C8.09092 17.388 7.57298 17.1364 7.07475 16.8507C7.03534 16.8277 7.03219 16.7713 7.06844 16.7443C7.17329 16.6658 7.27816 16.584 7.37827 16.5015C7.39638 16.4864 7.42162 16.4832 7.44292 16.4928C10.716 17.9871 14.2596 17.9871 17.4941 16.4928C17.5154 16.4824 17.5406 16.4856 17.5595 16.5007C17.6597 16.5832 17.7645 16.6658 17.8702 16.7443C17.9064 16.7713 17.904 16.8277 17.8646 16.8507C17.3664 17.1419 16.8485 17.388 16.3037 17.5935C16.2683 17.607 16.2525 17.6483 16.2698 17.6824C16.5702 18.2641 16.9131 18.818 17.2907 19.3434C17.3065 19.3657 17.3349 19.3752 17.3609 19.3672C18.9951 18.8617 20.6522 18.099 22.3628 16.8428C22.3778 16.8317 22.3873 16.815 22.3889 16.7967C22.8059 12.4826 21.6904 8.73517 19.4318 5.41309C19.4263 5.40199 19.4169 5.39405 19.4058 5.38929ZM9.15833 14.5238C8.17289 14.5238 7.36092 13.6191 7.36092 12.508C7.36092 11.3969 8.15715 10.4922 9.15833 10.4922C10.1674 10.4922 10.9715 11.4049 10.9557 12.508C10.9557 13.6191 10.1595 14.5238 9.15833 14.5238ZM15.8039 14.5238C14.8185 14.5238 14.0066 13.6191 14.0066 12.508C14.0066 11.3969 14.8028 10.4922 15.8039 10.4922C16.813 10.4922 17.6171 11.4049 17.6013 12.508C17.6013 13.6191 16.813 14.5238 15.8039 14.5238Z",
        new Rect(0, 0, 25, 25)
    ));

    // From Design System "Custom Icons" section on Figma
    public static readonly IconValue Forum = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M15.4751 4.12561V11.1256H5.6451L4.4751 12.2956V4.12561H15.4751ZM16.4751 2.12561H3.4751C2.9251 2.12561 2.4751 2.57561 2.4751 3.12561V17.1256L6.4751 13.1256H16.4751C17.0251 13.1256 17.4751 12.6756 17.4751 12.1256V3.12561C17.4751 2.57561 17.0251 2.12561 16.4751 2.12561ZM21.4751 6.12561H19.4751V15.1256H6.4751V17.1256C6.4751 17.6756 6.9251 18.1256 7.4751 18.1256H18.4751L22.4751 22.1256V7.12561C22.4751 6.57561 22.0251 6.12561 21.4751 6.12561Z",
        new Rect(0, 0, 25, 25)
    ));
    
    // Custom Icon from Figma. The source of this icon is currently unknown.
    // Need to ask. - Sewer
    public static readonly IconValue HardDrive = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M3.33317 14.1665H16.6665V9.1665H3.33317V14.1665ZM14.1665 12.9165C14.5137 12.9165 14.8089 12.795 15.0519 12.5519C15.295 12.3089 15.4165 12.0137 15.4165 11.6665C15.4165 11.3193 15.295 11.0241 15.0519 10.7811C14.8089 10.538 14.5137 10.4165 14.1665 10.4165C13.8193 10.4165 13.5241 10.538 13.2811 10.7811C13.038 11.0241 12.9165 11.3193 12.9165 11.6665C12.9165 12.0137 13.038 12.3089 13.2811 12.5519C13.5241 12.795 13.8193 12.9165 14.1665 12.9165ZM18.3332 7.49984H15.979L14.3123 5.83317H5.68734L4.02067 7.49984H1.6665L4.52067 4.64567C4.67345 4.49289 4.85053 4.37484 5.05192 4.2915C5.25331 4.20817 5.46512 4.1665 5.68734 4.1665H14.3123C14.5346 4.1665 14.7464 4.20817 14.9478 4.2915C15.1491 4.37484 15.3262 4.49289 15.479 4.64567L18.3332 7.49984ZM3.33317 15.8332C2.87484 15.8332 2.48248 15.67 2.15609 15.3436C1.8297 15.0172 1.6665 14.6248 1.6665 14.1665V7.49984H18.3332V14.1665C18.3332 14.6248 18.17 15.0172 17.8436 15.3436C17.5172 15.67 17.1248 15.8332 16.6665 15.8332H3.33317Z",
        new Rect(0, 0, 20, 20)
    ));

    // The Black and White Nexus 'Developer' Logo.
    // This is the variation of the Nexus logo used in the App, and on the Discord.
    public static readonly IconValue Nexus = new SimpleVectorIcon(new SimpleVectorIconImage(
            "M17.0963 0C16.5785 0 16.1734 0.142228 16.0273 0.193129L16.0234 0.19485C15.4195 0.394796 14.831 0.701523 14.2267 1.09167C14.1094 1.06767 13.9924 1.04077 13.875 1.0207C12.9854 0.868622 12.0683 0.82619 11.1644 0.895103C10.3016 0.960718 9.44838 1.12793 8.62698 1.3919C8.37395 1.47312 8.12573 1.57222 7.87861 1.67192C7.46212 1.52838 7.0229 1.38287 6.51125 1.30201C6.11078 1.23879 5.7113 1.20652 5.32056 1.20652H5.30595C5.11795 1.20696 4.92998 1.2157 4.74544 1.23104C4.08978 1.26228 3.56161 1.49197 3.18852 1.76999C3.0329 1.88354 2.88888 2.0139 2.7591 2.15969L2.77328 2.14377L2.58157 2.34594C2.35009 2.58848 2.12336 2.8448 1.90627 3.10899C1.41623 3.70544 1.01778 4.27182 0.694091 4.83812C0.550546 5.0895 0.354764 5.45228 0.202341 5.89968C0.119442 6.14292 0.0604333 6.38316 0.0269614 6.62445C-0.0676257 7.31048 0.112619 7.8627 0.169242 8.03657L0.174831 8.05376L0.173539 8.04859C0.427551 8.84109 0.800046 9.47199 1.12566 9.96569C1.10728 10.0674 1.08653 10.1685 1.07107 10.2707C0.934139 11.1742 0.909057 12.0941 0.996705 13.005C1.0801 13.8704 1.26613 14.7249 1.54949 15.5462C1.57071 15.6077 1.59464 15.6683 1.61698 15.7294C1.43192 16.2205 1.21232 16.8611 1.10632 17.6083C1.0517 17.993 1.0261 18.3773 1.03023 18.7533C1.032 18.9189 1.04027 19.0846 1.05387 19.2492C1.08212 19.8435 1.27235 20.3341 1.51511 20.6975C1.64502 20.8952 1.80235 21.0781 1.98493 21.2399L1.96817 21.2244L2.16891 21.4154C2.41446 21.6498 2.67287 21.8785 2.93834 22.0967C3.54143 22.5921 4.11349 22.9938 4.68397 23.3178C4.9395 23.4629 5.30845 23.661 5.76418 23.8112C6.01684 23.8945 6.26643 23.9514 6.51642 23.9807H6.51769C6.6291 23.9935 6.74121 24 6.85384 24C7.36696 24 7.76609 23.8615 7.91729 23.8086L7.91987 23.8077L7.93104 23.8038C8.58147 23.5879 9.2177 23.2465 9.88128 22.8029C9.90033 22.8066 9.91941 22.8113 9.93845 22.8149C10.8289 22.985 11.7482 23.045 12.6564 22.9921C13.5298 22.9416 14.3956 22.787 15.2308 22.5328C15.4407 22.4688 15.6474 22.391 15.8541 22.3143C16.3191 22.487 16.8381 22.6562 17.4269 22.7539C17.8486 22.8239 18.2697 22.8597 18.6808 22.8597H18.6958C18.8827 22.859 19.0708 22.8502 19.2563 22.8347C19.9079 22.8034 20.4335 22.5768 20.8059 22.3014C20.9633 22.1872 21.1106 22.0549 21.2435 21.9048L21.228 21.922L21.3905 21.7508L21.3884 21.7525C21.8608 21.2594 22.3028 20.7252 22.7042 20.1623C23.0595 19.6637 23.4951 19.0271 23.7814 18.2177C23.8651 17.9811 23.9264 17.7477 23.9636 17.5144C24.0758 16.811 23.8974 16.2392 23.8471 16.0769C23.6967 15.5921 23.4868 15.1135 23.2251 14.6519C23.1193 14.4654 22.9884 14.2689 22.8597 14.0729C23.1278 12.706 23.1488 11.2938 22.895 9.92087C22.782 9.3096 22.5947 8.71439 22.38 8.1298C22.4807 7.84962 22.5793 7.56887 22.6577 7.29019C22.7989 6.78756 22.8833 6.25131 22.9113 5.69397C22.924 5.44537 22.9223 5.19722 22.909 4.95199C22.9026 4.18017 22.6518 3.56263 22.3158 3.13512C22.2122 3.00099 22.0949 2.8751 21.9651 2.76004L21.9823 2.77596L21.782 2.58498C21.5361 2.35027 21.2778 2.1218 21.0119 1.90333C20.409 1.40802 19.8378 1.00654 19.2671 0.682618C19.0112 0.537143 18.6423 0.339502 18.1864 0.189258C17.934 0.106095 17.6841 0.0490344 17.4338 0.019786C17.3215 0.00666226 17.2088 0 17.0963 0ZM17.0963 1.32136C17.1581 1.32136 17.221 1.32514 17.2807 1.33212C17.4366 1.35032 17.5945 1.38545 17.7734 1.44438C18.1025 1.55286 18.3878 1.70257 18.6146 1.8315C19.1072 2.11109 19.6171 2.46681 20.1741 2.92447C20.4145 3.12194 20.6494 3.33035 20.8713 3.54214L21.0811 3.74172L21.0897 3.74946C21.1587 3.81066 21.22 3.87606 21.2732 3.94517L21.2754 3.94818L21.2775 3.95076C21.4456 4.16429 21.5869 4.45698 21.59 4.96716V4.98437L21.5908 5.00114C21.6026 5.20572 21.6033 5.4161 21.5925 5.62698C21.569 6.09414 21.4985 6.53451 21.3867 6.93243C21.2991 7.24343 21.1942 7.561 21.0742 7.87743L20.9834 8.11658L21.0776 8.35487C21.3087 8.93945 21.4826 9.54561 21.5964 10.1614C21.8348 11.451 21.8084 12.788 21.5229 14.0679L21.4602 14.3492L21.6235 14.5866C21.8015 14.8452 21.9495 15.08 22.0766 15.3041C22.2942 15.6881 22.4657 16.0808 22.5859 16.4684C22.636 16.6298 22.722 16.9138 22.6594 17.3063C22.6359 17.4537 22.5975 17.6053 22.5369 17.7765C22.3192 18.3922 21.9696 18.9173 21.629 19.3951C21.2644 19.9065 20.8625 20.3924 20.4353 20.8381L20.4345 20.8394L20.263 21.0197L20.2553 21.0283C20.1867 21.1057 20.1111 21.1738 20.0292 21.233L20.0257 21.2356L20.0227 21.2377C19.8344 21.3774 19.5849 21.4976 19.1909 21.516L19.1776 21.5165L19.1647 21.5178C19.0115 21.5311 18.8521 21.5379 18.6923 21.5384H18.6807C18.3468 21.5384 17.9965 21.5089 17.643 21.4502C17.0879 21.3581 16.5654 21.1838 16.0947 20.9994L15.8519 20.9048L15.6098 21.0007C15.3587 21.1006 15.1027 21.1906 14.8464 21.2687C14.1118 21.4924 13.3486 21.6286 12.5798 21.673C11.7816 21.7195 10.9688 21.6662 10.1868 21.5169C10.0917 21.4987 9.99632 21.479 9.90185 21.458L9.61601 21.3947L9.37744 21.5637C8.69248 22.0485 8.10535 22.3543 7.51189 22.5509L7.51019 22.5518L7.49084 22.5582L7.48783 22.5591C7.34412 22.6095 7.14075 22.6787 6.8538 22.6787C6.79239 22.6787 6.72924 22.6749 6.66854 22.668C6.51306 22.6497 6.35566 22.6149 6.17722 22.5561C5.84848 22.4478 5.56268 22.2975 5.33557 22.1686C4.84286 21.8887 4.33369 21.5333 3.7765 21.0756C3.53583 20.8778 3.30095 20.6701 3.0793 20.4584L2.8691 20.2584L2.86051 20.2507C2.76418 20.1652 2.68311 20.0711 2.61725 19.9706L2.61555 19.9676L2.61385 19.965C2.49122 19.782 2.38937 19.5441 2.37271 19.1847L2.37228 19.1718L2.37101 19.1584C2.35902 19.0189 2.3523 18.8785 2.35081 18.7391C2.34744 18.4336 2.36848 18.1148 2.414 17.7941C2.50495 17.153 2.71114 16.5527 2.89027 16.0856C2.90463 16.0481 2.91964 16.0098 2.93455 15.972L3.02998 15.7303L2.93498 15.4886C2.88628 15.3643 2.8403 15.2394 2.79734 15.1148C2.54813 14.3926 2.38456 13.6396 2.31117 12.8781C2.23394 12.0756 2.25595 11.2645 2.37651 10.469C2.40176 10.3021 2.43202 10.1338 2.46634 9.96658L2.52309 9.69044L2.36275 9.45816C2.04797 9.00219 1.66293 8.36927 1.43084 7.64515L1.42482 7.62709C1.3679 7.45229 1.28227 7.18787 1.33498 6.80554C1.35618 6.65293 1.39265 6.49974 1.4519 6.32594C1.56278 6.00048 1.71262 5.71801 1.84049 5.49407C2.12074 5.0038 2.47377 4.49896 2.92629 3.94817C3.12323 3.70849 3.32893 3.4759 3.53711 3.25781L3.53795 3.25697L3.73783 3.04664L3.74471 3.0389C3.81369 2.96141 3.88894 2.89335 3.96866 2.83545L3.97554 2.83028C4.16415 2.68937 4.41385 2.56863 4.81031 2.55028L4.82364 2.54942L4.83653 2.54855C4.98998 2.5353 5.14858 2.52833 5.30679 2.52791H5.32054C5.63812 2.52791 5.97015 2.55414 6.30533 2.60706C6.79887 2.68506 7.2626 2.82686 7.68602 2.98299L7.93275 3.07418L8.17433 2.97052C8.45411 2.85054 8.74206 2.74267 9.03059 2.65007C9.75276 2.41798 10.505 2.27082 11.2645 2.21306C12.0596 2.15244 12.8719 2.19011 13.6528 2.3236C13.8345 2.35467 14.0167 2.39104 14.1978 2.43285L14.4807 2.49823L14.7197 2.33392C15.337 1.91006 15.8819 1.63332 16.4382 1.44913L16.4412 1.44827L16.4601 1.44182L16.4614 1.44139C16.607 1.39065 16.8096 1.32136 17.0963 1.32136Z M8.92758 8.96557C8.43644 8.74349 8.08174 8.51976 7.71292 8.25621C7.14966 7.87099 6.63664 7.43272 6.20184 6.97839C5.14397 5.89888 4.66099 4.76909 4.81485 3.86797L4.42797 4.22703C3.65871 5.037 2.63779 6.45344 2.62887 7.06967L2.64769 7.13471C2.78425 7.60608 3.0165 8.07994 3.33745 8.54319L3.34276 8.55075C3.75676 9.22312 4.58365 10.3202 7.51246 11.6062L6.99454 12.5801L10.9472 11.5176L9.52333 7.85452L8.92758 8.96557Z M15.0736 15.1C15.565 15.3221 15.9195 15.5459 16.2883 15.8093C16.8517 16.1946 17.3646 16.6328 17.7994 17.0872C18.8574 18.1666 19.292 19.1879 19.1381 20.0886L19.5734 19.8386C20.3426 19.0286 21.3634 17.6121 21.3725 16.9959L21.3536 16.9309C21.217 16.4596 20.9849 15.9855 20.6638 15.5222L20.6584 15.5148C20.2446 14.8425 19.4176 13.7454 16.4888 12.4593L17.0067 11.4855L13.054 12.548L14.4781 16.2111L15.0736 15.1Z M15.1662 8.93522C15.388 8.44358 15.6118 8.08878 15.8751 7.71972C16.2599 7.15611 16.698 6.64274 17.1519 6.20766C18.2309 5.14896 19.3526 4.65805 20.2531 4.81202L19.9016 4.4325C19.0922 3.66274 17.6767 2.6413 17.061 2.63223L16.9959 2.65121C16.5247 2.78786 16.0513 3.02011 15.5883 3.34143L15.5807 3.34674C14.9089 3.761 13.8125 4.58842 12.5272 7.51916L11.554 7.0009L12.6158 10.9561L16.2766 9.5312L15.1662 8.93522Z M8.78405 15.0645C8.56209 15.5561 8.33846 15.9109 8.07513 16.2798C7.69014 16.8436 7.25215 17.3569 6.79825 17.792C5.71931 18.8507 4.6004 19.2986 3.69987 19.1447L4.04868 19.5671C4.85797 20.3368 6.2735 21.3584 6.88921 21.3673L6.95433 21.3484C7.42553 21.2118 7.89896 20.9795 8.36195 20.6581L8.36948 20.6529C9.04135 20.2386 10.1377 19.4113 11.4231 16.4805L12.3962 16.9987L11.3344 13.0435L7.67368 14.4683L8.78405 15.0645Z",
            new Rect(0, 0, 24, 24)
    ));

    // From Design System "Custom Icons" section on Figma
    public static readonly IconValue Stethoscope = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M13.8943 22.8744C12.0943 22.8744 10.561 22.2411 9.29429 20.9744C8.02762 19.7077 7.39429 18.1744 7.39429 16.3744V15.7994C5.96095 15.5661 4.76929 14.8952 3.81929 13.7869C2.86929 12.6786 2.39429 11.3744 2.39429 9.87439V3.87439H5.39429V2.87439H7.39429V6.87439H5.39429V5.87439H4.39429V9.87439C4.39429 10.9744 4.78595 11.9161 5.56929 12.6994C6.35262 13.4827 7.29429 13.8744 8.39429 13.8744C9.49429 13.8744 10.436 13.4827 11.2193 12.6994C12.0026 11.9161 12.3943 10.9744 12.3943 9.87439V5.87439H11.3943V6.87439H9.39429V2.87439H11.3943V3.87439H14.3943V9.87439C14.3943 11.3744 13.9193 12.6786 12.9693 13.7869C12.0193 14.8952 10.8276 15.5661 9.39429 15.7994V16.3744C9.39429 17.6244 9.83179 18.6869 10.7068 19.5619C11.5818 20.4369 12.6443 20.8744 13.8943 20.8744C15.1443 20.8744 16.2068 20.4369 17.0818 19.5619C17.9568 18.6869 18.3943 17.6244 18.3943 16.3744V14.6994C17.811 14.4994 17.3318 14.1411 16.9568 13.6244C16.5818 13.1077 16.3943 12.5244 16.3943 11.8744C16.3943 11.0411 16.686 10.3327 17.2693 9.74939C17.8526 9.16606 18.561 8.87439 19.3943 8.87439C20.2276 8.87439 20.936 9.16606 21.5193 9.74939C22.1026 10.3327 22.3943 11.0411 22.3943 11.8744C22.3943 12.5244 22.2068 13.1077 21.8318 13.6244C21.4568 14.1411 20.9776 14.4994 20.3943 14.6994V16.3744C20.3943 18.1744 19.761 19.7077 18.4943 20.9744C17.2276 22.2411 15.6943 22.8744 13.8943 22.8744ZM19.3943 12.8744C19.6776 12.8744 19.9151 12.7786 20.1068 12.5869C20.2985 12.3952 20.3943 12.1577 20.3943 11.8744C20.3943 11.5911 20.2985 11.3536 20.1068 11.1619C19.9151 10.9702 19.6776 10.8744 19.3943 10.8744C19.111 10.8744 18.8735 10.9702 18.6818 11.1619C18.4901 11.3536 18.3943 11.5911 18.3943 11.8744C18.3943 12.1577 18.4901 12.3952 18.6818 12.5869C18.8735 12.7786 19.111 12.8744 19.3943 12.8744Z",
        new Rect(0, 0, 25, 25)
    ));

    // From Design System "Custom Icons" section on Figma
    public static readonly IconValue ShieldHalfFull = new SimpleVectorIcon(new SimpleVectorIconImage(
        "M21.4751 11.1256C21.4751 16.6756 17.6351 21.8656 12.4751 23.1256C7.3151 21.8656 3.4751 16.6756 3.4751 11.1256V5.12561L12.4751 1.12561L21.4751 5.12561V11.1256ZM12.4751 21.1256C16.2251 20.1256 19.4751 15.6656 19.4751 11.3456V6.42561L12.4751 3.30561V21.1256Z",
        new Rect(0, 0, 25, 25)
    ));
#endregion
}
