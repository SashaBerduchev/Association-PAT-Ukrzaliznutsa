﻿#pragma checksum "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "710170576807C78F8220E22150FEC24E9DCA8805D1BE786CA92719DE91EBD8DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Association_PAT_Ukrzaliznutsa.MarshruteInfoWindow;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Association_PAT_Ukrzaliznutsa.MarshruteInfoWindow {
    
    
    /// <summary>
    /// MarshruteInfoWindow
    /// </summary>
    public partial class MarshruteInfoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Number;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PointStart;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PointEnd;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StationArray;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Train;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Cost;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSet;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox count;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Association PAT Ukrzaliznutsa;component/login/marshruteinfowindow/marshruteinfow" +
                    "indow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.PointStart = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PointEnd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.StationArray = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Train = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Cost = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnSet = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Login\MarshruteInfoWindow\MarshruteInfoWindow.xaml"
            this.btnSet.Click += new System.Windows.RoutedEventHandler(this.BtnSet_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.count = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

