﻿#pragma checksum "..\..\..\AddingInformationWindow\AddLocomotive.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C18818DE62DF8D9C2870414B93B21C530066E326"
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
    /// AddLocomotive
    /// </summary>
    public partial class AddLocomotive : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameLocomotive;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Type;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Information;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Velocity;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Power;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Photo;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FileLOad;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Association PAT Ukrzaliznutsa;component/addinginformationwindow/addlocomotive.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
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
            this.NameLocomotive = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Type = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Information = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Velocity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Power = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Photo = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
            this.Photo.Click += new System.Windows.RoutedEventHandler(this.Photo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FileLOad = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
            this.FileLOad.Click += new System.Windows.RoutedEventHandler(this.FileLOad_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Set = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\AddingInformationWindow\AddLocomotive.xaml"
            this.Set.Click += new System.Windows.RoutedEventHandler(this.Set_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

