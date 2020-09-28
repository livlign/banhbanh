﻿using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Web.UI;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SubSonic")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("a09d11de-ed0a-4b57-b2a9-e38675615d55")]
[assembly: PermissionSet(SecurityAction.RequestMinimum, Unrestricted = false)]
[assembly: AllowPartiallyTrustedCallers]

[assembly: TagPrefix("SubSonic", "subsonic")]

[assembly: WebResource("SubSonic.Controls.Calendar.skin.theme.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.calendar.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.calendar-setup.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-af.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-al.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-bg.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-big5-utf8.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-big5.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-br.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-ca.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-cs-utf8.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-cs-win.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-da.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-de.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-du.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-el.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-en.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-es.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-eu.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-fi.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-fr.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-he-utf8.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-hr-utf8.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-hr.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-hu.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-it.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-jp.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-ko-utf8.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-ko.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-lt-utf8.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-lt.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-lv.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-nl.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-no.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-pl-utf8.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-pl.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-pt.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-ro.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-ru.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-ru_win_.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-ru-UTF.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-si.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-sk.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-sp.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-sr-utf8.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-sr.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-sv.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-tr.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.lang.calendar-zh.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.normal-bg.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.title-bg.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.hover-bg.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.rowhover-bg.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.active-bg.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.dark-bg.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.status-bg.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.menuarrow.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Calendar.skin.calendar.gif", "image/gif")]
[assembly: WebResource("SubSonic.Controls.Resources.ClientScripts.js", "text/javascript")]
[assembly: WebResource("SubSonic.Controls.Resources.Scaffold.css", "text/css", PerformSubstitution = true)]
//[assembly: AssemblyKeyFileAttribute("subsonic.snk")]
