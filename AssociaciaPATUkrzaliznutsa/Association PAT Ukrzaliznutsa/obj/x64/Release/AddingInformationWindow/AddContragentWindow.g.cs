﻿#pragma checksum "..\..\..\..\AddingInformationWindow\AddContragentWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59CBB82CBCF2E2FA31EE1298B7AAE8C03CD4C6ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Association_PAT_Ukrzaliznutsa.AddingInformationWindow;
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


namespace Association_PAT_Ukrzaliznutsa.AddingInformationWindow {
    
    
    /// <summary>
    /// AddContragentWindow
    /// </summary>
    public partial class AddContragentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\AddingInformationWindow\AddContragentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox user;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\AddingInformationWindow\AddContragentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameKlient;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\AddingInformationWindow\AddContragentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Prodaction;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\AddingInformationWindow\AddContragentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox VagonType;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\AddingInformationWindow\AddContragentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Set;
        
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
            System.Uri resourceLocater = new System.Uri("/Association PAT Ukrzaliznutsa;component/addinginformationwindow/addcontragentwin" +
                    "dow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AddingInformationWindow\AddContragentWindow.xaml"
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
            this.user = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.NameKlient = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Prodaction = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.VagonType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Set = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\AddingInformationWindow\AddContragentWindow.xaml"
            this.Set.Click += new System.Windows.RoutedEventHandler(this.Set_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

